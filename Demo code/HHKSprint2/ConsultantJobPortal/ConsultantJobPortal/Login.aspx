<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConsultantJobPortal.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Log In
    </h2>
    <p>
    </p>
        <span class="failureNotification">
            <asp:Label ID="FailureText" runat="server" Text=""></asp:Label>
        </span>
    <div class ="accountInfo">  
        <fieldset>
          <legend> Account Information </legend>
          <p>
              <asp:Label ID="Username" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label>
              <asp:TextBox ID="txtUsername" runat="server" Width="337px"></asp:TextBox>
          </p>
          <p>
              <asp:Label ID="Password" Text="Password:" runat="server" AssociatedControlID="txtPassword"></asp:Label>
              <asp:TextBox ID="txtPassword" runat="server" Width="337px" TextMode="Password"></asp:TextBox>
          </p>
          <p class="submitButton">
              <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click"/>
              <br />
              <asp:Button ID="btnForgotPwd" runat="server" Text="Forgot Password" 
                  onclick="btnForgotPwd_Click" />
          </p>
        </fieldset>
    </div>
</asp:Content>