﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Threading.Tasks;
//using System.Runtime.Serialization.Json;
//using System.Web.Mvc;
//using BraintreeHttp;
//using PayPalCheckoutSdk.Core;
//using PayPalCheckoutSdk.Orders;
//using PayPal.Api;
//using PayPal;
//using HotelProctors.Models;
//using HttpResponse = BraintreeHttp.HttpResponse;
//using Order = PayPalCheckoutSdk.Orders.Order;
//using System.Text;


//namespace HotelProctors.Controllers
//{
//    public class Paypal1Controller : Controller
//    {
//        // GET: Paypal1
//        public ActionResult Index()
//        {
//            return View();
//        }
//    }

//    public class GetOrderSample
//    {

//        //2. Set up your server to receive a call from the client
//        /*
//          You can use this method to retrieve an order by passing the order ID.
//         */
//        public async static Task<HttpResponse> GetOrder(string orderId, bool debug = false)
//        {
//            OrdersGetRequest request = new OrdersGetRequest(orderId);
//            //3. Call PayPal to get the transaction
//            var response = await PaypalSample.client().Execute(request);
//            //4. Save the transaction in your database. Implement logic to save transaction to your database for future reference.
//            var result = response.Result<Order>();
//            Console.WriteLine("Retrieved Order Status");
//            Console.WriteLine("Status: {0}", result.Status);
//            Console.WriteLine("Order Id: {0}", result.Id);

//            Console.WriteLine("Links:");
//            foreach (LinkDescription link in result.Links)
//            {
//                Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
//            }
//            AmountWithBreakdown amount = result.PurchaseUnits[1].Amount;
//            Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);

//            return response;
//        }

//        /*
//          This driver method invokes the getOrder function with
//          order ID to retrieve order details.
    
//          To get the correct order ID, this sample uses createOrder to create
//          a new order and then uses the newly-created order ID with GetOrder.
//         */
//        static void Main(string[] args)
//        {
//            GetOrder().Wait();
//        }
//    }
//}
//}