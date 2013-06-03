<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TrainerWebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
     
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome <%= username %>
    </h2>

    <h3>
        Recent Jobs</h3>
    <p>
        To view more details about the job press Select.
        </p>

    <p>
    <asp:ScriptManager ID="RecentsScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:GridView ID="gvRecentJobs" runat="server"
                    autogenerateselectbutton="True"
                    selectedindex="-1" 
                    onselectedindexchanged="gvRecentJobs_SelectedIndexChanged"
                    HorizontalAlign="Center"
                    CellPadding="5"
                    AutoGenerateColumns="false"
                    AllowSorting="true" 
                    AllowPaging="true" PageSize="5" onsorting="gvRecentJobs_Sorting"
                    OnPageIndexChanging="gvRecentJobs_PageIndexChanging">
            <SelectedRowStyle BackColor="#B2D1B2" Font-Bold="true" ForeColor="GhostWhite" />
            <AlternatingRowStyle BackColor="AliceBlue" ForeColor="Black" />
            <RowStyle BackColor="GhostWhite" ForeColor="Black" />
            <HeaderStyle BackColor="CornflowerBlue" Font-Bold="true" ForeColor="GhostWhite" />
            <Columns>
                <asp:BoundField DataField="DatePosted" HeaderText="Date Posted" SortExpression="DatePosted" dataformatstring="{0:d}"/> 
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
                <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company"/> 
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location"/>
                <asp:BoundField DataField="Stream" HeaderText="Stream"/>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"/>
                <asp:BoundField DataField="Deadline" HeaderText="Deadline" SortExpression="Deadline" dataformatstring="{0:d}"/>
            </Columns>
        </asp:GridView>
    </p>
    <p>

    </p>
    <asp:Panel ID="pnlSelectJob" runat="server" Visible="false" BackColor="AliceBlue">
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Hide</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="recsLBTN" runat="server" onclick="recsLBTN_Click">Recommend Consultant</asp:LinkButton>
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
        DatePosted:
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
            <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" />
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
