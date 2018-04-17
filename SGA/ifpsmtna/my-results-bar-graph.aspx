<%@ Page Language="C#" MasterPageFile="~/tnaDesktopResult.Master"  AutoEventWireup="true" CodeBehind="my-results-bar-graph.aspx.cs" Inherits="SGA.ifpsmtna.my_results_bar_graph" %>
<%@ Register Src="~/controls/ctrlCMCGraph.ascx" TagName="cmcGragh" TagPrefix="sga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
       header {border-bottom:10px solid #e6e1d6; min-height:129px; padding-top:16px; position:relative}

#logo {width:228px; height:110px; margin:0 auto; text-align:center}
#logo a, #logo a:hover {display:block; width:228px; height:110px; background:url(../innerimages/logo.gif) left top no-repeat; text-decoration:none; text-indent:-999em}

nav {position:absolute; right:34px; top:22px; font-size:12px; color:#231f20; width:inherit}
nav li {float:left; margin-left:12px}
nav li a {color:#231f20 !important; text-decoration:none}
nav li a:hover {color:#ea4320 !important; text-decoration:none}
/* Footer */
footer {padding:18px 0; position:relative}
#footer-logo {margin:0 auto; width:158px; height:50px; text-align:center; font-size:10px}
#footer-logo a, #footer-logo a:hover {display:block; width:158px; height:50px; background:url(../innerimages/logo-footer.gif) top left no-repeat; text-decoration:none; text-indent:-999em}
.powered {position:absolute; top:18px; right:55px; font-family:Arial, Helvetica, sans-serif; font-size:14px; color:#58595b; text-align:right; line-height:50px}
/* -- -- -- -- */
    </style>
    <div class="dis-block clearfix  marT1 top-space">

<div class="main-heading dis-block clearfix pad15 font18 head-graybg padbottom-none padtop1 marTnone">
<h1>Visualisation<span>of your assessment </span></h1>
</div>
<sga:cmcGragh id="graph1" showCompare="0" runat="server"></sga:cmcGragh>

</div>

</asp:Content>

