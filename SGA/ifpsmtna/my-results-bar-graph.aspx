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
							<p class="title orange">My Results and Reports</p>
							<p>&nbsp;</p>
							<p><span class="dark">INSTRUCTIONS:</span> Below you will find the result for the assessment you have taken. In the left hand column you will note the menu where you can easily navigate. If you would like to access your reports or compare your results, simply navigate through the links.</p>
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

