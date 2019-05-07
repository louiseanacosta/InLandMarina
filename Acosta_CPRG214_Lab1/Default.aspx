<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Acosta_CPRG214_Lab1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to Inland Marina!</h1>
        <p class="MsoNormal">
            <span lang="EN-US">Located on the south shore Lake, just a small commute from major centers in the south west.</span></p>
        <p class="MsoNormal">
            <span lang="EN-US"></span></p>
        <p class="MsoNormal">
            <span lang="EN-US">Inland Marina was established in the 1967 shortly after. Inland
 Lake was created as a result of the South West damn.<span>&nbsp; </span>From its humble beginnings, it has grown to be the largest marina on Inland Lake.<span>&nbsp; </span>Due to the warm climate that extends year round, Inland 
Lake has become a popular tourist destination in the south west.<span>&nbsp; </span>Boat owners from California, Arizona,
Nevada, and Utah are attracted to the area.<span>&nbsp; </span>Inland Marina has 90 slips ranging in size from 16 to 32 feet in length.<span>&nbsp; </span>Dock services include electrical and fresh water.</span></p>
        <p class="lead">&nbsp;</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                We have 90 available dock stations for lease! You can now lease a slip online. Register or Login now!
            </p>
            <p>
                <asp:Image ID="Image1" runat="server" Height="310px" ImageUrl="~/Images/marina1.jpg" Width="335px" />
            </p>
            <p>
                <a class="btn btn-default" href="Register.aspx">Register or Login &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Contact Us</h2>
            <p>
                If you have any questions or inquiries, you can visit us or give us a call.
            </p>
            <p>
                <asp:Image ID="Image2" runat="server" Height="127px" ImageUrl="~/Images/marina2.jpg" Width="371px" />
            </p>
            <p>
                <a class="btn btn-default" href="Contact.aspx">Contact &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Available Slips</h2>
            <p>
                Take a look at a list of our available lease slips and order now.</p>
            <p>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/marina3.jpg" />
            </p>
            <p>
                <a class="btn btn-default" href="Lease.aspx">List of Slips &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
