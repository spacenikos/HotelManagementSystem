using HotelProctors.Models;
using HotelProctors.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelProctors.Models.Enum;
using PayPal.Api;


namespace HotelProctors.Controllers
{
    

    [Authorize]
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ReservationsRepository _reservationsRepository = new ReservationsRepository();
        private readonly RoomsRepository _roomsRepository = new RoomsRepository();
        public string strReservation = "ReservationRoom";

        [Authorize(Users = "admin@proctors.com")]
        // GET: Reservations 
        public ActionResult Index()
        {
            var reservations = _reservationsRepository.GetReservations();
          
            return View(reservations);
        }
        [Authorize(Users = "admin@proctors.com")]
        public ActionResult IndexFuture()
        {
            var reservations = _reservationsRepository.GetReservationsFuture();
            return View(reservations);
        }

        public ActionResult Create(int id)
        {
            //string currentUserId = User.Identity.GetUserId();
            try
            {
                Reservation reservation = new Reservation();
                reservation.RoomId = _roomsRepository.FindById(id).Id;
                reservation.ArrivalDate = DateTime.Now;
                reservation.DepartureDate = (DateTime.Now).AddDays(1);
                return View(reservation);
            }
            catch
            {
                
                return RedirectToAction("Index","Home");
            }
            
            //vm.ApplicationUser = _applicationDbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
           
            reservation.UserId = User.Identity.GetUserId();
            if (!(_reservationsRepository.CheckReservation(reservation)))
            {
                ViewBag.MessageAvailability = "Not Available in this period";
                return View("Create");

            }
          

            return RedirectToAction("index");
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            try
            {
                var reservation = _reservationsRepository.FindById(id);
                return View(reservation);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        [Authorize(Users = "admin@proctors.com")]
        public ActionResult Edit(int id)
        {
            try
            {
                Reservation reservation = _reservationsRepository.FindById(id);
                ViewBag.Rooms = _roomsRepository.GetRooms();
                return View(reservation);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "admin@proctors.com")]
        public ActionResult Edit(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Rooms = _roomsRepository.GetRooms();
                
                return View(reservation);
            }
            reservation.UserId = User.Identity.GetUserId();
            _reservationsRepository.UpdateReservation(reservation);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            try
            {
                var reservation = _reservationsRepository.FindById(id);
                return View(reservation);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _reservationsRepository.DeleteReservation(id);
            return RedirectToAction("Index");
        }

        public ActionResult ProccedToPayment(Reservation reservation)
        {
            if (!(_reservationsRepository.CheckReservation(reservation)))
            {
               ViewBag.MessageAvailability = "This room is not available in this period";
               
                return RedirectToAction("Create","Reservations",new{id = reservation.RoomId});

            }
            if ((!(_reservationsRepository.IsValid(reservation.ArrivalDate)))||(!(_reservationsRepository.IsValid(reservation.ArrivalDate))))
            {
                ViewBag.MessageFutureDates = "Future Dates Please";
                return RedirectToAction("Create","Reservations",new{id = reservation.RoomId});
            }

            reservation.UserId = User.Identity.GetUserId();
            reservation.ApplicationUser = db.Users.FirstOrDefault(x => x.Id == reservation.UserId);

            reservation.RoomId = _roomsRepository.FindById(reservation.RoomId).Id;
            reservation.Room = _roomsRepository.FindById(reservation.RoomId);

            if (Session[strReservation] == null)
            {
                Session[strReservation] = reservation;
            }

            return View(reservation);
        }

        




        public ActionResult PaymentWithPaypal()
        {
            Reservation reservation = (Reservation)Session[strReservation];
            Reservation reservation1 = new Reservation
            {
                ArrivalDate = reservation.ArrivalDate,
                DepartureDate = reservation.DepartureDate,
                RoomId = reservation.RoomId,
                UserId = reservation.UserId,
               
                

            }; 

            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/reservations/paymentwithpaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);

                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);

                }
                else
                {
                    //this one will be executed when we have received all the payment params from previous call
                    var guid = Request.Params["guid"];
                    var executePayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executePayment.state.ToLower() != "approved")
                    {
                        return View("Failure");
                    }
                }
            }
            catch (Exception ex)
            {
                PaypalLogger.Log("Error: " + ex.Message);
                return View("Failure");
            }
            _reservationsRepository.AddReservation(reservation1);
            return View("Success");
            

        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList() { items = new List<Item>() };


            Reservation reservation = (Reservation)Session[strReservation];
            //Room listroom = repository.FindById(14);
        

            listItems.items.Add(new Item()
            {
                name =reservation.Room.RoomType.ToString(),
                currency = "EUR",
                price= Convert.ToDouble(reservation.TotalCost).ToString(),
                quantity = "1",
                sku = "sku"

            });
           


            var payer = new Payer() { payment_method = "paypal" };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };




            //create details object
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
               subtotal= Convert.ToDouble(reservation.TotalCost).ToString()

                //subtotal = listrooms.Sum(x=>x.Price * 1).ToString()
            };

            var amount = new Amount()
            {
                currency = "EUR",
                total = Convert.ToDouble(reservation.TotalCost).ToString(),
                details = details
            };

            //Create Transaction
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Book",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }
        private Payment payment;

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);

        }
        
    }
}