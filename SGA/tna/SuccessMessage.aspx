<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="SuccessMessage.aspx.cs" Inherits="SGA.tna.SuccessMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dis-block clearfix  marT1 top-space">

<div class="main-heading dis-block clearfix pad15 padtop2 ">
<h1><asp:Label ID="lblName" runat="server" style="color: #F9A12A;font-size: 24px;font-family: 'HelveticaBold';"></asp:Label> </h1>
<h2 class="center marT4"><span>Whilst our engines are calculating your scores, please tell us more about yourself ..</span></h2>
</div>



<div class="loading-screen"><img src="../Images/loading.gif" id="loading" alt=""></div>




<div class="bottom-btn">

<div class="fright blue-btn"><a id="nextBtn" href="MyProfile.aspx" class="rightbt disable-btn">NEXT >> </a></div>


</div>






</div>
    <script>
        $(document).ready(function () {           
            setInterval(function () {
                $('#loading').attr('src', '../Images/loding-orange.gif')
                $('#nextBtn').attr('class', 'rightbt')
            }, 5000);
        });
    </script>
</asp:Content>

