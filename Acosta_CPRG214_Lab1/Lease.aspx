<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lease.aspx.cs" Inherits="Acosta_CPRG214_Lab1.Lease" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <strong>List of Available Slips for Lease:</strong><br />
    <asp:Label ID="Label1" runat="server" Text="Select Dock:"></asp:Label>
    <asp:ObjectDataSource ID="DocksDataSource" runat="server" SelectMethod="GetDocks" TypeName="MarinaBL.DockDB"></asp:ObjectDataSource>
    <asp:DropDownList ID="uxDockList" runat="server" DataSourceID="DocksDataSource" DataTextField="Name" DataValueField="Id" AutoPostBack="True"></asp:DropDownList>
    <br /> <br />
    <table class ="table">
        <tr>
            <th>Dock</th>
            <th>Water Service</th>
            <th>Electrical Service</th>
        </tr>
        <tr>
            <td>A</td>
            <td>Included</td>
            <td>Included</td>
        </tr>
        <tr>
            <td>B</td>
            <td>Included</td>
            <td>Not Included</td>
        </tr>
        <tr>
            <td>C</td>
            <td>Not Included</td>
            <td>Included</td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" DataSourceID="SlipsDataSource" Width="50px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Slip Number" SortExpression="Id" />
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="SlipsDataSource" runat="server" SelectMethod="GetSlips" TypeName="MarinaBL.SlipDB">
        <SelectParameters>
            <asp:ControlParameter ControlID="uxDockList" DefaultValue="0" Name="dockID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
