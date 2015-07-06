<%@ Page Title="" Language="C#" MasterPageFile="~/StaffTemplate.Master" AutoEventWireup="true" CodeBehind="ConfirmAddStaff.aspx.cs" Inherits="dwa_hansel.ConfirmAddStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    .auto-style2 {
        width: 100%;
    }
    .auto-style3 {
        width: 200px;
            height: 23px;
        }
    .auto-style4 {
        height: 26px;
    }
        .auto-style5 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style2">
        <tr>
            <td>&nbsp;</td>
            <td style="padding: 5px"><strong>Add Staff Record</strong></td>
        </tr>
        <tr>
            <td class="auto-style3">Name:</td>
            <td class="auto-style5">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Gender:</td>
            <td class="auto-style5">
                <asp:Label ID="lblGender" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>D.O.B.</td>
            <td>
                <asp:Label ID="lblDOB" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Salary:</td>
            <td>
                <asp:Label ID="lblSalary" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Email:</td>
            <td class="auto-style4">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Nationality:</td>
            <td>
                <asp:Label ID="lblNationality" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Full Time:</td>
            <td>
                <asp:Label ID="lblIsFullTimeStaff" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
            <td>
                <asp:Button ID="btnBack" runat="server" Text="Back" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
