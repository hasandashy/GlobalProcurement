<%@ Page Language="C#" MasterPageFile="~/webadmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="SGA.webadmin.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <tr>
        <td>
            <table width="1280" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="cat">
                        <h1 style="font-weight: normal">
                            > MEMBERS</h1>
                        <div style="border: 1px solid #ed1165; margin-left: 30px; width: 98%;">
                        </div>
                        <br />
                        <ul>
                            <li><a href="ListUsers.aspx">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblRegistered" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Registered<br />
                                    User</div>
                                <div class="clr">
                                </div>
                            </a></li>
                            <li><a href="ListUsers.aspx?id=1">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblUnApproved" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    UnApproved<br />
                                    User</div>
                                <div class="clr">
                                </div>
                            </a></li>
                            <li><a href="ListUsers.aspx?id=4">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblDeactive" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Expired<br />
                                    User</div>
                                <div class="clr">
                                </div>
                            </a></li>
                            <li><a href="ListUsers.aspx?id=5">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblTotalUserByAdmin" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Total user<br />
                                    created by admin</div>
                                <div class="clr">
                                </div>
                            </a></li>
                            <li><a href="ListUsers.aspx?id=6">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblFromFront" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Total user<br />
                                    registered by<br />
                                    front site</div>
                                <div class="clr">
                                </div>
                            </a></li>
                        </ul>
                        <br />
                    </td>
                </tr>
                <tr>
                <td class="cat">
                    <h1 style="font-weight: normal">
                        > ASSESSMENTS</h1>
                    <div style="border: 1px solid #ed1165; margin-left: 30px; width: 98%;">
                    </div>
                    <br />
                    <ul>
                       <%-- <li><a href="CompanyUsers.aspx">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblCompany" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total Registerd<br />
                                company</div>
                            <div class="clr">
                            </div>
                        </a></li>--%>
                        <li><a href="ListUsers.aspx?tabId=4">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblCMC" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total PKE <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                      <%--  <li><a href="ListUsers.aspx?tabId=5">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblSSA" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total SSA <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=6">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblBA" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total BA <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=7">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblNP" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total NP <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=8">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblMP" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total MP <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=9">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblCMA" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total CMA <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=13">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblCMASGA" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total CMSA <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=16">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblLeadership" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total Leadership <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=15">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblSCKE" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total SCKE <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=16">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblSCSA" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total SCSA <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>
                        <li><a href="ListUsers.aspx?tabId=17">
                            <div class="fl num_dashboard">
                                <asp:Label ID="lblCMKE" runat="server"></asp:Label></div>
                            <div class="fl hdtxt pt15">
                                Total CMKE <br />
                                Assess Taken</div>
                            <div class="clr">
                            </div>
                        </a></li>--%>
                    </ul>
                    <br />
                </td>
                </tr>
                <tr>
                    <td class="cat">
                        <h1 style="font-weight: normal">
                            > OPPORTUNITIES</h1>
                        <div style="border: 1px solid #ed1165; margin-left: 30px; width: 98%;">
                        </div>
                        <br />
                        <ul>
                            <li><a href="AllContactUs.aspx">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblContact" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Total Contact<br />
                                    us query
                                </div>
                                <div class="clr">
                                </div>
                            </a></li>
                            <li><a href="ManageEmailTemplates.aspx">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblEmailTemplate" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Total email
                                    <br />
                                    templates</div>
                                <div class="clr">
                                </div>
                            </a></li>
                            
                            <li><a href="ListUsers.aspx?id=3">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblLoggedin" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Total loggedin<br />
                                    users (till date)
                                </div>
                                <div class="clr">
                                </div>
                            </a></li>
                            <li><a href="ListUsers.aspx?id=2">
                                <div class="fl num_dashboard">
                                    <asp:Label ID="lblNotLoggenin" runat="server"></asp:Label></div>
                                <div class="fl hdtxt pt15">
                                    Total users not<br />
                                    loggedin till<br />
                                    today</div>
                                <div class="clr">
                                </div>
                            </a></li>
                           
                        </ul>
                        <br />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</asp:Content>

