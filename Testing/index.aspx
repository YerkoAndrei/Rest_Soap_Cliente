<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Servicios Soap</h1>

        <h3>Centímeros / pulgadas</h3>
        <table>
            <tr>
                <td><asp:TextBox ID="txtValor" runat="server" TextMode="Number"></asp:TextBox></td>
                <td>
                    <asp:RadioButton ID="radCm" runat="server" Text="Centímetro a pulgada" GroupName="Convertir" Checked/>
                    <asp:RadioButton ID="radPul" runat="server" Text="Pulgada a centímetro" GroupName="Convertir"/>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnCovnertir" runat="server" Text="Convertir" OnClick="btnCovnertir_Click"/></td>
                <td><asp:Label ID="lblConvertido" runat="server" Text="0"></asp:Label></td>
            </tr>
        </table>

        <h3>Siglo de un año</h3>
        <table>
            <tr>
                <td><asp:TextBox ID="txtAño" runat="server" TextMode="Number"></asp:TextBox></td>
                <td><asp:Label ID="lblSiglo" runat="server" Text="0"></asp:Label> </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnSigloAño" runat="server" Text="Siglo del año" OnClick="btnSigloAño_Click" /> </td>
                <td></td>
            </tr>
        </table>
    </div>

    <div>
        <h1>Servicios Rest</h1>
        <asp:TextBox ID="txtApi" runat="server" Text="http://localhost:60670/api/personas" Width="220px" Enabled="false"></asp:TextBox>
        
        <table border="1">
            <tr>
                <td>Get</td>
                <td><asp:TextBox ID="txtGet" runat="server" placeholder="Id..."></asp:TextBox> </td>
                <td></td>
                <td></td>
                <td><asp:Button ID="btnGet" runat="server" Text="Get" OnClick="btnGet_Click" /></td>
            </tr>
            <tr>
                <td>GetAll</td>
                <td></td>
                <td></td>
                <td></td>
                <td><asp:Button ID="betGetAll" runat="server" Text="GetAll" OnClick="betGetAll_Click" /></td>
            </tr>
            <tr>
                <td>Post</td>
                <td><asp:TextBox ID="txtPostNombre" runat="server" placeholder="Nombre..."></asp:TextBox></td>
                <td><asp:TextBox ID="txtPostApellido" runat="server" placeholder="Apellido..."></asp:TextBox> </td>
                <td></td>
                <td><asp:Button ID="btnPost" runat="server" Text="Post" OnClick="btnPost_Click" /></td>
            </tr>
            <tr>
                <td>Put</td>
                <td><asp:TextBox ID="txtPutId" runat="server" placeholder="Id..."></asp:TextBox></td>
                <td><asp:TextBox ID="txtPutNombre" runat="server" placeholder="Nombre..."></asp:TextBox></td>
                <td><asp:TextBox ID="txtPutApellido" runat="server" placeholder="Apellido..."></asp:TextBox></td>
                <td><asp:Button ID="btnPut" runat="server" Text="Put" OnClick="btnPut_Click" /></td>
            </tr>
            <tr>
                <td>Delete</td>
                <td><asp:TextBox ID="txtDelete" runat="server" placeholder="Id..."></asp:TextBox></td>
                <td></td>
                <td></td>
                <td><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
