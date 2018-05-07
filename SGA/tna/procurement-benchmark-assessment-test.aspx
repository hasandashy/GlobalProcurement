<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="procurement-benchmark-assessment-test.aspx.cs" Inherits="SGA.tna.procurement_benchmark_assessment_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        .itemselected {
            background: #f9a03d;
        }

         .spmodal
    {
        position: fixed;
        z-index: 999;
        height: 100%;
        width: 100%;
        top: 0;
        left: 0;
        background-color: Black;
        filter: alpha(opacity=60);
        opacity: 0.6;
        -moz-opacity: 0.8;
    }
    .center
    {
        z-index: 1000;
        margin: 300px auto;
        padding: 10px;
        width: 130px;
        background-color: black;
        border-radius: 10px;
        filter: alpha(opacity=100);
        opacity: 1;
        -moz-opacity: 1;
    }
    .center img
    {
        height: 128px;
        width: 128px;
    }
    </style>
    <div class="dis-block clearfix  marT1 top-space">
        <div class="main-heading dis-block clearfix pad15 font18 head-graybg padbottom-none padtop1 marTnone">
            <h1>Pillar <%= pillarId %><span runat="server" id="pillarNameSpan">Data, Analysis & Insights  </span></h1>
        </div>


        <div class="dis-block clearfix white-bg pad15 full-height pillar-question">
            <div class="gray-strip"></div>
            <div id="gray-strip-fill"></div>
            <div class="question-number" runat="server" id="pgLbl"></div>
            <asp:ListView ID="parentRepeater" runat="server" OnItemDataBound="parentRepeater_ItemDataBound" OnPagePropertiesChanged="parentRepeater_PagePropertiesChanged">
                <LayoutTemplate>

                    <div class="question-set dis-block clearfix">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </div>


                </LayoutTemplate>
                <ItemTemplate>
                    <div class="question-heading">
                        <i>
                            <asp:Label ID="lblNumber" ClientIDMode="Static" runat="server"></asp:Label>
                        </i>
                        <span attr-val='<%#Eval("questionId")%>' id="ques"><%#Eval("questionText")%></span>

                    </div>
                    <asp:ListView ID="lstQuestions" runat="server" DataSource='<%#GetData((int)DataBinder.Eval(Container.DataItem,"questionId"))%>'>
                        <LayoutTemplate>
                            <ul id="optionlist">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </ul>

                        </LayoutTemplate>
                        <ItemTemplate>
                            <li runat="server" attr-val='<%#Eval("optionId")%>'><i><%# Container.DataItemIndex + 1%></i><span><%#Eval("optionText")%></span></li>
                        </ItemTemplate>
                    </asp:ListView>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <asp:DataPager ID="DataPager1" runat="server" PageSize="1" PagedControlID="parentRepeater">
            <Fields>
                <asp:TemplatePagerField OnPagerCommand="pager">
                    <PagerTemplate>
                        <div class="bottom-btn">
                            <div class="fleft blue-btn">
                                <asp:LinkButton ID="lb1" ClientIDMode="Static" Text="<< BACK" CommandName="Previous" runat="server" CssClass="leftbt" />
                            </div>
                            <div class="fright blue-btn">
                                <asp:LinkButton ID="lb2" ClientIDMode="Static" Text="Next >>" CommandName="Next" runat="server" CssClass="rightbt" />
                            </div>
                        </div>
                    </PagerTemplate>
                </asp:TemplatePagerField>
            </Fields>
        </asp:DataPager>




        <%--  <div class="bottom-btn">
            <div class="fleft blue-btn"><a href="06-question-page-1.html" class="leftbt"><< BACK </a></div>
            <div class="fright blue-btn"><a href="05-pIllars-navigation-bar-complete.html" class="rightbt">NEXT >> </a></div>

        </div>--%>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                   <%-- <h4 class="modal-title"></h4>--%>
                </div>
                <div class="modal-body" style="text-align:center">
                    <p>Please select an option.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

    <div class="spmodal" style="display:none;">
    <div class="center">
        <img alt="" src="../images/sploader.gif" />
    </div>
