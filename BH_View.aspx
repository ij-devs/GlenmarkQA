<%@ page title="" language="C#" masterpagefile="~/fixitmasterpage.master" autoeventwireup="true" codefile="BH_View.aspx.cs" inherits="BH_View" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"
        integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css"
        integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <asp:Label ID="Label1" CssClass="moving-label" Text="Last date of submission: 28th November 2025 till 5.00 PM & if invoice channel type is medvol ZSM can place order" runat="server"></asp:Label>
            </div>
        </div>
        <div>
            <table>
                <tr>
                    <td class="style1">
                        <span style="font-size: 30px; cursor: pointer" onclick="openNav()">&#9776; </span>
                        <div id="mySidenav" class="sidenav">
                            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
                            <asp:Button ID="Btnnav6" CssClass="buttondis" runat="server" Enabled="false" Text="Disable" />
                            <br />
                            <asp:Button ID="Btnnav7" CssClass="button" runat="server" OnClick="btnapp" Text="Home" />
                            <br />
                            <asp:Button ID="Button6" CssClass="button" runat="server" OnClick="btntview" Text="Blocking List" />
                            <br />
                            <asp:Button ID="Button4" CssClass="button" runat="server" OnClick="btncontac" Text="Contact Us" />
                            <br />
                            <asp:Button ID="btnout" CssClass="button" runat="server" OnClick="btnoutclick" Text="Logout" />
                        </div>
                    </td>
                    <td class="style2">
                        <div id="header pull-right" style="width: 109%; text-align: Left; height: 48px;">
                            <asp:Label ID="Lblwelcm" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="Lblcount" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                            <br />
                        </div>
                    </td>
                    <td style="text-align: right;" class="style3">
                        <asp:Label ID="Lbldetail" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div id="notificationBadge" runat="server" class="notification-badge" style="background: none;">
                <span class="badge"></span>
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
        </div>
        <div>
            <hr class="divider-line" />
            <asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="ZSM Name:" Font-Names="calibri" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlempname" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlemp_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="Label3" Font-Size="Medium" Font-Bold="true" Text="Stockist Name:" Font-Names="calibri" runat="server" Style="margin-left: 20px;"></asp:Label>
            <asp:DropDownList ID="ddlStockist" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStockist_SelectedIndexChanged">
                <asp:ListItem Text="All Stockists" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label4" Font-Size="Medium" Font-Bold="true" Text="Product Name:" Font-Names="calibri" runat="server" Style="margin-left: 20px;"></asp:Label>
            <asp:DropDownList ID="ddlProduct" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                <asp:ListItem Text="All Products" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label5" Font-Size="Medium" Font-Bold="true" Text="Status:" Font-Names="calibri" runat="server" Style="margin-left: 20px;"></asp:Label>
            <asp:DropDownList ID="ddlStatus" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                <asp:ListItem Text="All Status" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label6" Font-Size="Medium" Font-Bold="true" Text="Tag:" Font-Names="calibri" runat="server" Style="margin-left: 20px;"></asp:Label>
            <asp:DropDownList ID="ddlTag" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTag_SelectedIndexChanged">
                <asp:ListItem Text="All Tags" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnReset" runat="server" Text="Reset Filters" CssClass="btn" OnClick="btnReset_Click" Style="margin-left: 20px;" />
            <script type="text/javascript">
                $('#<%=ddlempname.ClientID %>').chosen();
            </script>
            <hr class="divider-line" />
            <asp:Label ID="Lblrows" Font-Size="Medium" Font-Bold="true" CssClass="rigg" Font-Names="calibri" runat="server"></asp:Label>
            <center>
                <asp:Label ID="Lblwh" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
            </center>
            <div style="text-align: right; height: 15px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Bold="true" ToolTip="Export all Overall Blocking List of your DIVISION" CssClass="addbtn" Text="Overall Export to Excel" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Font-Bold="true" ToolTip="Export Blocking List of this ZSM" CssClass="addbtn" Text="Export to Excel" />
                <br />
            </div>
            <br />
            <br />
            <div class="grid-wrapper">
                <asp:GridView ID="Grdemp" HeaderStyle-BorderColor="#f2f2f2"
                    HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
                    RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeader="true" HeaderStyle-CssClass="sticky-header"
                    HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px"
                    HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"
                    AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"
                    AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
                    RowStyle-BorderColor="#f2f2f2" runat="server">
                    <columns>
                        <asp:BoundField DataField="SALES_DIVISION" SortExpression="SALES_DIVISION" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Division" HeaderStyle-Width="30px" />
                        <asp:BoundField DataField="ZSM CODE" SortExpression="ZSM CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Zsm Code" HeaderStyle-Width="30px" />
                        <asp:BoundField DataField="ZSM NAME" SortExpression="ZSM NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="ZSM Name" HeaderStyle-Width="30px" />
                        <asp:BoundField DataField="Territory Code" SortExpression="Territory Code" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Code" HeaderStyle-Width="100px" />
                        <asp:BoundField DataField="Territory Name" SortExpression="Territory Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name" HeaderStyle-Width="100px" />
                        <asp:BoundField DataField="SALES_GCV_ACC_CODE" SortExpression="SALES_GCV_ACC_CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Code" HeaderStyle-Width="60px" />
                        <asp:BoundField DataField="SALES_ACC_NAME" SortExpression="SALES_ACC_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name" HeaderStyle-Width="120px" />
                        <asp:BoundField DataField="SALES_ProdID" SortExpression="SALES_ProdID" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Code" HeaderStyle-Width="10px" />
                        <asp:BoundField DataField="SALES_PROD_NAME" SortExpression="SALES_PROD_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name" HeaderStyle-Width="110px" />
                        <asp:BoundField DataField="SALES_2023-09" SortExpression="SALES_2023-09" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales AUG-25(V)" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="SALES_2023-10" SortExpression="SALES_2023-10" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="SALES_2023-11" SortExpression="SALES_2023-11" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="AVG_SEC_NOV23" SortExpression="AVG_SEC_NOV23" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months" HeaderStyle-Width="180px" />
                        <asp:BoundField DataField="CLO_2023_11" SortExpression="CLO_2023_11" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (V)" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="CLO_Unit_11" SortExpression="CLO_Unit_11" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (U)" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="Brands" SortExpression="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Brands" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="Tag" SortExpression="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Tag" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="Approved" SortExpression="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Status" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
