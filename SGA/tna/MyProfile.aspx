<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SGA.tna.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="dis-block clearfix  marT1 top-space">

        <div class="main-heading dis-block clearfix pad15 font18 head-graybg padbottom-none padtop1 marTnone">

            <h1>Member Information<span>(Just so we can finalise your results) </span></h1>
        </div>


        <div class="dis-block clearfix white-bg pad15 full-height ">

            <div class="dis-block clearfix">

                <div class="dis-block clearfix member-info">
                    <span class="title">About your procurement function</span>
                    <ul>
                        <li><a href="ProfileDetails.aspx?id=1" runat="server" id="procModel">Procurement model</a></li>
                        <li><a href="ProfileDetails.aspx?id=2" runat="server" id="reportingLine">Reporting line</a></li>
                        <li><a href="ProfileDetails.aspx?id=3" runat="server" id="spenUnderInfluence">Spend under influence</a></li>
                        <li><a href="ProfileDetails.aspx?id=4" runat="server" id="numberOfEmp">Number of employees</a></li>
                        <li><a href="ProfileDetails.aspx?id=5" runat="server" id="sector">Sector</a></li>
                    </ul>
                </div>



                <div class="dis-block clearfix member-info">
                    <span class="title dis-block clearfix">About you</span>
                    <ul>
                        <li><a href="ProfileDetails.aspx?id=6" runat="server" id="jobRole">Role best described as:</a></li>
                        <li><a href="ProfileDetails.aspx?id=7" runat="server" id="category">Category you manage currently</a></li>
                        <li><a href="ProfileDetails.aspx?id=8" runat="server" id="spendUnderYour">Spend under your influence</a></li>
                        <li><a href="ProfileDetails.aspx?id=9" runat="server" id="geoInfluence">Geographical influence</a></li>
                        <li><a href="ProfileDetails.aspx?id=10" runat="server" id="exp">Years of procurement experience</a></li>
                        <li><a href="ProfileDetails.aspx?id=11" runat="server" id="procQual">Procurement qualifications</a></li>
                        <li><a href="ProfileDetails.aspx?id=12" runat="server" id="edu">Level of Education</a></li>
                        <li><a href="ProfileDetails.aspx?id=13" runat="server" id="prevExp">Your previous category experience</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="bottom-btn">
            <div class="fright blue-btn"><a href="Association.aspx" class="rightbt">Next >> </a></div>
        </div>
    </div>
</asp:Content>

