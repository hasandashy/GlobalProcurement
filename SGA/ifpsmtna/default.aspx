<%@ Page Language="C#" MasterPageFile="~/tnaDesktop.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SGA.ifpsmtna._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <!-- Popup -->
    <script type="text/javascript" src="../Scripts/jquery.colorbox-1.6.4.js"></script>
    <script type="text/javascript" language="javascript">

        function gup(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
			    results = regex.exec(location.search);
            return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
        var buyId = gup("id");
        var alertHtml = '';
        var lastpage = 'n';
        var redirect = 'y';

        $(document).ready(function () {
            if (buyId == 1) {
                $('#colorbox').css({ "display": "block" });

                alertHtml = "Thank you for your purchase! Your assessment(s) is now unlocked.";
                //$.colorbox({ href: "../Popup.aspx" });
                $.colorbox({
                    href: "../Popup.aspx",
                    width: "302px",
                    height: "170px",
                    onComplete: function () {
                        redirect = "n";
                        $('#colorbox').css({ "display": "block" });
                        $('#alertMessage').html(alertHtml);
                    }
                });
            }

        });
    </script>
    <style>
        *:focus {
            outline: 0;
        }
    </style>
    <article id="container">
        <section class="welcome">
            <p class="title40-orange">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </p>
            <p class="title40">Your Assessment</p>
            <p>Below you will see the assessment that you currently have access to. By clicking 'go' against each assessment, you will be directed to that particular assessment. First, you will reach an information page regarding the assessment you are about to undertake. If you see a lock symbol, this is because you do not yet have access to this assessment. Once access is granted, this assessment will be unlocked and you will be able to access it.</p>
        </section>
        <div class="dot-line">&nbsp;</div>
        <section class="color-box">
            <article class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/img-category-management-challenge.gif" alt="Procurement Benchmark Assessment" />
                </div>
                <div class="head">Procurement Benchmark Assessment</div>
                <div class="desc">This assessment balances a forward looking approach to procurement with current expectations. You will be asked to complete 9 questions across 7 Pillars of Capability.  Allow for at least one–hour to complete it.</div>
                <div class="info">
                    <asp:HyperLink ID="hylSga" runat="server"></asp:HyperLink>
                </div>
                <div class="clear"></div>
            </article>


            <article class="info-box-shdw">
                <div class="desc" style="width: 700px;">
                    <div style="text-align: center; font-weight: bold;">Other paid assessments offered by SkillsGAP Analysis are listed below.</div>
                    <div style="text-align: center;">To find out more simply select from the list below and click</div>
                    <div style="text-align: center;">“LET”S TALK” and we will be in touch.</div>
                </div>
                <div class="info">
                    <asp:HyperLink ID="hylLetsTalk" ClientIDMode="Static" Style="width: 135px; float: right;" CssClass="my-profile" Text="Lets Talk" runat="server"></asp:HyperLink>
                </div>
                <div class="clear"></div>
            </article>
            <article class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/img-category-management-challenge.gif" alt="Procurement Knowledge Evaluation" /></div>
                <div class="head">Procurement Knowledge Evaluation</div>
                <div class="desc">This assessment focuses on the skills required to perform procurement. It focuses on eight dimensions typically used in an end-to-end procurement process. For each dimension you will be asked nine questions.</div>
                <div class="info">
                    <asp:CheckBox ID="chkPKE" ClientIDMode="Static" runat="server" AutoPostBack="false" />
                </div>
                <div class="clear"></div>
            </article>
            <article class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/img-skills-self-assessment.gif" alt="Procurement - Technical Self Assessment" /></div>
                <div class="head"><%--Skills Self Assessment--%>Procurement Technical Self Assessment</div>
                <div class="desc">This is a self-evaluation of your procurement skills. You will be guided through the eight phases of the complete category management process as you assess yourself on 72 pivotal procurement skills.</div>
                <div class="info">
                    <asp:CheckBox ID="chkPTSA" ClientIDMode="Static" runat="server" />
                </div>
                <div class="clear"></div>
            </article>
            <article class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/img-behavioural-assessment.gif" alt="Procurement - Behavioural Self Assessment" /></div>
                <div class="head"><%--Behavioural Assessment--%>Procurement Behavioural Self Assessment</div>
                <div class="desc">This is a self-evaluation of your behavioural competencies. You will be guided through critical behavioural styles as you assess yourself on 72 behaviour descriptions.</div>
                <div class="info">
                    <asp:CheckBox ID="chkPBSA" ClientIDMode="Static" runat="server" />
                </div>
                <div class="clear"></div>
            </article>
            <article id="pnlCMK" runat="server" class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/img-contract-management-assessment.png" alt="Contract Management Knowledge Evaluation" /></div>
                <div class="head">Contract Management Knowledge Evaluation</div>
                <div class="desc">This is an evaluation of your Contract Management knowledge. You will be guided through eight dimensions of Contract Management and you will be asked three multiple choice questions for each dimension. This is a timed assessment and at 60 minutes the assessment will close. </div>
                <div class="info">
                    <asp:CheckBox ID="chkCMKE" ClientIDMode="Static" runat="server" />
                </div>
                <div class="clear"></div>
            </article>
            <article class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/bargraph.png" alt="Contract Management Self Assessment" /></div>
                <div class="head">Contract Management Self Assessment</div>
                <div class="desc">An online self-assessment survey designed to explore the capability required to perform commercial contract management. Based on your responses to 72 questions, across the 8 categories of contract management, a profile of your capability will be built and recommendations for future development will be made.</div>
                <div class="info">
                    <asp:CheckBox ID="chkCMSA" ClientIDMode="Static" runat="server" />
                </div>
                <div class="clear"></div>
            </article>
            <article class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/hierarchy.png" alt="Leadership Self Assessment" /></div>
                <div class="head">Leadership Self Assessment</div>
                <div class="desc">An online self-assessment survey to explore the skills required to motivate, lead and empower a team of people. It focuses on 8 stages of leadership and asks you to rate yourself across 72 capabilities in total.</div>
                <div class="info">
                    <asp:CheckBox ID="chkLSA" ClientIDMode="Static" runat="server" />
                </div>
                <div class="clear"></div>
            </article>

            <article class="info-box-shdw">
                <div class="icon">
                    <img src="../innerimages/calculator-icon.png" alt="Negotiation Profile" /></div>
                <div class="head">Negotiation Profile </div>
                <div class="desc">This is a self-evaluation of your negotiation skills. You will be guided through critical negotiation styles as you assess yourself on 72 pivotal negotiation skills.</div>
                <div class="info">
                    <asp:CheckBox ID="chkNA" ClientIDMode="Static" runat="server" />
                </div>
                <div class="clear"></div>
            </article>
            <article class="info-box-shdw">
							<div class="icon"><img src="../innerimages/img-department-maturity-profile.gif" alt="Department Maturity Profile" /></div>
							<div class="head">Department Maturity Profile</div>
							<div class="desc">This is your independent assessment of the procurement function that you operate within. You will be guided through 72 questions that will form a picture of where your procurement organization is, in the journey of assessing its maturity.  </div>
							<div class="info">
							 <asp:CheckBox ID="chkDMP" ClientIDMode="Static" runat="server" /></div>
							<div class="clear"></div>
						</article>
                      
                            <article class="info-box-shdw">
							<div class="icon"><img src="../innerimages/img-category-management-challenge.gif" alt="Supply Chain Knowledge Evaluation" /></div>
							<div class="head">Supply Chain Knowledge Evaluation</div>
							<div class="desc">This assessment focuses on the skills required to perform procurement. It focuses on eight dimensions typically used in an end-to-end procurement process. For each dimension you will be asked nine questions.</div>
							<div class="info">
					         <asp:CheckBox ID="chkSCKE" ClientIDMode="Static" runat="server" /></div>
							<div class="clear"></div>
						</article>
						<article class="info-box-shdw">
							<div class="icon"><img src="../innerimages/img-skills-self-assessment.gif" alt="Supply Chain Self Assessment" /></div>
							<div class="head">Supply Chain Self Assessment</div>
							<div class="desc">This is a self-evaluation of your procurement skills. You will be guided through the eight phases of the complete category management process as you assess yourself on 72 pivotal procurement skills.</div>
							<div class="info">
							 <asp:CheckBox ID="chkSCSA" ClientIDMode="Static" runat="server" /></div>
							<div class="clear"></div>
						</article>                 
        </section>
        <div class="dot-line">&nbsp;</div>
      <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Thank You</h4>
        </div>
        <div class="modal-body">
          <p>Thank you for your enquiry. We will get in touch with you.</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    </article>
    <script>
      
        $("#hylLetsTalk").bind('click', function (e) {
                var PKE = "";
                var PTSA = "";
                var PBSA = "";
                var CMKA = "";
                var CMSA = "";
                var LSA = "";
                var NP = "";
                var DMP = "";
                var SCKE = "";
                var SCSA = "";
                if ($('#chkPKE').is(':checked'))
                {
                    PKE = "Procurement Knowledge Evaluation";
                }
                if ($('#chkPTSA').is(':checked')) {
                    PTSA = "Procurement Technical Self Assessment";
                }
                if ($('#chkPBSA').is(':checked')) {
                    PBSA = "Procurement Behavioural Self Assessment";
                }
                if ($('#chkCMKA').is(':checked')) {
                    CMKA = "Contract Management Knowledge Evaluation";
                }
                if ($('#chkCMSA').is(':checked')) {
                    CMSA = "Contract Management Self Assessment";
                }
                if ($('#chkLSA').is(':checked')) {
                    LSA = "Leadership Self Assessment";
                }
                if ($('#chkNA').is(':checked')) {
                    NP = "Negotiation Profile";
                }
                if ($('#chkDMP').is(':checked')) {
                    DMP = "Department Maturity Profile";
                }
                if ($('#chkSCKE').is(':checked')) {
                    SCKE = "Supply Chain Knowledge Evaluation";
                }
                if ($('#chkSCSA').is(':checked')) {
                    SCSA = "Supply Chain Self Assessment";
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "default.aspx/SendEmail",
                    data: JSON.stringify({ 'PKE': PKE,'PTSA':PTSA,'PBSA':PBSA,'CMKA':CMKA,'CMSA':CMSA,'LSA':LSA,'NP':NP,'DMP':DMP,'SCKE':SCKE,'SCSA':SCSA}),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $("#myModal").modal({ backdrop: true });
                    },
                    error: (error) => {
                        alert('error');
                    }
                });
            });
       
    </script>
</asp:Content>
