<%@ page title="" language="C#" masterpagefile="~/fixitmasterpage.master" autoeventwireup="true" codefile="View_ZSM.aspx.cs" inherits="View_ZSM" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"
        integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css"
        integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
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
                <asp:Label ID="Label1" Font-Size="Large" Font-Bold="true" CssClass="moving-label" Font-Names="calibri" ForeColor="Red" Text="Last date of submission: 28th November 2025 till 5.00 PM & if invoice channel type is medvol ZSM can place order" runat="server"></asp:Label>
                <br />

            </div>
        </div>
        <div>
            <table>
                <tr>
                    <td class="style1">
                        <span style="font-size: 30px; cursor: pointer" onclick="openNav()">&#9776;</span>
                        <div id="mySidenav" class="sidenav">
                            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a><br />
                            <asp:Button ID="Button4" CssClass="button" runat="server" OnClick="btntemplate" Text="Home" />
                            <br />
                            <asp:Button ID="Button5" CssClass="button" runat="server" OnClick="btntbllist" Text="Blocking List" />
                            <br />
                            <asp:Button ID="Button3" CssClass="button" runat="server" OnClick="btnnotific" Text="Notifications" />
                            <br />
                            <asp:Button ID="Btncont" CssClass="button" runat="server" OnClick="Btncontact" Text="Contact Us" />
                            <br />
                            <asp:Button ID="btnout" CssClass="button" runat="server" OnClick="btnoutclick" Text="Logout" />
                            <br />
                            <asp:Button ID="Btnnav6" CssClass="buttondis" Enabled="false" runat="server" Text="Disable" />
                        </div>
                    </td>
                    <td class="style2">
                        <div id="header pull-right">
                            <asp:Label ID="Lblwelcm" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="Lbldetail" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-top: 10px">
                        <asp:Label ID="Lblcount" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                        <asp:Label ID="lblchecked" Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
                        <asp:Label ID="Lblrows" Font-Size="Medium" Font-Bold="true" CssClass="rigg" Font-Names="calibri" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <hr class="divider-line" />
            <center>
                <asp:Label ID="Lblwh" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
            </center>
            <div style="text-align: right; height: 15px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Bold="true" CssClass="addbtn" Text="Download Submitted List" />
                <asp:Button ID="Button2" runat="server" OnClick="Blocking_Click" Font-Bold="true" ToolTip="Download Overall Blocking List" CssClass="addbtn" Text="Blocking List to Excel" />
            </div>
            <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
            <br />
            <br />
            <center>
                <asp:Label ID="Lblanswer" Font-Size="Large" Font-Bold="true" ForeColor="Blue" Font-Names="calibri" runat="server"></asp:Label>
            </center>
            <div class="grid-wrapper">
                <asp:GridView ID="Grdrprt" HeaderStyle-BorderColor="#f2f2f2"
                    HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
                    RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeader="true" HeaderStyle-CssClass="sticky-header"
                    HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px"
                    HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"
                    AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"
                    AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
                    RowStyle-BorderColor="#f2f2f2" runat="server" AllowSorting="true" OnSorting="Grdrprt_Sorting">
                    <columns>
                        <asp:BoundField DataField="Territory Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name" HeaderStyle-Width="120px" SortExpression="Territory Name" />
                        <asp:BoundField DataField="SALES_ACC_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name" HeaderStyle-Width="120px" SortExpression="SALES_ACC_NAME" />
                        <asp:BoundField DataField="SALES_PROD_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name" HeaderStyle-Width="120px" SortExpression="SALES_PROD_NAME" />
                        <asp:BoundField DataField="SALES_2023-05" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales AUG-25(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="SALES_2023-05" />
                        <asp:BoundField DataField="SALES_2023-06" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="SALES_2023-06" />
                        <asp:BoundField DataField="SALES_2023-07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="SALES_2023-07" />
                        <asp:BoundField DataField="AVG_SEC_JUL23" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="AVG_SEC_JUL23" />
                        <asp:BoundField DataField="CLO_2023_07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="CLO_2023_07" />
                        <asp:BoundField DataField="CLO_Unit_07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (U)" HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="CLO_Unit_07" />
                        <asp:BoundField DataField="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Brands" ItemStyle-Width="150px" HeaderStyle-Width="150px" SortExpression="Brands" />
                        <asp:BoundField DataField="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" HeaderText="Tag" ItemStyle-Width="150px" HeaderStyle-Width="150px" SortExpression="Tag" />
                        <asp:BoundField DataField="Unblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Unblock" HeaderStyle-Width="100px" SortExpression="Unblock" />
                        <asp:BoundField DataField="Liquidation" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Liquidation Plan(Month)" HeaderStyle-Width="100px" SortExpression="Liquidation" />
                        <asp:BoundField DataField="ReasonUnblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Reason For Unblock" HeaderStyle-Width="100px" SortExpression="ReasonUnblock" />
                        <asp:BoundField DataField="Approved" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-Width="100px" SortExpression="Approved" />
                        <asp:BoundField DataField="Remark" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Remark" HeaderStyle-Width="100px" SortExpression="Remark" />
                    </columns>
                </asp:GridView>
            </div>
            <ajaxtoolkit:modalpopupextender id="ModalPopupExtender1" runat="server" cancelcontrolid="btntcancel"
                popupcontrolid="Popup" targetcontrolid="Btnnav6" backgroundcssclass="modalBackground">
            </ajaxtoolkit:modalpopupextender>

            <ajaxtoolkit:modalpopupextender id="ModalPopupExtender2" runat="server" cancelcontrolid="btnokcancelterror"
                popupcontrolid="error" targetcontrolid="Btnnav6" backgroundcssclass="modalBackground">
            </ajaxtoolkit:modalpopupextender>
            <script type="text/javascript">
                function openNav() {
                    document.getElementById("mySidenav").style.width = "250px";
                }

                function closeNav() {
                    document.getElementById("mySidenav").style.width = "0";
                }
            </script>
        </div>
    </div>
</asp:Content>
