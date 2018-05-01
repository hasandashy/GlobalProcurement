<%@ Page Language="C#" MasterPageFile="~/tnaDesktopResult.Master"  AutoEventWireup="true" CodeBehind="my-results-bar-graph.aspx.cs" Inherits="SGA.ifpsmtna.my_results_bar_graph" %>
<%@ Register Src="~/controls/ctrlDesktopCMCGraph.ascx" TagName="cmcGragh" TagPrefix="sga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/Chart.min.js"></script>
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/ddaccordion-menu.js"></script>
    <link href="../css/style_old.css" rel="stylesheet" />
    <style>
        nav {width:inherit}
    </style>
<!-- Content Area start -->
				<article>
					<section class="welcome-test">
						<p class="title40 floatL orange">Congratulations! <span class="txt20">You have completed your assessment.</span></p>
						
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
							<a href="#">Report Centre</a>&nbsp; &gt; &nbsp;<a href="#">Skills Test Results</a>&nbsp; <span>&gt; &nbsp;Bar Graph</span>
						</article>
						<p>&nbsp;</p>
						<p>&nbsp;</p>
						<div class="my-result-container">
							<div class="col-lft">
								<p class="title18"><span id="spCategory" runat="server">Procurement Knowledge Evaluation</span></p>
								<% if(isSgaResult) { %>
								<div class="acrd-menu">
									<p><a href="#" class="menuitem submenuheader">Display Results</a></p>
									<div class="submenu">
										<ul>
											<li><a href="my-results-bar-graph.aspx" class="active">&bull; Bar Graph</a></li>
										</ul>
									</div>
									
									
								</div>
                                <% } else { %>
                                <div class="result-info icon-score">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
								
                                   
							</div>
							<div class="col-cnt">								
								<p class="txtCtr">
                                    <h3 class="orange">Here are your scores:</h3>
                                 <!-- Graph comes up here -->
                                 <sga:cmcGragh id="graph1" showCompare="0" runat="server"></sga:cmcGragh>
                                 </p>
								<p>&nbsp;</p>
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
</asp:Content>

