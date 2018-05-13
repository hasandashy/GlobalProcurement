<%@ Page Title="" Language="C#" MasterPageFile="~/tnaDesktopResult.Master" AutoEventWireup="true" CodeBehind="Leadership.aspx.cs" Inherits="SGA.ifpsmtna.Leadership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/style_old.css" rel="stylesheet" />
    <style>
        nav {
            width: inherit;
        }
    </style>
    <article>
        <section class="welcome-test">
            <p class="title40 floatL orange"></p>

            <div class="clear"></div>
        </section>
        <div class="dot-line">&nbsp;</div>
        <section class="color-box">
            <article class="test-info-box">
                <p class="title orange">Leaderboard</p>
            </article>
        </section>
        <div class="dis-block clearfix  marT1 top-space">
            <div class="menu-icon">
            </div>


            <div class="dis-block clearfix white-bg pad10 full-height padtop3">

                <div class="dis-block clearfix">
                    <div class="question-number"></div>

                    <div class="tabs">
                        <div class="tab-links">
                            <ul>
                                <li id="first" class="active"><a href="#tab1">BY REGION</a></li>
                                <li id="second"><a href="#tab2">BY NATION</a></li>
                                <li id="third"><a href="#tab3">BY ASSOCIATION</a></li>
                            </ul>
                        </div>



                        <div class=" dis-block clearfix tab-content">

                            <div id="tab1" class="tab active">
                                <div class="question-heading">
                                    <span>Participants by Region
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
                                                    <div class="region-user"><%# Eval("nouserperc") %> %</div>
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
                                <div class="question-heading">
                                    <span>Participants by Nation
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
                                                    <div class="region-user"><%#Eval("nouserperc")%> %</div>
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
                                <div class="question-heading">
                                    <span>Participants by membership association
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
                                                    <img runat="server" id="imglogo2" alt="" width="90" height="90"></i>
                                                <span>
                                                    <img src="../images/two.png" alt=""></span>
                                            </div>


                                            <div class="logo-group" runat="server" id="logo1div" visible="false">
                                                <i>
                                                    <img runat="server" id="imglogo1" alt="" width="90" height="90"></i>
                                                <span>
                                                    <img src="../images/one.png" alt=""></span>
                                            </div>

                                            <div class="logo-group" runat="server" id="logo3div" visible="false">
                                                <i>
                                                    <img runat="server" id="imglogo3" alt="" width="90" height="90"></i>
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

            </div>


            <div>
                <div class="fleft">
                   <asp:Button ID="leftbt" ClientIDMode="Static" attr-val="#tab1" runat="server" Text="Back" CssClass="btn-next" />
                </div>
                <div class="fright"> <asp:Button ClientIDMode="Static" ID="rightbt" attr-val="#tab1" runat="server" Text="Next" CssClass="btn-next" /></div>
            </div>
        </div>
        <div class="dot-line">&nbsp;</div>
    </article>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            $('#leftbt').hide();
            jQuery('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('href');
                jQuery('#rightbt').attr('attr-val', currentAttrValue);
                jQuery('#leftbt').attr('attr-val', currentAttrValue);
                // Show/Hide Tabs
                jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');
                if (currentAttrValue === '#tab1') {
                    $('#leftbt').hide();
                    $('#rightbt').show();
                }

                if (currentAttrValue === '#tab2') {
                    $('#leftbt').show();
                    $('#rightbt').show();
                }

                if (currentAttrValue === '#tab3') {
                    $('#leftbt').show();
                    $('#rightbt').hide();
                }
                e.preventDefault();
            });

            //next btn click
            jQuery('#rightbt').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('attr-val');

                // Change/remove current tab to active
                jQuery('.tabs .tab-links a').parent('li').siblings().removeClass('active');

                if (currentAttrValue == '#tab1') {
                    $('#leftbt').show();
                    $('#rightbt').show();
                    jQuery(this).attr('attr-val', '#tab2');
                    jQuery('#leftbt').attr('attr-val', '#tab2');
                    jQuery('.tabs ' + '#tab2').show().siblings().hide();
                    jQuery('#second').addClass('active')
                }
                if (currentAttrValue == '#tab2') {
                    $('#leftbt').show();
                    $('#rightbt').hide();
                    jQuery(this).attr('attr-val', '#tab3');
                    jQuery('#leftbt').attr('attr-val', '#tab3');
                    jQuery('.tabs ' + '#tab3').show().siblings().hide();
                    jQuery('#third').addClass('active')

                }
                if (currentAttrValue == '#tab3') {
                    $('#rightbt').hide();
                    $('#leftbt').show();
                }

                // Show/Hide Tabs
                e.preventDefault();


            });


            //back btn click
            jQuery('#leftbt').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('attr-val');

                // Change/remove current tab to active
                jQuery('.tabs .tab-links a').parent('li').siblings().removeClass('active');

                if (currentAttrValue == '#tab1') {
                    $('#leftbt').hide();
                    $('#rightbt').show();
                }
                if (currentAttrValue == '#tab2') {
                    $('#leftbt').hide();
                    $('#rightbt').show();
                    jQuery(this).attr('attr-val', '#tab1');
                    jQuery('#rightbt').attr('attr-val', '#tab1');
                    jQuery('.tabs ' + '#tab1').show().siblings().hide();
                    jQuery('#first').addClass('active')
                }
                if (currentAttrValue == '#tab3') {
                    $('#leftbt').show();
                    $('#rightbt').show();
                    jQuery(this).attr('attr-val', '#tab2');
                    jQuery('#rightbt').attr('attr-val', '#tab2');
                    jQuery('.tabs ' + '#tab2').show().siblings().hide();
                    jQuery('#second').addClass('active')
                }
                e.preventDefault();
            });
        });



    </script>
</asp:Content>
