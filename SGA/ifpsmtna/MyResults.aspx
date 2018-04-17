<%@ Page Title="" Language="C#" MasterPageFile="~/tnaDesktop.Master" AutoEventWireup="true" CodeBehind="MyResults.aspx.cs" Inherits="SGA.ifpsmtna.MyResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Accordion Menu -->
		<script type="text/javascript" src="../js/jquery.min.js"></script>
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
						<p class="title40-orange"><asp:Label ID="lblName" runat="server"></asp:Label>
						</p>
						<p class="title40">Your Results</p>
						<p>Below you will see the results for assessments that you currently have access to. By clicking 'go' against each assessment, you will be directed to that particular assessments results.</p>
					</section>
					<div class="dot-line">&nbsp;</div>
					<section class="color-box">
						<article class="info-box-shdw">
							<div class="icon"><img src="../innerimages/img-category-management-challenge.gif" alt="Procurement Benchmark Assessment" /></div>
							<div class="head">Procurement Benchmark Assessment</div>
							<div class="desc">This assessment focuses on the skills required to perform procurement. It focuses on eight dimensions typically used in an end-to-end procurement process. For each dimension you will be asked nine questions.</div>
							<div class="info">
					        <asp:HyperLink ID="hylSga" runat="server"></asp:HyperLink></div>
							<div class="clear"></div>
						</article>
						    
					</section>
					<div class="dot-line">&nbsp;</div>
				</article>         
                       
</asp:Content>
