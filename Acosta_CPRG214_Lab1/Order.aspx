<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Acosta_CPRG214_Lab1.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <asp:ObjectDataSource ID="slipDataSource" runat="server" SelectMethod="GetSlips" TypeName="MarinaBL.SlipDB">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="dockID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="slipDataSource2" runat="server" SelectMethod="GetSlipsDockB" TypeName="MarinaBL.SlipDB"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="slipDataSource3" runat="server" SelectMethod="GetSlipsDockC" TypeName="MarinaBL.SlipDB"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="slipListDataSource" runat="server" SelectMethod="GetSlips" TypeName="MarinaBL.SlipDB">
            <SelectParameters>
                <asp:Parameter DefaultValue="-1" Name="dockID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

    

    <p>
        <strong>SELECT SLIP NUMBER TO LEASE:</strong></p>
    <p>
        <strong>(see list of available slips below)<asp:ObjectDataSource ID="dockDataSource" runat="server" SelectMethod="GetDocks" TypeName="MarinaBL.DockDB"></asp:ObjectDataSource>
        </strong></p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dockDataSource" DataTextField="Name" DataValueField="Id" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>

    
    <table class ="table" style="width: 75%">
        <tr>
            <th style="height: 36px">Dock</th>
            <th style="height: 36px">Water Service</th>
            <th style="height: 36px">Electrical Service</th>
        </tr>
        <tr>
            <td style="height: 37px">A</td>
            <td style="height: 37px">Included</td>
            <td style="height: 37px">Included</td>
        </tr>
        <tr>
            <td style="height: 16px">B</td>
            <td style="height: 16px">Included</td>
            <td style="height: 16px">Not Included</td>
        </tr>
        <tr>
            <td>A</td>
            <td>Not Included</td>
            <td>Included</td>
        </tr>
    </table>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" DataSourceID="slipDataSource" Width="248px">
                <Columns>
                    <asp:TemplateField HeaderText="Id" SortExpression="Id">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

           

        </p>
        <p>
        <asp:Button class="btn btn-primary btn-lg" ID="uxSubmit" runat="server" Text="LEASE" OnClick="uxSubmit_Click" />

           

        </p>
        <p>
            <asp:ObjectDataSource ID="leaseDataSource" runat="server" SelectMethod="GetLeases" TypeName="MarinaBL.LeaseDB">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="" Name="FirstName" SessionField="customerFirstName" Type="String" />
                    <asp:SessionParameter Name="LastName" SessionField="customerLastName" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <strong>CURRENT SLIPS LEASED (listed by slip number):</strong></p>


    <p>
     <asp:ListBox ID="ListBox1" runat="server" Width="133px" DataSourceID="leaseDataSource" DataTextField="SlipID" DataValueField="SlipID"></asp:ListBox>
        </p>
</asp:Content>
