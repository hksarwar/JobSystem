<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddRecommendation.aspx.cs" Inherits="TrainerWebApp.AddRecommendation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
    Recommend a Consultant for the selected job</h2>
    <br />
&nbsp;&nbsp;&nbsp; Selected Job:
    <asp:Label ID="selectedJobLBL" runat="server"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;Search by stream:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:DropDownList ID="streamFilterCBX" runat="server" 
        onselectedindexchanged="streamFilterCBX_SelectedIndexChanged">
    </asp:DropDownList>
    &nbsp;&nbsp;
    <asp:Button ID="GetConsultantsBTN" runat="server" Text="Go" 
        onclick="GetConsultantsBTN_Click" />
&nbsp;
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="SelectTextLBL" runat="server" 
        Text="Select the name of a Consultant:&nbsp;"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="SearchConsultantsRecLBX" runat="server" Height="173px" 
        Width="321px"></asp:ListBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="ReasonLBL" runat="server" 
        Text="Reason for Recommendation (optional):"></asp:Label>
&nbsp;<br />
    <br />
&nbsp; &nbsp;
    <asp:TextBox ID="ReasonTBX" runat="server" Height="70px" TextMode="MultiLine" 
        Width="640px"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="CancelRecBTN" runat="server" Text="Cancel" 
        onclick="CancelRecBTN_Click" />
&nbsp;&nbsp;
    <asp:Button ID="insertRecBTN" runat="server" Text="Recommend" 
        onclick="InsertRecBTN_Click" />
    <br />
    <br />
</asp:Content>
