<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarEmpleado.aspx.cs" Inherits="AddEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <strong>Agregar nuevo empleado:<br />
        </strong>
        <br />
        <table style="width: 320px">
            <tr>
                <td>
                    Apellido</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Puesto</td>
                <td>
                    <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Dirección</td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Ciudad</td>
                <td>
                    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Región</td>
                <td>
                    <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Código Postal</td>
                <td>
                    <asp:TextBox ID="txtCodigoPostal" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    País</td>
                <td>
                    <asp:TextBox ID="txtPais" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Extensión</td>
                <td>
                    <asp:TextBox ID="txtExtension" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnYES" runat="server" OnClick="btnYES_Click" Text="Guardar" />
        <asp:Button ID="btnNO" runat="server" OnClick="btnNO_Click" Text="Cancelar" /></div>
    </form>
</body>
</html>
