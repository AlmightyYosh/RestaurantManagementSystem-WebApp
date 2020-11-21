using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurant.Models;

namespace WebAppRestaurant.Repositories
{
    public class PaymentTypeRepository
    {
        //private RestaurantDBEntities RestaurantDBEntities;
        private RestaurantEntitiesDB RestaurantEntitiesDB;
        public PaymentTypeRepository() //Constructor to get the model
        {
            RestaurantEntitiesDB = new RestaurantEntitiesDB();

        }

        public IEnumerable<SelectListItem> GetAllPaymentType() //Getting the payment info from the model
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in RestaurantEntitiesDB.PaymentTypes
                               select new SelectListItem()
                               {
                                   Text = obj.PaymentTypeName,
                                   Value = obj.PaymentTypeId.ToString(),
                                   Selected = true




                               }).ToList();

            return selectListItems;
        }
    }
}