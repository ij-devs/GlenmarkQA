<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Summary" %>
<%@ Register Src="~/Labels.ascx" TagPrefix="uc" TagName="Labels" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js" 
    integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" 
    integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" /> 

<style type="text/css">
      .sidenav {
    height: 100%;
    width: 0;
    position: fixed;
    z-index: 1000; /* Lower z-index */
    top: 10;
    left: 0; 
    background-color: #0d9dbc;
    overflow-x: hidden;
    transition: 0.5s;
    border-radius: 0px 10px 0px 0px;
    padding-top: 60px;
}

.sidenav a {
    padding: 8px 8px 8px 32px;
    text-decoration: none;
    font-size: 25px;
    color: White;
    display: block;
    transition: 0.3s;
}

.sidenav a:hover {
    color: #0d9dbc;
}

.sidenav .closebtn {
    position: absolute;
    top: 0;
    right: 25px;
    font-size: 36px;
    margin-left: 50px;
}
 .button
 {
   box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
       border:none;
       width:250px;
       height:50px;
       background-color:#0d9dbc;
       color:white;
       text-align:center;
      }
     #header
        {
            width: 1731px;
            margin-left: 0px;
        }
        .Panell
        {
            margin-left: 0px;
            text-align:center;
            background-color:#0d9dbc;
            color:White;
            margin-top: 0px;
            margin-bottom: 0px;
            margin-left: 118px;
            border-radius:13px;
            padding:15px 50px 0px 20px;
            font-size:large;
        }
        .addbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
            color:White;
            height:30px;
                           }
      .popblbtn
      { 
             border:none;
             background-color:White;
             color:White;
             height:1px;
             width:1px;
                           }
             .popbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:50px;
                           }
                           .popbtn2
 .popbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:100px;
                           }
          .modalBackground
    {
        background-color:Black;
        filter:alpha(opacity=90) !important;
        opacity:0.6 !important;
        z-index:30;
    }
    .box
    {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:200px;
    }
    .boxsresn
      {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:100px;
    }
    .ddl22
      {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:140px;
    }
     .ddl
    {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:80px;
    }
     .btn1
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:40px;
             Width:150px; 
                          }
                           .PanelB
    { border-color:Black; 
       border-radius:15px 15px 0px 0px;
       background-color:#F2F2F2;
        width:200px;
        height:150px;
             box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
        }
          
    .modalpopup
    {
     border-radius:15px 15px 15px 15px; 
        position:relative;
        width:450px;
        height:90px;
         top: 50px;
          left:500px;
        text-align:center;
        background-color:White;
        border:1px solid black;    
       vertical-align:middle;    
    }
                   .rigg
               {
                   text-align:left;
               }
        .style1
    {
        width: 42px;
        height: 17px;
    }
    .style2
    {
        height: 17px;
        width: 876px;
    }
      .style3
    {
        width: 639px;
    }
    .hidden { display: none; }
    
    .notification-badge {
    position: absolute;
    top: 15%;
    right: 20px;
}

.badge {
    background-color: red;
    color: white;
    padding: 0px 8px;
    border-radius: 50%;
}
    .notification 
    {
          position: fixed;
    top: 30%;
    right: 20px; /* Adjust this value to control the distance from the right side */
    transform: translateY(-50%);
    z-index: 1000;
    position: fixed;
    background-color: #fff;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
    display: none;
}
  .moving-label {
    position: absolute;
    top: 100px;
    left: 0; /* Start from the leftmost position */
    white-space: nowrap; /* Prevent label text from wrapping */
    transition: left 5s linear; /* Transition for smooth movement */
}

    .movingLabel {
        position: absolute;
        left: -100%; /* Initial position outside the container */
        white-space: nowrap; /* Prevent labels from wrapping */
        animation: moveLabel 10s linear infinite; /* Animation properties */
       
    }
    .active {
  background-color: #004c70 !important; /* Darker highlight */
  color: white !important;
  font-weight: bold;
}
.frozen-header {
    position: sticky;
    top: 0;
    background-color: white;
    z-index: 500; /* Higher z-index than sidenav */
    box-shadow: 0 2px 2px -1px rgba(0,0,0,0.1);
}

/* For older browsers */
.frozen-header {
    position: -webkit-sticky;
    position: -moz-sticky;
}

.grid-container {
    height: 400px;
    overflow: auto;
    border: 1px solid #ccc;
    position: relative;
    z-index: 1; /* Regular stacking context */
}

