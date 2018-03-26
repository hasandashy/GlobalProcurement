using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Web;

namespace SGA.App_Code
{
    public static class iTextHelperFunctionDMP
    {
        /*private static BaseFont tradeGothic = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/fonts/") + "tradegothicltstd-cn18.ttf", "Cp1250", true);

        private static BaseFont Avenir = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/fonts/") + "Avenir-Light.ttf", "Cp1250", true);

        private static BaseFont kalavika = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/fonts/") + "klavika-regular-webfont.ttf", "Cp1250", true);

        private static BaseFont kalavika_lightplain = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/fonts/") + "klavika_light_plain.ttf", "Cp1250", true);*/

        private static BaseFont Arial = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/fonts/") + "arial.ttf", BaseFont.CP1252, false);

        private static BaseColor hcolor = new BaseColor(234, 66, 31);

        private static BaseColor bcolor = new BaseColor(0, 0, 0);

        private static BaseColor wcolor = new BaseColor(255, 255, 255);

        private static BaseColor sendTableBorderColor = new BaseColor(243, 242, 239);

        private static BaseColor tablebackcolor = new BaseColor(246, 243, 244);

        private static BaseColor tableborcolor = new BaseColor(246, 243, 244);

        private static BaseColor tablelitebackcolor = new BaseColor(221, 218, 213);

        private static BaseColor tableliteborcolor = new BaseColor(255, 255, 255);

