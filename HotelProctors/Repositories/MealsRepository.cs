using HotelProctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProctors.Repositories
{
    public class MealsRepository
    {
        public IEnumerable<Meal> GetMeals()
        {
            IEnumerable<Meal> meals;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                meals = db.Meals.ToList();
            }

            return meals;
        }

        
        public void AddMeal1(Meal meal)
        {
            if (meal == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Meals.Add(new Meal
                    {
                        Name = meal.Name,
                        Price = meal.Price,
                        Description = meal.Description,
                    });

                    db.SaveChanges();
                }
            }
            catch { }
        
        }




        public void UpdateMeal(Meal meal)
        {
            if (meal == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Meals.Attach(meal);
                    db.Entry(meal).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch
            {

            }
          
        }

        public void DeleteMeal(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var meal = db.Meals.Find(id);
                    db.Meals.Remove(meal);
                    db.SaveChanges();
                }
            }
            catch { }
          
        }

        public Meal FindById(int id)
        {

            
                Meal meal;

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    meal = db.Meals.Find(id);
                }

                return meal;
            
         
           


        }


    }
}