/* Ensure the main content has proper positioning */
.main-content {
    position: relative;
    z-index: 1;
}
                           </style>
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="Hidnfldname" runat="server" />
        <asp:HiddenField ID="Hidnfldcode" runat="server" />
            <asp:HiddenField ID="Hidnfldiv" runat="server" />
              <asp:HiddenField ID="Hidnfldlogin" runat="server" />
    <div id="header pull-left" style="width: 100%">
       <p style="background-color:#0d9dbc; height: 9px; width: 100%; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="87%" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
      FIXIT - Expiry Reduction</b></label> 
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 100%; margin-left: 0px;" />
  <table style=" width:100%; margin-top:0px; top: 86px;"> <td class="style1"><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
          <td class="style2"> 
          <div id="header pull-right" style="width: 100%; text-align:Left; height: 48px;"> 
              <asp:Label ID="Lblwelcm"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> 
   <br />
           <asp:Label ID="Lblcount"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
          <br />
          <div id="labelStripContainer">
  <uc:Labels ID="Banner" runat="server" />
</div>
           </div></td><td style=" text-align:right;" class="style3"> <asp:Label ID="Lbldetail"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></td>
                  
                   <div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
 <%--  <asp:Button ID="btnnav3" CssClass="button" runat="server"   Text="Home" />
   <br />
   <asp:DropDownList ID="ddlmasters" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlmaster_SelectedIndexChanged" runat="server">
     <asp:ListItem Text="Master"></asp:ListItem>
                         <asp:ListItem Text="Stockist Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Product Master" Value="Product master"></asp:ListItem>
                        <asp:ListItem Text="Employee Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Hierarchy Master" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="CNF Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Territory Master" Value="Product master"></asp:ListItem>
                        <asp:ListItem Text="YTD Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Product Category" Value="Product master"></asp:ListItem>
                          <asp:ListItem Text="Customer Master" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Product Division" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Product Type" Value="Product master"></asp:ListItem>
                        <asp:ListItem Text="City Master" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="HQ Master" Value="Product master"></asp:ListItem>
                 </asp:DropDownList>
   <br />--%>
    <asp:Button ID="Button2" CssClass="button" runat="server"  OnClick="btnhome"  Text="Home" />
  <br />
   <asp:Button ID="btnnav2" CssClass="button" runat="server"  OnClick="btntemp"  Text="Blocking List" />
  <br />

   <asp:DropDownList ID="ddlreports" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlreport_SelectedIndexChanged" runat="server">
     <asp:ListItem Text="Reports"></asp:ListItem>
      <%--<asp:ListItem Text="Overall Summary Report" Value="sumaryreport"></asp:ListItem>
                         <asp:ListItem Text="Savings(Expiry Reduction)" Value="Stockist master"></asp:ListItem>--%>
                         <asp:ListItem Text="Unblocking Report" Value="btnreprt"></asp:ListItem>
                      <%-- <asp:ListItem Text="Inventory Days" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Sales Expiry" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Stockist Reports" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="HQ Reports" Value="Product master"></asp:ListItem>
                        <asp:ListItem Text="Closing Value Trends" Value="closingtrnd"></asp:ListItem>
                         <asp:ListItem Text="Inevitable Expiry" Value="Product master"></asp:ListItem>--%>
                 </asp:DropDownList>
   <br />
<%--
   <asp:Button ID="btnrprt" CssClass="button"  runat="server" OnClick="btnreprt" Text="Unblocking Report" />
      <br />--%>
      
   

     <asp:Button ID="Button3" CssClass="button" runat="server" OnClick="btnloginDetails"  Text="Login Details" />
    <%--<br />
   
     <asp:Button ID="Button5" CssClass="button" runat="server" OnClick="btnApprovalDetails"  Text="Templateconsolidate" />--%>
     <br />
          <asp:Button ID="Button1" CssClass="button"  runat="server" OnClick="btnnotific" Text="Notifications" />
<br />
       <asp:Button ID="btnconta" CssClass="button"  runat="server" OnClick="btncontac" Text="Contact Us" />
      <br />
   <asp:Button ID="btnout" CssClass="button"  runat="server" OnClick="btnoutclick" Text="Logout" />
   </div><td align="right">    </td>
     </table>  
    <div id="notificationBadge" runat="server" class="notification-badge">
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
            AlternatingRowStyle-ForeColor="Black" RowStyle-Font-Size="Small"  AutoGenerateColumns="false"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"
            Height="50px" Width="100%" >
            <Columns>   
         <asp:BoundField DataField="NOTIFICATION" ItemStyle-Font-Size="Medium" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderText="Notifications" /> 
  <asp:BoundField DataField="Time" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="Time"   /> 
                              </Columns>           
                  </asp:GridView>
    <asp:Button ID="btnCloseNotification" runat="server" Text="Close" OnClick="btnCloseNotification_Click" />