        public static void AddDMAInnerPaddingRow(ref PdfPTable tab, string lefttext, string middletext, string righttext, int fontSize = 12, bool isBold = true, bool isBackground = true, bool isPadding = false)
        {
            //Chunk tc = new Chunk(">", new Font(iTextHelperFunction.Avenir, (float)fontSize, 0, new BaseColor(243, 48, 120)));
            Chunk tc2 = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(0, 0, 0)));
            PdfPCell cell = new PdfPCell(new Phrase
            {

                tc2
            });
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
                cell.PaddingLeft = 85f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc2 = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc2
            });
            cell.BorderColor = new BaseColor(255, 255, 255);
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc2 = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc2
            });
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
                cell.PaddingRight = 20f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.HorizontalAlignment = 2;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
        }

        public static void AddrowHeader(ref PdfPTable tab, string lefttext, string centertext1, string centertext2, string centertext3, string centertext4, string righttext)
        {
            Chunk tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, 12f, 1, new BaseColor(255, 255, 255)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(centertext1, new Font(iTextHelperFunctionDMP.Arial, 12f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(centertext2, new Font(iTextHelperFunctionDMP.Arial, 12f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(centertext3, new Font(iTextHelperFunctionDMP.Arial, 12f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(centertext4, new Font(iTextHelperFunctionDMP.Arial, 12f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, 12f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
        }
        public static void AddAssignmentRowTable(ref PdfPTable tab, string lefttext, string middletext1, string middletext2, string middletext3, string middletext4, string righttext, int fontSize = 12, bool isBold = true, bool isBackground = true, bool isPadding = false)
        {
            Chunk tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.HorizontalAlignment = 0;
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk(middletext1, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.HorizontalAlignment = 0;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            //cell.HorizontalAlignment = 1;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk(middletext2, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.HorizontalAlignment = 0;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            //cell.HorizontalAlignment = 1;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk(middletext3, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.HorizontalAlignment = 0;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            //cell.HorizontalAlignment = 1;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk(middletext4, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.HorizontalAlignment = 0;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            //cell.HorizontalAlignment = 1;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.HorizontalAlignment = 0;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            //cell.HorizontalAlignment = 0;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 1f;
            tab.AddCell(cell);
        }


        public static PdfPTable GetTable(int columns)
        {
            return new PdfPTable(columns)
            {
                TotalWidth = 500f,
                LockedWidth = true,
                HorizontalAlignment = 0
            };
        }

        public static PdfPTable GetTable(int columns, float width)
        {
            return new PdfPTable(columns)
            {
                TotalWidth = width,
                LockedWidth = true,
                HorizontalAlignment = 1
            };
        }

        public static void Addrow(ref PdfPTable tab, string lefttext, string righttext)
        {
            Chunk tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, 11f, 0, new BaseColor(75, 48, 109)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 12f;
            cell.PaddingLeft = 5f;
            cell.PaddingTop = 4f;
            tab.AddCell(cell);
            //tc = new Chunk(righttext, new Font(iTextHelperFunction.kalavika, 10.5f, 0, new BaseColor(75, 48, 109)));
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(75, 48, 109)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            tab.AddCell(cell);
        }

        public static void AddRowHeading(ref PdfPTable tab, string lefttext, int fontSize = 12, bool isPadding = false)
        {
            Chunk tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 1, new BaseColor(75, 48, 109)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 15f;
                cell.PaddingLeft = 40f;
            }
            cell.Colspan = 3;
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            tab.AddCell(cell);
        }

        public static void AddInnerPaddingRow(ref PdfPTable tab, string lefttext, string middletext, string righttext, int fontSize = 12, bool isBold = true, bool isBackground = true, bool isPadding = false)
        {
            Chunk tc = new Chunk(">", new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(243, 48, 120)));
            Chunk tc2 = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc,
                tc2
            });
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
                cell.PaddingLeft = 60f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc2 = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc2
            });
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc2 = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc2
            });
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
                cell.PaddingRight = 40f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.HorizontalAlignment = 1;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 1f;
            tab.AddCell(cell);
        }

        public static void AddAssignmentRow(ref PdfPTable tab, string lefttext, string middletext, string righttext, int fontSize = 12, bool isBold = true, bool isBackground = true, bool isPadding = false)
        {
            //Paragraph p = new Paragraph(lefttext, new Font(iTextHelperFunction.kalavika, (float)fontSize, 0, new BaseColor(75, 48, 109)));
            Chunk tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(75, 48, 109)));
            //p.FirstLineIndent = 2f;
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.HorizontalAlignment = 0;
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            //cell.FixedHeight = 45f;
            //cell.Indent = 2f;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(75, 48, 109)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(75, 48, 109)));
            //tc = new Chunk(righttext, new Font(Font.FontFamily.HELVETICA, 10f, 0, new BaseColor(75, 48, 109)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            cell.HorizontalAlignment = 0;
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.HorizontalAlignment = 0;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 1f;
            tab.AddCell(cell);
        }

        public static void AddCertificationRows(ref PdfPTable tab, string heading, string subHeading, string text, string link)
        {
            Chunk tc = new Chunk(heading, new Font(iTextHelperFunctionDMP.Arial, 17f, 1, new BaseColor(75, 48, 109)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            cell.PaddingBottom = 5f;
            tab.AddCell(cell);
            tc = new Chunk(subHeading, new Font(iTextHelperFunctionDMP.Arial, 15f, 0, new BaseColor(75, 48, 109)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingTop = 5f;
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            //Mohd
            tc = new Chunk(text, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingTop = 5f;
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            cell.SetLeading(1.0f, 1.5f);
            tab.AddCell(cell);

            Font linkfont = new Font(iTextHelperFunctionDMP.Arial, 14f, 0, new BaseColor(75, 48, 109));
            //Anchor anchor = new Anchor(, linkfont);
            //anchor.Reference = link;

            tc = new Chunk(">>CLICK HERE TO DISCOVER MORE", linkfont);
            tc.SetAnchor(link);
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingTop = 5f;
            cell.Border = 0;
            cell.HorizontalAlignment = 2;

            tab.AddCell(cell);
        }


        public static void AddHotTopicsRows(ref PdfPTable tab, string heading, string subHeading, string text, string link)
        {
            Chunk tc = new Chunk(heading, new Font(iTextHelperFunctionDMP.Arial, 14f, 1, new BaseColor(255, 255, 255)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            cell.PaddingBottom = 5f;

            cell.BackgroundColor = new BaseColor(153, 153, 153); ;//#999999;
            tab.AddCell(cell);
            tc = new Chunk(subHeading, new Font(iTextHelperFunctionDMP.Arial, 14f, 0, new BaseColor(75, 48, 109)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingTop = 5f;
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            //Mohd
            tc = new Chunk(text, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingTop = 5f;
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            cell.SetLeading(1.0f, 1.5f);
            tab.AddCell(cell);

            Font linkfont = new Font(iTextHelperFunctionDMP.Arial, 11f, Font.UNDERLINE, new BaseColor(75, 48, 109));
            //Anchor anchor = new Anchor(, linkfont);
            //anchor.Reference = link;

            tc = new Chunk(">>CLICK HERE TO DISCOVER MORE", linkfont);
            tc.SetAnchor(link);
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingTop = 5f;
            cell.Border = 0;
            cell.HorizontalAlignment = 2;

            tab.AddCell(cell);
        }

        public static void AddBlankRow(ref PdfPTable tab, bool isColspan = false)
        {
            Chunk tc = new Chunk("mohd", new Font(iTextHelperFunctionDMP.Arial, 14f, 1, new BaseColor(255, 255, 255)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            cell.PaddingBottom = 5f;
            if (isColspan)
            {
                cell.PaddingBottom = 0f;
                cell.Colspan = 2;
            }
            //cell.BackgroundColor = new BaseColor(153, 153, 153); ;//#999999;
            tab.AddCell(cell);
        }

        public static void AddCompentiesRow(ref PdfPTable tab, string text, bool isWhite, bool addLeading = false, string boldText = "")
        {

            //Chunk tc = new Chunk(text, new Font(iTextHelperFunction.Arial, 10f, 0, isWhite ? new BaseColor(255, 255, 255) : new BaseColor(0, 0, 0)));

            Phrase phrase = new Phrase();

            if (boldText.Length > 0)
            {
                phrase.Add(
                    new Chunk(boldText, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, isWhite ? new BaseColor(255, 255, 255) : new BaseColor(0, 0, 0)))
                );
            };
            phrase.Add(
                    new Chunk(text, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, isWhite ? new BaseColor(255, 255, 255) : new BaseColor(0, 0, 0)))
                );

            PdfPCell cell = new PdfPCell(new Phrase
            {
                phrase
            });
            if (addLeading)
            {
                cell.PaddingTop = 5f;
            }
            cell.Border = 0;
            cell.HorizontalAlignment = 0;

            if (!isWhite)
            {
                cell.SetLeading(1.0f, 1.5f);
            }



            cell.Colspan = 2;
            //cell.BackgroundColor = isWhite ? new BaseColor(255, 255, 255) : new BaseColor(0,0,0);
            tab.AddCell(cell);
        }


        public static void AddCompentiesDataRowText(ref PdfPTable tab, string text)
        {
            Chunk tc = new Chunk(text, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingTop = 5f;
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            cell.SetLeading(1.0f, 1.5f);

            //cell.BackgroundColor = isWhite ? new BaseColor(255, 255, 255) : new BaseColor(0,0,0);
            tab.AddCell(cell);
        }

        public static void AddCompentiesDataRowLink(ref PdfPTable tab, string link)
        {
            Font linkfont = new Font(iTextHelperFunctionDMP.Arial, 11f, Font.UNDERLINE, new BaseColor(75, 48, 109));
            //Anchor anchor = new Anchor(, linkfont);
            //anchor.Reference = link;

            Chunk tc = new Chunk(">>CLICK HERE TO DISCOVER MORE", linkfont);
            tc.SetAnchor(link);
            PdfPCell Cell = new PdfPCell(new Phrase
            {
                tc
            });
            Cell.PaddingTop = 5f;
            Cell.Border = 0;
            Cell.HorizontalAlignment = 2;

            tab.AddCell(Cell);
        }

        public static void AddCompentiesDataRows(ref PdfPTable tab, string heading)
        {
            Chunk tc = new Chunk(heading, new Font(iTextHelperFunctionDMP.Arial, 12f, 0, new BaseColor(255, 255, 255)));
            PdfPCell cell = new PdfPCell(new Phrase { tc });
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            cell.Padding = 5f;
            cell.Border = 40;
            cell.BorderColor = new BaseColor(255, 255, 255);
            //cell.Width = 50f;
            //cell.PaddingRight = 10f;
            //cell.PaddingLeft = 10f;
            cell.BackgroundColor = new BaseColor(153, 153, 153);
            tab.AddCell(cell);
        }

        public static void AddCompentiesHeadingDataRows(ref PdfPTable tab, string heading)
        {
            Chunk tc = new Chunk(heading, new Font(iTextHelperFunctionDMP.Arial, 14f, 0, new BaseColor(75, 48, 109)));
            PdfPCell cell = new PdfPCell(new Phrase { tc });
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            //cell.Width = 50f;
            cell.PaddingTop = 5f;
            //cell.BackgroundColor = new BaseColor(153, 153, 153);
            tab.AddCell(cell);
        }

        public static void AddElearningHeading(ref PdfPTable tab, string heading)
        {
            Chunk tc = new Chunk(heading, new Font(iTextHelperFunctionDMP.Arial, 22f, 0, new BaseColor(242, 206, 30)));
            PdfPCell cell = new PdfPCell(new Phrase { tc });
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            //cell.Width = 50f;
            cell.Padding = 5f;
            cell.Colspan = 2;
            cell.BackgroundColor = new BaseColor(80, 48, 115);
            tab.AddCell(cell);
        }

        public static void AddSendInfoHeader(ref PdfPTable tab, string lefttext, string middletext, string righttext)
        {
            Chunk tc = new Chunk("", new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(243, 48, 120)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderColorRight = iTextHelperFunctionDMP.sendTableBorderColor;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthLeft = 0f;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 14f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderColorRight = iTextHelperFunctionDMP.sendTableBorderColor;
            cell.PaddingBottom = 14f;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthLeft = 0f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderColorRight = iTextHelperFunctionDMP.sendTableBorderColor;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthLeft = 0f;
            cell.PaddingBottom = 14f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 14f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
        }

        public static void AddSendFormHeader(ref PdfPTable tab, string lefttext, string middletext, string righttext)
        {
            Chunk tc = new Chunk("", new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(243, 48, 120)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(0, 0, 0);
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 12f;
            cell.PaddingTop = 12f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(0, 0, 0);
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 12f;
            cell.PaddingTop = 12f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(0, 0, 0);
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 12f;
            cell.PaddingTop = 12f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(0, 0, 0);
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 12f;
            cell.PaddingTop = 12f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
        }

        public static void AddSendFormRows(ref PdfPTable tab, string number, string lefttext, string middletext)
        {
            Chunk tc = new Chunk(number, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(0, 0, 0)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderWidth = 0f;
            cell.BackgroundColor = new BaseColor(246, 243, 244);
            cell.PaddingBottom = 8f;
            cell.PaddingTop = 8f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(247, 246, 247);
            cell.PaddingBottom = 8f;
            cell.BorderWidth = 0f;
            cell.PaddingTop = 8f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderWidth = 0f;
            cell.BackgroundColor = new BaseColor(246, 243, 244);
            cell.PaddingBottom = 8f;
            cell.PaddingTop = 8f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk("", new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderWidth = 1f;
            cell.PaddingBottom = 8f;
            cell.PaddingTop = 8f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
        }

        public static void AddSendInfoRows(ref PdfPTable tab, string lefttext, string middletext, string righttext)
        {
            Chunk tc = new Chunk(">", new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(243, 48, 120)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.PaddingBottom = 4f;
            cell.BorderWidth = 0f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderWidth = 0f;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 0;
            tab.AddCell(cell);
        }

        public static void Addrow(ref PdfPTable tab, string lefttext, string middletext, string righttext, int fontSize = 12, bool isBold = true, bool isBackground = false, bool isPadding = false)
        {
            Chunk tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(0, 0, 0)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
                cell.PaddingLeft = 40f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.Border = 0;
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, (float)fontSize, 0, new BaseColor(0, 0, 0)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            if (isPadding)
            {
                cell.PaddingTop = 7f;
                cell.PaddingBottom = 7f;
                cell.PaddingRight = 20f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            }
            cell.HorizontalAlignment = 2;
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = 0f;
            tab.AddCell(cell);
        }

        public static void AddTopBottomBorderRow(ref PdfPTable tab, bool isTopBorder, bool isBottomBorder)
        {
            Chunk tc = new Chunk("", FontFactory.GetFont("Arial", 11f, 1, iTextHelperFunctionDMP.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderWidthBottom = (isBottomBorder ? 1f : 0f);
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = (isTopBorder ? 1f : 0f);
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk("", FontFactory.GetFont("Arial", 11f, 1, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderWidthBottom = (isBottomBorder ? 1f : 0f);
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = (isTopBorder ? 1f : 0f);
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk("", FontFactory.GetFont("Arial", 11f, 1, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderWidthBottom = (isBottomBorder ? 1f : 0f);
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = (isTopBorder ? 1f : 0f);
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk("", FontFactory.GetFont("Arial", 11f, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderWidthBottom = (isBottomBorder ? 1f : 0f);
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = (isTopBorder ? 1f : 0f);
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
            tc = new Chunk("", FontFactory.GetFont("Arial", 11f, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = iTextHelperFunctionDMP.tablebackcolor;
            cell.BorderWidthBottom = (isBottomBorder ? 1f : 0f);
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = (isTopBorder ? 1f : 0f);
            cell.BorderWidthRight = 0f;
            tab.AddCell(cell);
        }

        public static void Addrow(ref PdfPTable tab, string lefttext1, string lefttext2, string middletext, string righttext1, string righttext2)
        {
            Chunk tc = new Chunk(lefttext1, new Font(iTextHelperFunctionDMP.Arial, 11f, 1, iTextHelperFunctionDMP.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            tab.AddCell(cell);
            tc = new Chunk(lefttext2, new Font(iTextHelperFunctionDMP.Arial, 11f, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, 11f, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            tab.AddCell(cell);
            tc = new Chunk(righttext1, new Font(iTextHelperFunctionDMP.Arial, 11f, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            tab.AddCell(cell);
            tc = new Chunk(righttext2, new Font(iTextHelperFunctionDMP.Arial, 11f, 0, iTextHelperFunctionDMP.bcolor));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.Border = 0;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthTop = 0f;
            tab.AddCell(cell);
        }

        public static void AddrowHeader(ref PdfPTable tab, string lefttext, string righttext, string middletext = "")
        {
            Chunk tc = new Chunk(lefttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(255, 255, 255)));
            PdfPCell cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(middletext, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(righttext, new Font(iTextHelperFunctionDMP.Arial, 10f, 1, new BaseColor(255, 255, 255)));
            cell = new PdfPCell(new Phrase
            {
                tc
            });
            cell.BackgroundColor = new BaseColor(75, 48, 109);
            cell.BorderColor = iTextHelperFunctionDMP.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 4f;
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
        }

        public static void AddParagraph(ref Document doc, string text, int alignment, Font f)
        {
            Chunk c = new Chunk(text, f);
            Phrase ph = new Phrase();
            ph.Add(c);
            Paragraph p = new Paragraph();
            p.Add(ph);
            p.SetLeading(0f, 1f);
            p.Alignment = alignment;
            doc.Add(p);
        }

        public static void AddHeadingParagraph(ref Document doc, string text, int alignment, Font f)
        {
            Chunk c = new Chunk(text, f);
            Phrase ph = new Phrase();
            ph.Add(c);
            Paragraph p = new Paragraph();
            p.Add(ph);
            p.SetLeading(0f, 2f);
            p.Alignment = alignment;
            doc.Add(p);
        }

        public static void AddBlankParagraphLowHeight(ref Document doc, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                Paragraph p = new Paragraph("\n");
                p.SetLeading(0f, 0.5f);
                doc.Add(new Paragraph(p));
            }
        }

        public static void AddBlankParagraph(ref Document doc, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                Paragraph p = new Paragraph("\n");
                p.SetLeading(0f, 1f);
                doc.Add(new Paragraph(p));
            }
        }
    }
}