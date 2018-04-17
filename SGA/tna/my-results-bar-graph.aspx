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
<sga:cmcGragh id="graph1" showCompare="0" runat="server"></sga:cmcGragh>


</div>

</asp:Content>

