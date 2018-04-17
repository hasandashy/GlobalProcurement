<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlUserLeftMenu.ascx.cs" Inherits="SGA.controls.ctrlUserLeftMenu" %>
<div class="col-lft">
								<p class="title18"><span id="spCategory" runat="server">Procurement Benchmark Assessment</span></p>
								<% if(isSgaResult) { %>
                                <div class="acrd-menu">
									<p><a href="#" class="menuitem submenuheader">Display Results</a></p>
									<div class="submenu">
										<ul>
											<li><a href="~/ifpsmtna/my-results-bar-graph.aspx"  id="hylPKEGraph" runat="server">&bull; Bar Graph</a></li>
											
										</ul>
									</div>
									
									
								</div>
								<% } %>
							</div>