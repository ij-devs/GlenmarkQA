<%@ page title="" language="C#" masterpagefile="~/fixitmasterpage.master" autoeventwireup="true" codefile="Approvalpage.aspx.cs" inherits="Approvalpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"
        integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css"
        integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="Hidnfldname" runat="server" />
    <asp:HiddenField ID="Hidnfldcode" runat="server" />
    <asp:HiddenField ID="Hidnfldiv" runat="server" />
    <asp:HiddenField ID="Hidnfldlogin" runat="server" />
    <asp:HiddenField ID="HiddenfldBH_Code" runat="server" />
    <div class="page-wrapper">
        <div id="header" class="page-header">
            <div>
                <hr class="header-line" />
                <div class="logo-wrapper">
                    <img src="images/ggror p.png" alt="GREGOR ANALYTICS" />
                    <asp:Panel ID="Panel2" CssClass="blue-band" runat="server">
                        FIXIT - Expiry Reduction
                    </asp:Panel>
                </div>
                <hr class="header-line bottom" />
            </div>
            <div id="labelStripContainer">
                <asp:Label ID="Label3" CssClass="moving-label" Text="Last date of submission: 28th November 2025 till 5.00 PM & if invoice channel type is medvol ZSM can place order" runat="server"></asp:Label>
            </div>
        </div>
        <div>
            <table>
                <tr>
                    <td class="style1">
                        <span style="font-size: 30px; cursor: pointer" onclick="openNav()">&#9776;</span>
                        <div id="mySidenav" class="sidenav">
                            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
                            <asp:Button ID="Button4" CssClass="button" runat="server" OnClick="btnthome" Text="Home" />
                            <br />
                            <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btntemp" Text="Blocking List" />
                            <br />
                            <asp:Button ID="Button2" CssClass="button" runat="server" OnClick="btnclk_noti" Text="Notification" />
                            <br />
                            <asp:Button ID="Button3" CssClass="button" runat="server" OnClick="btnconta" Text="Contact Us" />
                            <br />
                            <asp:Button ID="btnout" CssClass="button" runat="server" OnClick="btnoutclick" Text="Logout" />
                        </div>
                    </td>
                    <td>
                        <div id="header pull-right">
                            <asp:Label ID="Lblcount" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                            <asp:Label ID="Lblwelcm" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="Lbldetail" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="ZSM Name:" Font-Names="calibri" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlempname" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" onselectedindexchanged="ddlemp_SelectedIndexChanged">
                        </asp:DropDownList>
                        <script type="text/javascript">
                            $('#<%=ddlempname.ClientID %>').chosen();
                        </script>
                        <asp:Label ID="Label1" Font-Size="Medium" Font-Bold="true" Text="Brands:" Font-Names="calibri" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlbrand" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" onselectedindexchanged="ddlbrnd_SelectedIndexChanged">
                        </asp:DropDownList>
                        <script type="text/javascript">
                            $('#<%=ddlbrand.ClientID %>').chosen();
                        </script>
                        <asp:Label ID="Label5" Font-Size="Medium" Font-Bold="true" Text="Tags:" Font-Names="calibri" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddltag" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" onselectedindexchanged="ddltag_SelectedIndexChanged">
                        </asp:DropDownList>
                        <script type="text/javascript">
                            $('#<%=ddltag.ClientID %>').chosen();
                        </script>
                    </td>
                </tr>
            </table>
            <div>
                <hr class="divider-line" />
                <center>
                    <asp:Label ID="Lblwh" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                </center>
                <br />
                <div class="grid-wrapper">
                    <asp:GridView ID="Grdemp" HeaderStyle-BorderColor="#f2f2f2"
                        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
                        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeader="true" HeaderStyle-CssClass="sticky-header"
                        HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px"
                        HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"
                        AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"
                        AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
                        RowStyle-BorderColor="#f2f2f2" runat="server" onrowcommand="Grdemp_rowcommand">
                        <columns>
                            <asp:BoundField DataField="Division" SortExpression="Division" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Division" ItemStyle-Width="200px" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="ZSM CODE" SortExpression="ZSM CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="ZSM Code" ItemStyle-Width="200px" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="ZSM_Name" SortExpression="ZSM_Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="ZSM Name" ItemStyle-Width="300px" HeaderStyle-Width="300px" />
                            <asp:BoundField DataField="Unblocked" SortExpression="Unblocked" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Unblocked" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Blocked" SortExpression="Blocked" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Blocked" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Total" SortExpression="Total" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Total" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Unblocked Percentage" SortExpression="Unblocked Percentage" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Unblocked Percentage" ItemStyle-Width="200px" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="Approved" SortExpression="Approved" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Status" ItemStyle-Width="200px" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="Remark" SortExpression="Remark" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Remark" ItemStyle-Width="200px" HeaderStyle-Width="200px" />

                            <asp:TemplateField HeaderText="Approval List" ItemStyle-HorizontalAlign="center">
                                <itemtemplate>
                                    <div class="approvalAction">                                    
                                    <asp:CheckBox ID="Checkedbox" Enabled="false" Checked="true" runat="server" />
                                    <asp:Button ID="btnApproved" Enabled="true" CssClass="addbtn green" CommandArgument='<%#Eval("ZSM CODE") + ";" +Eval("ZSM_Name")+ ";" +Eval("Unblocked Percentage") + ";" +Eval("Approved")%>' CommandName="btncApproved" runat="server" Text="Approved" />
                                    <asp:Button ID="btnNotApproved" Enabled="true" CssClass="addbtn danger" CommandArgument='<%#Eval("ZSM CODE") + ";" +Eval("ZSM_Name")+ ";" +Eval("Unblocked Percentage") + ";" +Eval("Approved")%>' CommandName="btncNotApproved" runat="server" Text="Not Approved" />
                                    <asp:ImageButton ID="btnview" Enabled="true" Width="20px" CommandName="btncview" CommandArgument='<%#Eval("ZSM CODE") + ";" +Eval("ZSM_Name")+ ";" +Eval("Unblocked Percentage") + ";" +Eval("Approved")%>' runat="server"
                                        ImageUrl="~/images/search.png" ToolTip="view" />
                                    </div>
                                </itemtemplate>
                            </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div id="notificationBadge" runat="server" class="notification-badge">
        </div>
        <div id="notificationPopup" runat="server" class="notification">
            <asp:GridView ID="notific" HeaderStyle-BackColor="#0d9dbc"
                HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px"
                HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
                RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px"
                RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true"
                HeaderStyle-Height="3px" AlternatingRowStyle-Height="15px" RowStyle-Height="15px"
                HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2" ShowHeader="false"
                AlternatingRowStyle-ForeColor="Black" RowStyle-Font-Size="Small" AutoGenerateColumns="false"
                AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
                RowStyle-BorderColor="#f2f2f2" runat="server"
                Height="50px" Width="100%">
                <columns>
                    <asp:BoundField DataField="NOTIFICATION" ItemStyle-Font-Size="Medium" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Notifications" />
                    <asp:BoundField DataField="Time" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Time" />
                </columns>
            </asp:GridView>
            <asp:Button ID="btnCloseNotification" runat="server" Text="Close" OnClick="btnCloseNotification_Click" />
        </div>
        <div>
            <hr class="divider-line" />
        </div>
        <center>
            <asp:Label ID="lblnow" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        </center>
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <contenttemplate>
                <div class="grid-wrapper topbotMar">
                    <asp:GridView ID="Grdrprt" HeaderStyle-BorderColor="#f2f2f2"
                        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
                        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeader="true" HeaderStyle-CssClass="sticky-header"
                        HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px"
                        HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"
                        AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"
                        AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
                        RowStyle-BorderColor="#f2f2f2" runat="server" OnRowDataBound="Grdemp_NEERowdatabound">
                        <columns>
                            <asp:BoundField DataField="Territory Name" SortExpression="Territory Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name" HeaderStyle-Width="120px" />
                            <asp:BoundField DataField="SALES_ACC_NAME" SortExpression="SALES_ACC_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name" HeaderStyle-Width="120px" />
                            <asp:BoundField DataField="SALES_PROD_NAME" SortExpression="SALES_PROD_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name" HeaderStyle-Width="120px" />
                            <asp:BoundField DataField="SALES_2023-05" SortExpression="SALES_2023-05" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales AUG-25(V)" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="SALES_2023-06" SortExpression="SALES_2023-06" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="SALES_2023-07" SortExpression="SALES_2023-07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="AVG_SEC_JUL23" SortExpression="AVG_SEC_JUL23" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months(V)" HeaderStyle-Width="210px" />
                            <asp:BoundField DataField="CLO_2023_07" SortExpression="CLO_2023_07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (V)" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="CLO_Unit_07" SortExpression="CLO_Unit_07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (U)" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="Brands" SortExpression="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Brands" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="Tag" SortExpression="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Tag" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="Liquidation" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Liquidation Plan(Month)" HeaderStyle-Width="70px" />
                            <asp:BoundField DataField="ReasonUnblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Reason For Unblock" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Remark" SortExpression="Remark" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Remark" ItemStyle-Width="200px" HeaderStyle-Width="200px" />

                            <asp:TemplateField HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200px" HeaderText="Unblock">
                                <itemtemplate>
                                    <center>
                                        <asp:DropDownList ID="ddlblock" AutoPostBack="true" CssClass="ddl22" runat="server">
                                        </asp:DropDownList>
                                    </center>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="recommendation" SortExpression="recommendation" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="BH Recommendation" ItemStyle-Width="200px" HeaderStyle-Width="200px" />

                        </columns>
                    </asp:GridView>
                </div>
            </contenttemplate>
            <triggers>
                <asp:AsyncPostBackTrigger ControlID="Grdrprt" />
            </triggers>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="btndisapp" CssClass="addbtn" runat="server" Text="DHblocked" onclick="btndisapp_Click" />
    </div>
    <script type="text/javascript">
        function openNav() {
            document.getElementById("mySidenav").style.width = "250px";
        }
        function closeNav() {
            document.getElementById("mySidenav").style.width = "0";
        }
    </script>
</asp:Content>
