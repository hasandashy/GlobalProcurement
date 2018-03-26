<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master"  AutoEventWireup="true" CodeBehind="my-results-bar-graph.aspx.cs" Inherits="SGA.tna.my_results_bar_graph" %>
<%@ Register Src="~/controls/ctrlCMCGraph.ascx" TagName="cmcGragh" TagPrefix="sga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <script type="text/javascript" src="../Scripts/jquery.colorbox.js"></script>
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/ddaccordion-menu.js"></script>--%>
    <div class="dis-block clearfix  marT1 top-space">

<div class="main-heading dis-block clearfix pad15 font18 head-graybg padbottom-none padtop1 marTnone">
<h1>Visualisation<span>of your assessment </span></h1>
</div>
<div class="dis-block clearfix white-bg pad15 full-height padtop3">

<div class="dis-block clearfix">
<div class="question-number">Question 1 of 8</div>

<div class="tabs">
<div class="tab-links">
<ul>
<li class="active"><a href="#tab1">YOUR SCORE</a></li>
<li><a href="#tab2">BY ROLE</a></li>
<li><a href="#tab3">BY SECTOR</a></li>
</ul>
</div>



<div class=" dis-block clearfix tab-content">

<div id="tab1" class="tab active">
<div class="question-heading"><i>01</i> <span>In the graph below you can see your results for each pillar. This provides a visual display of your strengths and development opportunities
</span></div>

<div class="dis-block clearfix  graph"> 
    <%--<sga:cmcGragh id="graph1" showCompare="0" runat="server"></sga:cmcGragh>--%>
    <img src="../images/graph1.jpg" alt="">
</div>
</div>

<div id="tab2" class="tab">
<div class="question-heading"><i>02</i> <span>In the graph below you can see a benchmark of your result against users in the same job role
</span>
<div class="redtitle">Procurement Analyst</div>
</div>

<div class="dis-block clearfix marT3 graph"><img src="../images/graph2.jpg" alt=""></div>
</div>

<div id="tab3" class="tab">
<div class="question-heading"><i>03</i> <span>In the graph below you can see a benchmark of your result against users in the same sector.

</span>
<div class="redtitle">Sector</div>
</div>

<div class="dis-block clearfix marT3 graph"><img src="../images/graph3.jpg" alt=""></div>
</div>

</div>
</div>







</div>

















</div>










<div class="bottom-btn">
<div class="fright blue-btn"><a href="javascript:void(0)" class="rightbt">NEXT >> </a></div>


</div>
</div>

</asp:Content>

