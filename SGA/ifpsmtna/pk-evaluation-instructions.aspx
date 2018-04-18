<%@ Page Title="" Language="C#" MasterPageFile="~/tnaDesktop.Master" AutoEventWireup="true" CodeBehind="pk-evaluation-instructions.aspx.cs" Inherits="SGA.ifpsmtna.pk_evaluation_instructions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Custom Form -->
		<script type="text/javascript" src="../js/custom-form-elements.js"></script>
		
		<!-- Accordion Menu -->
		<script type="text/javascript" src="../js/jquery.min.js"></script>
		<script type="text/javascript" src="../js/ddaccordion.js"></script>
		<script type="text/javascript" src="../js/ddaccordion-menu.js"></script>
		<!-- Popup -->
		<script type="text/javascript" src="../Scripts/jquery.colorbox.js"></script>
		<script type="text/javascript" src="../js/custom.js"></script>

<script type="text/javascript" language="javascript">
    var alertHtml = '';
    var lastpage = 'n';
    var redirect = 'y';
    function sentBack() {
        window.location.href = '/ifpsmtna/default.aspx';
    }
    function FinalSubmit() {
        $('#colorbox').css({ "display": "none" });
        window.location.href = '/ifpsmtna/procurement-knowledge-evaluation-test.aspx';
    }

    $(document).ready(function () {
        $('.my-profile').colorbox({
            href: "../Popup.aspx",
            width: "392px",
            height: "450px",
            onComplete: function () {
                if (lastpage == 'y') {
                    $('#title').text("Confirmation");
                    if (alertHtml.length > 1) {
                        $('#colorbox').css({ "display": "block" });
                        $('#alertMessage').text(alertHtml);
                        $('#btnCancel').css("display", "block");
                        $('#btnOk').removeClass("btn-yes");
                        $('#btnOk').addClass("btn-back");
                        $('#btnCancel').removeClass("btn-back");
                        $('#btnCancel').addClass("btn-yes");
                    }
                } else {
                    $('#colorbox').css({ "display": "none" });
                    window.location.href = '/ifpsmtna/myprofile.aspx?id=1';
                }
            }
        });

        $('.my-profile').click(function () {
            var value = "<%=directSend %>";
            if (value == 0) {
                // send to profile page
                lastpage = 'n';
            } else {
                // show confirmation
                lastpage = 'y';
                alertHtml = 'You are about to begin your Procurement Benchmark Assessment. Are you ready to begin?';
                //alertHtml = 'You are about to begin your Procurement Benchmark Assessment. This is a timed event and must be taken in a single sitting. Are you ready to begin?';
            }
        });
    });
</script>

<!-- Content Area start -->
				<article id="container">
					<section class="welcome">
						<p class="title40-orange" style="text-align:center;"><asp:Label ID="lblName" runat="server"></asp:Label></p>
						<p class="title40" style="text-align:center;">Welcome to the Procurement Benchmark Assessment</p>
					</section>
					<div class="dot-line">&nbsp;</div>
					<section class="color-box">
						<article class="info-box-shdw-inner">
							<p class="title40">Instructions</p>
							<p>&nbsp;</p>
							<p class="txt16-bold">You are about to complete an evaluation of your knowledge.</p>
							<p>&nbsp;</p>
                            <p>This evaluation focuses on the skills required to perform in procurement and is future-looking in its design. This is the purpose of the benchmark, to prepare ourselves for 2025. So, don't be alarmed if you see themes emerging that are new.</p>
                            <p>&nbsp;</p>
							<p class="txt30">01</p>
							<p>The assessment focuses on seven capability pillar.</p>
							<p>&nbsp;</p>
							<p class="txt16-bold">The 7 capability pillars are:</p>
							<div class="step1">
								<p>1. Relationships & Value</p>
								<p>2. Data, Analysis & Insights</p>
								<p>3. Category Management & Innovation</p>
								<p>4. Business Partnership & Brand</p>
							</div>
							<div class="step2">
								<p>5. Performance & Results</p>
								<p>6. Operate & Negotiate</p>
								<p>7. Sustainability & Ethics</p>
							</div>
                           <div class="clear"></div>
							<hr class="divider-line" />
							<p class="txt30">02</p>
							<p>For each capability pillar, you will be asked nine multiple-choice questions.</p>
							<hr class="divider-line" />
							<p class="txt30">03</p>
							<p>On completion of the evaluation you will have access to your results as a visualisation of your results against the benchmark. You can use your results for your own records – as an evaluation of your knowledge, as it stands today against what may be required of you in the future. Please feel free to click through the various graphs to explore the benchmark data across the world.</p>
							<p>&nbsp;</p>
							<p>&nbsp;</p>
							<div class="floatR">
                            
                            
                            <%--<a href="MyProfile.aspx?id=1"  class="update-profile">UPDATE PROFILE</a>--%>
                            <a id="hylProfile"  runat="server" href="#" class="my-profile">BEGIN NOW</a>
                           </div>
							<div class="clear"></div>
							<p>&nbsp;</p>
							<%--<div class="timed-task">
								<p class="title"><span>THIS IS A<br /><font class="orange">TIMED TASK!</font></span></p>
								<p>&nbsp;</p>
								<p>You are given 60 minutes to complete the evaluation. There are eight sections with nine questions in each. You will see the clock throughout the evaluation in the top right hand side of the page in orange and you are given a guide of your completion progress as you go. </p>
							</div>--%>
						</article>
					</section>
					<div class="dot-line">&nbsp;</div>
				</article>
				<!-- Content Area end // -->
</asp:Content>
