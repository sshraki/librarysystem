<%@ Page Title="" Language="C#" MasterPageFile="MainMaster.master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="BooksApp.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
               <title></title>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
	<script type="text/javascript">
        function rowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }
    </script>
</telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <br /><br /><br />

          <div style="align-items:center;text-align:center;width:80% !important;margin-left:100px;">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" DataSourceID="usersconnection" 
        HorizontalAlign="Center" Height="300px"
        OnNeedDataSource="RadGrid1_NeedDataSource" 
OnUpdateCommand="RadGrid1_UpdateCommand"
OnItemCreated="RadGrid1_ItemCreated" 
OnDeleteCommand="RadGrid1_DeleteCommand"
OnInsertCommand="RadGrid1_InsertCommand"
OnItemCommand="RadGrid1_ItemCommand" Width="1224px" style="margin-right: 0px" >
        <GroupingSettings CollapseAllTooltip="Collapse all groups">
        </GroupingSettings>
        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" DataSourceID="usersconnection">
            <RowIndicatorColumn ShowNoSortIcon="False" Visible="False">
            </RowIndicatorColumn>
            <ExpandCollapseColumn ShowNoSortIcon="False" Created="True">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="UserName" FilterControlAltText="Filter UserName column" HeaderText="UserName" ShowNoSortIcon="False" SortExpression="UserName" UniqueName="UserName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserPassword" FilterControlAltText="Filter UserPassword column" HeaderText="UserPassword" ShowNoSortIcon="False" SortExpression="UserPassword" UniqueName="UserPassword">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserRole" FilterControlAltText="Filter UserRole column" HeaderText="UserRole" ShowNoSortIcon="False" SortExpression="UserRole" UniqueName="UserRole">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn ShowNoSortIcon="False">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="usersconnection" runat="server" ConnectionString="<%$ ConnectionStrings:BooksConnectionString %>" SelectCommand="SELECT [UserName], [UserPassword], [UserRole] FROM [Users]"></asp:SqlDataSource>
  </div>
</asp:Content>
