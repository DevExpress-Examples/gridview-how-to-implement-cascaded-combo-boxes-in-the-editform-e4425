using System.Web.Mvc;
using E4425.Models;
using DevExpress.Web.Mvc;

namespace E4425.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(DataProvider.GetCustomers());
        }

        /*CRUD*/
        public ActionResult GridViewPartial() {
            return PartialView(DataProvider.GetCustomers());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Customer customerInfo) {
            if(ModelState.IsValid)
                DataProvider.InsertCustomer(customerInfo);
            return PartialView("GridViewPartial", DataProvider.GetCustomers());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Customer customerInfo) {
            if(ModelState.IsValid)
                DataProvider.UpdateCustomer(customerInfo);
            return PartialView("GridViewPartial", DataProvider.GetCustomers());
        }
        public ActionResult EditingDelete(int customerID) {
            DataProvider.DeleteCustomer(customerID);
            return PartialView("GridViewPartial", DataProvider.GetCustomers());
        }
        /*CRUD*/

        public ActionResult ComboBoxCityPartial() {
            int countryID = (Request.Params["CountryID"] != null) ? int.Parse(Request.Params["CountryID"]) : -1;
            return PartialView(DataProvider.GetCities(countryID));
        }
    }
}