<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCMCGraph2.ascx.cs" Inherits="SGA.controls.ctrlCMCGraph2" %>


<%--<script src="https://code.highcharts.com/highcharts.js"></script>--%>
<%--<script src="https://code.highcharts.com/modules/exporting.js"></script>--%>
<script src="https://code.highcharts.com/maps/highmaps.js"></script>

<div class="dis-block clearfix white-bg pad15 full-height padtop3">

    <div class="dis-block clearfix">
        <div class="question-number"></div>

        <div class="tabs">
            <div class="tab-links">
                <ul>
                    <li class="active"><a href="#tab1">BY NATION</a></li>
                    <li><a href="#tab2">BY REGION</a></li>
                    <li><a href="#tab3">BY HEATMAP</a></li>
                </ul>
            </div>



            <div class=" dis-block clearfix tab-content">

                <div id="tab1" class="tab active">
                    <div class="question-heading">
                        <i>01</i> <span>In the graph below you can see a benchmark of your result against users in the same region
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix  graph" id="container">
                    </div>
                </div>

                <div id="tab2" class="tab">
                    <div class="question-heading">
                        <i>02</i> <span>In the graph below you can see a benchmark of your result against users in the same country
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix marT3 graph" id="container1"></div>
                </div>

                <div id="tab3" class="tab">
                    <div class="question-heading">
                        <i>03</i> <span>In the graph below you can see a benchmark of your result.

                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix marT3 graph" id="container2"></div>
                </div>

            </div>
        </div>

    </div>

</div>

<script>
   
</script>


<script type="text/javascript">
    jQuery(document).ready(function () {


        var chart1 = Highcharts.chart('container', {
            chart: {
                type: 'column'
            },
            title: {
                text: 'Procurement Benchmark Assessment'
            },
            subtitle: {
                text: ''
            },
            xAxis: {
                categories: [
                    '<%= topic1name %>',
                '<%= topic2name %>',
                '<%= topic3name %>',
                '<%= topic4name %>',
                '<%= topic5name %>',
                '<%= topic6name %>',
                '<%= topic7name %>'
            ],
            crosshair: true
        },
       yAxis: {
           min: 0,
           title: {
               text: 'Marks (avg)'
           }
       },
       tooltip: {
           headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
           pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
               '<td style="padding:0"><b>{point.y:.1f} %</b></td></tr>',
           footerFormat: '</table>',
           shared: true,
           useHTML: true
       },
       plotOptions: {
           column: {
               pointPadding: 0.2,
               borderWidth: 0
           }
       },
       series: [{
           name: 'Your Marks',
           data: [ <%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>]

        }, {
            name: 'Average Marks',
            data: [<%= medain1 %>,<%= medain2 %>,<%= medain3 %>,<%= medain4 %>,<%= medain5 %>,<%= medain6 %>,<%= medain7 %>]
        }],


       //}, {
       //    name: 'London',
       //    data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]

       //}, {
       //    name: 'Berlin',
       //    data: [42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1]

       //}]
   });


        jQuery('.tabs .tab-links a').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('href');

            // Show/Hide Tabs
            jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

            // Change/remove current tab to active
            jQuery(this).parent('li').addClass('active').siblings().removeClass('active');
            if (currentAttrValue === '#tab1') {
                chart1.reflow();
            }

            if (currentAttrValue === '#tab2') {
                var chart2 = Highcharts.chart('container1', {
                    chart: {
                        type: 'column'
                    },
                    title: {
                        text: 'Procurement Benchmark Assessment'
                    },
                    subtitle: {
                        text: ''
                    },
                    xAxis: {
                        categories: [
                            '<%= topic1name %>',
                '<%= topic2name %>',
                '<%= topic3name %>',
                '<%= topic4name %>',
                '<%= topic5name %>',
                '<%= topic6name %>',
                '<%= topic7name %>'
            ],
            crosshair: true
        },
                 yAxis: {
                     min: 0,
                     title: {
                         text: 'Marks (avg)'
                     }
                 },
                 tooltip: {
                     headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                     pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                         '<td style="padding:0"><b>{point.y:.1f} %</b></td></tr>',
                     footerFormat: '</table>',
                     shared: true,
                     useHTML: true
                 },
                 plotOptions: {
                     column: {
                         pointPadding: 0.2,
                         borderWidth: 0
                     }
                 },
                 series: [{
                     name: 'Your Marks',
                     data: [ <%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>]

        }, {
            name: 'Average Marks',
            data: [<%= countrymedain1 %>,<%= countrymedain2 %>,<%= countrymedain3 %>,<%= countrymedain4 %>,<%= countrymedain5 %>,<%= countrymedain6 %>,<%= countrymedain7 %>]
        }]

                 //}, {
                 //    name: 'London',
                 //    data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]

                 //}, {
                 //    name: 'Berlin',
                 //    data: [42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1]

                 //}]
             });

}
        e.preventDefault();
    });
    });



</script>
