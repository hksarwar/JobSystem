<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountManagers.aspx.cs" Inherits="TrainerWebApp.AccountManagers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    Account Managers
</h2>
<p></p>
<p></p>
<div>
    <asp:GridView ID="gvAccMan" runat="server" 
                    CellPadding="25" ForeColor="#333333" 
                    GridLines="None" ShowHeader="false" 
                    HorizontalAlign="Center" onrowcommand="gvAccMan_RowCommand">
        <AlternatingRowStyle BackColor="AliceBlue" ForeColor="Black" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="CornflowerBlue" Font-Bold="true" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="CornflowerBlue" Font-Bold="true" ForeColor="GhostWhite" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="GhostWhite" ForeColor="Black"/>
        <SelectedRowStyle BackColor="#B2D1B2" Font-Bold="true" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <Columns>
               <asp:ButtonField ButtonType="Link" CommandName="Email" Text="Email" /> 
    </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
</div>
</asp:Content>