</div>
    <script>
        $( document ).ready(function() {
            FillValues();


            if ($('#lblNumber').text() == '01') {
                $("#lb1").css("visibility", "hidden");
            }
            var cls = 'width' + $('#lblNumber').text().substring(1) + ' gray-strip-fill';
            $("#gray-strip-fill").attr('class', cls);
        });
        $("#optionlist li").click(function () {
            $('#optionlist li').removeAttr('id');
            $('#optionlist li').removeAttr('class');
            $(this).attr('id', 'selected');
            $(this).attr('class', 'itemselected');
           
        });
        $("#lb1").click(function (event) {           
            //SaveAssessment();           
        });

        $("#lb2").click(function (event) {
            if ($('#optionlist #selected').length) {
                $(".spmodal").show();
                SaveAssessment();           
                if ($('#lblNumber').text() == '09') {
                    event.preventDefault();
                    if(<%=this.pillarId%> == 7)
                    {
                        CompleteAssessment()
                        $(".spmodal").hide();
                        window.location.href = "/tna/SuccessMessage.aspx";
                    }
                    else{
                        $(".spmodal").hide();
                        window.location.href = "/tna/assessment-pillars.aspx";
                    }
                }
            }
        
            else {
                $("#myModal").modal({ backdrop: true });
                event.preventDefault();
                return false;
            }
        });

        function FillValues(){
            var json =
                             $.ajax({
                                 type: "POST",
                                 async: false,
                                 url: "procurement-benchmark-assessment-test.aspx/GetSelectedOption",
                                 data: JSON.stringify({ 'questionId': $('#ques').attr('attr-val'), 'testId': <%=this.testId%> }),
                                 dataType: "json",
                                 contentType: "application/json; charset=utf-8",
                                 success: function (data) {
                                     $("#optionlist li").each(function () {   
                                         var result =data.d;
                                         var att = $(this).attr('attr-val');
                                         if( att === result) {
                                             $(this).attr('id', 'selected');
                                             $(this).attr('class', 'itemselected');
                                         }
                                     }); 
                                 },
                                 error: (error) => {
                                     alert('error');
                                 }
                             });
                         }

                         function SaveAssessment()
                         {    
           
                             //$.preloader.start({
                             //    modal: true,
                             //    src: 'sprites.png'
                             //});
              
                             var json =
                                          $.ajax({
                                              type: "POST",
                                              async: false,
                                              url: "procurement-benchmark-assessment-test.aspx/SaveData",
                                              data: JSON.stringify({ 'questionId': $('#ques').attr('attr-val'), 'optionId': $('#selected').attr('attr-val'), 'testId': <%=this.testId%> }),
                                 dataType: "json",
                                 contentType: "application/json; charset=utf-8",
                                 success: function (data) {
                                     //alert('success')
                                     //$.preloader.stop();
                                 },
                                 error: (error) => {
                                     //$.preloader.stop();
                                     alert('Error while saving data');
                                     event.preventDefault();
                                     return false;
                                 }
                             });
                       
                         }

                         function CompleteAssessment()
                         {           
                             //$.preloader.start({
                             //    modal: true,
                             //    src: 'sprites.png'
                             //});
                             var json =
                                          $.ajax({
                                              type: "POST",
                                              async: false,
                                              url: "procurement-benchmark-assessment-test.aspx/CompleteAssessment",
                                              data: JSON.stringify({'testId': <%=this.testId%> }),
                                          dataType: "json",
                                          contentType: "application/json; charset=utf-8",
                                          success: function (data) {
                                              //alert('success')
                                              //$.preloader.stop();
                                          },
                                          error: (error) => {
                                              //$.preloader.stop();
                                              alert('Error while saving data');
                                              event.preventDefault();
                                              return false;
                                          }
                                      });
           
                                  }

    </script>
</asp:Content>
