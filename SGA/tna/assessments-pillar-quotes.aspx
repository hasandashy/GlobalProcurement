<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="assessments-pillar-quotes.aspx.cs" Inherits="SGA.tna.assessments_pillar_quotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dis-block clearfix  marT1 top-space">

        <div class="main-heading dis-block clearfix pad15 font18 head-orangebg main-heading2 padbottom-none padtop4 marTnone">
            <h1 id="heading" runat="server"></h1>
        </div>


        <div class="dis-block clearfix white-bg pad15 full-height ">
            <asp:ListView ID="parentRepeater" runat="server">
                <LayoutTemplate>
                    <div class="dis-block clearfix">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </div>

                </LayoutTemplate>
                <ItemTemplate>
                    <div class="dis-block clearfix center marT2">
                        <p><%#Eval("pillarQuotes").ToString()%></p>
                    </div>

                    <div class="dis-block clearfix center marT1">
                        <img src='<%#Eval("imagePath").ToString()%>' alt=""></div>

                </ItemTemplate>
            </asp:ListView>

        </div>
        <div class="bottom-btn">
            <div class="fright blue-btn">
                <asp:LinkButton ID="hyl" ClientIDMode="Static" runat="server" CssClass="rightbt" Text="NEXT >>" OnClick="hyl_Click" />
            </div>


        </div>
    </div>
</asp:Content>