</div>

<script type="text/javascript">
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
    }
</script>
<%--<script type="text/javascript">
    function startAutoMove() {
        var label = document.getElementById('<%= movingLabel.ClientID %>');

        label.style.left = '100%'; // Reset to the starting position
        label.style.transition = 'none'; // Disable transition initially

        // Use requestAnimationFrame for smoother animations
        requestAnimationFrame(function () {
            label.style.transition = 'left 10s linear'; // Adjust the duration as needed
            label.style.left = '42%'; // Move to the left
        });
    }

    // Start the animation on page load
    window.onload = startAutoMove;
    function disableButton(btn) {
        btn.disabled = true;
        btn.value = "Processing...";  // Optional text change
        return true; // continue postback
</script>--%>
</p>
</div>
   
    
<script type="text/javascript">
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
    }
</script>

  <asp:Label ID="Label3" Font-Size="Medium" Font-Bold="true" Text="Percentage:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddlpercent"  CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlpercent_SelectedIndexChanged">
  <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
  <asp:ListItem Text="Below 30%" Value="30"></asp:ListItem>
 <asp:ListItem Text="30% - 40%" Value="40"></asp:ListItem>
 <asp:ListItem Text="40% - 50%" Value="50"></asp:ListItem>
 <asp:ListItem Text="50% - 60%"  Value="60"></asp:ListItem>
  <asp:ListItem Text="60% - 70%"  Value="70"></asp:ListItem>
  <asp:ListItem Text="70% - 80%" Value="80"></asp:ListItem>
  <asp:ListItem Text="80% - 90%" Value="90"></asp:ListItem>
    <asp:ListItem Text="90% & Above" Value="90"></asp:ListItem>
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddlpercent.ClientID %>').chosen();
                </script>   <asp:Label ID="Label1" Font-Size="Medium" Font-Bold="true" Text="Division:" Font-Names="calibri" runat="server"></asp:Label> <asp:DropDownList ID="ddldivname" Width="150px" CssClass="ddl" runat="server" AutoPostBack="true"  onselectedindexchanged="FilterChanged">
                 </asp:DropDownList>       <script type="text/javascript">
                                               $('#<%=ddldivname.ClientID %>').chosen();
                </script> 
<asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="ZSM Name:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddlempname" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="FilterChanged">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddlempname.ClientID %>').chosen();
                </script> 
                 <asp:Label ID="Label4" Font-Size="Medium" Font-Bold="true" Text="Brands:" Font-Names="calibri" runat="server" Visible="false"></asp:Label>
 <asp:DropDownList ID="ddlbrand" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="FilterChanged" Visible="false">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddlbrand.ClientID %>').chosen();
                </script> 
                                  <asp:Label ID="Label5" Font-Size="Medium" Font-Bold="true" Text="Tags:" Font-Names="calibri" runat="server" Visible="false"></asp:Label>
 <asp:DropDownList ID="ddltag" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="FilterChanged" Visible="false">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddltag.ClientID %>').chosen();
                </script>
<asp:Label ID="Label6" Font-Size="Medium" Font-Bold="true" Text="Status:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddlstatus"  CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="FilterChanged">
 <%-- <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
  <asp:ListItem Text="Accept" Value="1"></asp:ListItem>
 <asp:ListItem Text="Pending" Value="2"></asp:ListItem>
 <asp:ListItem Text="Reject" Value="3"></asp:ListItem>--%>
 
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddlstatus.ClientID %>').chosen();
                </script>
                <asp:Button ID="btnResetFilters" runat="server" Text="Reset Filters" 
    CssClass="btn btn-secondary" OnClick="btnResetFilters_Click" />
              
</div>     <hr style="width: 1506px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
   <center>  <asp:Label ID="Lblwh" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
   <div style=" text-align:right"> </div>
   <br /><asp:ScriptManager ID="ScriptManger1" runat="Server" EnablePartialRendering="true">
