<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDesktopCMCGraph.ascx.cs" Inherits="SGA.controls.ctrlCMCDesktopCMCGraph" %>

<div class="dis-block clearfix white-bg pad15 full-height padtop3">
    <style>
        canvas {
            -moz-user-select: none;
            -webkit-user-select: none;
            -ms-user-select: none;
        }
    </style>
    <div class="dis-block clearfix">
        <div class="question-number"></div>

        <div class="tabs">
            <div class="tab-links">
                <ul>
                    <li id="first" class="active"><a href="#tab1">YOUR SCORE</a></li>
                    <li id="second"><a href="#tab2">BY ROLE</a></li>
                    <li id="third"><a href="#tab3">BY SECTOR</a></li>
                </ul>
            </div>
            <div class=" dis-block clearfix tab-content">

                <div id="tab1" class="tab active">
                    <div class="question-heading">
                        <i>01</i> <span>In the graph below you can see your results for each pillar. This provides a visual display of your strengths and development opportunities
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix graph">
                        <canvas id="container"></canvas>
                    </div>
                </div>

                <div id="tab2" class="tab">
                    <div class="question-heading">
                        <i>02</i> <span>In the graph below you can see a benchmark of your result against users in the same job role
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix marT3 graph">
                        <canvas id="container1"></canvas>
                    </div>
                </div>

                <div id="tab3" class="tab">
                    <div class="question-heading">
                        <i>03</i> <span>In the graph below you can see a benchmark of your result against users in the same sector.

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
    <div class="fleft">
        <asp:Button ID="leftbt" ClientIDMode="Static" attr-val="#tab1" runat="server" Text="Back" CssClass="btn-next" />
    </div>
    <div class="fright">
        <asp:Button ClientIDMode="Static" ID="rightbt" attr-val="#tab1" runat="server" Text="Next" CssClass="btn-next" /></div>

</div>

<script type="text/javascript">
    jQuery(document).ready(function () {
        $('#leftbt').hide();
        var color = Chart.helpers.color;
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
                backgroundColor: '#FF8C00',
                borderColor: '#FF8C00',
                borderWidth: 1,
                data: [
					<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>
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
                backgroundColor: '#4682B4',
                borderColor: '#4682B4',
                borderWidth: 1,
                data: [
					<%= medain1 %>,<%= medain2 %>,<%= medain3 %>,<%= medain4 %>,<%= medain5 %>,<%= medain6 %>,<%= medain7 %>
                ]
            }]

        };

        var barChartData3 = {
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
					<%= sectormedain1 %>,<%= sectormedain2 %>,<%= sectormedain3 %>,<%= sectormedain4 %>,<%= sectormedain5 %>,<%= sectormedain6 %>,<%= sectormedain7 %>
                ]
            }]

         };
        //-------------------------------------------------------------------------

        var ctx = document.getElementById('container').getContext('2d');
        window.myBar = new Chart(ctx, {
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

        var ctx1 = document.getElementById('container1').getContext('2d');
        window.myBar = new Chart(ctx1, {
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

        var ctx2 = document.getElementById('container2').getContext('2d');
        window.myBar = new Chart(ctx2, {
            type: 'bar',
            data: barChartData3,
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
            jQuery('#rightbt').attr('attr-val', currentAttrValue);
            jQuery('#leftbt').attr('attr-val', currentAttrValue);
            // Show/Hide Tabs
            jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

            // Change/remove current tab to active
            jQuery(this).parent('li').addClass('active').siblings().removeClass('active');


            if (currentAttrValue === '#tab1') {
                $('#leftbt').hide();
            }

            if (currentAttrValue === '#tab2') {
                $('#leftbt').show();

            }

            if (currentAttrValue === '#tab3') {
                $('#leftbt').show();

            }
            e.preventDefault();


        });
        //next btn click
        jQuery('#rightbt').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('attr-val');
            // Change/remove current tab to active
            jQuery('.tabs .tab-links a').parent('li').siblings().removeClass('active');

            if (currentAttrValue == '#tab1') {
                $('#leftbt').show();
                jQuery(this).attr('attr-val', '#tab2');
                jQuery('#leftbt').attr('attr-val', '#tab2');
                jQuery('.tabs ' + '#tab2').show().siblings().hide();
                jQuery('#second').addClass('active')
            }
            if (currentAttrValue == '#tab2') {
                $('#leftbt').show();
                jQuery(this).attr('attr-val', '#tab3');
                jQuery('#leftbt').attr('attr-val', '#tab3');
                jQuery('.tabs ' + '#tab3').show().siblings().hide();
                jQuery('#third').addClass('active')

            }
            if (currentAttrValue == '#tab3') {
                window.location.href = "my-results-bar-graph-gap.aspx"
                //e.preventDefault();
            }

            // Show/Hide Tabs
            e.preventDefault();


        });


        //back btn click
        jQuery('#leftbt').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('attr-val');

            // Change/remove current tab to active
            jQuery('.tabs .tab-links a').parent('li').siblings().removeClass('active');

            if (currentAttrValue == '#tab1') {
                $('#leftbt').hide();
            }
            if (currentAttrValue == '#tab2') {
                $('#leftbt').hide();
                jQuery(this).attr('attr-val', '#tab1');
                jQuery('#rightbt').attr('attr-val', '#tab1');
                jQuery('.tabs ' + '#tab1').show().siblings().hide();
                jQuery('#first').addClass('active')
            }
            if (currentAttrValue == '#tab3') {
                $('#leftbt').show();
                jQuery(this).attr('attr-val', '#tab2');
                jQuery('#rightbt').attr('attr-val', '#tab2');
                jQuery('.tabs ' + '#tab2').show().siblings().hide();
                jQuery('#second').addClass('active')
            }
            e.preventDefault();
        });
    });




</script>
