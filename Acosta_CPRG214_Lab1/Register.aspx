<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Acosta_CPRG214_Lab1.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="FirstName" runat="server" Text="First Name:"></asp:Label><br />
    <asp:TextBox ID="uxFirstName" runat="server"></asp:TextBox><br />

    <asp:Label ID="LastName" runat="server" Text="Last Name:"></asp:Label><br />
    <asp:TextBox ID="uxLastName" runat="server"></asp:TextBox><br />

    <asp:Label ID="Phone" runat="server" Text="Phone:"></asp:Label><br />
    <asp:TextBox ID="uxPhone" runat="server"></asp:TextBox><br />

    <asp:Label ID="City" runat="server" Text="City:"></asp:Label><br />
    <asp:TextBox ID="uxCity" runat="server"></asp:TextBox><br />

    <br />
    <asp:Button ID="uxRegister" runat="server" Text="Register" OnClick="uxRegister_Click" />
<br />
<br />
<asp:Label ID="uxError" runat="server"></asp:Label>
</asp:Content>