</asp:ScriptManager>

    <asp:GridView ID="Grdemp" HeaderStyle-BackColor="#0d9dbc" AllowSorting="true" OnSorting="Grdemp_Sorting"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" HeaderStyle-CssClass="frozen-header"
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" HeaderStyle-Font-Size="13 px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
        ShowHeader="true" ShowHeaderWhenEmpty="true"
            AlternatingRowStyle-ForeColor="Black"    AutoGenerateColumns="false"  OnRowDataBound="Grdemp_RowDataBound"
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white"  DataKeyNames="ZSM_NAME"
            RowStyle-BorderColor="#f2f2f2" runat="server"  onrowcommand="Grdemp_rowcommand"  RowStyle-Font-Size="11 px"
            Height="50px" Width="1506px"  >
            <Columns>
            <asp:TemplateField HeaderText="Click To Expand" ItemStyle-HorizontalAlign="center">
                                <itemtemplate>
                                    <div class="approvalAction">                                    
                                   <asp:ImageButton ID="btnview" Enabled="true" Width="20px" CommandName="btncview" CommandArgument='<%#Eval("ZSM CODE") + ";" +Eval("ZSM_Name")+ ";" +Eval("Unblocked Percentage") + ";" +Eval("Approved")%>' runat="server"
                                        ImageUrl="~/images/View.png" ToolTip="view" />
                                    </div>
                                </itemtemplate>
                            </asp:TemplateField>
             <asp:BoundField DataField="Division" SortExpression="Division" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="center" HeaderText="Division" ItemStyle-Width="200px"  HeaderStyle-Width="200px" />
               <asp:BoundField DataField="ZSM CODE" SortExpression="ZSM CODE" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="center" HeaderText="ZSM Code" ItemStyle-Width="200px"   HeaderStyle-Width="200px" />
                 <asp:BoundField DataField="ZSM_Name" SortExpression="ZSM_Name" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="center" HeaderText="ZSM Name" ItemStyle-Width="250px"   HeaderStyle-Width="250px" />
                   <asp:BoundField DataField="Unblocked" SortExpression="Unblocked" ItemStyle-HorizontalAlign="center" HeaderText="Unblocked"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                     <asp:BoundField DataField="NO_Of_DOH" SortExpression="NO_Of_DOH"  ItemStyle-HorizontalAlign="center" HeaderText="Post-Unblock High Inv" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="NO_Of_Newadd" SortExpression="NO_Of_Newadd"  ItemStyle-HorizontalAlign="center" HeaderText="New Entry" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                            
                     <asp:BoundField DataField="Blocked" SortExpression="Blocked" ItemStyle-HorizontalAlign="center" HeaderText="Blocked"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
  <asp:BoundField DataField="Total" SortExpression="Total" ItemStyle-HorizontalAlign="center" HeaderText="Total"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
  <asp:BoundField DataField="Unblocked Percentage" SortExpression="Unblocked Percentage" ItemStyle-HorizontalAlign="center" HeaderText="Unblocked Percentage"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" DataFormatString="{0}%" /> 
                    <asp:BoundField DataField="Approved" SortExpression="Approved" ItemStyle-HorizontalAlign="center" HeaderText="Status"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" /> 
                    
                    <asp:BoundField DataField="Submit_Time" SortExpression="Submit_Time" DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" HtmlEncode="false" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="center"  HeaderText="Submit Time" ItemStyle-Width="150px"  HeaderStyle-Width="150px" />
               <asp:BoundField DataField="Approved_Time" SortExpression="Approved_Time" DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" HtmlEncode="false" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="center"  HeaderText="Approval Time" ItemStyle-Width="150px"  HeaderStyle-Width="150px" />

                    <asp:TemplateField HeaderText="Approval List" ItemStyle-HorizontalAlign="center">  <ItemTemplate>
                    <div class="approvalAction"> 
                     <asp:CheckBox ID="Checkedbox" Enabled="false"  Checked="true"  runat="server" /> 
                    <asp:Button ID="btnApproved"    BackColor="#50C878"
            runat="server" 
            Enabled="false"  
            CssClass="addbtn green" 
            CommandName="btncApproved" 
            Text="Approved"  
            OnClientClick="disableButton(this);" 
            CommandArgument='<%# 
                (Eval("ZSM CODE") == null ? "" : Eval("ZSM CODE").ToString()) + ";" +
                (Eval("ZSM_Name") == null ? "" : Eval("ZSM_Name").ToString()) + ";" +
                (Eval("Unblocked Percentage") == null ? "" : Eval("Unblocked Percentage").ToString()) + ";" +
                (Eval("Approved") == null ? "" : Eval("Approved").ToString()) %>' />        

