﻿<%@ Page Title="" Language="C#" MasterPageFile="~/tnaDesktop.Master" AutoEventWireup="true" CodeBehind="MyResults.aspx.cs" Inherits="SGA.ifpsmtna.MyResults" %>
<%@ Register Src="~/controls/ctrlUserLeftMenu.ascx" TagName="leftMenu" TagPrefix="sga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/ddaccordion-menu.js"></script>
<script type="text/javascript" src="../js/custom-form-elements-load.js"></script>
<script type="text/javascript" src="../Scripts/jquery.colorbox.js"></script>
<!-- Content Area start -->
				<article id="container">
					<section class="welcome-test">
						<p class="title40 floatL orange">Congratulations! <span class="txt20">You have completed your assessment.</span></p>
						<div class="score-ur">
							<!--<div class="percent">57%</div>
							<div class="content">IS YOUR<br />SCORE</div>-->
							<div class="clear"></div>
						</div>
						<div class="clear"></div>
					</section>
					<div class="dot-line">&nbsp;</div>
					<section class="color-box">
						<article class="test-info-box">
							<p class="title orange">Your  Personalised Dashboard</p>
							<p>&nbsp;</p>
							<p>Your participation in this Global Capability Benchmark gives you the unique insight on how well you perform against your peers. Click through the graphs below to see how you faired against others with the same role, in the same sector, by region, by nation, etc.</p>
						</article>
					</section>
					<section class="my-result-box">
						<article class="breadcrumb">
							<a href="#">Report Centre</a>&nbsp; &gt; &nbsp;<a href="#">Skills Test Results</a>&nbsp; <span>&gt; &nbsp;Reports</span>
						</article>
						<p>&nbsp;</p>
						<p>&nbsp;</p>
						<div class="my-result-container">
							<!-- Left menu will come here -->
                            <sga:leftMenu id="menu1" strLinkType="hylPKE" runat="server" />
							<div class="col-cnt">
								<div class="wide640">
									<p class="txt28 orange mrg-bt-5 floatL">Reports</p>
									
									<div class="clear"></div>
									<p>&nbsp;</p>
									
                                    <asp:Repeater id="rptSgaTest" runat="server" 
                                        onitemdatabound="rptSgaTest_ItemDataBound" 
                                        onitemcommand="rptSgaTest_ItemCommand">
                                        <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
											<td width="40%"><span class="dark">Time stamp</span><br />
                                            
                                            <asp:Label ID="lblConvertedDate" runat="server" ></asp:Label>
                                            <asp:Label ID="lblDate" runat="server" Visible="false"  Text='<%#Eval("testDate")%>' CssClass="adminheader2"></asp:Label>

                                            </td>
											<td width="30%"><span class="dark">Time taken</span><br />
                                            <asp:Label ID="lblTimeTaken" runat="server"></asp:Label>
                                            </td>											
                                            <td width="10%">
                                            <asp:ImageButton ID="ibtnGraph" runat="server" CommandArgument='<%#Eval("testId") %>' CommandName="bar" ImageUrl="~/innerimages/img-graph-icon.gif" />
                                            </td>											
										</tr>
                                        <hr class="divider-line" />
                                        </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
									<p>&nbsp;</p>
									<p>&nbsp;</p>
                                    <div class="floatR">
                                        <asp:Button ID="btnprev" runat="server" OnClick="btnprev_Click" class="btn-save" Text="Back"></asp:Button>
                                        <asp:Button ID="btnnext" runat="server" OnClick="btnnext_Click" class="btn-next" Text="Next"></asp:Button>
                                    </div>
									<p>&nbsp;</p>
								</div>
								<hr class="divider-line" />
								<p>&nbsp;</p>
								
							</div>
							<div class="clear"></div>
							<p>&nbsp;</p>
						</div>
					</section>
					<div class="dot-line">&nbsp;</div>
				</article>
				<!-- Content Area end // -->
                <script type="text/javascript" language="javascript">
                 function StyleRadio() {
                     $('table.styled input:radio').addClass("styled");
                     Custom.init();
                 }
                 var alertHtml = '';
                 var alertTitle = '';

                 $('#sendResult').colorbox({
                     href: "../Popup.aspx",
                     width: "392px",
                     height: "200px",
                     onComplete: function () {
                         $("#title").text(alertTitle);
                         $('#alertMessage').text(alertHtml);
                     }
                 });

                 $('#sendResult').click(function () {
                     var error = 0;
                     var emptyFields = new Array();
                     var specification = "";

                     $("input[name='selectedtest']:checked").each(function () {
                         specification += $(this).val() + ",";
                     });

                     if (specification.length <= 0) {
                         error = 1;
                     }

                     if (error) {
                         $('#colorbox').css({ "display": "block" });
                         alertTitle = 'Please select';
                         alertHtml = 'To have your results sent to you be email, please select the results you would like sent by ticking the \'tick-box\'.';
                     }
                     else {
                         var json =
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "my-results-reports.aspx/EmailResultBack",
                            data: JSON.stringify({ 'testIds': specification }),
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d == 's') {
                                    alertTitle = 'Success!';
                                    $('#colorbox').css({ "display": "block" });
                                    alertHtml = 'Your results have now been sent to you by email. Please check your inbox!';
                                }
                            }
                        });
                     }
                     //$('#colorbox').css({ "display": "block" });
                 });
                 </script>
</asp:Content>

