using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurant.Models;

namespace WebAppRestaurant.Repositories
{
    public class CustomerRepository
    {
        //private RestaurantDBEntities RestaurantDBEntities;
        private RestaurantEntitiesDB RestaurantEntitiesDB;
        public CustomerRepository()
        {
            RestaurantEntitiesDB = new RestaurantEntitiesDB();

        }

        //Using .net foundation you have access to full integrated entity framework 
        //Using dependency injection i pulled my Restaurantmodles datatdabe within the contructor

        public IEnumerable<SelectListItem> GetAllCustomer()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in RestaurantEntitiesDB.Customers
                               select new SelectListItem()
                               {
                                   Text = obj.CustomerName,
                                   Value = obj.CustomerId.ToString(),
                                   Selected = true




                               }).ToList();

            return selectListItems;
        }
        //Using the IEnumerable allowed me to select the relevent information to put in this repository class 
    }
}