<%@ Page Title="" Language="C#" MasterPageFile="~/StaffTemplate.Master" AutoEventWireup="true" CodeBehind="DeleteStaff.aspx.cs" Inherits="dwa_hansel.DeleteStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style2">
        Are you sure you want to delete for Staff
        <asp:Label ID="lblStaffID" runat="server" Font-Bold="True"></asp:Label>
&nbsp;-
        <asp:Label ID="lblStaffName" runat="server" Font-Bold="True"></asp:Label>
&nbsp;?</p>
    <p class="auto-style2">
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" />
&nbsp;
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
    </p>
    <p class="auto-style2">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
    </p>
    <p class="auto-style2">
        <asp:HyperLink ID="lnkViewStaff" runat="server" NavigateUrl="ViewStaff.aspx" Visible="False">Return to View Staff Page</asp:HyperLink>
    </p>
</asp:Content>
