Imports Microsoft.VisualBasic
Imports System.Web.Mvc
Imports E4425.Models
Imports DevExpress.Web.Mvc

Namespace E4425.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View(DataProvider.GetCustomers())
		End Function

		'CRUD
		Public Function GridViewPartial() As ActionResult
			Return PartialView(DataProvider.GetCustomers())
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function EditingAddNew(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customerInfo As Customer) As ActionResult
			If ModelState.IsValid Then
				DataProvider.InsertCustomer(customerInfo)
			End If
			Return PartialView("GridViewPartial", DataProvider.GetCustomers())
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function EditingUpdate(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customerInfo As Customer) As ActionResult
			If ModelState.IsValid Then
				DataProvider.UpdateCustomer(customerInfo)
			End If
			Return PartialView("GridViewPartial", DataProvider.GetCustomers())
		End Function
		Public Function EditingDelete(ByVal customerID As Integer) As ActionResult
			DataProvider.DeleteCustomer(customerID)
			Return PartialView("GridViewPartial", DataProvider.GetCustomers())
		End Function
		'CRUD

		Public Function ComboBoxCityPartial() As ActionResult
			Dim countryID As Integer = If((Request.Params("CountryID") IsNot Nothing), Integer.Parse(Request.Params("CountryID")), -1)
			Return PartialView(DataProvider.GetCities(countryID))
		End Function
	End Class
End Namespace