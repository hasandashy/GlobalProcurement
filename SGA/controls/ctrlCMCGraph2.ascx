<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCMCGraph2.ascx.cs" Inherits="SGA.controls.ctrlCMCGraph2" %>
 <script src="../js/plotly-latest.min.js"></script>

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

                    <div class="dis-block clearfix  graph">
                          <div id="container"></div>
                    </div>
                </div>

                <div id="tab2" class="tab">
                    <div class="question-heading">
                        <i>02</i> <span>In the graph below you can see a benchmark of your result against users in the same country
                        </span>
                        <div class="redtitle"></div>
                    </div>

                    <div class="dis-block clearfix marT3 graph">
                          <div id="container1"></div>
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
       
        var trace1 = {
            x: ['<%= topic1name %>',
                     '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
            y: [<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>],
            name: 'Your Marks',
            type: 'bar'
        };

        var trace2 = {
            x: ['<%= topic1name %>',
                            '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
            y: [<%= medain1 %>,<%= medain2 %>,<%= medain3 %>,<%= medain4 %>,<%= medain5 %>,<%= medain6 %>,<%= medain7 %>],
            name: 'Average Marks',
            type: 'bar'
        };

        var data = [trace1, trace2];

        var layout = {
            barmode: 'group',
            autosize: true // set autosize to rescale
        };

        Plotly.newPlot('container', data, layout);


        jQuery('.tabs .tab-links a').on('click', function (e) {
            var currentAttrValue = jQuery(this).attr('href');
            jQuery('.rightbt').attr('href', currentAttrValue);
            jQuery('.leftbt').attr('href', currentAttrValue);
            // Show/Hide Tabs
            jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

            // Change/remove current tab to active
            jQuery(this).parent('li').addClass('active').siblings().removeClass('active');
          

            if (currentAttrValue === '#tab2') {
                var trace3 = {
                    x: ['<%= topic1name %>',
                             '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
                    y: [<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>],
                    name: 'Your Marks',
                    type: 'bar'
                };

                var trace4 = {
                    x: ['<%= topic1name %>',
                            '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
                     y: [<%= countrymedain1 %>,<%= countrymedain2 %>,<%= countrymedain3 %>,<%= countrymedain4 %>,<%= countrymedain5 %>,<%= countrymedain6 %>,<%= countrymedain7 %>],
                     name: 'Average Marks',
                     type: 'bar'
                 };

                 var data = [trace3, trace4];

                 var layout = {
                     barmode: 'group',
                     autosize: true // set autosize to rescale
                 };

                 Plotly.newPlot('container1', data, layout);

            }

            if (currentAttrValue === '#tab3') {
                Plotly.d3.csv('https://raw.githubusercontent.com/plotly/datasets/master/2014_world_gdp_with_codes.csv', function (err, rows) {
                    function unpack(rows, key) {
                        return rows.map(function (row) { return row[key]; });
                    }

                    var data = [{
                        type: 'choropleth',
                        locations: unpack(rows, 'CODE'),
                        z: unpack(rows, 'GDP (BILLIONS)'),
                        text: unpack(rows, 'COUNTRY'),
                        colorscale: [
                            [0, 'rgb(5, 10, 172)'], [0.35, 'rgb(40, 60, 190)'],
                            [0.5, 'rgb(70, 100, 245)'], [0.6, 'rgb(90, 120, 245)'],
                            [0.7, 'rgb(106, 137, 247)'], [1, 'rgb(220, 220, 220)']],
                        autocolorscale: false,
                        reversescale: true,
                        marker: {
                            line: {
                                color: 'rgb(180,180,180)',
                                width: 0.5
                            }
                        },
                        tick0: 0,
                        zmin: 0,
                        dtick: 1000,
                        colorbar: {
                            autotic: false,
                            tickprefix: '$',
                            title: 'GDP Billions US$'
                        }
                    }];

                    var layout = {
                        title: '2014 Global GDP',
                        geo: {
                            showframe: false,
                            showcoastlines: false,
                            projection: {
                                type: 'mercator'
                            }
                        },
                        autosize:true
                    };
                    Plotly.plot('container2', data, layout, { showLink: false });
                });
            }
            e.preventDefault();
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






            if (currentAttrValue === '#tab1') {
                var trace3 = {
                    x: ['<%= topic1name %>',
                              '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
                     y: [<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>],
                     name: 'Your Marks',
                     type: 'bar'
                 };

                 var trace4 = {
                     x: ['<%= topic1name %>',
                            '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
                     y: [<%= countrymedain1 %>,<%= countrymedain2 %>,<%= countrymedain3 %>,<%= countrymedain4 %>,<%= countrymedain5 %>,<%= countrymedain6 %>,<%= countrymedain7 %>],
                     name: 'Average Marks',
                     type: 'bar'
                 };

                 var data = [trace3, trace4];

                 var layout = {
                     barmode: 'group',
                     autosize: true // set autosize to rescale
                 };

                 Plotly.newPlot('container1', data, layout);
            }
            if (currentAttrValue === '#tab2') {
                Plotly.d3.csv('https://raw.githubusercontent.com/plotly/datasets/master/2014_world_gdp_with_codes.csv', function (err, rows) {
                    function unpack(rows, key) {
                        return rows.map(function (row) { return row[key]; });
                    }

                    var data = [{
                        type: 'choropleth',
                        locations: unpack(rows, 'CODE'),
                        z: unpack(rows, 'GDP (BILLIONS)'),
                        text: unpack(rows, 'COUNTRY'),
                        colorscale: [
                            [0, 'rgb(5, 10, 172)'], [0.35, 'rgb(40, 60, 190)'],
                            [0.5, 'rgb(70, 100, 245)'], [0.6, 'rgb(90, 120, 245)'],
                            [0.7, 'rgb(106, 137, 247)'], [1, 'rgb(220, 220, 220)']],
                        autocolorscale: false,
                        reversescale: true,
                        marker: {
                            line: {
                                color: 'rgb(180,180,180)',
                                width: 0.5
                            }
                        },
                        tick0: 0,
                        zmin: 0,
                        dtick: 1000,
                        colorbar: {
                            autotic: false,
                            tickprefix: '$',
                            title: 'GDP Billions US$'
                        }
                    }];

                    var layout = {
                        title: '2014 Global GDP Source',
                        geo: {
                            showframe: false,
                            showcoastlines: false,
                            projection: {
                                type: 'mercator'
                            },
                            autosize:true
                        }
                    };
                    Plotly.plot('container2', data, layout, { showLink: false });
                });
            }
            e.preventDefault();
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
                jQuery(this).attr('href', '#tab3');
                jQuery('.rightbt').attr('href', '#tab3');
                jQuery('.tabs ' + '#tab3').show().siblings().hide();
                jQuery('#third').addClass('active')
            }
            if (currentAttrValue == '#tab3') {
                jQuery(this).attr('href', '#tab2');
                jQuery('.rightbt').attr('href', '#tab2');
                jQuery('.tabs ' + '#tab2').show().siblings().hide();
                jQuery('#second').addClass('active')
            }
            // Show/Hide Tabs
            if (currentAttrValue === '#tab3') {
                var trace3 = {
                    x: ['<%= topic1name %>',
                              '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
                     y: [<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>],
                     name: 'Your Marks',
                     type: 'bar'
                 };

                 var trace4 = {
                     x: ['<%= topic1name %>',
                            '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
                     y: [<%= countrymedain1 %>,<%= countrymedain2 %>,<%= countrymedain3 %>,<%= countrymedain4 %>,<%= countrymedain5 %>,<%= countrymedain6 %>,<%= countrymedain7 %>],
                     name: 'Average Marks',
                     type: 'bar'
                 };

                 var data = [trace3, trace4];

                 var layout = {
                     barmode: 'group',
                     autosize: true // set autosize to rescale
                 };

                 Plotly.newPlot('container1', data, layout);
            }
            if (currentAttrValue === '#tab2') {
                 var trace1 = {
            x: ['<%= topic1name %>',
                     '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
            y: [<%= topic1mark %>,<%= topic2mark %>,<%= topic3mark %>,<%= topic4mark %>,<%= topic5mark %>,<%= topic6mark %>,<%= topic7mark %>],
            name: 'Your Marks',
            type: 'bar'
        };

        var trace2 = {
            x: ['<%= topic1name %>',
                            '<%= topic2name %>',
                            '<%= topic3name %>',
                            '<%= topic4name %>',
                            '<%= topic5name %>',
                            '<%= topic6name %>',
                            '<%= topic7name %>'],
            y: [<%= medain1 %>,<%= medain2 %>,<%= medain3 %>,<%= medain4 %>,<%= medain5 %>,<%= medain6 %>,<%= medain7 %>],
            name: 'Average Marks',
            type: 'bar'
        };

        var data = [trace1, trace2];

        var layout = {
            barmode: 'group',
            autosize: true // set autosize to rescale
        };

        Plotly.newPlot('container', data, layout);
            }
            e.preventDefault();
        });

        window.onresize = function () {
            window.onresize = function () {
                var currentAttrValue = jQuery('.rightbt').attr('href');
                Plotly.Plots.resize('container');
                var window_height = window.innerHeight;
                var content_div_height = document.getElementById('container').offsetHeight;
                // workaround for bug in Plotly: when flexbox container gets smaller, graph does not shrink
                if (content_div_height > (window_height - 40)) {
                    var svg_container = document.getElementById('container').getElementsByClassName('plot-container')[0].getElementsByClassName('svg-container')[0];
                    svg_container.style.height = (window_height - 40) + 'px';
                    Plotly.Plots.resize(gd);
                }

                if (currentAttrValue === '#tab2') {
                    Plotly.Plots.resize('container1');
                    var window_height = window.innerHeight;
                    var content_div_height = document.getElementById('container1').offsetHeight;
                    // workaround for bug in Plotly: when flexbox container gets smaller, graph does not shrink
                    if (content_div_height > (window_height - 40)) {
                        var svg_container = document.getElementById('container1').getElementsByClassName('plot-container')[0].getElementsByClassName('svg-container')[0];
                        svg_container.style.height = (window_height - 40) + 'px';
                        Plotly.Plots.resize(gd);
                    }
                }
                if (currentAttrValue === '#tab3') {
                    Plotly.Plots.resize('container2');
                    var window_height = window.innerHeight;
                    var content_div_height = document.getElementById('container2').offsetHeight;
                    // workaround for bug in Plotly: when flexbox container gets smaller, graph does not shrink
                    if (content_div_height > (window_height - 40)) {
                        var svg_container = document.getElementById('container2').getElementsByClassName('plot-container')[0].getElementsByClassName('svg-container')[0];
                        svg_container.style.height = (window_height - 40) + 'px';
                        Plotly.Plots.resize(gd);
                    }
                }
            };
          
        };
    });



</script>
