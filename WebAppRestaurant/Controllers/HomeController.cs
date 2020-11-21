using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurant.Models;
using WebAppRestaurant.Repositories;
using WebAppRestaurant.ViewModel;

namespace WebAppRestaurant.Controllers
{
    public class HomeController : Controller
    {

        //private RestaurantDBEntities RestaurantDBEntities;
        private RestaurantEntitiesDB RestaurantEntitiesDB;

        public HomeController()
        {
            RestaurantEntitiesDB = new RestaurantEntitiesDB();

        }
        //Using dependency injection i pulled my Restaurantmodles datatdabe within the contructor

        /*In index controller and a corresponding index view to return too.
         * Now our first issue with using this multiple view model format is that 
         * I need to pass multiple view models to a single view. To solve this I used the tuple solution.*/
        public ActionResult Index()
        {

            CustomerRepository customerRepository = new CustomerRepository();
            ItemRepository itemRepository = new ItemRepository();
            PaymentTypeRepository paymentTypeRepository = new PaymentTypeRepository();



            var MultipleModles = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (customerRepository.GetAllCustomer(), itemRepository.GetAllItems(), paymentTypeRepository.GetAllPaymentType());

            //Using a tuple i inputted the databse repositories into the item property of the tuple and implimented the get... method to pull the data.

            return View(MultipleModles);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal unitPrice = RestaurantEntitiesDB.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
            /*Using this JsonResult action method in my controller i called a single item model from the 
            restaurantDB through dependency injection and returned through Json*/
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);
            return Json(data: "Your Order has been Successfully Created.", JsonRequestBehavior.AllowGet);
            //Using a jsonresult i run a post request to the database when the finalsave method is called. 
        }

        public ActionResult About()

        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}