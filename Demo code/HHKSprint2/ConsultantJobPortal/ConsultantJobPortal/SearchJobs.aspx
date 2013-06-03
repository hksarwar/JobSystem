<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchJobs.aspx.cs" Inherits="ConsultantJobPortal.SearchJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>
    Job Search
</h2>
    <p>
        Select any of the following criteria to search by:</p>
    <p>
        Stream:
        <asp:DropDownList ID="ddlStream" runat="server" AppendDataBoundItems="true" >
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Status:
        <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="true">
        <asp:ListItem Text="All" Value="All"></asp:ListItem>
        </asp:DropDownList>
</p>
    <p>
        Location:
        <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="true">
        <asp:ListItem Text="Any" Value="Any"></asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Company:
        <asp:DropDownList ID="ddlCompany" runat="server" AppendDataBoundItems="true">
        <asp:ListItem Text="All" Value="All"></asp:ListItem>
        </asp:DropDownList>
</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <br />
        &nbsp;Skills:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button 
            ID="btnAddSkill" runat="server" Text="Add >>" onclick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Selected Skills:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lbxSkills" runat="server" Height="124px" Width="204px"></asp:ListBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:ListBox ID="lbxSelectedSkills" runat="server" Height="124px" Width="204px">
        </asp:ListBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="btnRemoveSkill" runat="server" Text="<< Remove" 
            onclick="btnRemoveSkill_Click" />
</p>
    <p>
        <asp:Button ID="btnSearch" runat="server" Text="Search" 
            onclick="btnSearch_Click" />
</p>
    <p>
        <asp:Label ID="lblFail" runat="server" CssClass="failureNotification"></asp:Label>
</p>
    <p>
        <asp:GridView ID="gvResults" runat="server"
                    autogenerateselectbutton="True"
                    selectedindex="-1" 
                    HorizontalAlign="Center"
                    CellPadding="5"
                    AllowPaging="true" PageSize="5" AutoGenerateColumns="false" 
                    onselectedindexchanged="gvResults_SelectedIndexChanged"
                    onsorting="gvResults_Sorting" AllowSorting="true"
                    OnPageIndexChanging="gvResults_PageIndexChanging">
            <SelectedRowStyle BackColor="#B2D1B2" Font-Bold="true" ForeColor="GhostWhite" />
            <AlternatingRowStyle BackColor="AliceBlue" ForeColor="Black" />
            <RowStyle BackColor="GhostWhite" ForeColor="Black" />
            <HeaderStyle BackColor="CornflowerBlue" Font-Bold="true" ForeColor="GhostWhite" />
            <FooterStyle BackColor="CornflowerBlue" Font-Bold="true" ForeColor="GhostWhite" />
            <Columns>
                <asp:BoundField DataField="DatePosted" HeaderText="Date Posted" SortExpression="DatePosted" dataformatstring="{0:d}"/> 
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
                <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company"/> 
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location"/>
                <asp:BoundField DataField="Stream" HeaderText="Stream" SortExpression="Stream"/>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"/>
                <asp:BoundField DataField="Deadline" HeaderText="Deadline" SortExpression="Deadline" dataformatstring="{0:d}"/>
            </Columns>
        </asp:GridView>
</p>
<asp:Panel ID="pnlSelectJob" runat="server" Visible="false" BackColor="AliceBlue">
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Hide</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LbtnFavs" runat="server" onclick="LbtnFavs_Click">Add To Favourites</asp:LinkButton>
        <br />
        <br />
        Stream:
        <asp:Label ID="lblStream" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Status:
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <br />
        Company:
        <asp:Label ID="lblCompany" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Location:
        <asp:Label ID="lblLocation" runat="server"></asp:Label>
        <br />
        <br />
        Title:
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
        <br />
        <br />
        Description:<br />
        <asp:Label ID="lblDescription" runat="server"></asp:Label>
        <br />
        <br />
        Skills:
        <asp:BulletedList ID="blSkills" runat="server">
        </asp:BulletedList>
        <br />
        <br />
        Date Posted:
        <asp:Label ID="lblDateposted" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Deadline:
        <asp:Label ID="lblDeadline" runat="server"></asp:Label>
        <br />
        <br />
        Account Manager:
        <asp:Label ID="lblAccMan" runat="server"></asp:Label>
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlAddCom" runat="server" BackColor="AliceBlue" Height="223px" 
            Visible="False">
            <br />
            &nbsp;Comment:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtComment" runat="server" Height="107px" TextMode="MultiLine" 
                Width="804px" Rows="10"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" onclick="btnAdd_Click" Text="Add" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                onclick="btnCancel_Click" />
        </asp:Panel>
    <asp:LinkButton ID="lbtnAddComment" runat="server" onclick="lbtnAddComment_Click" Visible="false">Add Comment</asp:LinkButton>
        <br />
        <asp:Label ID="lblSuccess" runat="server" Text="" 
            CssClass="successNotification"></asp:Label>
        <asp:Label ID="lblError" runat="server" Text="" 
          CssClass="failureNotification"></asp:Label>
        <br />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="cmntTimer" runat="server" Interval="1000" 
            OnTick="cmntTimer_tick" Enabled="False"></asp:Timer>
        <br />
        <asp:GridView ID="gvComments" runat="server"
                      ShowHeader="false" CellPadding="20"
                      GridLines="None" HorizontalAlign="Center"
                      AllowPaging="true" PageSize="20"
                      AutoGenerateColumns="false"
                      OnClientClick="javascript:return confirm('Are you sure to delete this comment?')"
                      onrowdeleting="gvComments_RowDeleting" 
            onrowdatabound="gvComments_RowDataBound">
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
                <asp:BoundField DataField="DateAdded" />
                <asp:BoundField DataField="Text" />
                <asp:BoundField DataField="Username"/>
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
