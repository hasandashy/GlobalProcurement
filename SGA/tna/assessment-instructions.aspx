<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="assessment-instructions.aspx.cs" Inherits="SGA.tna.assessment_instructions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dis-block clearfix  marT1 top-space">

        <div class="main-heading dis-block clearfix pad15 padtop1">
            <h1>
                <asp:Label ID="lblName" runat="server" Style="color: #F9A12A; font-size: 24px; font-family: 'HelveticaBold';"></asp:Label><span>Procurement Benchmark Assessment </span></h1>
        </div>


        <div class="dis-block clearfix gray-light-bg pad15 full-height">

            <div class="sub-heading dis-block clearfix">
                <h2>Instructions</h2>
            </div>

            <p><strong>You are about to complete an evaluation of your knowledge.</strong></p>

            <p>This evaluation focuses on the skills required to perform in procurement and is future-looking in its design. This is the purpose of the benchmark, to prepare ourselves for 2025. So, don't be alarmed if you see themes emerging that are new.</p>
            <p>The assessment focuses on seven capability pillars and for each, you will be asked nine multiple-choice questions.</p>
            <p><strong>The 7 capability pillars are:</strong></p>
            <p>
                1. Relationships & Value<br />
                2. Data, Analysis & Insights<br />
                3. Category Management & Innovation<br />
                4. Business Partnership & Brand<br />
                5. Performance & Results<br />
                6. Operate & Negotiate<br />
                7. Sustainability & Ethics
            </p>
            <p>On completion of the evaluation you will have access to your results as a visualisation of your results against the benchmark. You can use your results for your own records – as an evaluation of your knowledge, as it stands today against what may be required of you in the future. </p>
            <p>Please feel free to click through the various graphs to explore the benchmark data across the world.</p>
        </div>










        <div class="bottom-btn">
            <div class="fleft blue-btn"><a href="default.aspx" class="leftbt"><< BACK </a></div>
            <div class="fright blue-btn"><a href="assessment-pillars.aspx" class="rightbt">NEXT >> </a></div>
        </div>

    </div>
</asp:Content>

