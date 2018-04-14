﻿<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="SGA.tna.Leaderboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dis-block clearfix  marT1 top-space">
        <div class="menu-icon">
            <a href="MainMenu.aspx">
                <img src="../images/menu-icon.png" alt=""></a>
        </div>
        <div class="main-heading dis-block clearfix pad15 font18 head-graybg padbottom-none padtop1 marTnone">
            <h1>Leaderboard<span> </span></h1>
        </div>

        <div class="dis-block clearfix white-bg pad10 full-height padtop3">

            <div class="dis-block clearfix">
                <div class="question-number"></div>

                <div class="tabs">
                    <div class="tab-links">
                        <ul>
                            <li class="active"><a href="#tab1">BY REGION</a></li>
                            <li><a href="#tab2">BY NATION</a></li>
                            <li><a href="#tab3">BY ASSOCIATION</a></li>
                        </ul>
                    </div>



                    <div class=" dis-block clearfix tab-content">

                        <div id="tab1" class="tab active">
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

                        <div id="tab2" class="tab">
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
                                                <img src='<%# "../Images/" + Eval("country").ToString().Replace(" ", String.Empty) + ".png" %>' alt="">
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

                        <div id="tab3" class="tab">
                            
<div class=" dis-block clearfix pad10 association-tab">
<div class="strip-heading"><i><img src="../images/association-icon.png" alt=""></i><span>Association</span></div>
<div class="dis-block clearfix pad3 light-gray-bg">
<div class="association-block">
<div ID="membershipName" runat="server"></div>




</div>

<div class="dis-block clearfix center assessments-icon-logo">

<div class="logo-group" runat="server" id="logo2div" visible ="false">
<i><img runat="server" id="imglogo2" alt=""></i>
<span><img src="../images/two.png" alt=""></span>
</div>


<div class="logo-group" runat="server" id="logo1div" visible ="false">
<i><img runat="server" id="imglogo1" alt=""></i>
<span><img src="../images/one.png" alt=""></span>
</div>

<div class="logo-group" runat="server" id="logo3div" visible ="false">
<i><img runat="server" id="imglogo3"  alt=""></i>
<span><img src="../images/three.png" alt=""></span>
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

        </div>


        <%--<div class="bottom-btn">
<div class="fright blue-btn"><a href="my-results-bar-graph-gap.aspx" class="rightbt">NEXT >> </a></div>


</div>--%>
    </div>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('href');

                // Show/Hide Tabs
                jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });



    </script>
</asp:Content>