<%@ page title="" language="C#" masterpagefile="~/fixitmasterpage.master" autoeventwireup="true" codefile="Templates.aspx.cs" inherits="Templates" %>

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
                    <asp:Panel ID="Panel1" CssClass="blue-band" runat="server">
                        FIXIT - Expiry Reduction
                    </asp:Panel>
                </div>
                <hr class="header-line bottom" />
            </div>
            <div id="labelStripContainer">
                <asp:Label CssClass="moving-label" Text="Last date of submission: 28th November 2025 till 5.00 PM & if invoice channel type is medvol ZSM can place order" runat="server"></asp:Label>
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
            <div class="info-action">
                <asp:Label ID="Lblwh" runat="server" class="info"></asp:Label>
                <div class="action">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Bold="true" CssClass="addbtn" Text="Download Submitted List" />
                    <asp:Button ID="Button2" runat="server" OnClick="Blocking_Click" Font-Bold="true" ToolTip="Download Overall Blocking List" CssClass="addbtn" Text="Blocking List to Excel" />
                </div>
                <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
            </div>
            <div id="divxl" runat="server"></div>
            <div id="pnom" runat="server" class="grid-wrapper">
                <asp:UpdatePanel ID="updatePanel1" runat="server">
                    <contenttemplate>
                        <asp:GridView ID="Grdemp"
                            HeaderStyle-BorderColor="#f2f2f2"
                            HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
                            RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeader="true" HeaderStyle-CssClass="sticky-header"
                            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px"
                            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"
                            AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"
                            AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
                            RowStyle-BorderColor="#f2f2f2" runat="server" OnRowDataBound="Grdemp_Rowdatabound">
                            <columns>
                                <asp:BoundField DataField="SALES_DIVISION" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Division" HeaderStyle-Width="30px" />
                                <asp:BoundField DataField="ZSM CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Zsm Code" HeaderStyle-Width="30px" />
                                <asp:BoundField DataField="ZSM NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Zsm Name" HeaderStyle-Width="30px" />
                                <asp:BoundField DataField="Territory Code" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Code" HeaderStyle-Width="100px" />
                                <asp:BoundField DataField="Territory Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name" ItemStyle-CssClass="width-150" />
                                <asp:BoundField DataField="SALES_GCV_ACC_CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Code" HeaderStyle-Width="60px" />
                                <asp:BoundField DataField="SALES_ACC_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name" ItemStyle-CssClass="width-150" />
                                <asp:BoundField DataField="SALES_ProdID" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Code" HeaderStyle-Width="10px" />
                                <asp:BoundField DataField="SALES_PROD_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name" ItemStyle-CssClass="width-150" />
                                <asp:BoundField DataField="SALES_2023-06" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales AUG-25(V)" ItemStyle-CssClass="width-100" />
                                <asp:BoundField DataField="SALES_2023-07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)" ItemStyle-CssClass="width-100" />
                                <asp:BoundField DataField="SALES_2023-08" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)" ItemStyle-CssClass="width-100" />
                                <asp:BoundField DataField="AVG_SEC_AUG23" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months" ItemStyle-CssClass="width-100" />
                                <asp:BoundField DataField="CLO_2023_08" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (V)" ItemStyle-CssClass="width-100" />
                                <asp:BoundField DataField="CLO_Unit_08" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing OCT-25 (U)" ItemStyle-CssClass="width-100" />
                                <asp:BoundField DataField="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="left" HeaderText="Brands" ItemStyle-CssClass="width-100" visible="false" />
                                <asp:BoundField DataField="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="left" HeaderText="Tag" ItemStyle-CssClass="width-100" />
                                <asp:BoundField DataField="BH_Code" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="left" HeaderText="Tag" ItemStyle-Width="150px" HeaderStyle-Width="150px" Visible="false" />

                                <asp:TemplateField HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderText="Unblock">
                                    <itemtemplate>
                                        <%--<center>  <asp:CheckBox ID="CheckBox1" ToolTip="Click to Unblock"  AutoPostBack="true" OnCheckedChanged="changed" runat="server" />  </center>--%>
                                        <center>
                                            <asp:DropDownList ID="ddlUnblock" AutoPostBack="true" OnSelectedIndexChanged="changed" CssClass="ddl" runat="server">
                                            </asp:DropDownList>
                                        </center>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="width-100" HeaderStyle-HorizontalAlign="Center" HeaderText="Liquidation Plan(Month)" visible="false">
                                    <itemtemplate>
                                        <center>
                                            <asp:DropDownList ID="ddlliquid" Enabled="false" CssClass="ddl" runat="server">
                                            </asp:DropDownList>
                                        </center>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="width-100" HeaderStyle-HorizontalAlign="Center" HeaderText="Reason for Unblock">
                                    <itemtemplate>
                                        <asp:DropDownList ID="ddlReason" CssClass="ddl" Enabled="true" runat="server">
                                            <asp:ListItem Text="-- Select Reason --" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Inventory stock already liquidated" Value="Inventory stock already liquidated"></asp:ListItem>
                                            <asp:ListItem Text="Demand / POB expected shortly" Value="Demand / POB expected shortly"></asp:ListItem>
                                            <asp:ListItem Text="Error in Secondary Data Reported" Value="Error in Secondary Data Reported"></asp:ListItem>
                                            <asp:ListItem Text="New product Launch or reactivation push" Value="New product Launch or reactivation push"></asp:ListItem>
                                            <asp:ListItem Text="Marketing campaign aligned requirement of stock" Value="Marketing campaign aligned requirement of stock"></asp:ListItem>
                                        </asp:DropDownList>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="width-100" HeaderStyle-HorizontalAlign="Center" HeaderText="Remark">
                                    <itemtemplate>
                                        <asp:TextBox ID="txtreason" CssClass="ddl" Enabled="false" runat="server"></asp:TextBox>
                                    </itemtemplate>
                                </asp:TemplateField>
                            </columns>
                        </asp:GridView>
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="Grdemp" />
                    </triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <asp:Button ID="btnreview" CssClass="addbtn" runat="server" Text="Review" ToolTip="This action will keep your Selected SKU in save mode"
            onclick="btnreview_Click" />
        <center>
            <asp:Label ID="Lblnote" Font-Size="Large" Font-Bold="true" ForeColor="Maroon" Font-Names="calibri" runat="server">Your Unblocking list sent for further Approval</asp:Label>
        </center>
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
                RowStyle-BorderColor="#f2f2f2" runat="server" AllowSorting="true"
                OnSorting="Grdrprt_Sorting">
                <columns>
                    <asp:BoundField DataField="Territory Name" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name"
                        HeaderStyle-Width="120px" SortExpression="Territory Name" />
                    <asp:BoundField DataField="SALES_ACC_NAME" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name"
                        HeaderStyle-Width="120px" SortExpression="SALES_ACC_NAME" />
                    <asp:BoundField DataField="SALES_PROD_NAME" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name"
                        HeaderStyle-Width="120px" SortExpression="SALES_PROD_NAME" />
                    <asp:BoundField DataField="SALES_2023-05" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Pri Sales AUG-25(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}"
                        SortExpression="SALES_2023-05" />
                    <asp:BoundField DataField="SALES_2023-06" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Pri Sales SEP-25(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}"
                        SortExpression="SALES_2023-06" />
                    <asp:BoundField DataField="SALES_2023-07" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Pri Sales OCT-25(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}"
                        SortExpression="SALES_2023-07" />
                    <asp:BoundField DataField="AVG_SEC_JUL23" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Avg.Secondary 3 months(V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}"
                        SortExpression="AVG_SEC_JUL23" />
                    <asp:BoundField DataField="CLO_2023_07" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Closing OCT-25 (V)" HeaderStyle-Width="200px" DataFormatString="{0:N2}"
                        SortExpression="CLO_2023_07" />
                    <asp:BoundField DataField="CLO_Unit_07" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Closing OCT-25 (U)" HeaderStyle-Width="200px" DataFormatString="{0:N2}"
                        SortExpression="CLO_Unit_07" />
                    <asp:BoundField DataField="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"
                        HeaderStyle-HorizontalAlign="left" HeaderText="Brands" ItemStyle-Width="150px"
                        HeaderStyle-Width="150px" SortExpression="Brands" />
                    <asp:BoundField DataField="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"
                        HeaderStyle-HorizontalAlign="left" HeaderText="Tag" ItemStyle-Width="150px"
                        HeaderStyle-Width="150px" SortExpression="Tag" />
                    <asp:BoundField DataField="Unblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center" HeaderText="Unblock" HeaderStyle-Width="100px"
                        SortExpression="Unblock" />
                    <asp:BoundField DataField="Liquidation" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                        HeaderText="Liquidation Plan(Month)" HeaderStyle-Width="100px" SortExpression="Liquidation" />
                    <asp:BoundField DataField="ReasonUnblock" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                        HeaderText="Reason For Unblock" HeaderStyle-Width="100px" SortExpression="ReasonUnblock" />
                    <asp:BoundField DataField="Approved" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-Width="100px"
                        SortExpression="Approved" />
                    <asp:BoundField DataField="Remark" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center" HeaderText="Remark" HeaderStyle-Width="100px"
                        SortExpression="Remark" />
                </columns>
            </asp:GridView>
        </div>
        <div class="grid-wrapper">
            <asp:GridView ID="gridedit" HeaderStyle-BorderColor="#f2f2f2"
                HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
                RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeader="true" HeaderStyle-CssClass="sticky-header"
                HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px"
                HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"
                AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"
                AlternatingRowStyle-BorderColor="#f2f2f2" RowStyle-BackColor="white"
                RowStyle-BorderColor="#f2f2f2" runat="server">
                <columns>
                    <asp:BoundField DataField="Territory Name" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name"
                        HeaderStyle-Width="120px" />
                    <asp:BoundField DataField="SALES_ACC_NAME" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name"
                        HeaderStyle-Width="120px" />
                    <asp:BoundField DataField="SALES_PROD_NAME" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name"
                        HeaderStyle-Width="120px" />
                    <asp:BoundField DataField="SALES_2023-05" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Pri Sales AUG-25(V)" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="SALES_2023-06" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Pri Sales SEP-25(V)" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="SALES_2023-07" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Pri Sales OCT-25(V)" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="AVG_SEC_JUL23" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Avg.Secondary 3 months(V)" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="CLO_2023_07" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Closing OCT-25 (V)" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="CLO_Unit_07" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                        HeaderText="Closing OCT-25 (U)" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"
                        HeaderStyle-HorizontalAlign="left" HeaderText="Brands" ItemStyle-Width="150px"
                        HeaderStyle-Width="150px" />
                    <asp:BoundField DataField="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"
                        HeaderStyle-HorizontalAlign="left" HeaderText="Tag" ItemStyle-Width="150px"
                        HeaderStyle-Width="150px" />
                    <asp:BoundField DataField="Unblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center" HeaderText="Unblock" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="Liquidation" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                        HeaderText="Liquidation Plan(Month)" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="ReasonUnblock" ItemStyle-Font-Size="Small"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                        HeaderText="Reason For Unblock" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="Remark" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center" HeaderText="Remark" HeaderStyle-Width="100px" />

                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="center">
                        <itemtemplate>
                            <asp:ImageButton ID="btndele" Enabled="true" Width="20px"
                                ToolTip="This action will delete the selected SKU" CommandName="btncdele"
                                CommandArgument='<%#Eval("Territory Name") + "^" +Eval("SALES_ACC_NAME")+ "^" +Eval("SALES_PROD_NAME")%>'
                                runat="server" ImageUrl="~/images/Delete-Button.png" class="ttip_t" />
                        </itemtemplate>
                    </asp:TemplateField>
                </columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnadd" CssClass="addbtn" ToolTip="Add more SKU's" runat="server" Text="Add"
            onclick="btnadd_Click" />
        <asp:Button ID="btnccancel" CssClass="addbtn" ToolTip="This action will delete all the selected SKU's" runat="server" Text="Cancel"
            onclick="btncancel_Click" />
        <asp:Button ID="btnsubmit" CssClass="addbtn" runat="server" Text="Submit" ToolTip="This action will Submit all the Selected SKU's as your Unblocking list"
            onclick="btnsubmit_Click" />
        <asp:Button ID="Btnsubmore" ToolTip="This action will Submit all the Selected SKU's as your Unblocking list" CssClass="addbtn" runat="server" Text="Submit"
            onclick="btnsubmore_Click" />
        <ajaxtoolkit:modalpopupextender id="ModalPopupExtender1" runat="server" cancelcontrolid="btntcancel"
            popupcontrolid="Popup" targetcontrolid="Btnnav6" backgroundcssclass="modalBackground">
        </ajaxtoolkit:modalpopupextender>
        <div id="Popup" class="modalpopup">
            <br />
            <center>
                <asp:Label ID="lblwarning" runat="server"
                    Style="font-size: 20px; vertical-align: baseline; font-weight: bold; color: Maroon; font-family: Calibri;"></asp:Label>
            </center>
            <br />
            <center>
                <asp:Button ID="btnok" CssClass="popbtn" runat="server" ToolTip="This action will keep your Selected SKU in save mode" Text="OK" onclick="btnok_Click" />
                <asp:Button ID="btntcancel" CssClass="hidden" runat="server" ToolTip="This action will delete all the Selected SKU's" onclick="btncancel_Click" />
                <asp:Button ID="btncancel" CssClass="popbtn" runat="server" ToolTip="This action will delete all the Selected SKU's" Text="Cancel" onclick="btncancelerror_Click" />
            </center>
        </div>
        <ajaxtoolkit:modalpopupextender id="ModalPopupExtender2" runat="server" cancelcontrolid="btnokcancelterror"
            popupcontrolid="error" targetcontrolid="Btnnav6" backgroundcssclass="modalBackground">
        </ajaxtoolkit:modalpopupextender>
        <div id="error" class="modalpopup">
            <center>
                <label id="lblerror"
                    style="font-size: 30px; vertical-align: baseline; font-weight: bold; color: Red; font-family: Calibri;">
                    You have Selected Nothing to Unblock
                </label>
            </center>
            <br />
            <br />
            <center>
                <asp:Button ID="btnokerror" CssClass="popbtn2" runat="server" Text="OK I Know" ToolTip="This action will Submit your Unblocking list with 0% Unblocking" onclick="btnokerror_Click" />
                <asp:Button ID="btnokcancelterror" CssClass="hidden" runat="server" onclick="btncancel_Click" />
                <asp:Button ID="btnokcancelerror" CssClass="popbtn2" Width="150px" runat="server" Text="I want to Add more" onclick="btncancelerror_Click" />
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
