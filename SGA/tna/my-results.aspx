<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="my-results.aspx.cs" Inherits="SGA.tna.my_results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="dis-block clearfix pad15 marT1 top-space">
        <div class="main-heading dis-block clearfix">
            <h1 style="width: 80%; text-align: left;">
                <span>Procurement Benchmark Assessment</span></h1>
            <div class="menu-icon">
                <a href="MainMenu.aspx">
                    <img src="../Images/menu-icon.png" alt=""></a>
            </div>
        </div>


        <%-- <p>Below you will see the result for each assessment you have taken if you would like to access your results, navigate through links.</p>--%>
        <div class=" dis-block clearfix pad10">
            <div class="strip-heading">
                <i></i><span>Results</span>
            </div>
            <asp:ListView ID="parentRepeater" runat="server" OnItemCommand="parentRepeater_ItemCommand" OnItemDataBound="parentRepeater_ItemDataBound">
                <LayoutTemplate>
                    <div class="dis-block clearfix pad3 light-gray-bg">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="40%"><span style="font-weight: bold">Time stamp</span></td>
                                <td width="30%"><span style="font-weight: bold">Time taken</span></td>
                                <td width="10%"></td>
                            </tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            <div class="clearfix"></div>
                            <hr class="divider-line" />
                        </table>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <%--  <div class="yellow-bg assesment-box" runat="server">
                    <asp:LinkButton ID="hyl" runat="server" CommandArgument='<%# Eval("testId") %>' CommandName="graph"><i>
                <img src="../images/icon1.png" alt="Procurement Benchmark Assessment" /></i>
                <p>Procurement Benchmark Assessment (<%# Convert.ToDateTime(Eval("testDate")).ToShortDateString() %>)</p>
                <em>>></em></asp:LinkButton>
                </div>
                <br />--%>

                    <tr>
                        <td width="40%">

                            <asp:Label ID="lblConvertedDate" runat="server"></asp:Label>
                            <asp:Label ID="lblDate" runat="server" Visible="false" Text='<%# Convert.ToDateTime(Eval("testDate")).ToShortDateString() %>' CssClass="adminheader2"></asp:Label>

                        </td>
                        <td width="30%">
                            <asp:Label ID="lblTimeTaken" runat="server"></asp:Label>
                        </td>
                        <td width="10%">
                            <asp:ImageButton ID="ibtnGraph" runat="server" CommandArgument='<%#Eval("testId") %>' CommandName="graph" ImageUrl="~/innerimages/img-graph-icon.gif" />
                        </td>
                    </tr>

                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="yellow-bg assesment-box" runat="server">  
                        <div class="innerdiv">
                           <div style="width: 20%;float: left;">
                               <img src="../images/icon1.png" alt="Procurement Benchmark Assessment" />
                            </div>
                            <div style="width: 70%;float: left;padding-left:10px;">
                                Procurement Benchmark Assessment           
                            </div>
                            <div style="width:auto;float: left;">
                                <img src="../innerimages/icon-locked.png" style="float:right;"/>
                            </div>                        
                            <span class="innerspan">Your results are restricted of this assessment</span>                     
                           </div>
                      </div>                    
                  
                </EmptyDataTemplate>
            </asp:ListView>

        </div>




        <%-- <div class="yellow-bg assesment-box " id="asseslocked" runat="server" visible="false">
            <a><i>
                <img src="../images/icon1.png" alt="Procurement Benchmark Assessment" /></i>
                <p>
                    Procurement Benchmark Assessment
                    <img src="../innerimages/icon-locked.png" style="float: right;" />
                </p>
            </a>

        </div>--%>



        <%--<div class="gray-bg assesment-box marT3">
<a href="javascript:void(0)"><i><img src="images/icon1.png" alt=""></i> <p>Procurement Benchmark Assessment </p><em>>></em>  </a>
</div>--%>
    </div>

</asp:Content>
