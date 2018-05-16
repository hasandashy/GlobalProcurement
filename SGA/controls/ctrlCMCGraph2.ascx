<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCMCGraph2.ascx.cs" Inherits="SGA.controls.ctrlCMCGraph2" %>
<script src="../js/Chart.min.js"></script>
<script type="text/javascript" src="https://www.google.com/jsapi?autoload={'modules':[{'name':'visualization','version':'1','packages':['geochart']}]}"></script>
<div class="dis-block clearfix white-bg pad15 full-height padtop3">

    <div class="dis-block clearfix">
        <div class="question-number"></div>

        <div class="tabs">
            <div class="tab-links">
                <ul>
                    <li id="first" class="active"><a href="#tab1">BY REGION</a></li>
                    <li id="second"><a href="#tab2">BY NATION</a></li>
                    <li id="third"><a href="#tab3">BY HEATMAP</a></li>
                </ul>
            </div>



            <div class=" dis-block clearfix tab-content">

                <div id="tab1" class="tab active">
                    <div class="question-heading">
                        <i>01</i> <span>In the graph below you can see a benchmark of your result against users in the same region
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix graph">
                        <canvas id="container"></canvas>
                    </div>
                </div>

                <div id="tab2" class="tab">
                    <div class="question-heading">
                        <i>02</i> <span>In the graph below you can see a benchmark of your result against users in the same country
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix marT3 graph">
                        <canvas id="container1"></canvas>
                    </div>
                </div>

                <div id="tab3" class="tab">
                    <div class="question-heading">
                        <i>03</i> <span>In the graph below you can see a benchmark of your result.

                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix marT3 graph">
                          <div id="container2"></div>
                    </div>
                </div>

            </div>
        </div>

    </div>

</div>

<div class="bottom-btn">
    <div class="fleft blue-btn">
        <a href="#tab1" class="leftbt"><< BACK </a>
    </div>
    <div class="fright blue-btn"><a href="#tab1" class="rightbt">NEXT >> </a></div>
</div>

<script type="text/javascript">
    jQuery(document).ready(function () {
        var barChartData1 = {
            labels: ['anlyse', 'align', 'catman', 'sustin', 'relate', 'perfrm', 'partnr'],
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

        var barChartData2 = {
            labels: ['anlyse', 'align', 'catman', 'sustin', 'relate', 'perfrm', 'partnr'],
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

        var ctx1 = document.getElementById('container').getContext('2d');
        window.myBar = new Chart(ctx1, {
            type: 'bar',
            data: barChartData1,
            options: {
                responsive: true,
                legend: {
                    position: 'top',
                },
                scales:
       {
           xAxes: [{
               display: true,
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

        var ctx2 = document.getElementById('container1').getContext('2d');
        window.myBar = new Chart(ctx2, {
            type: 'bar',
            data: barChartData2,
            options: {
                responsive: true,
                legend: {
                    position: 'top',
                },
                scales:
       {
           xAxes: [{
               display: true,
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
        //google.setOnLoadCallback(drawRegionsMap);
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
                datalessRegionColor: 'grey',
            };

            //var options = {
            //    resolution: 'continents',
            //    colorAxis: { colors: ['grey','yellow', 'orange'] }
            //};


            var chart = new google.visualization.GeoChart(document.getElementById('container2'));

            chart.draw(data, options);
        }


        jQuery('.tabs .tab-links a').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('href');

          
            jQuery('.rightbt').attr('href', currentAttrValue);
            jQuery('.leftbt').attr('href', currentAttrValue);
            // Show/Hide Tabs
            jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

            // Change/remove current tab to active
            jQuery(this).parent('li').addClass('active').siblings().removeClass('active');
            if (currentAttrValue === '#tab3') {
                drawRegionsMap();

            }



        });
        //next btn click
        jQuery('.rightbt').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('href');
           
            // Change/remove current tab to active
            jQuery('.tabs .tab-links a').parent('li').siblings().removeClass('active');

            if (currentAttrValue == '#tab1') {
                jQuery(this).attr('href', '#tab2');
                jQuery('.leftbt').attr('href', '#tab2');
                jQuery('.tabs ' + '#tab2').show().siblings().hide();
                jQuery('#second').addClass('active')
            }
            if (currentAttrValue == '#tab2') {
                jQuery(this).attr('href', '#tab3');
                jQuery('.leftbt').attr('href', '#tab3');
                jQuery('.tabs ' + '#tab3').show().siblings().hide();
                jQuery('#third').addClass('active')
            }
            if (currentAttrValue == '#tab3') {
                if (window.location.href.indexOf("ifpsmtna") > -1) {
                    window.location.href = "default.aspx"
                } else {
                    window.location.href = "association.aspx"
                }
                e.preventDefault();
            }

           
            if (currentAttrValue === '#tab2') {
                drawRegionsMap();
            }



        
        });

        //next btn click
        jQuery('.leftbt').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('href');

            // Change/remove current tab to active
            jQuery('.tabs .tab-links a').parent('li').siblings().removeClass('active');

            if (currentAttrValue == '#tab1') {
                window.location.href = "my-results-bar-graph.aspx"
                e.preventDefault();
            }
            if (currentAttrValue == '#tab2') {
                jQuery(this).attr('href', '#tab1');
                jQuery('.rightbt').attr('href', '#tab1');
                jQuery('.tabs ' + '#tab1').show().siblings().hide();
                jQuery('#first').addClass('active')
            }
            if (currentAttrValue == '#tab3') {
                jQuery(this).attr('href', '#tab2');
                jQuery('.rightbt').attr('href', '#tab2');
                jQuery('.tabs ' + '#tab2').show().siblings().hide();
                jQuery('#second').addClass('active')
            }
         
        });


    });



</script>
