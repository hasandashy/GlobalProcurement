<%@ Page Language="C#" MasterPageFile="~/webadmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PlanAndElearningMapping.aspx.cs" Inherits="SGA.webadmin.PlanAndElearningMapping" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register TagName="left" TagPrefix="sga" Src="~/controls/ctrlLeftMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- SimpleTabs -->
    <link rel="stylesheet" href="css/jquery-ui.css">
<script  src="//code.jquery.com/jquery-1.9.1.js"></script>
<script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
<script>
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
                                    Manage Elearning Plans Mapping
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="tabs">
                                        <ul >
                                            <li><a href="#tabs-3">Procurement Benchmark Assessment Plans Mapping</a></li>
                                            <li><a href="#tabs-1">Skills Self Assessment Management Plans Mapping</a></li>
                                            <li><a href="#tabs-2">Contract Management Plans Mapping</a></li>
                                        </ul>
                                        <div id="tabs-3">
                                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="hd20">
                                                        MANAGE Procurement Benchmark Assessment Plans Mapping
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="pnlCMCList" runat="server">
                                                <tr>
                                                    <td>
                                                        <asp:DataGrid ID="grdCMCSuggestions" runat="server" AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False" CssClass="grdMain" OnItemCommand="grdCMCSuggestions_ItemCommand"
                                                Width="100%" GridLines="None" PageSize="10">
                                                <HeaderStyle CssClass="gridHeader" />
                                                <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                                                <ItemStyle CssClass="gridItem"  />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="User Score" ItemStyle-width="18%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <%#Eval("minPercentage") + "% - "+Eval("maxPercentage")+"%" %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="opportunityAnalysisTopicPlan" HeaderText="Opportunity Analysis<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="maTopicPlan" HeaderText="Market Analysis<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="sdTopicPlan" HeaderText="Strategy Development <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    
                                                    <asp:BoundColumn DataField="meTopicPlan" HeaderText="Market Engagement<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="negotiateTopicPlan" HeaderText="Negotiation <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="ciTopicPlan" HeaderText="Contract Implementation <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="SrmTopicPlan" HeaderText="SRM <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="rsTopicPlan" HeaderText="Strategy Refresh <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    
                                                   
                                                    <asp:TemplateColumn HeaderText="Edit" ItemStyle-width="8%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="iBtnEdit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Id") %>' CommandName="Edit" ImageUrl="~/webadmin/images/edit.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <asp:Panel ID="pnlCMCEdit" runat="server" Visible="false">
                                                <tr>
                                                    <td class="grybox">
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
                                                            <tr>
                                                                <td class="txtrht">
                                                                    User Score
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCMCScore" runat="server" style="font-weight:bold;"></asp:Label>
                                                                </td>
                                                                
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Negotiation Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMCNegPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Supplier Relationship Management Plan
                                                                </td>
                                                                <td>
                                                                     <asp:DropDownList ID="ddlCMCSRMPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Opportunity Analysis Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMCOAPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Refresh Strategy Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMCSRPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Strategy Development Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlCMCSDPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Market Analysis Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlCMCMAPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Market Engagement Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlCMCMEPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Contract Implementation Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlCMCCIPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" >&nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td >
                                                                    <asp:ImageButton ID="imgCMCEdit" runat="server" OnClick="imgCMCEdit_Click" ImageUrl="~/webadmin/images/save.png"  />
                                                                    <asp:ImageButton ID="imgCMCCancel" runat="server" OnClick="imgCMCCancel_Click" ImageUrl="~/webadmin/images/close.png"  CausesValidation="false" />
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                </asp:Panel>
                                            </table>
                                        </div>
                                        <div id="tabs-1">
                                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="hd20">
                                                        MANAGE Procurement Management Plans Mapping
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="pnlSSAList" runat="server">
                                                <tr>
                                                    <td>
                                                        <asp:DataGrid ID="grdSSASuggestions" runat="server" AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False" CssClass="grdMain" OnItemCommand="grdSSASuggestions_ItemCommand"
                                                Width="100%" GridLines="None" PageSize="10">
                                                <HeaderStyle CssClass="gridHeader" />
                                                <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                                                <ItemStyle CssClass="gridItem"  />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="User Score" ItemStyle-width="18%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <%#Eval("minPercentage") + "% - "+Eval("maxPercentage")+"%" %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="opportunityAnalysisTopicPlan" HeaderText="Opportunity Analysis<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="maTopicPlan" HeaderText="Market Analysis<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="sdTopicPlan" HeaderText="Strategy Development <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    
                                                    <asp:BoundColumn DataField="meTopicPlan" HeaderText="Market Engagement<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="negotiateTopicPlan" HeaderText="Negotiate <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="ciTopicPlan" HeaderText="Contract Implementation <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="SrmTopicPlan" HeaderText="SRM <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="rsTopicPlan" HeaderText="Refresh Strategy <br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    
                                                   
                                                    <asp:TemplateColumn HeaderText="Edit" ItemStyle-width="8%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="iBtnEdit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Id") %>' CommandName="Edit" ImageUrl="~/webadmin/images/edit.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <asp:Panel ID="pnlSSAEdit" runat="server" Visible="false">
                                                <tr>
                                                    <td class="grybox">
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
                                                            <tr>
                                                                <td class="txtrht">
                                                                    User Score
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblSSAScore" runat="server" style="font-weight:bold;"></asp:Label>
                                                                </td>
                                                                
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Negotiate Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSSANegPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Supplier Relationship Management Plan
                                                                </td>
                                                                <td>
                                                                     <asp:DropDownList ID="ddlSSASRMPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Opportunity Analysis Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSSAOAPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Strategy Refresh Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSSASRPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Strategy Development Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlSSASDPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Market Analysis Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlSSAMAPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Market Engagement Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlSSAMEPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Contract Implementation Plan
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="ddlSSACIPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" >&nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td >
                                                                    <asp:ImageButton ID="imgSSAEdit" runat="server" OnClick="imgSSAEdit_Click" ImageUrl="~/webadmin/images/save.png"  />
                                                                    <asp:ImageButton ID="imgSSACancel" runat="server" OnClick="imgSSACancel_Click" ImageUrl="~/webadmin/images/close.png"  CausesValidation="false" />
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                </asp:Panel>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="hd20">
                                                        MANAGE Contract Management Plans Mapping
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="pnlCMAList" runat="server">
                                                <tr>
                                                    <td>
                                                        <asp:DataGrid ID="grdCMASuggestions" runat="server" AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False" CssClass="grdMain" OnItemCommand="grdCMASuggestions_ItemCommand"
                                                Width="100%" GridLines="None" PageSize="10">
                                                <HeaderStyle CssClass="gridHeader" />
                                                <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                                                <ItemStyle CssClass="gridItem"  />
                                                <Columns>
                                                    
                                                    <asp:TemplateColumn HeaderText="User Score" ItemStyle-width="18%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <%#Eval("minPercentage") + "% - "+Eval("maxPercentage")+"%" %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="opportunityAnalysisTopicPlan" HeaderText="Planning and Governance<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="maTopicPlan" HeaderText="Measuring Performance<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="sdTopicPlan" HeaderText="Building Relationships<br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    
                                                    <asp:BoundColumn DataField="meTopicPlan" HeaderText="Reviewing Performance<br> Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="negotiateTopicPlan" HeaderText="Sponsor Improvement<br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="ciTopicPlan" HeaderText="Administer Contract<br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="SrmTopicPlan" HeaderText="Managing Risk<br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="rsTopicPlan" HeaderText="Commercial Awareness<br>Topic Plan" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" HeaderStyle-Width="8%" >
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Edit" ItemStyle-width="8%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="iBtnEdit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Id") %>' CommandName="Edit" ImageUrl="~/webadmin/images/edit.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <asp:Panel ID="pnlCMAEdit" runat="server" Visible="false">
                                                <tr>
                                                    <td class="grybox">
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
                                                            <tr>
                                                                <td class="txtrht">
                                                                    User Score
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCMAScore" runat="server" style="font-weight:bold;"></asp:Label>
                                                                </td>
                                                                
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Commercial Awareness Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMACAPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Building Relationships Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMABRPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Planning and Governance Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMAPGPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Sponsor Improvement Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMASIPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Managing Risk Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMAMRPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Measuring Performance Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMAMPPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Reviewing Performance Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMARPPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Administer Contract Plan
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCMAACPlan" runat="server"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" >&nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td >
                                                                    <asp:ImageButton ID="imgCMAEdit" runat="server" OnClick="imgCMAEdit_Click" ImageUrl="~/webadmin/images/save.png"  />
                                                                    <asp:ImageButton ID="imgCMACancel" runat="server" OnClick="imgCMACancel_Click" ImageUrl="~/webadmin/images/close.png"  CausesValidation="false" />
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                </asp:Panel>
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

