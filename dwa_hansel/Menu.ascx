<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="dwa_hansel.Menu" %>
<asp:Menu ID="menuAdmin" runat="server" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1em" ForeColor="#666666" Orientation="Horizontal" StaticSubMenuIndent="10px" OnMenuItemClick="menuAdmin_MenuItemClick">
    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicMenuStyle BackColor="#E3EAEB" />
    <DynamicSelectedStyle BackColor="#1C5E55" />
    <Items>
        <asp:MenuItem NavigateUrl="~/AddStaff.aspx" Text="- Add Staff" Value="AddStaff"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/ViewStaff.aspx" Text="- View Staff" Value="ViewStaff"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/ViewBranch.aspx" Text="- View Branch" Value="ViewBranch"></asp:MenuItem>
        <asp:MenuItem Text="- Rental Calculator" Value="RentalCalculator" NavigateUrl="~/RentalCalculator.aspx"></asp:MenuItem>
        <asp:MenuItem Text="- Fine Calculator" Value="FineCalculator" NavigateUrl="~/FineCalculator.aspx"></asp:MenuItem>
        <asp:MenuItem Text="- Logout" Value="Logout"></asp:MenuItem>
    </Items>
    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticSelectedStyle BackColor="#1C5E55" />
</asp:Menu>

