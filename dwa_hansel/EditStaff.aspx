<%@ Page Title="" Language="C#" MasterPageFile="~/StaffTemplate.Master" AutoEventWireup="true" CodeBehind="EditStaff.aspx.cs" Inherits="dwa_hansel.EditStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    .auto-style2 {
        width: 100%;
    }
    .auto-style3 {
        width: 200px;
    }
    .auto-style4 {
        height: 26px;
    }
        .auto-style5 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style2">
        <tr>
            <td>&nbsp;</td>
            <td style="padding: 5px"><strong>Edit Staff Record</strong></td>
        </tr>
        <tr>
            <td class="auto-style3">Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Please specify a name" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Gender:</td>
            <td>
                <asp:RadioButton ID="radMale" runat="server" Checked="True" GroupName="Gender" Text="Male" />
&nbsp;<asp:RadioButton ID="radFemale" runat="server" GroupName="Gender" Text="Female" />
            </td>
        </tr>
        <tr>
            <td>D.O.B.</td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Salary:</td>
            <td>
                <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="covSalary" runat="server" ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Please specify a valid salary" ForeColor="Red" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                <asp:RangeValidator ID="ravSalary" runat="server" ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Please specify between 1 to 10000" ForeColor="Red" MaximumValue="10000" MinimumValue="1" Type="Currency">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Email:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please specify a valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Nationality:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlNationality" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Branch:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlBranch" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:CheckBox ID="chkFullTime" runat="server" Text="Is Full-Time Staff?" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" />
                <br />
&nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>
</asp:Content>
