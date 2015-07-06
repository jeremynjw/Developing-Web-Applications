<%@ Page Title="" Language="C#" MasterPageFile="~/StaffTemplate.Master" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="dwa_hansel.ViewStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <strong>View Staff</strong></p>
<p>
    <asp:GridView ID="gvStaff" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvStaff_PageIndexChanging" PageSize="5" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="StaffID" HeaderText="Staff ID" />
            <asp:BoundField DataField="Name" HeaderText="Staff Name" />
            <asp:BoundField DataField="Salary" HeaderText="Salary" />
            <asp:BoundField DataField="EmailAddr" HeaderText="Email Address" />
            <asp:HyperLinkField DataNavigateUrlFields="StaffID" DataNavigateUrlFormatString="EditStaff.aspx?staffid={0}" HeaderText="Edit" Text="Update" />
            <asp:HyperLinkField DataNavigateUrlFields="StaffID,Name" DataNavigateUrlFormatString="DeleteStaff.aspx?staffid={0}&amp;name={1}" HeaderText="Delete" Text="Remove" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</p>
<p>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</p>
</asp:Content>
