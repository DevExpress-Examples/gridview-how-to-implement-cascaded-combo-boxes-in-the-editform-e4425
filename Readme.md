# GridView - How to implement cascaded combo boxes in the EditForm


<p>This example is an illustration of the <a href="https://www.devexpress.com/Support/Center/p/KA18675">KA18675: MVC ComboBox Extension - How to implement cascaded combo boxes</a> KB Article. Refer to the Article for an explanation.<br><br><strong>UPDATED:</strong><br><br></p>
<p>Starting with <strong>v16.1</strong>, it's not necessary to define the second combo box using the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxGridViewColumn_SetEditItemTemplateContenttopic">MVCxGridViewColumn.SetEditItemTemplateContent</a> method to enable callbacks. <br>Use a new API instead

* <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxGridViewColumn_EditorPropertiestopic">MVCxGridViewColumn.EditorProperties</a> 
* <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebMvcMVCxColumnComboBoxPropertiestopic">MVCxColumnComboBoxProperties</a> 
* <a href="http://help.devexpress.com/#AspNet/DevExpressWebMvcGridExtensionBase_GetComboBoxCallbackResulttopic">GetComboBoxCallbackResult</a> <br> <br>You can find detailed steps by clicking the "Show Implementation Details" link below.</p>

<br/>


