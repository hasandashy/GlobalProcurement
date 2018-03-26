<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="assessment-pillars.aspx.cs" Inherits="SGA.tna.assessment_pillars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dis-block clearfix pad15 marT1 top-space">
        <div class="main-heading dis-block clearfix">
            <h1>
                <asp:Label ID="lblName" runat="server" Style="color: #F9A12A; font-size: 24px; font-family: 'HelveticaBold';"></asp:Label><span>Capability Pillars </span></h1>
        </div>


        <div class="pillars dis-block clearfix">
            

        


        <asp:ListView ID="parentRepeater" runat="server" OnItemDataBound="parentRepeater_ItemDataBound">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </ul>

            </LayoutTemplate>
            <ItemTemplate>
                 <li id="list" runat="server">
                    <a href='assessments-pillar-quotes.aspx?pillerId=<%#Eval("topicId")%>'>
                        <div class="pillers-txt"><%#Eval("topicName").ToString().Replace("<br />"," ")%>
                            <div class="starthere" id="start" runat="server" visible="false">Start here >></div>
                        </div>
                        <i class="top-icon">
                            <img src="../images/icon9.png" alt=""></i><i class="bottom-icon"><img src="../images/icon<%#Container.DataItemIndex + 2%>.png" alt=""></i></a>
                </li>
              
            </ItemTemplate>
        </asp:ListView>


        </div>





    </div>

    
</asp:Content>
