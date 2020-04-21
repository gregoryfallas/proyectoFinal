function llamarajax() {
    jQuery.support.cors = true;
    var ListarRequest = "<soapenv:Envelope xmlns: soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns: tem=\"http://tempuri.org/ \"> " +
            "   <soapenv:Header/> " +
            "<soapenv:Body> "+
            "<tem:ListarDatos>" +
            "  <!--Optional:--> "+
            "<tem:sNombreSP>sp_Listar_Estados</tem:sNombreSP >" +
            "  < !--Optional: --> "+
            "<tem:sMsjError>?</tem:sMsjError > "+
            "</tem:ListarDatos >" +
            "</soapenv:Body > "+
            " </soapenv:Envelope > ";
    $.ajax({
        type: "POST",
        url: "http://localhost:8733/Design_Time_Addresses/WCF_Proyecto_SVC/Contract/BD",
        data: ListarRequest,
        contentType: "text/xml; charset=utf-8",
        dataType: "xml",
        //beforeSend: function (xhr) {
        //    xhr.setRequestHeader("SOAPAction", "http://tempuri.org/IBD/ListarDatos")
        //},
        success: function (data) {
            alert(data.d);
        },
        error: errores
    });
}

function resultado(data) {
    alert(data.d);
}

function errores(msg) {
    alert('Error: ' + msg.responseText);
}


$(document).ready(function () {
    $('#openmodal').click({
        function () { //subscribe to show method
            var getIdFromRow = $(event.target).closest('tr').data('id'); //get the id from tr
            var getIdColumns = getIdFromRow.getElementsByTagName('td');

            for (var i = 0; i < getIdColumns.length; i++) {
                var input = getIdColumns[i]
                input.text(columns[i]);
            }
        }
    });
});

//function loadModal(row) {
//    var columns = $(#row).getElementsByTagName("th");

//    for (var i = 0; i < columns.length; i++) {
//        var input = "inputcolumn" + i;
//        $(#input).text(columns[i]);
//    }
//}