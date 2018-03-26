﻿<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="ResultDenied.aspx.cs" Inherits="SGA.tna.ResultDenied" %>
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
							
							<div class="clear"></div>
						</div>
						<div class="clear"></div>
					</section>
					<div class="dot-line">&nbsp;</div>
					<section class="color-box">
						<article class="test-info-box">
							<p class="title orange">My Results and Reports</p>
							<p>&nbsp;</p>
							<p><span class="dark">INSTRUCTIONS:</span> Below you will find the results and report for each assessment you have taken. In the left hand column you will note the menu where you can easily navigate. If you would like to access your reports or compare your results, simply navigate through the links. We encourage you to share the 'Negotiation Profile Assessment' since aggregate data from this challenge will provide an important insight into 'Category Management Capability' in Australia. The richer the data - the greater the insights.</p>
						</article>
					</section>
					<section class="my-result-box">
						<article class="breadcrumb">
							<a href="#">Report Centre</a>&nbsp; &gt; &nbsp;<a href="#">Results Restricted</a>
						</article>
						<p>&nbsp;</p>
						<p>&nbsp;</p>
						<div class="my-result-container">
							<!-- Left menu will come here -->
                            <sga:leftMenu id="menu1" strLinkType="" runat="server" />
							<div class="col-cnt">
								<div class="wide640">
									
									<p class="floatR txt14">
                                    
                                    </p>
									<div class="clear"></div>
									<p>&nbsp;</p>
									
                                    <p class="txt28 orange mrg-bt-5">Thank you for completing the assessment. Your results have been saved. </p>
                                    
									<p>&nbsp;</p>
									<p>&nbsp;</p>
                                    
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
				
</asp:Content>