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
using SGA.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace SGA.Controller
{
    public class TnaResultController : System.Web.Mvc.Controller
    {
        public ActionResult Index(int? id)
        {
            SGACommon.IsViewResult("viewTnaResult");

            const string NAME = "Topic marks";

            SqlParameter[] sqlParamTopic = new SqlParameter[2];
            sqlParamTopic[0] = new SqlParameter("@testId", id.Value);
            sqlParamTopic[1] = new SqlParameter("@username", SGACommon.LoginUserInfo.name);

            DataSet Topic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetTestTopicsTna", sqlParamTopic);

            //Data data =null;
            string strTopic = "";
            string strQuestion = "";
            string strMarks = "";
            string[] topicMarks = new string[8];
            string[] questionText = new string[8];
            //object value = "0.00,0.00,0.60,0.40,0.40,1.39,0.60,0.40,1.39";

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
                    strTopic += Topic.Tables[0].Rows[i]["topic"].ToString().Replace("'", "\\'") + ",";

                    SqlParameter[] sqlParamTopicInner = new SqlParameter[2];
                    sqlParamTopicInner[0] = new SqlParameter("@testId", id.Value);
                    sqlParamTopicInner[1] = new SqlParameter("@topicId", Topic.Tables[0].Rows[i]["topicId"].ToString());


                    DataSet QuestionByTopic = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetQuestionByTopicTna", sqlParamTopicInner);

                    if (QuestionByTopic != null)
                    {

                        topicMarks[i] = Topic.Tables[0].Rows[i]["marks"].ToString();

                        for (int j = 0; j < QuestionByTopic.Tables[0].Rows.Count; j++)
                        {
                            strQuestion += QuestionByTopic.Tables[0].Rows[j]["questionName"].ToString().Replace("'", "\\'") + "#";
                            //strQuestion += "Question1#";


                            switch (i)
                            {
                                case 0:
                                    obj1.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
                                    break;
                                case 1:
                                    obj2.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
                                    break;
                                case 2:
                                    obj3.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
                                    break;
                                case 3:
                                    obj4.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
                                    break;
                                case 4:
                                    obj5.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
                                    break;
                                case 5:
                                    obj6.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
                                    break;
                                case 6:
                                    obj7.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
                                    break;
                                case 7:
                                    obj8.SetValue(Convert.ToDouble(QuestionByTopic.Tables[0].Rows[j]["marks"]), j);
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
                Response.Redirect("default.aspx", false);
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
                .SetTitle(new Title { Text = "Training needs analysis Result" })
                .SetSubtitle(new Subtitle { Text = "Click the columns to view questions per topic. Click again to view Topics." })
                .SetXAxis(new XAxis { Categories = categories })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Total marks per topic" } })
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
                    @"var point = this.point, s = this.x +':<b>'+ this.y +'</b><br/>';
                      if (point.drilldown) {
                        s += 'Click to view '+ point.category +' Topics question';
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
    }
}