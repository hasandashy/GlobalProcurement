<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Reset_Password.aspx.cs" Inherits="SGA.Reset_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form class="infusion-form-reset" id="infusion-form-reset">
        <span class="dotline top1 bdrt1"></span>

        <div class="container ">
            <div class="heading two-line  marT50 marB50">
                <h2><span>Reset Password</span></h2>
                <span>To reset your or password, enter the required details. You will receive a system-generated email with further instructions to complete the password reset.</span>
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
                                           <asp:Label ID="lblErrorReset" ClientIDMode="Static" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <input required class="form-control" id="inf_field_Email" maxlength="250" name="inf_field_Email" type="text" placeholder="Email *" autocomplete="off" />
                                    </div>
                                   
                                    <div class="form-group register-btn">
                                        <input type="submit" id="restpassword" class="btn custom-btn" value="Go" />
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
