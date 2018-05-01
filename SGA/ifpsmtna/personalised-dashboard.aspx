<%@ Page Title="" Language="C#" MasterPageFile="~/tnaDesktopResult.Master" AutoEventWireup="true" CodeBehind="personalised-dashboard.aspx.cs" Inherits="SGA.ifpsmtna.personalised_dashboard" %>
<%@ Register Src="~/controls/cmcPersonilisedDashboard.ascx" TagName="cmcGragh" TagPrefix="sga" %>
<%@ Register Src="~/controls/cmcPersonilisedDashboard2.ascx" TagName="cmcGragh2" TagPrefix="sga2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../js/Chart.min.js"></script>
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/ddaccordion-menu.js"></script>
    <link href="../css/style_old.css" rel="stylesheet" />
    <style>
        nav {width:inherit}
    </style>
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
						<%--<article class="breadcrumb">
							<a href="#">Report Centre</a>&nbsp; &gt; &nbsp;<a href="#">Skills Test Results</a>&nbsp; <span>&gt; &nbsp;Bar Graph</span>
						</article>--%>
						<h3 class="orange">Here are your scores:</h3>
						<div class="my-result-container">							
							<div >								
								<p class="txtCtr">
                                    
                                 <!-- Graph One comes up here -->
                                     <sga:cmcGragh id="graph1" showCompare="0" runat="server"></sga:cmcGragh>

                                 <!-- Graph Two comes up here -->
                                    <sga2:cmcGragh2 id="graph2" showCompare="0" runat="server"></sga2:cmcGragh2>

                              <%--   <!-- Graph Three comes up here -->
                             <h3 id="leader" class="orange">Here is your Leaderboard</h3>

            <div class="dis-block clearfix white-bg pad10 full-height padtop3">

                <div class="dis-block clearfix">
                    <div class="question-number"></div>

                    <div class="tabs">
                        <div class="tab-links">
                            <ul>
                                <li id="seventh" class="active"><a href="#tab7">BY REGION</a></li>
                                <li id="eigth"><a href="#tab8">BY NATION</a></li>
                                <li id="ninth"><a href="#tab9">BY ASSOCIATION</a></li>
                            </ul>
                        </div>



                        <div class=" dis-block clearfix tab-content">

                            <div id="tab7" class="tab active">
                                <div class="question-heading">
                                    <span>In the board below you can see the ranking of user registration by region.
                                    </span>
                                    <div class="redtitle"></div>
                                </div>
                                <div class=" dis-block clearfix pad10">
                                    <div class="strip-heading">
                                        <i>
                                            <img src="../images/map-icon.png" alt=""></i><span>By Region</span>
                                    </div>

                                    <asp:ListView ID="lstRegion" OnItemDataBound="lstRegion_ItemDataBound" runat="server">
                                        <LayoutTemplate>
                                            <div class="dis-block clearfix pad3 light-gray-bg">
                                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                                <div class="clearfix"></div>
                                            </div>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <div class="region-strip">
                                                <div class="region-map">
                                                    <img id="regionImage" runat="server" alt="">
                                                </div>

                                                <div class="region-name-block">
                                                    <div class="region-name"><%# Container.DataItemIndex + 1%>. <%# Eval("countryRegion") %></div>
                                                    <div class="region-user"><%# Eval("nouser") %> users</div>
                                                    <div class="clear"></div>
                                                    <div class="dis-block clearfix progress-top">
                                                        <div class="progress-bar"></div>
                                                        <div class="fill-progress-bar" runat="server" id="progressBar"></div>
                                                    </div>

                                                </div>

                                                <div class="region-bdr"></div>

                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                    <div class="clearfix"></div>

                                </div>






                            </div>

                            <div id="tab8" class="tab">
                                <div class="question-heading">
                                    <span>In the board below you can see the ranking of the number of users who have completed assessments by nation.
                                    </span>
                                    <div class="redtitle"></div>
                                </div>
                                <div class=" dis-block clearfix pad10 nation-leaderboard">
                                    <div class="strip-heading">
                                        <i>
                                            <img src="../images/flag-icon.png" alt=""></i><span>By Nation</span>
                                    </div>


                                    <asp:ListView ID="lstRegionUsers" OnItemDataBound="lstRegionUsers_ItemDataBound" runat="server">
                                        <LayoutTemplate>
                                            <div class="dis-block clearfix pad3 light-gray-bg ">
                                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                            </div>
                                            <div class="clearfix"></div>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <div class="region-strip">
                                                <div class="region-map">
                                                    <img src='<%# "../Images/" + Eval("country").ToString().Replace(" ","-") + ".png" %>' alt="">
                                                </div>

                                                <div class="region-name-block">
                                                    <div class="region-name"><%# Container.DataItemIndex + 1%>. <%#Eval("country")%></div>
                                                    <div class="region-user"><%#Eval("nouser")%> users</div>
                                                    <div class="clear"></div>
                                                    <div class="dis-block clearfix progress-top">
                                                        <div class="progress-bar"></div>
                                                        <div class="fill-progress-bar" id="progressBar" runat="server"></div>
                                                    </div>


                                                </div>

                                                <div class="region-bdr"></div>

                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>



                                </div>

                                <div class="clearfix"></div>


                            </div>

                            <div id="tab9" class="tab">
                                <div class="question-heading">
                                    <span>In the board below you can see the ranking of the number of users who have completed assessments by membership association.
                                    </span>
                                    <div class="redtitle"></div>
                                </div>
                                <div class=" dis-block clearfix pad10 association-tab">
                                    <div class="strip-heading">
                                        <i>
                                            <img src="../images/association-icon.png" alt=""></i><span>Association</span>
                                    </div>
                                    <div class="dis-block clearfix pad3 light-gray-bg">
                                        <div class="association-block">
                                            <div id="membershipName" runat="server"></div>




                                        </div>

                                        <div class="dis-block clearfix center assessments-icon-logo">

                                            <div class="logo-group" runat="server" id="logo2div" visible="false">
                                                <i>
                                                    <img runat="server" id="imglogo2" alt=""></i>
                                                <span>
                                                    <img src="../images/two.png" alt=""></span>
                                            </div>


                                            <div class="logo-group" runat="server" id="logo1div" visible="false">
                                                <i>
                                                    <img runat="server" id="imglogo1" alt=""></i>
                                                <span>
                                                    <img src="../images/one.png" alt=""></span>
                                            </div>

                                            <div class="logo-group" runat="server" id="logo3div" visible="false">
                                                <i>
                                                    <img runat="server" id="imglogo3" alt=""></i>
                                                <span>
                                                    <img src="../images/three.png" alt=""></span>
                                            </div>




                                        </div>






                                        <div class="clearfix"></div>
                                    </div>

                                    <div class="clearfix"></div>

                                </div>







                            </div>

                        </div>
                    </div>

                </div>

            </div>--%>


                                 </p>
								
							</div>
							<div class="clear"></div>
							<p>&nbsp;</p>
						</div>
					</section>
					<div class="dot-line">&nbsp;</div>
				</article>
				<!-- Content Area end // -->
    
</asp:Content>
