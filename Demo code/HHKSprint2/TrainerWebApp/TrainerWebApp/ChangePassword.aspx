<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="ChangePassword.aspx.cs" Inherits="TrainerWebApp.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome <%= username %>
    </h2>

    <h3>
        Change Password
    <span class="failureNotification">
            <asp:Label ID="FailureText" runat="server" Text=""></asp:Label>
        </span>
    </h3>
    <p>
    </p>
    <div class ="accountInfo">  
        <fieldset>
          <legend> Enter New Password </legend>
          <p>
              <asp:Label ID="NewPass" runat="server" Text="New Password:" AssociatedControlID="txtnewPasswd"></asp:Label>
              <asp:TextBox ID="txtnewPasswd" runat="server" Width="337px" TextMode="Password"></asp:TextBox>
          </p>
          <p>
              <asp:Label ID="ConfirmPass" Text="Confirm Password:" runat="server" AssociatedControlID="txtConfirmPasswd"></asp:Label>
              <asp:TextBox ID="txtConfirmPasswd" runat="server" Width="337px" TextMode="Password"></asp:TextBox>
          </p>
          <p class="submitButton">
              <asp:Button ID="btnChngPass" runat="server" Text="Change Password" onclick="btnChngPwd_Click"
              OnClientClick="javascript:return confirm('Password changed. You will now be redirected to the log on page')"/>
              <br />
              <br />
              <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                  onclick="btnCancel_Click" />
          </p>
        </fieldset>
    </div>
    </asp:Content>