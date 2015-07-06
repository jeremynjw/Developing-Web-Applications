<%@ Page Title="" Language="C#" MasterPageFile="~/StaffTemplate.Master" AutoEventWireup="true" CodeBehind="RentalCalculator.aspx.cs" Inherits="dwa_hansel.RentalCalculator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 30%;
        }
        .auto-style4 {
            width: 70%;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style2">
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td style="padding: 5px" class="auto-style4"><strong>Rental Calculator</strong></td>
    </tr>
    <tr>
        <td class="auto-style3">Number of Books:</td>
        <td class="auto-style4">
            <asp:DropDownList ID="ddlNumBooks" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Number of Days:</td>
        <td class="auto-style4">
            <asp:DropDownList ID="ddlNumDays" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Rental Rate (SGD):</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtRentalRate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Button ID="btnCalRentalFee" runat="server" Text="Compute Rental" OnClick="btnCalRentalFee_Click" />
        </td>
        <td class="auto-style4">
            <asp:Button ID="btnCalcDiscountRentalFee" runat="server" OnClick="btnCalcDiscountRentalFee_Click" Text="Calculate Discount" />
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Rental Fee (SGD):</td>
        <td class="auto-style4">
            <asp:Label ID="lblRentalFee" runat="server">0.0</asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Discount Given</td>
        <td class="auto-style4">
            <asp:Label ID="lblDiscountPercent" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">Amount Payable:</td>
        <td class="auto-style4">
            <asp:Label ID="lblAmtPayable" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Currency</td>
        <td class="auto-style4">
            <asp:RadioButtonList ID="rdoCurrencies" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoCurrencies_SelectedIndexChanged" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
</asp:Content>
