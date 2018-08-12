<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cmcPersonilisedDashboard2.ascx.cs" Inherits="SGA.controls.cmcPersonilisedDashboard2" %>
<script type="text/javascript" src="https://www.google.com/jsapi?autoload={'modules':[{'name':'visualization','version':'1','packages':['geochart']}]}"></script>
<div class="dis-block clearfix white-bg pad15 full-height padtop3">

    <div class="dis-block clearfix">
        <div class="question-number"></div>

        <div class="tabs">
            <div class="tab-links">
                <ul>
                    <li id="fourth" class="active"><a href="#tab4">BY REGION</a></li>
                    <li id="fifth"><a href="#tab5">BY NATION</a></li>
                    <li id="sixth"><a href="#tab6">BY HEATMAP</a></li>
                </ul>
            </div>



            <div class=" dis-block clearfix tab-content">

                <div id="tab4" class="tab active">
                    <div class="question-heading">
                        <span>In the graph below you can see a benchmark of your result against users in the same region
                        </span>
                        <div class="redtitle"></div>
                    </div>
                    <article class="navigation" style="border-top: none;">
                        <ul>
                            <asp:Repeater ID="rptrTopics1" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <asp:LinkButton ID="lnkBtn" CssClass="color" runat="server" Font-Size="12px" Text='<%#Eval("topicName").ToString().Replace(" ","<br />")%>' CommandArgument='<%#Eval("topicId") %>' CommandName="select">LinkButton</asp:LinkButton></li>

                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </article>
                    <div class="dis-block clearfix graph">
                        <canvas id="container3"></canvas>
                    </div>
                </div>

                <div id="tab5" class="tab">
                    <div class="question-heading">
                        <span>In the graph below you can see a benchmark of your result against users in the same country
                        </span>
                        <div class="redtitle"></div>
                    </div>
                    <article class="navigation" style="border-top: none;">
                        <ul>
                            <asp:Repeater ID="rptrTopics2" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <asp:LinkButton ID="lnkBtn" CssClass="color" runat="server" Font-Size="12px" Text='<%#Eval("topicName").ToString().Replace(" ","<br />")%>' CommandArgument='<%#Eval("topicId") %>' CommandName="select">LinkButton</asp:LinkButton></li>

                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </article>
                    <div class="dis-block clearfix marT3 graph">
                        <canvas id="container4"></canvas>
                    </div>
                </div>

                <div id="tab6" class="tab">
                    <div class="question-heading">
                        <span>In the graph below you can see a benchmark of your result.
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix marT3 graph">
                        <div id="container5"></div>
                    </div>
                </div>

            </div>
        </div>

    </div>

</div>


