<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlUserLeftMenu.ascx.cs" Inherits="SGA.controls.ctrlUserLeftMenu" %>
<div class="col-lft">
								<p class="title18"><span id="spCategory" runat="server">Procurement Knowledge Evaluation</span></p>
								<% if(isSgaResult) { %>
                                <div class="acrd-menu">
									<p><a href="#" class="menuitem submenuheader">Display Results</a></p>
									<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph.aspx"  id="hylPKEGraph" runat="server">&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports.aspx" id="hylPKE" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
									
									
								</div>
								<% } else { %>
                                <div class="result-info icon-score">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
								<p class="title18"><span id="spSkills" runat="server">Procurement - Technical Self <br />Assessment</span></p>
                                <% if(isTnaResult) { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-ssa.aspx" id="hylSSAGraph" runat="server">&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-ssa.aspx" id="hylSSA" runat="server">&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-graf">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
                                <p class="title18"><span id="spBehaviour" runat="server">Procurement - Behavioural Self <br />Assessment</span></p>
                                <% if(isPmpResult) { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-ba.aspx" id="hylBAGraph" runat="server" >&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-ba.aspx" id="hylBA" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-bulb">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>

                                <p class="title18"><span id="spCMK" runat="server">Contract Management Knowledge <br />Evaluation</span></p>
                                <% if(isCMKResult) { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-cmk.aspx" id="hylCMKGraph" runat="server" >&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-cmk.aspx" id="hylCMK" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-graf">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
                                

                                <p class="title18"><span id="spCMASGA" runat="server">Contract Management Self <br />Assessment</span></p>
                                <% if (isCMASGAResult)
                                   { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-cma-sga.aspx" id="hylCMASGAGraph" runat="server"  >&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-cma-sga.aspx" id="hylCMASGA" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-bar">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>

                                

                                
                                

                                <p class="title18"><span id="spLeadership" runat="server">Leadership <br />Assessment</span></p>
                                <% if (isLeadershipResult)
                                   { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-leadership.aspx" id="hylLeadershipGraph" runat="server"  >&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-leadership.aspx" id="hylLeadership" runat="server"  >&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-hierarchy">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
                                <p class="title18"><span id="spNegotiation" runat="server">Negotiation Profile</span></p>
								<% if (isNpResult)
                                { %>
                                <div class="acrd-menu">
									<p><a href="#" class="menuitem submenuheader">Display Results</a></p>
									<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-np.aspx" id="hylNPGraph" runat="server">&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-np.aspx" id="hylNP" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
                                    <p><a href="share-the-challenge.aspx" class="menuitem">Share the Assessment</a></p>
								</div>
								<% } else { %>
                                <div class="result-info icon-calcualtor">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
                                <p class="title18"><span id="spMaturity" runat="server">Maturity Profile <br />Assessment</span></p>
                                <% if (isDmpResult)
                                   { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-mp.aspx" id="hylDMPGraph" runat="server"  >&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-mp.aspx" id="hylDMP" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-arrow">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>

                                <div style="display:none;">
                                    <p class="title18"><span id="spCMA" runat="server">Contract Management <br />Assessment</span></p>
                                <% if (isCMAResult)
                                   { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-cma.aspx" id="hylCMAGraph" runat="server"  >&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-cma.aspx" id="hylCMA" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-copy">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
                                <p class="title18"><span id="spDNA" runat="server">Diagnostic <br />Assessment</span></p>
                                <% if (isDNAResult)
                                   { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-dna.aspx"  id="hylDNAGraph" runat="server" >&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-dna.aspx" id="hylDNA" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-dna">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
                                </div>
                                <p class="title18"><span id="spSCKE" runat="server">Supply Chain Knowledge Evaluation</span></p>
								<% if(isSCKEResult) { %>
                                <div class="acrd-menu">
									<p><a href="#" class="menuitem submenuheader">Display Results</a></p>
									<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-scke.aspx" id="hylSCKEGraph" runat="server">&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-scke.aspx" id="hylSCKE" runat="server" >&bull; Reports</a></li>
										</ul>
									</div>
									
									
								</div>
								<% } else { %>
                                <div class="result-info icon-score">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>
								<p class="title18"><span id="spSCSA" runat="server">Supply Chain Self Assessment</span></p>
                                <% if(isSCSAResult) { %>
                                <div class="acrd-menu">
                                <p><a href="#" class="menuitem submenuheader">Display Results</a></p>
								<div class="submenu">
										<ul>
											<li><a href="~/tna/my-results-bar-graph-scsa.aspx" id="hylSCSAGraph" runat="server">&bull; Bar Graph</a></li>
											<li><a href="~/tna/my-results-reports-scsa.aspx" id="hylSCSA" runat="server">&bull; Reports</a></li>
										</ul>
									</div>
                                </div>
                                <% } else { %>
                                <div class="result-info icon-graf">
									<p>Your results are restricted of this assessment.</p>
								</div>
                                <%} %>

                                    
                                

							</div>