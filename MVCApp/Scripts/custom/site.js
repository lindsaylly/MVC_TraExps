function LoadProvinceList(name) {
    $.get("/Home/GetProvinceList", { CountryName: name }, function (data) {
        $("#Province").empty();
        $("#Province").append("<option></option>");
        $.each(data, function (index, row) {
            $("#Province").append("<option value='" + row.ProvAbbr + "'>" + row.ProvName + "</option>")
        });
    });
}


function MaskPhoneNumber() 
{
    $("#BusinessPhone, #HomePhone").mask("(999) 999-9999");
}



