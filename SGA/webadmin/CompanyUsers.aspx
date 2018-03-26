<%@ Page  Language="C#" MasterPageFile="~/webadmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CompanyUsers.aspx.cs" Inherits="SGA.webadmin.CompanyUsers" %>
<%@ Register TagName="left" TagPrefix="sga" Src="~/controls/ctrlLeftMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<tr>
        <td class="inrbg">
            <table width="1280" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="227" valign="top" class="lftnav">
                        <sga:left id="menu1" runat="server"></sga:left>
                    </td>
                    <td valign="top">
                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0" class="panbox">
                            <tr>
                                <td class="hd26">
                                    Registered company under SGA and No of Users
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
                                                       
                                                        <asp:Button ID="btnUpdateAllTop" runat="server" style="float:right" CausesValidation="false" 
                                                            Text="Update" onclick="btnUpdateAllTop_Click" /><br /><br />
                                                        <asp:DataGrid ID="dtgList" runat="server" AllowPaging="false" AllowSorting="true"
                                                AutoGenerateColumns="False" CssClass="grdMain" OnSortCommand="dtgList_SortCommand" 
                                                Width="100%" GridLines="None" PageSize="20" onitemcommand="dtgList_ItemCommand"  >
                                                <HeaderStyle CssClass="gridHeader" />
                                                <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                                                <ItemStyle CssClass="gridItem"  />
                                                <Columns>
                                                    
                                                    <asp:TemplateColumn SortExpression="company" ItemStyle-Width="40%" HeaderText="Company name" HeaderStyle-Width="40%" >
                                                        <ItemTemplate>
                                                            <input type="text" autocomplete="off" maxlength="250" value='<%#Eval("company") %>' id="txtCompany" style="width:400px" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="noofusers" ReadOnly="true" SortExpression="noofusers" ItemStyle-Width="10%" HeaderText="Total users" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="ApprovedUsers" ReadOnly="true" SortExpression="ApprovedUsers" ItemStyle-Width="10%" HeaderText="Approved users" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="UnApprovedUsers" ReadOnly="true" SortExpression="UnApprovedUsers" ItemStyle-Width="10%" HeaderText="UnApproved users" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="TotalNotLoggedIn" ReadOnly="true" SortExpression="TotalNotLoggedIn" ItemStyle-Width="10%" HeaderText="Not logged in" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="TotalLoggedIn" ReadOnly="true" SortExpression="TotalLoggedIn" ItemStyle-Width="10%" HeaderText="Logged in" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" >
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn ItemStyle-Width="10%" HeaderText="Update" HeaderStyle-Width="10%" >
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%#Eval("company") %>' CommandName="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                                        <br />
                                                        <asp:Button ID="btnUpdateAllBottom" runat="server" CausesValidation="false" style="float:right"  OnClick="btnUpdateAllTop_Click" Text="Update" />
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

