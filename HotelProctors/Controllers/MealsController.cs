using HotelProctors.Models;
using HotelProctors.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelProctors.Controllers
{
    [Authorize(Users = "admin@proctors.com")]
    public class MealsController : ApiController
    {
        private readonly MealsRepository _mealsRepository = new MealsRepository();

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Print()

        {
            var response = Request.CreateResponse(HttpStatusCode.OK, _mealsRepository.GetMeals());
            return ResponseMessage(response);
        }
        [HttpPut]
        public IHttpActionResult Edit(Meal meal)
        {
            _mealsRepository.UpdateMeal(meal);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            return ResponseMessage(response);

        }
        [HttpPost]
        public IHttpActionResult Create(Meal meal)
        {
         


            _mealsRepository.AddMeal1(meal);
            return Ok();



        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, "Errorrrr");
            _mealsRepository.DeleteMeal(id);
            return ResponseMessage(response);
        }
    }
}