<script type="text/javascript">
    jQuery(document).ready(function () {
        var barChartData4 = {
            <%-- labels: ['<%= topic1name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic2name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic3name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic4name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic5name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic6name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic7name %>'.replace('<span>', '').replace('</span>', '')],--%>
            labels: ['ANLYSE', 'ALIGN', 'CATMAN', 'SUSTIN', 'RELATE', 'PERFRM', 'PARTNR'],
            datasets: [{
                label: 'Your results',
                borderWidth: 1,
                backgroundColor: '#FF8C00',
                borderColor: '#FF8C00',
                data: [
					<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>
                ]
            }, {
                label: 'Avg results',
                backgroundColor: '#4682B4',
                borderColor: '#4682B4',
                borderWidth: 1,
                data: [
					<%= medain1 %>,<%= medain2 %>,<%= medain3 %>,<%= medain4 %>,<%= medain5 %>,<%= medain6 %>,<%= medain7 %>
                ]
            }]

        };

        var barChartData5 = {
            <%--  labels: ['<%= topic1name %>'.replace('<span>', '').replace('</span>', ''),
                             '<%= topic2name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic3name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic4name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic5name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic6name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic7name %>'.replace('<span>', '').replace('</span>', '')],--%>
            labels: ['ANLYSE', 'ALIGN', 'CATMAN', 'SUSTIN', 'RELATE', 'PERFRM', 'PARTNR'],
            datasets: [{
                label: 'Your results',
                borderWidth: 1,
                backgroundColor: '#FF8C00',
                borderColor: '#FF8C00',
                data: [
                    <%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>
                ]
            }, {
                label: 'Avg results',
                borderWidth: 1,
                backgroundColor: '#4682B4',
                borderColor: '#4682B4',
                data: [
                    <%= countrymedain1 %>,<%= countrymedain2 %>,<%= countrymedain3 %>,<%= countrymedain4 %>,<%= countrymedain5 %>,<%= countrymedain6 %>,<%= countrymedain7 %>
                ]
            }]

        };

        var ctx4 = document.getElementById('container3').getContext('2d');
        window.myBar = new Chart(ctx4, {
            type: 'bar',
            data: barChartData4,
            options: {
                responsive: true,
                legend: {
                    position: 'top',
                },
                scales:
       {
           xAxes: [{
               display: false,
               gridLines: {
                   display: false
               }
           }],
           yAxes: [{
               display: true,
               ticks: {
                   beginAtZero: true,
                   max: 100
               },
               gridLines: {
                   display: true
               }
           }]
       }
            }
        });

        var ctx5 = document.getElementById('container4').getContext('2d');
        window.myBar = new Chart(ctx5, {
            type: 'bar',
            data: barChartData5,
            options: {
                responsive: true,
                legend: {
                    position: 'top',
                },
                scales:
       {
           xAxes: [{
               display: false,
               gridLines: {
                   display: false
               }
           }],
           yAxes: [{
               display: true,
               ticks: {
                   beginAtZero: true,
                   max: 100
               },
               gridLines: {
                   display: true
               }
           }]
       }
            }
        });


        function drawRegionsMap() {

            var data = google.visualization.arrayToDataTable([
                ['Region Code', 'Continent', 'Avg Score'],
                ['015', 'Northern Africa', <%=this._nAfricaAvg%>],
['011', 'Western Africa', <%=this._wAfricaAvg%>],
['017', 'Middle Africa', <%=this._mAfricaAvg%>],
['014', 'Eastern Africa', <%=this._eAfricaAvg%>],
['018', 'Southern Africa', <%=this._sAfricaAvg%>],
['154', 'Northern Europe', <%=this._nEuropeAvg%>],
['155', 'Western Europe', <%=this._wEuropeAvg%>],
['151', 'Eastern Europe', <%=this._eEuropeAvg%>],
['039', 'Southern Europe', <%=this._sEuropeAvg%>],
['021', 'Northern America', <%=this._nAmericaAvg%>],
['029', 'Caribbean', <%=this._carAmericaAvg%>],
['013', 'Central America', <%=this._cAmericaAvg%>],
['005', 'South America', <%=this._sAmericaAvg%>],
['143', 'Central Asia', <%=this._cAsiaAvg%>],
['030', 'Eastern Asia', <%=this._eAsiaAvg%>],
['034', 'Southern Asia', <%=this._sAsiaAvg%>],
['035', 'South-Eastern Asia', <%=this._saAsiaAvg%>],
['145', 'Western Asia', <%=this._wAsiaAvg%>],
['053', 'Australia and New Zealand', <%=this._aNOcenAvg%>],
['054', 'Melanesia', <%=this._mOcenAvg%>],
['057', 'Micronesia', <%=this._micOcenAvg%>],
['061', 'Polynesia', <%=this._pOcenAvg%>]
            ]);

            // extract column index 1 for color values
            var colorValues = [<%=this._nAfricaAvg%>,<%=this._wAfricaAvg%>,<%=this._mAfricaAvg%>,<%=this._eAfricaAvg%>,<%=this._sAfricaAvg%>,<%=this._nEuropeAvg%>,<%=this._wEuropeAvg%>,<%=this._eEuropeAvg%>,<%=this._sEuropeAvg%>,<%=this._nAmericaAvg%>,<%=this._carAmericaAvg%>,<%=this._cAmericaAvg%>,<%=this._sAmericaAvg%>,<%=this._cAsiaAvg%>,<%=this._eAsiaAvg%>,<%=this._sAsiaAvg%>,<%=this._saAsiaAvg%>,<%=this._wAsiaAvg%>,<%=this._aNOcenAvg%>,<%=this._mOcenAvg%>,<%=this._micOcenAvg%>,<%=this._pOcenAvg%>]
            // sort ascending
            colorValues.sort(function (a, b) { return a - b });
            // build color names red <= -10 > yellow <= 10 > green
            var colorNames = [];
            colorValues.forEach(function (value) {
                if (value < 1) {
                    colorNames.push('grey');
                } else if ((value > 0) && (value <= 30)) {
                    colorNames.push('#ef4135');
                } else if ((value > 30) && (value <= 50)) {
                    colorNames.push('#f26522');
                } else if ((value > 50) && (value <= 70)) {
                    colorNames.push('#f7941d');
                } else if ((value > 70) && (value <= 90)) {
                    colorNames.push('yellow');
                } else {
                    colorNames.push('green');
                }
            });

            var options = {
                resolution: 'subcontinents',
                colorAxis: {
                    colors: colorNames,
                    values: colorValues
                },
                datalessRegionColor: 'grey'

            };

            //var options = {
            //    resolution: 'continents',
            //    colorAxis: { colors: ['grey','yellow', 'orange'] }
            //};


            var chart = new google.visualization.GeoChart(document.getElementById('container5'));

            chart.draw(data, options);
        }



        jQuery('.tabs .tab-links a').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('href');
            // Show/Hide Tabs
            jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

            // Change/remove current tab to active
            jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

            if (currentAttrValue === '#tab6') {
                drawRegionsMap();

            }

        });



    });



</script>