<asp:Button ID="btnNotApproved" 
            runat="server"   BackColor="#ff0000"
            Enabled="false"  
            CssClass="addbtn" 
            CommandName="btncNotApproved"   
            Text="Not Approved"  
            OnClientClick="disableButton(this);" 
            CommandArgument='<%# 
                (Eval("ZSM CODE") == null ? "" : Eval("ZSM CODE").ToString()) + ";" +
                (Eval("ZSM_Name") == null ? "" : Eval("ZSM_Name").ToString()) + ";" +
                (Eval("Unblocked Percentage") == null ? "" : Eval("Unblocked Percentage").ToString()) + ";" +
                (Eval("Approved") == null ? "" : Eval("Approved").ToString()) %>' />

                      <%--<asp:ImageButton ID="btnview" Enabled="true" Width="20px"  CommandName="btncview" CommandArgument='<%# (Eval("ZSM CODE") ?? "") + ";" + 
                 (Eval("ZSM_Name") ?? "") + ";" + 
                 (Eval("Unblocked Percentage") ?? "") + ";" + 
                 (Eval("Approved") ?? "") %>' runat="server"
                       ImageUrl="~/images/search.png" class="ttip_t" ToolTip="view" /> --%>
                       </div>                 
                     </ItemTemplate></asp:TemplateField> 
                          </Columns>           
                  </asp:GridView>
                  

      <hr style="width: 1506px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
        <br />
           <center>  <asp:Label ID="lblnow" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
          <div style=" text-align:right"><asp:Button ID="btndisapp" CssClass="addbtn" runat="server" Text="Submit" onclick="btndisapp_Click"   BackColor="#50C878"/> </div>
       
           <div  style=" left:0px; text-align:left;">  <asp:UpdatePanel ID="updatePanel1" runat="server">
                         <ContentTemplate>
        <asp:GridView ID="Grdrprt" HeaderStyle-BackColor="#0d9dbc" AllowSorting="true" OnSorting="Grdrprt_Sorting"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true"
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2" HeaderStyle-Font-Size="13 px" 
            AlternatingRowStyle-ForeColor="Black" RowStyle-Font-Size="11 px"  AutoGenerateColumns="false"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server" OnRowDataBound="Grdemp_NEERowdatabound"
            Height="50px" Width="1506px" >
            <Columns>       
               <asp:BoundField DataField="Territory Name" SortExpression="Territory Name" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name"  HeaderStyle-Width="120px" />       
               <asp:BoundField DataField="SALES_ACC_NAME" SortExpression="SALES_ACC_NAME" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name"  HeaderStyle-Width="120px" />
                <asp:BoundField DataField="SALES_PROD_NAME" SortExpression="SALES_PROD_NAME" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name"  HeaderStyle-Width="120px" />
               <asp:BoundField DataField="SALES_2023-05" SortExpression="SALES_2023-05" ItemStyle-HorizontalAlign="Right"  HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)"  HeaderStyle-Width="180px" />
                <asp:BoundField DataField="SALES_2023-06" SortExpression="SALES_2023-06" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)"  HeaderStyle-Width="180px" />
              <asp:BoundField DataField="SALES_2023-07" SortExpression="SALES_2023-07" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales NOV-25(V)"  HeaderStyle-Width="180px" />
               <asp:BoundField DataField="AVG_SEC_JUL23" SortExpression="AVG_SEC_JUL23" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months(V)"  HeaderStyle-Width="210px" />
               <asp:BoundField DataField="CLO_2023_07" SortExpression="CLO_2023_07" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (V)"  HeaderStyle-Width="180px" />
                <asp:BoundField DataField="CLO_Unit_07" SortExpression="CLO_Unit_07" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (U)"  HeaderStyle-Width="180px" />
               <asp:BoundField DataField="INVENTORY_DAYS" SortExpression="INVENTORY_DAYS"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Inventory Days" HeaderStyle-Width="180px"  HtmlEncode="False" />
                            <asp:BoundField DataField="Tag" SortExpression="Tag"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Additional Info" HeaderStyle-Width="180px" />
                             <asp:BoundField DataField="ReasonUnblock" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="Reason For Unblock"  HeaderStyle-Width="100px" />
                 <asp:BoundField DataField="Remark" SortExpression="Remark" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="Remark"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" /> 
                                
                             <asp:TemplateField HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200px" HeaderText="Unblock">
                                       <ItemTemplate>  
                           <center> <asp:DropDownList ID="ddlblock" AutoPostBack="true"  CssClass="ddl22"  runat="server">
                 </asp:DropDownList> </center> 
                    </ItemTemplate>  
                </asp:TemplateField>  
            </Columns>           
                  </asp:GridView> </ContentTemplate>  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="Grdrprt" />
</Triggers>      
            </asp:UpdatePanel><br />
                 
          </div>
</asp:Content>


