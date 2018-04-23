@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"

            settings.KeyFieldName = "CustomerID"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
            settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "EditingAddNew"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "EditingUpdate"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "EditingDelete"}

            settings.CommandColumn.Visible = True
            settings.CommandColumn.NewButton.Visible = True
            settings.CommandColumn.DeleteButton.Visible = True
            settings.CommandColumn.EditButton.Visible = True

            settings.Columns.Add("CustomerID").Visible = False
            settings.Columns.Add("CustomerName")
            settings.Columns.Add( _
                Sub(columnCountry)
                        columnCountry.Caption = "Country"
                        columnCountry.FieldName = "CountryID"

                        columnCountry.ColumnType = MVCxGridViewColumnType.ComboBox
                        Dim propertiesComboBox As ComboBoxProperties = CType(columnCountry.PropertiesEdit, ComboBoxProperties)
                        propertiesComboBox.DataSource = E4425.Models.DataProvider.GetCountries()
                        propertiesComboBox.TextField = "CountryName"
                        propertiesComboBox.ValueField = "CountryID"
                        propertiesComboBox.ValueType = GetType(Integer)

                        propertiesComboBox.EnableSynchronization = DefaultBoolean.False
                        propertiesComboBox.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith

                        propertiesComboBox.ClientSideEvents.SelectedIndexChanged = "CountriesCombo_SelectedIndexChanged"
                End Sub)

            settings.Columns.Add( _
                Sub(columnCity)
                        columnCity.Caption = "City"
                        columnCity.FieldName = "CityID"

                        'Display Mode
                        columnCity.ColumnType = MVCxGridViewColumnType.ComboBox
                        Dim propertiesComboBox As ComboBoxProperties = CType(columnCity.PropertiesEdit, ComboBoxProperties)
                        propertiesComboBox.DataSource = E4425.Models.DataProvider.GetCities()
                        propertiesComboBox.TextField = "CityName"
                        propertiesComboBox.ValueField = "CityID"
                        propertiesComboBox.ValueType = GetType(Integer)
                        'Display Mode

                        'Edit Mode
                        columnCity.SetEditItemTemplateContent( _
                            Sub(c)
                                    Dim countryID = c.Grid.GetRowValues(c.Grid.EditingRowVisibleIndex, "CountryID")
            
                                    Dim cityID = c.Grid.GetRowValues(c.Grid.EditingRowVisibleIndex, c.Column.FieldName)
                                    ViewData("CityID") = cityID

                                    Dim cities = If((countryID Is Nothing), E4425.Models.DataProvider.GetCities(), E4425.Models.DataProvider.GetCities(CInt(Fix(countryID))))
                                    Html.RenderPartial("ComboBoxCityPartial", cities)
                            End Sub)
                        'Edit Mode
        
                End Sub)
            
    End Sub).Bind(Model).GetHtml()