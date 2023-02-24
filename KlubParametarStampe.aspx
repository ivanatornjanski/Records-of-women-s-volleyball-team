<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KlubParametarStampe.aspx.cs" Inherits="KorisnickiInterfejs.KlubParametarStampe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
            width: 385px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" style="text-align: right" 
                    Text="Naziv kluba"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbFilter" runat="server"></asp:TextBox>
                <asp:Button ID="btnFilterStampa" runat="server" onclick="btnFilterStampa_Click" 
                    Text="PRIKAZI FILTRIRANI SPISAK ZA STAMPU" Width="297px" />
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
