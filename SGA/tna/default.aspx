<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SGA.tna._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="dis-block clearfix pad15 marT1 top-space">    
<div class="main-heading dis-block clearfix">
<h1><asp:Label ID="lblName" runat="server" style="color: #F9A12A;font-size: 24px;font-family: 'HelveticaBold';"></asp:Label>  <span>Your Assessments</span></h1>
    <div class="menu-icon"><a href="MainMenu.aspx"><img src="../Images/menu-icon.png" alt=""></a></div>
</div>


<p>Below you will see the assessments that you currently have access to. By clicking 'go' against each assessment, you will be directed to that particular assessment. </p> 

<p>Once access is granted, this assessment will be unlocked and you will be able to access it.</p>



<div class="yellow-bg assesment-box " id="assesactive" runat="server" visible="false">
<a href="assessment-instructions.aspx"><i><img src="../images/icon1.png" alt="Procurement Benchmark Assessment" /></i>
<p>Procurement Benchmark Assessment </p> <em>>></em></a>

</div>

<div class="yellow-bg assesment-box " id="asseslocked" runat="server" visible="false">
<a><i><img src="../images/icon1.png" alt="Procurement Benchmark Assessment" /></i>
<p>Procurement Benchmark Assessment <img src="../innerimages/icon-locked.png" style="float:right;"/></p></a>

</div>


<%--<div class="gray-bg assesment-box marT3">
<a href="javascript:void(0)"><i><img src="images/icon1.png" alt=""></i> <p>Procurement Benchmark Assessment </p><em>>></em>  </a>
</div>--%>



</div>

         
                       
</asp:Content>
