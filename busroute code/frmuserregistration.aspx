<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmuserregistration.aspx.cs" Inherits="frmuserregistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 25px;
        }
        .auto-style3 {
            height: 22px;
        }
    .auto-style4 {
        height: 26px;
    }
    .auto-style5 {
        width: 251px;
    }
    .auto-style6 {
        height: 25px;
        width: 251px;
    }
    .auto-style7 {
        height: 26px;
        width: 251px;
    }
    .auto-style8 {
        height: 22px;
        width: 251px;
    }
    .auto-style9 {
        width: 184px;
    }
    .auto-style10 {
        height: 25px;
        width: 184px;
    }
    .auto-style11 {
        height: 26px;
        width: 184px;
    }
    .auto-style12 {
        height: 22px;
        width: 184px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2> User Registration</h2>
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style10">User ID (Auto Generate)</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_userid" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">Name of the user</td>
            <td>
                <asp:TextBox ID="txt_name" runat="server" Width="273px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">Gender</td>
            <td>
                <asp:DropDownList ID="drop_gender" runat="server">
                    <asp:ListItem Selected="True">&lt;--- Select ---&gt;</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">Email Id</td>
            <td>
                <asp:TextBox ID="txt_emailid" runat="server" Width="271px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style11">Mobile Number</td>
            <td class="auto-style4">
                <asp:TextBox ID="txt_mobile" runat="server" Width="269px"></asp:TextBox>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style11">Username</td>
            <td class="auto-style4">
                <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style11">Password</td>
            <td class="auto-style4">
                <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style12"></td>
            <td class="auto-style3"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>
                <asp:Button ID="btnregister" runat="server" Text="Register" OnClick="btnregister_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

