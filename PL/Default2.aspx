<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>
<html>
<head>
    <title>WCF + Ajax + jQuery + JSON</title>
    <script src="Scripts/jquery-2.1.4.js"></script>
</head>
<body>
    <form runat="server" method="post">
    <div class="page">
        <div class="main">
            <div style="font:15px Arial;">
                <h2><strong>Lamando servicios WCF con Ajax y JSON</strong></h2><br />
                <div>
                    <b>Introduce el Empleado ID</b>:  <input id="txtID" type="text" runat="server" />
                </div>

                <div id="EmpleadoDetalle" runat="server" style="margin:10px 0;"> </div>

                <div style="margin:10px auto;">
                    <input type="button" value="Enviar" id="btnEnviar" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
    <script>
        $('#btnEnviar').click(function () {
            $.ajax({
                url: "http://localhost:61489/SrvEmpleado.svc/ObtenerEmpleadoDetalle",
                data: JSON.stringify($('#txtID').val()),
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#EmpleadoDetalle').html('EmployeeID: ' + data.EmployeeID +
                        '<br /> LastName: ' + data.LastName +
                        '<br /> FirstName: ' + data.FirstName +
                        '<br /> Title: ' + data.Title +
                        '<br /> Address: ' + data.Address +
                        '<br /> City: ' + data.City +
                        '<br /> Region: ' + data.Region +
                        '<br /> PostalCode: ' + data.PostalCode +
                        '<br /> Country: ' + data.Country +
                        '<br /> Extension: ' + data.Extension
                        );
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ': ' + errorThrown.toString());
                }
            });

        });
    </script>
 </html>
