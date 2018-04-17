﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCMCDesktopGraph2.ascx.cs" Inherits="SGA.controls.ctrlCMCDesktopGraph2" %>
<script src="../js/Chart.min.js"></script>

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
                        <canvas id="container2"></canvas>
                    </div>
                </div>

            </div>
        </div>

    </div>

</div>

<div>
    <div class="fleft blue-btn">
        <a href="#tab1" class="leftbt"><< BACK </a>
    </div>
    <div class="fright blue-btn"><a href="#tab1" class="rightbt">NEXT >> </a></div>
</div>

<script type="text/javascript">
    jQuery(document).ready(function () {
        var barChartData1 = {
            labels: ['<%= topic1name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic2name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic3name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic4name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic5name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic6name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic7name %>'.replace('<span>', '').replace('</span>', '')],
            datasets: [{
                label: 'Your marks',
                borderWidth: 1,
                backgroundColor: '#FF8C00',
                borderColor: '#FF8C00',
                data: [
					<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>
                ]
            }, {
                label: 'Avg marks',
                backgroundColor: '#4682B4',
                borderColor: '#4682B4',
                borderWidth: 1,
                data: [
					<%= medain1 %>,<%= medain2 %>,<%= medain3 %>,<%= medain4 %>,<%= medain5 %>,<%= medain6 %>,<%= medain7 %>
                ]
            }]

        };

        var barChartData2 = {
            labels: ['<%= topic1name %>'.replace('<span>', '').replace('</span>', ''),
                             '<%= topic2name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic3name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic4name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic5name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic6name %>'.replace('<span>', '').replace('</span>', ''),
                            '<%= topic7name %>'.replace('<span>', '').replace('</span>', '')],
             datasets: [{
                 label: 'Your marks',
                 borderWidth: 1,
                 backgroundColor: '#FF8C00',
                 borderColor: '#FF8C00',
                 data: [
                     <%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>
                ]
            }, {
                label: 'Avg marks',
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
               display: false
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
               display: false
           }]
       }
            }
        });

        jQuery('.tabs .tab-links a').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('href');
            jQuery('.rightbt').attr('href', currentAttrValue);
            jQuery('.leftbt').attr('href', currentAttrValue);
            // Show/Hide Tabs
            jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

            // Change/remove current tab to active
            jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

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

            // Show/Hide Tabs




        
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