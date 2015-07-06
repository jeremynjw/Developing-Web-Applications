<%@ Page Title="" Language="C#" MasterPageFile="~/StaffTemplate.Master" AutoEventWireup="true" CodeBehind="FineCalculator.aspx.cs" Inherits="dwa_hansel.FineCalculator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 200px;
        }
        .auto-style4 {
            width: 200px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td style="font-weight: bold">Fine Calculator</td>
        </tr>
        <tr>
            <td class="auto-style3">Number of overdue book (s):</td>
            <td>
                <asp:TextBox ID="txtNumOverdueBk" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btnCompute" runat="server" OnClick="btnCompute_Click" Text="Compute" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">Fine (SGD):</td>
            <td class="auto-style5">
                <asp:Label ID="lblFine" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Breakdown of the fine: </td>
            <td>
                <asp:Label ID="lblFineBreakdown" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
