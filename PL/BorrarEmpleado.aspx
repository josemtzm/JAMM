<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BorrarEmpleado.aspx.cs" Inherits="BorrarEmpleado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Borrar Empleado</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Confirmación para borrar el empleado:<br />
        <br />
        <table style="width: 320px">
            <tr>
                <td>
                    Empleado ID</td>
                <td>
                    <asp:Label ID="lblEmpleadoID" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Apellido</td>
                <td>
                    <asp:Label ID="lblApellido" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Nombre</td>
                <td>
                    <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Puesto</td>
                <td>
                    <asp:Label ID="lblPuesto" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Dirección</td>
                <td>
                    <asp:Label ID="lblDireccion" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Ciudad</td>
                <td>
                    <asp:Label ID="lblCiudad" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Región</td>
                <td>
                    <asp:Label ID="lblRegion" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Código Postal</td>
                <td>
                    <asp:Label ID="lblCodigoPostal" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    País</td>
                <td>
                    <asp:Label ID="lblPais" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Extensión</td>
                <td>
                    <asp:Label ID="lblExtension" runat="server" Font-Bold="True" Text=""></asp:Label></td>
            </tr>
        </table>
    
    </div>
        <br />
        ¿Esta seguro que desea borrar el registro?: &nbsp; &nbsp;
        <asp:Button ID="btnYES" runat="server" Text="Si" OnClick="btnYES_Click" />
        <asp:Button ID="btnNO" runat="server" Text="No" OnClick="btnNO_Click" /><br />
        <br />
    </form>
</body>
</html>
