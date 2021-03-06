﻿<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SGA.tna._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <style>
      
        input[type=checkbox] {
            /* Double-sized Checkboxes */
            -ms-transform: scale(1.2); /* IE */
            -moz-transform: scale(1.2); /* FF */
            -webkit-transform: scale(1.2); /* Safari and Chrome */
            -o-transform: scale(1.2); /* Opera */
        }
    </style>
    <div class="dis-block clearfix pad15 marT1 top-space">
        <div class="main-heading dis-block clearfix">
            <h1>
                <asp:Label ID="lblName" runat="server" Style="color: #F9A12A; font-size: 24px; font-family: 'HelveticaBold';"></asp:Label>
                <span>Your Assessments</span></h1>
            <div class="menu-icon">
                <a href="MainMenu.aspx">
                    <img src="../Images/menu-icon.png" alt=""></a>
            </div>
        </div>


        <p>Below you will see the assessment that you currently have access to. By clicking 'go' against each assessment, you will be directed to that particular assessment. First, you will reach an information page regarding the assessment you are about to undertake. If you see a lock symbol, this is because you do not yet have access to this assessment.</p>

        <p>Once access is granted, this assessment will be unlocked and you will be able to access it.</p>



        <div class="yellow-bg assesment-box " id="assesactive" runat="server" visible="false">
            <a href="assessment-instructions.aspx"><i>
                <img src="../images/icon1.png" alt="Procurement Benchmark Assessment" /></i>
                <p>Procurement Benchmark Assessment </p>
                <em>>></em></a>

        </div>

        <div class="yellow-bg assesment-box " id="asseslocked" runat="server" visible="false">
            <div class="innerdiv">
                <div style="width: 20%; float: left;">
                    <img src="../images/icon1.png" alt="Procurement Benchmark Assessment" />
                </div>
                <div style="width: 70%; float: left; padding-left: 10px;">
                    Procurement Benchmark Assessment           
                </div>
                <div style="width: auto; float: left;">
                    <img src="../innerimages/icon-locked.png" style="float: right;" />
                </div>
            </div>
        </div>
        <br />

        <div class="assesment-box ">
            <div style="text-align: center; font-weight: bold;">Other paid assessments offered by SkillsGAP Analysis are listed below.</div>
            <div style="text-align: center;">To find out more simply select from the list below and click “LET”S TALK” and we will be in touch.</div>
             <%--<br />
            <div class="blue-btn">
             <asp:HyperLink ID="hylLetsTalk" ClientIDMode="Static"  CssClass="rightbt" Text="Lets Talk" runat="server"></asp:HyperLink></div>
        --%></div>
       
           <br />
        <div class="yellow-bg assesment-box">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Procurement Knowledge Evaluation" /></i>--%>
               <%-- <p>--%>
                    Procurement Knowledge Evaluation

               <%-- </p>--%>
               <em><asp:CheckBox ID="chkPKE" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Procurement Technical Self Assessment" /></i>--%>
                Procurement Technical Self Assessment
               <em><asp:CheckBox ID="chkPTSA" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Procurement - Behavioural Self Assessment" /></i>--%>
                Procurement Behavioural<br /> Self Assessment
               <em><asp:CheckBox ID="chkPBSA" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Contract Management Knowledge Evaluation" /></i>--%>
                Contract Management Knowledge Evaluation
               <em><asp:CheckBox ID="chkCMKE" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Contract Management Self Assessment" /></i>--%>
                Contract Management Self Assessment
               <em><asp:CheckBox ID="chkCMSA" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Leadership Self Assessment" /></i>--%>
                Leadership Self Assessment
               <em><asp:CheckBox ID="chkLSA" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Negotiation Profile" /></i>--%>
                Negotiation Profile
               <em><asp:CheckBox ID="chkNA" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Department Maturity Profile" /></i>--%>
                Department Maturity Profile
               <em><asp:CheckBox ID="chkDMP" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
         <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Supply Chain Knowledge Evaluation" /></i>--%>
                Supply Chain Knowledge Evaluation
               <em><asp:CheckBox ID="chkSCKE" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
        <div class="yellow-bg assesment-box  marT3">
            <a ><%--<i>
                <img src="../images/icon1.png" alt="Supply Chain Self Assessment" /></i>--%>
                Supply Chain Self<br /> Assessment
               <em><asp:CheckBox ID="chkSCSA" ClientIDMode="Static" runat="server" AutoPostBack="false" /></em></a>

        </div>
        <br />
         <div class="fleft blue-btn">
             <asp:HyperLink ID="hylLetsTalk" ClientIDMode="Static"  CssClass="rightbt" Text="Lets Talk" runat="server"></asp:HyperLink></div>
    </div>

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
                if ($('#chkCMKE').is(':checked')) {
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
