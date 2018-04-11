<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="procurement-benchmark-assessment-test.aspx.cs" Inherits="SGA.tna.procurement_benchmark_assessment_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
    .itemselected {
        background:#f9a03d;
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
                            <li attr-val='<%#Eval("optionId")%>'><i><%# Container.DataItemIndex + 1%></i><span><%#Eval("optionText")%></span></li>
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
                                <asp:LinkButton ID="lb1" ClientIDMode="Static" Text="<< BACK" CommandName="Previous" runat="server" CssClass="leftbt"/>
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
    <script>
        $( document ).ready(function() {
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
            SaveAssessment();           
        });

        $("#lb2").click(function (event) {
            SaveAssessment();           
            if ($('#lblNumber').text() == '09') {
                event.preventDefault();
                if(<%=this.pillarId%> == 7)
                {
                    window.location.href = "/tna/SuccessMessage.aspx";
                }
                else{
                    window.location.href = "/tna/assessment-pillars.aspx";
                }
            }
        });

        function SaveAssessment()
        {           
            if ($(this).attr("selected")) {
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
                                  
                                 },
                                 error: (error) => {
                                     alert('Error while saving data');
                                     event.preventDefault();
                                     return false;
                                 }
                             });
            }
            else {
                alert('please select some value');
                event.preventDefault();
                return false;
            }
        }

    </script>
</asp:Content>
