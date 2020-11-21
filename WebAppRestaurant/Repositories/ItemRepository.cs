using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurant.Models;

namespace WebAppRestaurant.Repositories
{
    public class ItemRepository
    {
        //private RestaurantDBEntities RestaurantDBEntities;
        private RestaurantEntitiesDB RestaurantEntitiesDB;
        public ItemRepository()
        {
            RestaurantEntitiesDB = new RestaurantEntitiesDB();

        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in RestaurantEntitiesDB.Items
                               select new SelectListItem()
                               {
                                   Text = obj.ItemName,
                                   Value = obj.ItemId.ToString(),
                                   Selected = false




                               }).ToList();

            return selectListItems;
        }
    }
}