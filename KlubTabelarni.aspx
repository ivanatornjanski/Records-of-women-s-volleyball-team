<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KlubTabelarni.aspx.cs" Inherits="KorisnickiInterfejs.KlubTabelarni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 237px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                TABELARNI PRIKAZ KLUBOVA</td>
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
        <tr>
            <td class="style1">
                Filter (naziv):</td>
            <td>
                <asp:TextBox ID="txbFilter" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltriraj" runat="server" onclick="btnFiltriraj_Click" 
                    Text="FILTRIRAJ" />
                <asp:Button ID="btnSvi" runat="server" onclick="btnSvi_Click" Text="SVI" 
                    Width="68px" />
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
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvSpisakKlub" runat="server" Height="211px" Width="353px">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
