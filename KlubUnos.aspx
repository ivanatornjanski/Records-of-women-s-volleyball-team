<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KlubUnos.aspx.cs" Inherits="KorisnickiInterfejs.KlubUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 214px;
            text-align: right;
        }
        .style2
        {
            width: 214px;
            text-align: right;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <b>UNOS KLUBOVA
                </b></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Sifra</td>
            <td>
                <asp:TextBox ID="txbSifra" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Naziv</td>
            <td>
                <asp:TextBox ID="txbNaziv" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="status"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSnimi" runat="server" onclick="btnSnimi_Click" Text="SNIMI" 
                    Width="90px" />
                <asp:Button ID="btnOdustani" runat="server" onclick="btnOdustani_Click" 
                    Text="ODUSTANI" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
