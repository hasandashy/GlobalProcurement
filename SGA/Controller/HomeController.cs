using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Point = DotNet.Highcharts.Options.Point;
using DotNet.Highcharts;
using System.Data.SqlClient;
using System.Data;
using SGA.App_Code;
using System.Web.Security;

namespace SGA.Controller
{
    public class HomeController : System.Web.Mvc.Controller
    {
        [Authorize]
        public ActionResult Index(int? id) {
            

            const string NAME = "Topic marks";
            
            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSgaGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks=new string[8];
            string[] questionText = new string[8];
            object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[9];
            /*obj1.SetValue(0.00, 0);
            obj1.SetValue(0.00, 1);
            obj1.SetValue(0.60, 2);
            obj1.SetValue(0.40, 3);
            obj1.SetValue(0.40, 4);
            obj1.SetValue(1.39, 5);
            obj1.SetValue(0.60, 6);
            obj1.SetValue(0.40, 7);
            obj1.SetValue(1.39, 8);
             *  { 0.20,0.99,0.40,0.99,0.40,1.39,1.39,0.00,1.39 }
             *  { 0.40,0.79,0.2,0.00,0.00,0.79,0.20,1.39,1.39 }
             *  { 0.20,0.20,0.00,0.40,0.60,0.40,1.39,1.39,1.39 }
             *  { 1.38,0.40,0.40,0.40,0.40,0.60,1.39,0.40,0.00 }
             *  { 0.20,0.20,0.60,0.60,0.20,1.39,0.60,1.39,0.60 }
             *  { 0.20,0.79,0.99,0.60,0.00,1.39,1.39,0.20,0.20}
             *  { 0.60,0.40,0.20,1.39,0.00,0.60,1.39,0.00,1.39 } 
            */
            object[] obj2 = new object[9];
            object[] obj3 = new object[9];
            object[] obj4 = new object[9];
            object[] obj5 = new object[9];
            object[] obj6 = new object[9];
            object[] obj7 = new object[9];
            object[] obj8 = new object[9];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topicName"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicSGA", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        //topicMarks[i] = Topic.Tables[0].Rows[i]["topicmarks"].ToString(); used for showing only marks

                        topicMarks[i] = Topic.Tables[0].Rows[i]["percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Procurement Benchmark Assessment Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }

        [Authorize]
        public ActionResult SSAResult(int? id)
        {

            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSsaGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            //object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[9];
            
            object[] obj2 = new object[9];
            object[] obj3 = new object[9];
            object[] obj4 = new object[9];
            object[] obj5 = new object[9];
            object[] obj6 = new object[9];
            object[] obj7 = new object[9];
            object[] obj8 = new object[9];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topictitle"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicSSA", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        //topicMarks[i] = Topic.Tables[0].Rows[i]["topicmarks"].ToString();
                        topicMarks[i] = Topic.Tables[0].Rows[i]["percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else
            {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Skills Gap Test Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }

        [Authorize]
        public ActionResult BAResult(int? id)
        {

            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetBaGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            //object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[9];

            object[] obj2 = new object[9];
            object[] obj3 = new object[9];
            object[] obj4 = new object[9];
            object[] obj5 = new object[9];
            object[] obj6 = new object[9];
            object[] obj7 = new object[9];
            object[] obj8 = new object[9];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topictitle"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicBA", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        //topicMarks[i] = Topic.Tables[0].Rows[i]["topicmarks"].ToString(); 
                        topicMarks[i] = Topic.Tables[0].Rows[i]["Percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["Percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else
            {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Behavioural Assessment Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }

        [Authorize]
        public ActionResult NPResult(int? id)
        {

            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetNPGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            //object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[9];

            object[] obj2 = new object[9];
            object[] obj3 = new object[9];
            object[] obj4 = new object[9];
            object[] obj5 = new object[9];
            object[] obj6 = new object[9];
            object[] obj7 = new object[9];
            object[] obj8 = new object[9];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topictitle"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicNP", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        //topicMarks[i] = Topic.Tables[0].Rows[i]["topicmarks"].ToString();
                        topicMarks[i] = Topic.Tables[0].Rows[i]["percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else
            {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Negotiation Profile Assessment Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }

        [Authorize]
        public ActionResult MPResult(int? id)
        {

            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetMPGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            //object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[9];

            object[] obj2 = new object[9];
            object[] obj3 = new object[9];
            object[] obj4 = new object[9];
            object[] obj5 = new object[9];
            object[] obj6 = new object[9];
            object[] obj7 = new object[9];
            object[] obj8 = new object[9];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topictitle"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicMP", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        topicMarks[i] = Topic.Tables[0].Rows[i]["percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else
            {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Maturity Profile Assessment Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }


        [Authorize]
        public ActionResult CMAResult(int? id)
        {

            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetCMAGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            //object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[3];

            object[] obj2 = new object[3];
            object[] obj3 = new object[3];
            object[] obj4 = new object[3];
            object[] obj5 = new object[3];
            object[] obj6 = new object[3];
            object[] obj7 = new object[3];
            object[] obj8 = new object[3];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topictitle"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicCMA", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        //topicMarks[i] = Topic.Tables[0].Rows[i]["topicmarks"].ToString();
                        topicMarks[i] = Topic.Tables[0].Rows[i]["percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else
            {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Contract Management Assessment Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }

        [Authorize]
        public ActionResult CompareResult()
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userId", SGACommon.LoginUserInfo.userId);
            DataSet ds = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetUsersByCompany", param);

            ViewData["ds"] = ds;
            ViewData["message"] = "";
            ViewData["users"] = null;
            ViewData["assessment"] = null;
            ViewData["jobrole"] = null;
            Highcharts chart = null;
            /*Highcharts chart = new Highcharts("chart")
                 .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                 .SetTitle(new Title { Text = "Monthly Average Rainfall" })
                 .SetSubtitle(new Subtitle { Text = "Source: WorldClimate.com" })
                 .SetXAxis(new XAxis { Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } })
                 .SetYAxis(new YAxis
                 {
                     Min = 0,
                     Title = new YAxisTitle { Text = "Rainfall (mm)" }
                 })
                 .SetLegend(new Legend
                 {
                     Layout = Layouts.Vertical,
                     Align = HorizontalAligns.Left,
                     VerticalAlign = VerticalAligns.Top,
                     X = 100,
                     Y = 70,
                     Floating = true,
                     BackgroundColor = ColorTranslator.FromHtml("#FFFFFF"),
                     Shadow = true
                 })
                 .SetTooltip(new Tooltip { Formatter = @"function() { return ''+ this.x +': '+ this.y +' mm'; }" })
                 .SetPlotOptions(new PlotOptions
                 {
                     Column = new PlotOptionsColumn
                     {
                         PointPadding = 0.2,
                         BorderWidth = 0
                     }
                 })
                 .SetSeries(new[]
                           {
                               new Series { Name = "Tokyo", Data = new Data(new object[] { 49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 }) },
                               new Series { Name = "London", Data = new Data(new object[] { 48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2 }) },
                               new Series { Name = "New York", Data = new Data(new object[] { 83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0, 104.3, 91.2, 83.5, 106.6, 92.3 }) },
                               new Series { Name = "Berlin", Data = new Data(new object[] { 42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1 }) }
                           });*/

            return View(chart);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CompareResult(FormCollection frm)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userId", SGACommon.LoginUserInfo.userId);
            DataSet ds = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetUsersByCompany", param);
            Highcharts chart = null;
            ViewData["ds"] = ds;
            ViewData["message"] = "";
            ViewData["users"] = Request["user"];
            ViewData["assessment"] = Request["AssessmentType"];
            ViewData["jobrole"] = Request["jobRole"];
            if (Request["user"] == null) {
                ViewData["message"] = "Select at least a user to view compare results";
            }
            else if (Request["AssessmentType"] == null || Request["AssessmentType"] == "0")
            {
                ViewData["message"] = "Select assessment type to compare";
            }
            else {
                string[] topicNames = new string[8];
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@userIds", Request["user"].ToString());
                param[1] = new SqlParameter("@type", Request["AssessmentType"].ToString());
                param[2] = new SqlParameter("@jobroleId", Request["jobRole"].ToString());
                string testIds = DataTier.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetTestsIdByType", param).ToString();
                
                if (testIds.Length > 0) {
                    string[] testId = testIds.Split(',');
                    object[] obj1 = new object[8];
                    Series[] ser1 = new Series[testId.Length];
                    if (testId.Length > 0) {
                        for (int i = 0; i < testId.Length; i++) {
                            SqlParameter[] sqlParamTopic = new SqlParameter[1];
                            sqlParamTopic[0] = new SqlParameter("@testId", testId[i]);

                            DataSet Topic=null;
                            if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 1) {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSsaGraph", sqlParamTopic);
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 2)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetBaGraph", sqlParamTopic);
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 3)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetNpGraph", sqlParamTopic);
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 4)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetMPGraph", sqlParamTopic);
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 5)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetCMAGraph", sqlParamTopic);
                            }
                            
                            if (i == 0) {
                                for (int j = 0; j < Topic.Tables[0].Rows.Count; j++)
                                {
                                    topicNames[j] = Topic.Tables[0].Rows[j]["topicTitle"].ToString().Replace("<br />", " ");
                                }
                            }

                            ser1[i] = new Series { Name = HttpUtility.JavaScriptStringEncode(Topic.Tables[0].Rows[0]["name"].ToString()), Data = new Data(new object[] { Convert.ToDouble(Topic.Tables[0].Rows[0]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[1]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[2]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[3]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[4]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[5]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[6]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[7]["percentage"].ToString()) }) };


                        }
                    }

                    chart = new Highcharts("chart")
                   .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                   .SetTitle(new Title { Text = "Compare Result (Percentage based)" })
                   .SetSubtitle(new Subtitle { Text = "Source: SkillsGapAnalysis" })
                   .SetXAxis(new XAxis { Categories = topicNames })
                   .SetYAxis(new YAxis
                   {
                       Min = 0,
                       Title = new YAxisTitle { Text = "Score (Percentage)" }
                   })
                   .SetLegend(new Legend
                   {
                       Layout = Layouts.Vertical,
                       Align = HorizontalAligns.Left,
                       VerticalAlign = VerticalAligns.Top,
                       X = 100,
                       Y = 70,
                       Floating = true,
                       BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                       Shadow = true
                   })
                   .SetTooltip(new Tooltip { Formatter = @"function() { return ''+ this.x +': '+ this.y +' %'; }" })
                   .SetPlotOptions(new PlotOptions
                   {
                       Column = new PlotOptionsColumn
                       {
                           PointPadding = 0.2,
                           BorderWidth = 0
                       }
                   })
                   .SetSeries(ser1);
                   

                }
            }
            return View(chart);


        }

        [Authorize]
        public ActionResult SCSAResult(int? id)
        {

            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetScsaGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            //object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[9];

            object[] obj2 = new object[9];
            object[] obj3 = new object[9];
            object[] obj4 = new object[9];
            object[] obj5 = new object[9];
            object[] obj6 = new object[9];
            object[] obj7 = new object[9];
            object[] obj8 = new object[9];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topictitle"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicSCSA", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        //topicMarks[i] = Topic.Tables[0].Rows[i]["topicmarks"].ToString();
                        topicMarks[i] = Topic.Tables[0].Rows[i]["percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else
            {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Supply Chain Self Assessment Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }

        [Authorize]
        public ActionResult SCKEResult(int? id)
        {


            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[1];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSCKEGraph", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

            object[] obj1 = new object[9];
            /*obj1.SetValue(0.00, 0);
            obj1.SetValue(0.00, 1);
            obj1.SetValue(0.60, 2);
            obj1.SetValue(0.40, 3);
            obj1.SetValue(0.40, 4);
            obj1.SetValue(1.39, 5);
            obj1.SetValue(0.60, 6);
            obj1.SetValue(0.40, 7);
            obj1.SetValue(1.39, 8);
             *  { 0.20,0.99,0.40,0.99,0.40,1.39,1.39,0.00,1.39 }
             *  { 0.40,0.79,0.2,0.00,0.00,0.79,0.20,1.39,1.39 }
             *  { 0.20,0.20,0.00,0.40,0.60,0.40,1.39,1.39,1.39 }
             *  { 1.38,0.40,0.40,0.40,0.40,0.60,1.39,0.40,0.00 }
             *  { 0.20,0.20,0.60,0.60,0.20,1.39,0.60,1.39,0.60 }
             *  { 0.20,0.79,0.99,0.60,0.00,1.39,1.39,0.20,0.20}
             *  { 0.60,0.40,0.20,1.39,0.00,0.60,1.39,0.00,1.39 } 
            */
            object[] obj2 = new object[9];
            object[] obj3 = new object[9];
            object[] obj4 = new object[9];
            object[] obj5 = new object[9];
            object[] obj6 = new object[9];
            object[] obj7 = new object[9];
            object[] obj8 = new object[9];

            if (Topic != null)
            {


                for (int i = 0; i < Topic.Tables[0].Rows.Count; i++)
                {
                    strTopic += Topic.Tables[0].Rows[i]["topicName"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicSCKE", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        //topicMarks[i] = Topic.Tables[0].Rows[i]["topicmarks"].ToString(); used for showing only marks

                        topicMarks[i] = Topic.Tables[0].Rows[i]["percentage"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["percentage"]), j);
                                    break;
                            }


                            //strMarks += QuestionByTopic.Tables[0].Rows[j]["marks"].ToString()+",";
                        }

                        strQuestion = SGACommon.RemoveLastCharacter(strQuestion);
                        strMarks = SGACommon.RemoveLastCharacter(strMarks);
                        questionText[i] = strQuestion;


                        strQuestion = "";
                        strMarks = "";

                    }
                }
                strTopic = SGACommon.RemoveLastCharacter(strTopic);
            }
            else
            {
                Response.Redirect("~/webadmin/listusers.aspx", false);
            }
            string[] categories = strTopic.Split(',');
            //object[] obj = new object[] { 10.85, 7.35, 33.06, 2.81 };

            //string[] categories = new[] { "MSIE", "Firefox", "Chrome", "Safari", "Opera" };
            //const string NAME = "Browser brands";
            //Data data = null;
            Data data = new Data(new[]
                                 {
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[0]),
                                         Color = Color.FromName("colors[0]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[0],
                                                         Categories = questionText[0].Split('#'),
                                                         Data = new Data(obj1),
                                                         Color = Color.FromName("colors[0]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[1]),
                                         Color = Color.FromName("colors[1]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[1],
                                                         Categories = questionText[1].Split('#'),
                                                         Data = new Data(obj2),
                                                         Color = Color.FromName("colors[1]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[2]),
                                         Color = Color.FromName("colors[2]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[2],
                                                         Categories = questionText[2].Split('#'),
                                                         Data = new Data(obj3),
                                                         Color = Color.FromName("colors[2]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[3]),
                                         Color = Color.FromName("colors[3]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[3],
                                                         Categories = questionText[3].Split('#'),
                                                         Data = new Data(obj4),
                                                         Color = Color.FromName("colors[3]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[4]),
                                         Color = Color.FromName("colors[4]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[4],
                                                         Categories = questionText[4].Split('#'),
                                                         Data = new Data(obj5),
                                                         Color = Color.FromName("colors[4]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[5]),
                                         Color = Color.FromName("colors[5]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[5],
                                                         Categories = questionText[5].Split('#'),
                                                         Data = new Data(obj6),
                                                         Color = Color.FromName("colors[5]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[6]),
                                         Color = Color.FromName("colors[6]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[6],
                                                         Categories = questionText[6].Split('#'),
                                                         Data = new Data(obj7),
                                                         Color = Color.FromName("colors[6]")
                                                     }
                                     },
                                     new Point
                                     {
                                         Y = Convert.ToDouble(topicMarks[7]),
                                         Color = Color.FromName("colors[7]"),
                                         Drilldown = new Drilldown
                                                     {
                                                         Name = categories[7],
                                                         Categories = questionText[7].Split('#'),
                                                         Data = new Data(obj8),
                                                         Color = Color.FromName("colors[7]")
                                                     }
                                     }
                                 });

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Procurement Benchmark Assessment Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Percentage per topic" } })
                .SetLegend(new Legend { Enabled = true })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        Cursor = Cursors.Pointer,
                        Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Color = Color.FromName("colors[0]"),
                            Formatter = "function() { return this.y; }",
                            Style = "fontWeight: 'bold'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = NAME,
                    Data = data,
                    Color = Color.White
                })
                .SetExporting(new Exporting { Enabled = true })
                .AddJavascripFunction(
                    "TooltipFormatter",
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b>%<br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics';
                      } else {
                        s += 'Click to return to Topics';
                      }
                      return s;"
                )
                .AddJavascripFunction(
                    "ColumnPointClick",
                    @"var drilldown = this.drilldown;
                      if (drilldown) { // drill down
                        setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                      } else { // restore
                        setChart(name, categories, data.data);
                      }"
                )
                .AddJavascripFunction(
                    "setChart",
                    @"chart.xAxis[0].setCategories(categories);
                      chart.series[0].remove();
                      chart.addSeries({
                         name: name,
                         data: data,
                         color: color || 'white'
                      });",
                    "name", "categories", "data", "color"
                )
                .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                .AddJavascripVariable("name", "'{0}'".FormatWith(NAME))
                .AddJavascripVariable("categories", JsonSerializer.Serialize(categories))
                .AddJavascripVariable("data", JsonSerializer.Serialize(data));

            return View(chart);
        }

        [HttpPost]
        public JsonResult GetTopicsByTest(int id) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@assessmentType", id);
            DataSet ds = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetTopicByTest", param);

            var myData = ds.Tables[0].AsEnumerable().Select(r => new Topic
            {
                topicTitle = r.Field<string>("topicTitle"),
                topicId = r.Field<int>("topicId")
            });

            JsonResult result = new JsonResult();

            result.Data = myData.ToList();

            return result;

        }

        [Authorize]
        public ActionResult ReviewResult()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userId", SGACommon.LoginUserInfo.userId);
            DataSet ds = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetUsersByCompany", param);

            ViewData["ds"] = ds;
            ViewData["message"] = "";
            ViewData["users"] = null;
            ViewData["assessment"] = null;
            ViewData["jobrole"] = null;
            Highcharts chart = null;
            return View(chart);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ReviewResult(FormCollection frm)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userId", SGACommon.LoginUserInfo.userId);
            DataSet ds = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetUsersByCompany", param);
            Highcharts chart = null;
            ViewData["ds"] = ds;
            ViewData["message"] = "";
            ViewData["users"] = Request["user"];
            ViewData["assessment"] = Request["AssessmentType"];
            ViewData["jobrole"] = Request["jobRole"];
            if (Request["user"] == null)
            {
                ViewData["message"] = "Select at least a user to view compare results";
            }
            else if (Request["AssessmentType"] == null || Request["AssessmentType"] == "0")
            {
                ViewData["message"] = "Select assessment type to compare";
            }
            else
            {
                string[] topicNames = new string[8];
                param = new SqlParameter[3];
                param[0] = new SqlParameter("@userIds", Request["user"].ToString());
                param[1] = new SqlParameter("@type", Request["AssessmentType"].ToString());
                param[2] = new SqlParameter("@jobroleId", Request["jobRole"].ToString());
                string testIds = DataTier.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetTestsIdByType", param).ToString();

                if (testIds.Length > 0)
                {
                    string[] testId = testIds.Split(',');
                    object[] obj1 = new object[8];
                    Series[] ser1 = new Series[testId.Length * 2];
                    if (testId.Length > 0)
                    {
                        for (int i = 0; i < testId.Length; i++)
                        {
                            SqlParameter[] sqlParamTopic = new SqlParameter[1];
                            sqlParamTopic[0] = new SqlParameter("@testId", testId[i]);

                            DataSet Topic = null;
                            DataSet TopicReviewed = null;
                            if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 1)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSsaGraph", sqlParamTopic);
                                TopicReviewed = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSsaGraphReviewed", sqlParamTopic);
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 2)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetBaGraph", sqlParamTopic);
                                TopicReviewed = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetBaGraphReviewed", sqlParamTopic);
                                //spGetBaGraphReviewed
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 3)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetNpGraph", sqlParamTopic);
                                TopicReviewed = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetNPGraphReviewed", sqlParamTopic);
                                //spGetNPGraphReviewed
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 4)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetMPGraph", sqlParamTopic);
                                TopicReviewed = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetMpGraphReviewed", sqlParamTopic);
                                //spGetMpGraphReviewed
                            }
                            else if (Convert.ToInt32(Request["AssessmentType"].ToString()) == 5)
                            {
                                Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetCMAGraph", sqlParamTopic);
                                TopicReviewed = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetCMAGraphReviewed", sqlParamTopic);
                                //spGetMpGraphReviewed
                            }

                            if (i == 0)
                            {
                                for (int j = 0; j < Topic.Tables[0].Rows.Count; j++)
                                {
                                    topicNames[j] = Topic.Tables[0].Rows[j]["topicTitle"].ToString().Replace("<br />", " ");
                                }
                                ser1[i] = new Series { Name = HttpUtility.JavaScriptStringEncode(Topic.Tables[0].Rows[0]["name"].ToString()), Data = new Data(new object[] { Convert.ToDouble(Topic.Tables[0].Rows[0]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[1]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[2]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[3]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[4]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[5]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[6]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[7]["percentage"].ToString()) }) };
                                ser1[i + 1] = new Series { Name = HttpUtility.JavaScriptStringEncode(TopicReviewed.Tables[0].Rows[0]["name"].ToString()), Data = new Data(new object[] { Convert.ToDouble(TopicReviewed.Tables[0].Rows[0]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[1]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[2]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[3]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[4]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[5]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[6]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[7]["percentage"].ToString()) }) };
                            }
                            else {
                                int k = i + 1;
                                ser1[k] = new Series { Name = HttpUtility.JavaScriptStringEncode(Topic.Tables[0].Rows[0]["name"].ToString()), Data = new Data(new object[] { Convert.ToDouble(Topic.Tables[0].Rows[0]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[1]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[2]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[3]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[4]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[5]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[6]["percentage"].ToString()), Convert.ToDouble(Topic.Tables[0].Rows[7]["percentage"].ToString()) }) };
                                ser1[k + 1] = new Series { Name = HttpUtility.JavaScriptStringEncode(TopicReviewed.Tables[0].Rows[0]["name"].ToString()), Data = new Data(new object[] { Convert.ToDouble(TopicReviewed.Tables[0].Rows[0]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[1]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[2]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[3]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[4]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[5]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[6]["percentage"].ToString()), Convert.ToDouble(TopicReviewed.Tables[0].Rows[7]["percentage"].ToString()) }) };
                            }

                        }
                    }

                    chart = new Highcharts("chart")
                   .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                   .SetTitle(new Title { Text = "Compare Result (Percentage based)" })
                   .SetSubtitle(new Subtitle { Text = "Source: SkillsGapAnalysis" })
                   .SetXAxis(new XAxis { Categories = topicNames })
                   .SetYAxis(new YAxis
                   {
                       Min = 0,
                       Title = new YAxisTitle { Text = "Score (Percentage)" }
                   })
                   .SetLegend(new Legend
                   {
                       Layout = Layouts.Vertical,
                       Align = HorizontalAligns.Left,
                       VerticalAlign = VerticalAligns.Top,
                       X = 100,
                       Y = 70,
                       Floating = true,
                       BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                       Shadow = true
                   })
                   .SetTooltip(new Tooltip { Formatter = @"function() { return ''+ this.x +': '+ this.y +' %'; }" })
                   .SetPlotOptions(new PlotOptions
                   {
                       Column = new PlotOptionsColumn
                       {
                           PointPadding = 0.2,
                           BorderWidth = 0
                       }
                   })
                   .SetSeries(ser1);
                }
            }

            return View(chart);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            //Response.Redirect("~/index.aspx", false);
            return Redirect("~/index.aspx");
            //Response.Redirect("~/index.aspx", false);
        }
    }
}