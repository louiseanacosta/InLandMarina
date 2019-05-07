<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Acosta_CPRG214_Lab1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <address>
        Inland Lake Marina<br />
        Box 123<br />
        Inland Lake, Arizonac
        86038<br /><br />

        Office Phone: (928) 450-2234<br />
        Leasing Phone: (928) 450-2235<br />
        Fax: (928) 450-2236<br /><br />

        Manager: Glen Cooke<br />
        Slip Manager: Kimberley Carson<br /><br />
    </address>

    <address>
        <strong>Contact email:</strong> <a href="mailto:info@inlandmarina.com">info@inlandmarina.com</a><br />
    </address>
</asp:Content>
