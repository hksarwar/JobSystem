<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logoff.aspx.cs" Inherits="ConsultantJobPortal.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       Log Out
    </h2>
    <p class="logOff">
        Are you sure you want to log out?
    </p>
    <p class="logOff">
        <asp:Button ID="btnYes" runat="server" Text="Yes" onclick="btnYes_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" />
    </p>
</asp:Content>
