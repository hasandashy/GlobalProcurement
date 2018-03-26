<%@ Page Language="C#" MasterPageFile="~/webadmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSubdomains.aspx.cs" Inherits="SGA.webadmin.ManageSubdomains" %>
<%@ Register TagName="left" TagPrefix="sga" Src="~/controls/ctrlLeftMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- SimpleTabs -->
    <link rel="stylesheet" href="css/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.9.1.js"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link rel="Stylesheet" href="css/thickbox.css" />
    <script src="js/thickbox.js"></script>
    <script type="text/javascript" language="javascript" >
        
        var selected_tab = 1;
        $(function () {
            var tabs = $("#tabs").tabs({
                activate: function (event, ui) {
                    //alert(ui.newTab.index());
                    selected_tab = ui.newTab.index();
                }
            });
            selected_tab = $("[id$=selected_tab]").val() != "" ? parseInt($("[id$=selected_tab]").val()) : 0;
            //alert(selected_tab);
            tabs.tabs("option", "active", selected_tab);

            $("form").submit(function () {
                $("[id$=selected_tab]").val(selected_tab);
            });


            $('.pager a,.gridHeader a,.gridHeaderASC a,.gridHeaderSortDESC a').click(function () {
                $("[id$=selected_tab]").val(selected_tab);
            });
        });
    </script>
 <asp:HiddenField ID="selected_tab" runat="server" />
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
                                    Manage Sub Domains
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">View Sub-domains</a></li>
                                            <li><a href="#tabs-2">Add/Edit Sub-domains </a></li>
                                        </ul>
                                        <div id="tabs-1">
                                             <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="hd20">
                                                        SUB DOMAINS LIST
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td >
                                                    &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td >
                                                            <asp:DataGrid ID="grdUsers" runat="server" AllowPaging="True" AllowSorting="false"
                                                AutoGenerateColumns="False" CssClass="grdMain" 
                                                OnItemDataBound="grdUsers_ItemDataBound" OnPageIndexChanged="grdUsers_PageIndexChanged"  OnItemCommand="grdUsers_ItemCommand"
                                                Width="100%" GridLines="None" PageSize="75">
                                                <HeaderStyle CssClass="gridHeader" />
                                                <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                                                <ItemStyle CssClass="gridItem"  />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="Sub domain"  ItemStyle-width="20%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                               <asp:Label ID="lblSubdomainUrl" runat="server"></asp:Label><%# Eval("urlSuffix") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Logo"  ItemStyle-width="30%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%">
                                                        <ItemTemplate>
                                                               <img style="width:100px;height:80px" id="imgLogo" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                     <asp:TemplateColumn HeaderText="Infusionsoft code"  ItemStyle-width="10%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                               <%#Eval("ISCode") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Button hexcode"  ItemStyle-width="12%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="12%">
                                                        <ItemTemplate>
                                                               <%#"#"+Eval("hexCode") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Create On"  ItemStyle-width="14%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="14%">
                                                        <ItemTemplate>
                                                               <%#Eval("insDt") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Action" ItemStyle-width="10%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="iBtnEdit" runat="server" CausesValidation="false" AlternateText="Edit"  CommandArgument='<%#Eval("Id") %>' CommandName="edit" ToolTip="Edit" ImageUrl="~/webadmin/images/edit.png" />&nbsp;
                                                            <asp:ImageButton ID="iBtnDelete" runat="server" CausesValidation="false" AlternateText="Delete" OnClientClick="return confirm('Are you sure you want to delete this subdomain?');" CommandArgument='<%#Eval("Id") %>' CommandName="delete" ToolTip="Delete" ImageUrl="~/webadmin/images/disapprove_icon.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="hd20">
                                                        ADD/EDIT SUB DOMAINS
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="grybox">
        
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
                                                             <tr>
                                                                 <td class="txtrht">Upload logo</td>
                                                                 <td><asp:FileUpload ID="fleCatalogImage" ValidationGroup="add" runat="server" />
                                                                     <asp:RequiredFieldValidator ID="rfvLogo" runat="server" SetFocusOnError="true" CssClass="error" ControlToValidate="fleCatalogImage" ValidationGroup="add" Text="*"></asp:RequiredFieldValidator>       
                                                                     <asp:RegularExpressionValidator ID="revCatalogImage" ValidationGroup="add" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
    ControlToValidate="fleCatalogImage" runat="server" ForeColor="Red" ErrorMessage="Please select a valid Image file type."
    Display="Dynamic" />
                                                                            <br />
                                                                            <asp:Image ID="imgProduct" runat="server" Visible="false" />
                                                                            <asp:HiddenField ID="hdimageUrl" runat="server" />
                                                                 </td>
                                                                 <td class="txtrht">Hexcode</td>
                                                                 <td>#<input type="text" autocomplete="off" name="txtHexcode" ValidationGroup="add" id="txtHexcode" runat="server" maxlength="6" />
                                                                    <asp:RequiredFieldValidator ID="rfvHexcode" runat="server" SetFocusOnError="true" CssClass="error" ControlToValidate="txtHexcode" ValidationGroup="add" Text="*"></asp:RequiredFieldValidator>
                                                                 </td>
                                                             </tr>
                                                            <tr>
                                                                    <td valign="top" class="txtrht">Infusionsoft tag code</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtISCode" runat="server" TextMode="SingleLine" ValidationGroup="add" MaxLength="20" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvISCode" runat="server" SetFocusOnError="true" CssClass="error" ControlToValidate="txtISCode" ValidationGroup="add" Text="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" class="txtrht">Paragraph Text</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtParagraph" runat="server" TextMode="MultiLine" ValidationGroup="add" Rows="10" Columns="100"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvParagraph" runat="server" SetFocusOnError="true" CssClass="error" ControlToValidate="txtParagraph" ValidationGroup="add" Text="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                             <tr>
                                                                    <td class="txtrht">SubDomain url</td>
                                                                    <td colspan="3">
                                                                        <asp:Label ID="lblSubdomainUrl" runat="server"></asp:Label>
                                                                        <asp:TextBox ID="txtSubdomainUrl" runat="server" TextMode="SingleLine" MaxLength="100" ValidationGroup="add" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvSubdomainUrl" runat="server" SetFocusOnError="true" CssClass="error" ControlToValidate="txtSubdomainUrl" ValidationGroup="add" Text="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
                        </td>
                        </tr>
  
  <tr>
    
    <td colspan="4" align="center">
    <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/webadmin/images/save.png" OnClick="imgSave_Click" CommandArgument="0" ValidationGroup="add" /></td>
    
  </tr>
                                                        </table>
                                                        </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</asp:Content>