<asp:BoundField DataField="SubmitTime" SortExpression="SubmitTime" ItemStyle-Font-Size="Small" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="false" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Submit Time" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="ApprovalTime" SortExpression="ApprovalTime" ItemStyle-Font-Size="Small" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="false" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Approval Time" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                    </columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <center>
            <asp:Label ID="Lblnote" Font-Size="Large" Font-Bold="true" ForeColor="Green" Font-Names="calibri" runat="server">Your Unblocking list has been sent for Approval</asp:Label>
        </center>
        <center>
            <asp:Label ID="Lblanswer" Font-Size="Large" Font-Bold="true" ForeColor="Green" Font-Names="calibri" runat="server"></asp:Label>
        </center>
        <asp:GridView ID="Grdrprt" HeaderStyle-BackColor="#0d9dbc" AllowSorting="true" OnSorting="Grdrprt_Sorting"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px"
            HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px"
            RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true"
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px"
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"
            AlternatingRowStyle-ForeColor="Black" RowStyle-Font-Size="Small" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
            RowStyle-BorderColor="#f2f2f2" runat="server"
            Height="50px" Width="1506px">
            <columns>
                <asp:BoundField DataField="Territory Name" SortExpression="Territory Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name" HeaderStyle-Width="120px" />
                <asp:BoundField DataField="SALES_ACC_NAME" SortExpression="SALES_ACC_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name" HeaderStyle-Width="120px" />
                <asp:BoundField DataField="SALES_PROD_NAME" SortExpression="SALES_PROD_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name" HeaderStyle-Width="120px" />
                <asp:BoundField DataField="SALES_2023-05" SortExpression="SALES_2023-05" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales AUG-25(V)" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="SALES_2023-06" SortExpression="SALES_2023-06" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="SALES_2023-07" SortExpression="SALES_2023-07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="AVG_SEC_JUL23" SortExpression="AVG_SEC_JUL23" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months(V)" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="CLO_2023_07" SortExpression="CLO_2023_07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (V)" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="CLO_Unit_07" SortExpression="CLO_Unit_07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (U)" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="Brands" SortExpression="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Brands" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                <asp:BoundField DataField="Tag" SortExpression="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Tag" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                <asp:BoundField DataField="Unblock" SortExpression="Unblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Unblock" HeaderStyle-Width="100px" />
                <asp:BoundField DataField="Liquidation" SortExpression="Liquidation" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Liquidation Plan(Month)" HeaderStyle-Width="100px" />
                <asp:BoundField DataField="ReasonUnblock" SortExpression="ReasonUnblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Reason For Unblock" HeaderStyle-Width="100px" />
            </columns>
        </asp:GridView>
        <br />

        <asp:Button ID="btnsubmit" CssClass="addbtn" runat="server" Text="Submit" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <ajaxtoolkit:modalpopupextender id="ModalPopupExtender1" runat="server" cancelcontrolid="btntcancel"
            popupcontrolid="Popup" targetcontrolid="Btnnav6" backgroundcssclass="modalBackground">
        </ajaxtoolkit:modalpopupextender>
        <div id="Popup" class="modalpopup">
            <br />
            <center>
                <label id="lblwarning" style="font-size: 30px; vertical-align: baseline; font-weight: bold; color: Red; font-family: Calibri;">You have Unblocked 100% or Above</label></center>
            <br />
            <center>
                <asp:Button ID="btnok" CssClass="popbtn" runat="server" Text="OK" />
                <asp:Button ID="btntcancel" CssClass="hidden" runat="server" />
                <asp:Button ID="btncancel" CssClass="popbtn" runat="server" Text="Cancel" />
            </center>
        </div>
        <ajaxtoolkit:modalpopupextender id="ModalPopupExtender2" runat="server" cancelcontrolid="btnokcancelerror"
            popupcontrolid="error" targetcontrolid="Btnnav6" backgroundcssclass="modalBackground">
        </ajaxtoolkit:modalpopupextender>
        <div id="error" class="modalpopup">
            <center>
                <label id="lblerror" style="font-size: 30px; vertical-align: baseline; font-weight: bold; color: Red; font-family: Calibri;">You have Selected Nothing to Unblock </label>
            </center>
            <br />
            <center>
                <asp:Button ID="btnokerror" CssClass="popbtn2" runat="server" Text="OK I Know" />
                <asp:Button ID="btnokcancelerror" CssClass="popblbtn" runat="server" Text="Cancel" />
            </center>
        </div>
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
