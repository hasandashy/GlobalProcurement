<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCMCGraph.ascx.cs" Inherits="SGA.controls.ctrlCMCGraph" %>
<%--<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<style>div.google-visualization-tooltip { font-weight:bold; }</style>
<script type="text/javascript">
    google.load("visualization", "1", { packages: ["corechart"] });
    //google.setOnLoadCallback(drawChart);
    function drawChart() {
            var data = google.visualization.arrayToDataTable([
	        ['Topic Name', 'My Score', { role: 'style' }, { role: 'tooltip' }],
            ['<%= topic1name %>', <%= topic1mark %>, '#F89F5A', '<%= topic1name %>' + "\r\n My Score " + <%= topic1mark %> +"%"],            // RGB value
	        ['<%= topic2name %>', <%= topic2mark %>, '#7B7C7F', '<%= topic2name %>' + "\r\n My Score " + <%= topic2mark %> +"%"],            // English color name
	        ['<%= topic3name %>', <%= topic3mark %>, '#F89F5A', '<%= topic3name %>' + "\r\n My Score " + <%= topic3mark %> +"%"],
	        ['<%= topic4name %>', <%= topic4mark %>, '#7B7C7F', '<%= topic4name %>' + "\r\n My Score " + <%= topic4mark %> +"%"], // CSS-style declaration
            ['<%= topic5name %>', <%= topic5mark %>, '#F89F5A', '<%= topic5name %>' + "\r\n My Score " + <%= topic5mark %> +"%"], // CSS-style declaration
            ['<%= topic6name %>', <%= topic6mark %>, '#7B7C7F', '<%= topic6name %>' + "\r\n My Score " + <%= topic6mark %> +"%"], // CSS-style declaration
            ['<%= topic7name %>', <%= topic7mark %>, '#F89F5A', '<%= topic7name %>' + "\r\n My Score " + <%= topic7mark %> +"%"], // CSS-style declaration
            ['<%= topic8name %>', <%= topic8mark %>, '#7B7C7F', '<%= topic8name %>' + "\r\n My Score " + <%= topic8mark %> +"%"] // CSS-style declaration
          ]);
        var options = {
                tooltip: { isHtml: true },
                title: ' ',
                hAxis: { title: ' ', titleTextStyle: { color: 'red'} },
                legend: {position: 'none'}
            };
       
        var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
    
    function drawChartAverage() {
    
        var data = google.visualization.arrayToDataTable([
          ['Topic', 'My Score','<%= median %>'],
          ['<%= topic1name %>', <%= topic1mark %>, <%= medain1 %>],
          ['<%= topic2name %>', <%= topic2mark %>, <%= medain2 %>],
          ['<%= topic3name %>', <%= topic3mark %>, <%= medain3 %>],
          ['<%= topic4name %>', <%= topic4mark %>, <%= medain4 %>],
          ['<%= topic5name %>', <%= topic5mark %>, <%= medain5 %>],
          ['<%= topic6name %>', <%= topic6mark %>, <%= medain6 %>],
          ['<%= topic7name %>', <%= topic7mark %>, <%= medain7 %>],
          ['<%= topic8name %>', <%= topic8mark %>, <%= medain8 %>]
        ]
        );
        var options = {
            title: ' ',
            hAxis: { title: ' ', titleTextStyle: { color: 'red'} },
            seriesType: "bars",
            series: {5: {type: "line"}},
            legend: {position: 'right'},
            colors: ['#EA4320','#7B7C7F']
        };
       
        var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
</script>
<table width="100%" border="0" cellspacing="1" cellpadding="1" id="tblCompare" runat="server" class="tform">
    <tr>
        <td width="30%" class="txtrht">
            Compare results againest:
        </td>
        <td width="45%">
            <asp:RadioButtonList ID="rdlQuartile" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Average" Value="4"></asp:ListItem>
                <asp:ListItem Text="Lower Quartile" Value="1"></asp:ListItem>
                <asp:ListItem Text="Median" Selected="True" Value="2"></asp:ListItem>
                <asp:ListItem Text="Upper Quartile" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
            
        </td>
        <td width="25%" class="txtlht"><asp:LinkButton ID="lnkCompare" runat="server" CausesValidation="false" Text="Compare"
                CssClass="rdbut" OnClick="lnkCompare_Click"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="3">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3"></td>
    </tr>
</table>
<div id="chart_div" style="width: 725px; height: 500px;">
</div>--%>
<%----%>




<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
    
<div class="dis-block clearfix white-bg pad15 full-height padtop3">

<div class="dis-block clearfix">
<div class="question-number"></div>

<div class="tabs">
<div class="tab-links">
<ul>
<li class="active"><a href="#tab1">YOUR SCORE</a></li>
<li><a href="#tab2">BY ROLE</a></li>
<li><a href="#tab3">BY SECTOR</a></li>
</ul>
</div>



<div class=" dis-block clearfix tab-content">

<div id="tab1" class="tab active">
<div class="question-heading"><i>01</i> <span>In the graph below you can see your results for each pillar. This provides a visual display of your strengths and development opportunities
</span>
<div class="redtitle"></div>
</div>

<div class="dis-block clearfix  graph" id="container"> 
</div>
</div>

<div id="tab2" class="tab">
<div class="question-heading"><i>02</i> <span>In the graph below you can see a benchmark of your result against users in the same job role
</span>
<div class="redtitle"></div>
</div>

<div class="dis-block clearfix graph" id="container1"></div>
</div>

<div id="tab3" class="tab">
<div class="question-heading"><i>03</i> <span>In the graph below you can see a benchmark of your result against users in the same sector.

</span>
<div class="redtitle"></div>
</div>

<div class="dis-block clearfix  graph" id="container2"></div>
</div>

</div>
</div>

</div>

</div>

<script>
    Highcharts.chart('container', {
        chart: {
            type: 'column',
            width: 1300
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
            name: 'Marks',
            data: [ <%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>]
        }]
        //}, {
        //    name: 'New York',
        //    data: [83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0, 104.3, 91.2, 83.5, 106.6, 92.3]

        //}, {
        //    name: 'London',
        //    data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]

        //}, {
        //    name: 'Berlin',
        //    data: [42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1]

        //}]
    });
</script>

<script>
    Highcharts.chart('container1', {
        chart: {
            type: 'column',
            width: 1300
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
            data: [83.6, 78.8, 98.5, 93.4, 32.0, 55.5, 40.0]
        }]

        //}, {
        //    name: 'London',
        //    data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]

        //}, {
        //    name: 'Berlin',
        //    data: [42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1]

        //}]
    });
</script>

<script>
    Highcharts.chart('container2', {
        chart: {
            type: 'column',
            width: 1300
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
            data: [40.6, 30.8, 65.5, 45.4, 76.0, 12.5, 33.0]
        }]

        //}, {
        //    name: 'London',
        //    data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]

        //}, {
        //    name: 'Berlin',
        //    data: [42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1]

        //}]
    });
</script>
<script type="text/javascript">
jQuery(document).ready(function() {
    jQuery('.tabs .tab-links a').on('click', function(e)  {
        var currentAttrValue = jQuery(this).attr('href');
 
        // Show/Hide Tabs
        jQuery('.tabs ' + currentAttrValue).show().siblings().hide();
 
        // Change/remove current tab to active
        jQuery(this).parent('li').addClass('active').siblings().removeClass('active');
 
        e.preventDefault();
    });
});



</script>