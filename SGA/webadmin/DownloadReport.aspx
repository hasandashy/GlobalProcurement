<%@ Page Language="C#" MasterPageFile="~/webadmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DownloadReport.aspx.cs" Inherits="SGA.webadmin.DownloadReport" %>
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
                                    Download Reports
                                </td>
                            </tr>
                            <tr>
                            <td class="grybox">
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
                                                            <tr>
                                                                <td class="txtrht">
                                                                    First Name
                                                                </td>
                                                                <td>
                                                                    <input type="text" autocomplete="off" name="txtFname" id="txtFname" runat="server" maxlength="100" />
                                                                </td>
                                                                <td class="txtrht">
                                                                    Last Name
                                                                </td>
                                                                <td>
                                                                    <input type="text" autocomplete="off" name="txtLname" id="txtLname" runat="server" maxlength="100" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Email
                                                                </td>
                                                                <td>
                                                                   <input type="text" autocomplete="off" name="txtEmail" id="txtEmail" runat="server" maxlength="250" />
                                                                </td>
                                                                <td class="txtrht">
                                                                    Company
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCompany" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Assessment Type
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlAssessmentType" runat="server">
                                                                        <asp:ListItem Selected="True" Value="0" >Select Assessment Type</asp:ListItem>
                                                                        <asp:ListItem Value="1" >Procurement Benchmark Assessment</asp:ListItem>
                                                                        <asp:ListItem Value="2" >Procurement Self Assessment</asp:ListItem>
                                                                        <asp:ListItem Value="3" >Behavioural Assessment</asp:ListItem>
                                                                        <asp:ListItem Value="4" >Negotiation Profile</asp:ListItem>
                                                                        <asp:ListItem Value="5" >Department Maturity Profile</asp:ListItem>
                                                                        <asp:ListItem Value="7" >Contract Management Assessment</asp:ListItem>
                                                                        <asp:ListItem Value="13" >Contract Management Knowledge Evaluation</asp:ListItem>
                                                                        <asp:ListItem Value="14" >Contract Management Self Assessment</asp:ListItem>
                                                                        <asp:ListItem Value="6" >CMC - Quartile</asp:ListItem>
                                                                        <asp:ListItem Value="8" >BA - Quartile</asp:ListItem>
                                                                        <asp:ListItem Value="9" >SSA - Quartile</asp:ListItem>
                                                                        <asp:ListItem Value="10" >MP - Quartile</asp:ListItem>
                                                                        <asp:ListItem Value="11" >NP - Quartile</asp:ListItem>
                                                                        <asp:ListItem Value="12" >CMA - Quartile</asp:ListItem>
                                                                    </asp:DropDownList> 
                                                                </td>
                                                                <td class="txtrht">
                                                                    Assessment date
                                                                </td>
                                                                <td>
                                                                    From : 
                                                    <asp:TextBox runat="server" ID="txtFrom" style="width:100px" ></asp:TextBox>
                                                    <asp:ImageButton ID="imgStartdate" runat="server" Height="16px" ImageUrl="~/Images/cal.gif"
                                                        Width="16px" ImageAlign="Bottom" />
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgStartDate"
                                                        TargetControlID="txtFrom" Format="dd/MM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                                    &nbsp;&nbsp;&nbsp;
                                                    To: 
                                                        <asp:TextBox ID="txtTo" runat="server" style="width:100px" ></asp:TextBox>
                                                        <asp:ImageButton ID="imgEndDate" runat="server" Height="16px" ImageUrl="~/Images/cal.gif"
                                                            Width="16px" ImageAlign="Bottom" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="imgEndDate" TargetControlID="txtTo">
                                                        </ajaxToolkit:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtrht">
                                                                    Status
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RadioButton ID="rdoCompleted" GroupName="type" Checked="true" runat="server" />&nbsp;Completed
                                                                    <asp:RadioButton ID="rdoUncomplete" GroupName="type" runat="server" />&nbsp;Uncomplete
                                                                    <asp:RadioButton ID="rdoAll" GroupName="type" runat="server" />&nbsp;All
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
                                                                    <asp:LinkButton ID="btnExport" runat="server" CausesValidation="false" 
                                        Text="Export to Excel" CssClass="rdbut" onclick="btnExport_Click" ></asp:LinkButton>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                    <asp:Table ID="excel" runat="server" BorderStyle="Solid" BorderColor="Red" style="font-size:10px" CellPadding="2" 
                                    CellSpacing="2" GridLines="Both"></asp:Table>
                                </td>
                            </tr>
                            
                    </table>
                    </td>
                </tr>
            </table>
        </td>
</tr>
</asp:Content>


