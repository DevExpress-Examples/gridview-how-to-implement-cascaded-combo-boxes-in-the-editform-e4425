@Imports E4425.Models
@(
														Html.DevExpress().GridView(Of Customer)(Sub(settings)
																									settings.Name = "grid"
																									settings.KeyFields(Function(c) c.CustomerId)
																									settings.Width = Unit.Pixel(500)
																									settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

																									settings.SettingsEditing.Mode = GridViewEditingMode.Inline
																									settings.SettingsEditing.UpdateRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewEditPartial"}
																									settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewInsertPartial"}
																									settings.SettingsEditing.DeleteRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewDeletePartial"}

																									settings.CommandColumn.Visible = True
																									settings.CommandColumn.ShowNewButtonInHeader = True
																									settings.CommandColumn.ShowDeleteButton = True
																									settings.CommandColumn.ShowEditButton = True

																									settings.Columns.Add(Function(c) c.CustomerId).Visible = False
																									settings.Columns.Add(Function(c) c.CustomerName)
																									settings.SettingsEditing.ShowModelErrorsForEditors = True
																									settings.Columns.Add(Function(c) c.CountryId, Sub(country)
																																					  country.Caption = "Country"
																																					  country.EditorProperties().ComboBox(Sub(cs)
																																															  cs.Assign(ComboBoxPropertiesProvider.Current.CountryComboBoxProperties)
																																														  End Sub)
																																				  End Sub)
																									settings.Columns.Add(Function(c) c.CityId, Sub(city)
																																				   city.Caption = "City"
																																				   city.EditorProperties().ComboBox(Sub(cs)
																																														cs.Assign(ComboBoxPropertiesProvider.Current.CityComboBoxProperties)
																																													End Sub)
																																			   End Sub)
																									settings.CellEditorInitialize = Sub(s, e)
																																		Dim editor As ASPxEdit = CType(e.Editor, ASPxEdit)
																																		editor.ValidationSettings.Display = Display.Dynamic
																																	End Sub
																									settings.ClientSideEvents.BeginCallback = "onBeginCallback"
																									settings.ClientSideEvents.EndCallback = "onEndCallback"

																								End Sub).SetEditErrorText(TryCast(ViewData("EditError"), String)).Bind(Model).GetHtml())
