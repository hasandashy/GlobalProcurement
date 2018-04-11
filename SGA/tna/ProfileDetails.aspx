<%@ Page Title="" Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="ProfileDetails.aspx.cs" Inherits="SGA.tna.ProfileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dis-block clearfix  marT1 top-space">
        <div class="main-heading dis-block clearfix pad15 font18 head-graybg padbottom-none padtop4 marTnone">
           <div class="menu-icon"><a href="MainMenu.aspx"><img src="../images/menu-icon.png" alt=""></a></div>
            <h1>Member Information<span> </span></h1>
        </div>
        <asp:MultiView ID="multiView" runat="server">
            <asp:View runat="server" ID="procModel">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Procurement model</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Centralised Procurement Function</a></li>
                                <li><a href="#" onclick="SaveData(2)">Decentralised Procurement Function</a></li>
                                <li><a href="#" onclick="SaveData(3)">Centre-Led Procurement Function</a></li>
                                <li><a href="#" onclick="SaveData(4)">Procurement strategy is centralised, but execution is de-centralised</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="reportsTo">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Reporting line</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">CEO</a></li>
                                <li><a href="#" onclick="SaveData(2)">CFO</a></li>
                                <li><a href="#" onclick="SaveData(3)">COO</a></li>
                                <li><a href="#" onclick="SaveData(4)">CIO</a></li>
                                <li><a href="#" onclick="SaveData(5)">Legal Council</a></li>
                                <li><a href="#" onclick="SaveData(6)">Head of Supply Chain</a></li>
                                <li><a href="#" onclick="SaveData(7)">Division or Busines Unit Head</a></li>
                                <li><a href="#" onclick="SaveData(8)">Regional of Global Procurement</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="spendUnder">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Spend under influence</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">$1 billion or more</a></li>
                                <li><a href="#" onclick="SaveData(2)">$500 million to $999.9 million</a></li>
                                <li><a href="#" onclick="SaveData(3)">$100 million to $499.9 million</a></li>
                                <li><a href="#" onclick="SaveData(4)">$50 million to $99.9 million</a></li>
                                <li><a href="#" onclick="SaveData(5)">$20 million to $49.9 million</a></li>
                                <li><a href="#" onclick="SaveData(6)">$10 million to $19.9 million</a></li>
                                <li><a href="#" onclick="SaveData(7)">$5 million to $9.9 million</a></li>
                                <li><a href="#" onclick="SaveData(8)">$2.5 million to $4.9 million</a></li>
                                <li><a href="#" onclick="SaveData(9)">$1 million to $2.49 million</a></li>
                                <li><a href="#" onclick="SaveData(10)">$500,000 to $999,999</a></li>
                                <li><a href="#" onclick="SaveData(11)">Less than $500,000</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="numberOfEmp">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Number of employees</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">100+</a></li>
                                <li><a href="#" onclick="SaveData(2)">75 to 99</a></li>
                                <li><a href="#" onclick="SaveData(3)">50 to 74</a></li>
                                <li><a href="#" onclick="SaveData(4)">30 to 49</a></li>
                                <li><a href="#" onclick="SaveData(5)">15 to 29</a></li>
                                <li><a href="#" onclick="SaveData(6)">10 to 14</a></li>
                                <li><a href="#" onclick="SaveData(7)">9</a></li>
                                <li><a href="#" onclick="SaveData(8)">8</a></li>
                                <li><a href="#" onclick="SaveData(9)">7</a></li>
                                <li><a href="#" onclick="SaveData(10)">6</a></li>
                                <li><a href="#" onclick="SaveData(11)">5</a></li>
                                <li><a href="#" onclick="SaveData(12)">4</a></li>
                                <li><a href="#" onclick="SaveData(13)">3</a></li>
                                <li><a href="#" onclick="SaveData(14)">2</a></li>
                                <li><a href="#" onclick="SaveData(15)">1</a></li>

                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>

            <asp:View runat="server" ID="sector">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Sector</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Public</a></li>
                                <li><a href="#" onclick="SaveData(2)">Private</a></li>
                                <li><a href="#" onclick="SaveData(3)">Not for Profit</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="jobRole">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Job Role</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Analyst</a></li>
                                <li><a href="#" onclick="SaveData(2)">Procurement Support</a></li>
                                <li><a href="#" onclick="SaveData(3)">Strategic Sourcing</a></li>
                                <li><a href="#" onclick="SaveData(4)">Vendor Manager/ Supplier Relationship Manager</a></li>
                                <li><a href="#" onclick="SaveData(5)">Category Manager</a></li>
                                <li><a href="#" onclick="SaveData(6)">Procurement Leader</a></li>
                                <li><a href="#" onclick="SaveData(7)">Supply Chain</a></li>
                                <li><a href="#" onclick="SaveData(8)">Non-Procurement: CXO</a></li>
                                <li><a href="#" onclick="SaveData(9)">Non-Procurement: Director</a></li>
                                <li><a href="#" onclick="SaveData(10)">Non-Procurement: Manager</a></li>
                                <li><a href="#" onclick="SaveData(11)">Non-Procurement: Professional</a></li>
                                <li><a href="#" onclick="SaveData(12)">Non-Procurement: Trainee</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="catManaged">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Category you manage currently</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Generalist Direct & Indirects</a></li>
                                <li><a href="#" onclick="SaveData(2)">General Directs</a></li>
                                <li><a href="#" onclick="SaveData(3)">Generalist Indirects</a></li>
                                <li><a href="#" onclick="SaveData(4)">Chemical</a></li>
                                <li><a href="#" onclick="SaveData(5)">Energy</a></li>
                                <li><a href="#" onclick="SaveData(6)">Facilities</a></li>
                                <li><a href="#" onclick="SaveData(7)">Fleet</a></li>
                                <li><a href="#" onclick="SaveData(8)">Heavy Machinery and Equipment</a></li>
                                <li><a href="#" onclick="SaveData(9)">HR Services</a></li>
                                <li><a href="#" onclick="SaveData(10)">ICT</a></li>
                                <li><a href="#" onclick="SaveData(11)">Ingredients</a></li>
                                <li><a href="#" onclick="SaveData(12)">Marketing</a></li>
                                <li><a href="#" onclick="SaveData(13)">Mininng Equipment</a></li>
                                <li><a href="#" onclick="SaveData(14)">MRO and Capex</a></li>
                                <li><a href="#" onclick="SaveData(15)">Packaging</a></li>
                                <li><a href="#" onclick="SaveData(16)">Professional Services</a></li>
                                <li><a href="#" onclick="SaveData(17)">Raw Materials</a></li>
                                <li><a href="#" onclick="SaveData(18)">Travel</a></li>
                                <li><a href="#" onclick="SaveData(19)">Wardrobe & Workwear</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="spentUnderYour">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Spend under your influence</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">$1 billion or more</a></li>
                                <li><a href="#" onclick="SaveData(2)">$500 million to $999.9 million</a></li>
                                <li><a href="#" onclick="SaveData(3)">$100 million to $499.9 million</a></li>
                                <li><a href="#" onclick="SaveData(4)">$50 million to $99.9 million</a></li>
                                <li><a href="#" onclick="SaveData(5)">$20 million to $49.9 million</a></li>
                                <li><a href="#" onclick="SaveData(6)">$10 million to $19.9 million</a></li>
                                <li><a href="#" onclick="SaveData(7)">$5 million to $9.9 million</a></li>
                                <li><a href="#" onclick="SaveData(8)">$2.5 million to $4.9 million</a></li>
                                <li><a href="#" onclick="SaveData(9)">$1 million to $2.49 million</a></li>
                                <li><a href="#" onclick="SaveData(10)">$500,000 to $999,999</a></li>
                                <li><a href="#" onclick="SaveData(11)">Less than $500,000</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="GeoInfluence">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Geographical influence</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Local</a></li>
                                <li><a href="#" onclick="SaveData(2)">Regional</a></li>
                                <li><a href="#" onclick="SaveData(3)">Global</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="Exp">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Years of procurement experience</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Less than 1 year</a></li>
                                <li><a href="#" onclick="SaveData(2)">1 - 3 years</a></li>
                                <li><a href="#" onclick="SaveData(3)">3 - 5 years</a></li>
                                <li><a href="#" onclick="SaveData(4)">5 - 10 years</a></li>
                                <li><a href="#" onclick="SaveData(5)">10 or more years</a></li>
                                <li><a href="#" onclick="SaveData(6)">Not applicable</a></li>

                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="procQual">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Procurement qualifications</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Undergraduate degree in procurement/supply chain</a></li>
                                <li><a href="#" onclick="SaveData(2)">Postgraduate degree in procurement/supply chain</a></li>
                                <li><a href="#" onclick="SaveData(3)">CIPS: Member (MIPS)</a></li>
                                <li><a href="#" onclick="SaveData(4)">CIPS: Fellow (FCIPS)</a></li>
                                <li><a href="#" onclick="SaveData(5)">AAPCM: Member</a></li>
                                <li><a href="#" onclick="SaveData(6)">AAPCM: Fellow</a></li>
                                <li><a href="#" onclick="SaveData(7)">Other</a></li>
                                <li><a href="#" onclick="SaveData(8)">Not applicable</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="Edu">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Level of Education</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Secondary school</a></li>
                                <li><a href="#" onclick="SaveData(2)">Certificate</a></li>
                                <li><a href="#" onclick="SaveData(3)">Diploma</a></li>
                                <li><a href="#" onclick="SaveData(4)">Advanced Diploma</a></li>
                                <li><a href="#" onclick="SaveData(5)">Undergraduate</a></li>
                                <li><a href="#" onclick="SaveData(6)">Postgraduate</a></li>
                                <li><a href="#" onclick="SaveData(7)">Masters</a></li>
                                <li><a href="#" onclick="SaveData(8)">Doctorate</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="prevCatExp">
                <div class="dis-block clearfix white-bg pad15 full-height member-info-detail">
                    <div class="dis-block clearfix">
                        <div class="dis-block clearfix member-info ">
                            <span class="title">Your previous category experience</span>
                            <ul>
                                <li><a href="#" onclick="SaveData(1)">Indirect- General</a></li>
                                <li><a href="#" onclick="SaveData(2)">Directs - General</a></li>
                                <li><a href="#" onclick="SaveData(3)">IT&T Services: Software, Hardware, Telco etc.</a></li>
                                <li><a href="#" onclick="SaveData(4)">Packaging: PET, Glass, Print, Labels, etc.</a></li>
                                <li><a href="#" onclick="SaveData(5)">Marketing Services: ABT, BTL, Print, etc.</a></li>
                                <li><a href="#" onclick="SaveData(6)">Ingredients</a></li>
                                <li><a href="#" onclick="SaveData(7)">HR Services: Labour hire, Recruitment, Training, etc.</a></li>
                                <li><a href="#" onclick="SaveData(8)">Chemicals</a></li>
                                <li><a href="#" onclick="SaveData(9)">Professional Services: Legal, Audit & Accounting, Security, etc.</a></li>
                                <li><a href="#" onclick="SaveData(10)">Industry specific production material</a></li>
                                <li><a href="#" onclick="SaveData(11)">Facilities and Corporate Real Estate (FM/CRE)</a></li>
                                <li><a href="#" onclick="SaveData(12)">Utilities: Gas, Electricity, Water</a></li>
                                <li><a href="#" onclick="SaveData(13)">Capex: Heavy machinery and equipment</a></li>
                                <li><a href="#" onclick="SaveData(14)">MRO Maintenance, Repairs, Operations and Consumables</a></li>
                                <li><a href="#" onclick="SaveData(15)">Office: Stationery, post</a></li>
                                <li><a href="#" onclick="SaveData(16)">Travel</a></li>
                                <li><a href="#" onclick="SaveData(17)">Fleet</a></li>
                                <li><a href="#" onclick="SaveData(18)">Logistics</a></li>
                                <li><a href="#" onclick="SaveData(19)">Other</a></li>

                            </ul>
                        </div>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>


    <script>
        function SaveData(val) {
           var json =
                             $.ajax({
                                 type: "POST",
                                 async: false,
                                 url: "ProfileDetails.aspx/SaveProfileData",
                                 data: JSON.stringify({ 'val': val }),
                                 dataType: "json",
                                 contentType: "application/json; charset=utf-8",
                                 success: function (data) {
                                     //alert('success')
                                     window.location.href = "MyProfile.aspx";
                                 },
                                 error: (error) => {
                                     alert('Error while saving data');
                                     event.preventDefault();
                                     return false;
                                 }
                             });
           
        }
    </script>
</asp:Content>
