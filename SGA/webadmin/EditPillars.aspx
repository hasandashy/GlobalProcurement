<%@ Page Title="" Language="C#" MasterPageFile="~/webadmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditPillars.aspx.cs" Inherits="SGA.webadmin.EditPillars" %>
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
                                    Edit Pillar
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
                                                        <asp:HiddenField ID="imgExg" runat="server" />
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
  
  <tr>
        <td class="grybox">
        
        <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
  <tr>
    <td class="txtrht">Thoughts</td>
    <td><asp:TextBox ID="txtTitle" runat="server" MaxLength="1000" TextMode="MultiLine" CssClass="txtBig"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="*" SetFocusOnError="true" ></asp:RequiredFieldValidator></td>
    
  </tr>
            <tr>
    <td class="txtrht">Existing Image</td>
    <td>
        <asp:Image ID="imgQuotes" Height="80" Width="80" runat="server"></asp:Image>
                                    </td>
    
  </tr>
  <tr>
    <td class="txtrht">Upload New</td>
    <td><asp:FileUpload ID="txtImage" runat="server" />
                                    </td>
    
  </tr>
  
  <tr>
    <td></td>
    <td>&nbsp;</td>
  </tr>
  
  <tr>
    
    <td colspan="2" align="center">
    <asp:ImageButton ID="iBtnSave" runat="server" ImageUrl="images/save.png" 
            AlternateText="Save" width="96" height="37" onclick="iBtnSave_Click" />
    <a href="ManageAssessmentPillars.aspx"><img src="images/close.png" width="96" height="37" alt="" /></a></td>
    
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
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</asp:Content>
