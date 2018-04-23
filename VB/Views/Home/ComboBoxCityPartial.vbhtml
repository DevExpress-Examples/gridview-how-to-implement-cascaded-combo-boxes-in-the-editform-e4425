@Html.DevExpress().ComboBox( _
    Sub(settings)
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "ComboBoxCityPartial"}
            settings.Name = "CityID"

            settings.Properties.TextField = "CityName"
            settings.Properties.ValueField = "CityID"
            settings.Properties.ValueType = GetType(Integer)

            settings.Properties.EnableSynchronization = DefaultBoolean.False
            settings.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith

            settings.Properties.ClientSideEvents.BeginCallback = "CitiesCombo_BeginCallback"
End Sub).BindList(Model).Bind(ViewData("CityID")).GetHtml()