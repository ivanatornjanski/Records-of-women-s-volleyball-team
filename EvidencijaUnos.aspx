<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EvidencijaUnos.aspx.cs" Inherits="KorisnickiInterfejs.EvidencijaUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 423px;
    }
    .style2
    {
        width: 342px;
        text-align: right;
    }
    .style3
    {
        width: 423px;
        font-size: large;
    }
    .style4
    {
        font-size: large;
    }
    .style5
    {
        width: 342px;
        font-size: large;
        text-align: right;
    }
    .auto-style1 {
        width: 342px;
        text-align: right;
        height: 21px;
    }
    .auto-style2 {
        width: 423px;
        height: 21px;
    }
    .auto-style3 {
        height: 21px;
    }
    .auto-style4 {
        width: 342px;
        text-align: right;
        height: 30px;
    }
    .auto-style5 {
        width: 423px;
        height: 30px;
    }
    .auto-style6 {
        height: 30px;
    }
    .auto-style10 {
        width: 342px;
        text-align: right;
        height: 26px;
    }
    .auto-style11 {
        width: 423px;
        height: 26px;
    }
    .auto-style12 {
        height: 26px;
    }
    .auto-style13 {
        width: 342px;
        text-align: right;
        height: 11px;
    }
    .auto-style14 {
        width: 423px;
        height: 11px;
    }
    .auto-style15 {
        height: 11px;
    }
    .auto-style16 {
        width: 342px;
        text-align: right;
        height: 27px;
    }
    .auto-style17 {
        width: 423px;
        height: 27px;
    }
    .auto-style18 {
        height: 27px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style3">
            <strong>UNOS EVIDENCIJA</strong></td>
        <td class="style4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="ID Igraca"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbIDIgraca" runat="server" OnTextChanged="txbIDIgraca_TextChanged"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Ime igraca"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbIgracIme" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
          <tr>
        <td class="style2">
            <asp:Label ID="Label6" runat="server" Text="">Prezime igraca</asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbIgracPrezime" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10">
            <asp:Label ID="Label3" runat="server" Text="Godina rodjenja"></asp:Label>
        </td>
        <td class="auto-style11">
            <asp:TextBox ID="txbGodinaRodjenja" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style12">
            </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="Label4" runat="server" Text="BrojNaDresu"></asp:Label>
        </td>
        <td class="auto-style2">
            <asp:TextBox ID="txbBrojNaDresu" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            </td>
    </tr>
    <tr>
        <td class="auto-style16">
            <asp:Label ID="Label5" runat="server" Text="Klub"></asp:Label>
        </td>
        <td class="auto-style17">
            <asp:DropDownList ID="ddlKlubovi" runat="server" Height="16px" Width="233px">
            </asp:DropDownList>
        </td>
        <td class="auto-style18">
            </td>
    </tr>
  
    <tr>
        <td class="auto-style13">
            </td>
        <td class="auto-style14">
            <asp:Label ID="lblStatus" runat="server" Text="STATUS"></asp:Label>
        </td>
        <td class="auto-style15">
            </td>
    </tr>
    <tr>
        <td class="auto-style4">
            </td>
        <td class="auto-style5">
            <asp:Button ID="btnSnimi" runat="server" Text="SNIMI" Width="69px" 
                onclick="btnSnimi_Click" />
            <asp:Button ID="btnPonisti" runat="server" Text="PONISTI" 
                onclick="btnPonisti_Click" />
        </td>
        <td class="auto-style6">
            </td>
    </tr>
</table>
</asp:Content>
