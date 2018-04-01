<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SGA.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form class="infusion-form-login" id="infusion-form-login">
        <span class="dotline top1 bdrt1"></span>

        <div class="container ">
            <div class="heading two-line  marT50 marB50">
                <h2>Login to <span>Global Procurement Capability Benchmark</span></h2>
            </div>
        </div>
        <!-- Content Area start // -->
        <div>

            <div class="faq-page">

                <div class="clear"></div>
                <div class="dot-line">&nbsp;</div>


                <!-- Banner end // -->
                <!-- Content Area start -->
                <div class="block1 greybg padtop-none full-graybg ">
                    <div class="container ">

                      
                        <div class="info-block exchange1 ">
                            <div class="audit-form">
                               
                                <div class="dis_block clearfix">
                                    <div class="form-group" style="text-align:center;">
                                           <asp:Label ID="lblErrorLogin" ClientIDMode="Static" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <input required class="form-control" id="inf_field_UserName" maxlength="250" name="inf_field_UserName" type="text" placeholder="Username *" />
                                    </div>
                                    <div class="form-group">
                                        <input required class="form-control" id="inf_field_Password" maxlength="250" name="inf_field_Password" type="password" placeholder="Password *" />
                                    </div>
                                    <div class="form-group">
                                        <div class="g-recaptcha" data-sitekey="6LcmizoUAAAAAEaosP0r9KGtp_HjPZYSc74w295V"></div>
                                    </div>
                                    <div class="form-group">
                                        <a href="Reset_Password.aspx">Forgot Your Password?</a>
                                    </div>


                                    <div class="form-group register-btn">
                                        <input type="submit" id="homehide" class="btn custom-btn" value="Go" />
                                    </div>
                                </div>
                            </div>



                        </div>


                    </div>



                </div>
                <!-- Content Area end // -->

                <div class="clear"></div>
                <div class="dot-line">&nbsp;</div>


            </div>
        </div>

    </form>
</asp:Content>
