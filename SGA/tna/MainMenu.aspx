<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="SGA.tna.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="heading-wrapper">
<h1><asp:Label ID="lblName" runat="server"></asp:Label></h1>


</div>


<div class="dis-block clearfix  top-space">

<div class="dis-block clearfix main-link">
<ul>
<li><a href="MyProfile.aspx?source=menu"><i><img src="../images/usericon.png" alt=""></i>My Profile</a></li>
<li><a href="default.aspx"><i><img src="../images/assessments-icon.png" alt=""></i>My Assessments</a></li>
<li><a href="my-results.aspx"><i><img src="../images/result-icon.png" alt=""></i>My Results</a></li>
<li><a href="Leaderboard.aspx"><i><img src="../images/leaderboard-icon.png" alt=""></i>Leaderboard</a></li>
    <li><a href="https://comprara.atlassian.net/servicedesk/customer/portal/5" target="_blank"><i><img src="../Images/helpicon.png" alt=""></i>Help</a></li>
    <li><a href="https://gn231.infusionsoft.com/app/form/352ae51ac9194655d7be91f0aea45ec6" target="_blank"><i><img src="../Images/contactusicon.png" alt="" ></i>Contact Us</a></li>

    <li><asp:LinkButton ID="lnkLogout" runat="server" CausesValidation="false" onclick="lnkLogout_Click"  ><i><img src="../images/logout-icon.png" alt=""></i>Logout</asp:LinkButton></li>

</ul>
</div>




<div class="pasia-logo"><img src="../images/pasia-logo2.png" alt=""></div>






</div>
</asp:Content>
