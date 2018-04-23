<script type="text/javascript">
    function CountriesCombo_SelectedIndexChanged(s, e) {
        CityID.PerformCallback();
    }
    function CitiesCombo_BeginCallback(s, e) {
        e.customArgs['CountryID'] = grid.GetEditor('CountryID').GetValue();
    }
</script>
@Html.Partial("GridViewPartial")