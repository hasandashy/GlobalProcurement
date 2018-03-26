<%@ Page  Language="C#" MasterPageFile="~/webadmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PeerReviewRequests.aspx.cs" Inherits="SGA.webadmin.PeerReviewRequests" %>
<%@ Register TagName="left" TagPrefix="sga" Src="~/controls/ctrlLeftMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<tr>
        <td class="inrbg">
            <table width="1280" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="227" valign="top" class="lftnav">
                        <sga:left id="menu1" runat="server"></sga:left>
                    </td>
                    <td width="1053" valign="top">
                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0" class="panbox">
                            <tr>
                                <td class="hd26">
                                    Peer Review Request List
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        
                                                        <asp:DataGrid ID="dtgList" runat="server" AllowPaging="false" AllowSorting="true"
                                                        AutoGenerateColumns="False" CssClass="grdMain" OnItemCommand="dtgList_ItemCommand" OnSortCommand="dtgList_SortCommand"
                                                        Width="100%" GridLines="None" PageSize="20">
                                                        <HeaderStyle CssClass="gridHeader" />
                                                        <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                                                        <ItemStyle CssClass="gridItem"  />
                                                        <Columns>
                                                           <asp:TemplateColumn SortExpression="requestedEmail" ItemStyle-Width="18%" HeaderText="Request By" HeaderStyle-Width="18%" >
                                                                <ItemTemplate>
                                                                    <%#Eval("requestedEmail") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="firstname" SortExpression="firstname" ItemStyle-Width="10%" HeaderText="Manager<br>First name" HeaderStyle-Width="10%" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="lastname" SortExpression="lastname" ItemStyle-Width="10%" HeaderText="Manager<br>Last name" HeaderStyle-Width="10%" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="email" SortExpression="email" ItemStyle-Width="15%" HeaderText="Manager<br>Email" HeaderStyle-Width="15%" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="relationship" SortExpression="relationship" ItemStyle-Width="15%" HeaderText="Relationship" HeaderStyle-Width="15%" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="insDt" SortExpression="insDt" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" HeaderText="Requested<br>On" HeaderStyle-Width="15%" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="marks" SortExpression="marks" ItemStyle-Width="8%" HeaderText="Marks" HeaderStyle-Width="8%" ></asp:BoundColumn>
                                                            <asp:TemplateColumn ItemStyle-Width="20%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="iBtnEdit" runat="server" CausesValidation="false" AlternateText="View/Edit" style="height:25px;width:25px;" CommandArgument='<%#Eval("emaillink") %>' CommandName="Edit" ToolTip="Edit" ImageUrl="~/webadmin/images/edit.png" />
                                                                    <asp:ImageButton ID="iBtnDelete" runat="server" CausesValidation="false" AlternateText="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete this request ?');"  style="height:25px;width:25px;" CommandArgument='<%#Eval("emaillink") %>' CommandName="Delete" ToolTip="Delete" ImageUrl="images/disapprove_icon.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                   
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                
                                            </table>
 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</asp:Content>


