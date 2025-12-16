<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="Login_Details_Admin.aspx.cs" Inherits="Login_Details_Admin" %>
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
       width:300px;
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
            height:35px;
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
          .buttondis
{           border:none;
       width:300px;
       height:50px;
       background-color:#0d9dbc;
       color:#0d9dbc;
       text-align:center;
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

    .movingLabel {
        position: absolute;
        left: -100%; /* Initial position outside the container */
        white-space: nowrap; /* Prevent labels from wrapping */
        animation: moveLabel 10s linear infinite; /* Animation properties */
       
    }
     .moving-label {
    position: absolute;
    top: 100px;
    left: 0; /* Start from the leftmost position */
    white-space: nowrap; /* Prevent label text from wrapping */
    transition: left 5s linear; /* Transition for smooth movement */
}
.active {
  background-color: #004c70 !important; /* Darker highlight */
  color: white !important;
  font-weight: bold;
}
.button2
 {
   box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
       border:none;
       width:250px;
       height:50px;
       background-color:#0d9dbc;
       color:white;
       text-align:center;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="Hidnfldname" runat="server" />
        <asp:HiddenField ID="Hidnfldcode" runat="server" />
            <asp:HiddenField ID="Hidnfldiv" runat="server" />
              <asp:HiddenField ID="Hidnfldlogin" runat="server" />
              <asp:HiddenField ID="HiddenfldBH_Code" runat="server" />
    <div id="header pull-left" style="width: 92%; height: 148px;">
       <p style="background-color:#0d9dbc; height: 9px; width: 1520px; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="1330px" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
       Login Details</b></label> 
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 1520px; margin-left: 0px;" />
  <table style=" width:109%; margin-top:0px height: 51px; height: 50px;"> 
      <td class="style1"><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
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
 <%--    <asp:Button ID="btnnav2" CssClass="button" runat="server"  OnClick="btnhome" Text="Home" />
   <br />--%>
      <%-- <asp:DropDownList ID="ddlmasters" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlmaster_SelectedIndexChanged" runat="server">
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
  <%-- <asp:Button ID="btnreprt" CssClass="button" runat="server" OnClick="btnreprt" Text="Unblocking Reoprt" />--%>
   <%--<br />
    <asp:Button ID="btnnav4" CssClass="button"  runat="server" OnClick="btnsettng" Text="Settings" />
    <br /> --%> 
  <asp:Button ID="Btnnav6" CssClass="buttondis" runat="server" Enabled="false"  Text="Disable" />
   <br />
   <asp:Button ID="Btnnav7" CssClass="button"  runat="server"  OnClick="btnapp" Text="Home" />
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
     <asp:Button ID="Button3" CssClass="button" runat="server" OnClick="btnloginDetails"  Text="Login Details" />

   
    <br />
         <asp:Button ID="Button4" CssClass="button" runat="server" OnClick="btncontac"  Text="Contact Us" />
    <br />
    <%-- <asp:Button ID="btnrprt" CssClass="button"  runat="server" OnClick="btnreprt" Text="Unblocking Report" />
      <br />--%>
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
</div>
<div style=" text-align:left;"> 
   <hr style="width: 1499px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px; height: -16px;" />
 <asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="ZSM Name:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddlempname" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlemp_SelectedIndexChanged">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddlempname.ClientID %>').chosen();
                </script> 
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Bold="true" ToolTip="Export all Overall Blocking List of your DIVISION" CssClass="addbtn" Text="Export to Excel" />
    <hr style="width: 1499px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px; height: -16px;" />

  <asp:Label ID="Lblrows"  Font-Size="Medium" Font-Bold="true" CssClass="rigg" Font-Names="calibri" runat="server"></asp:Label>

   <center>  <asp:Label ID="Lblwh" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>  
 <div style=" text-align:right; height: 15px;">
 <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Font-Bold="true" ToolTip="Export Blocking List of this ZSM" CssClass="addbtn" Text="Export to Excel" />
 <br /></div>
  
    <asp:GridView ID="Grdemp" HeaderStyle-BackColor="#0d9dbc" AllowSorting="true" OnSorting="Grdemp_Sorting" HeaderStyle-CssClass="frozen-header"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2" 
            AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"   RowStyle-Font-Size="11 px" HeaderStyle-Font-Size="13 px"
            Height="50px" Width="1506px" >
            <Columns>
        
        <asp:BoundField DataField="ZSM_Code" HeaderText="ZSM Code" SortExpression="ZSM_Code" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="Password" HeaderText="Password"  ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="Division" HeaderText="Division" SortExpression="Division" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="LatestLogin" HeaderText="Latest Login" 
                        DataFormatString="{0:dd-MMM-yyyy HH:mm}" ItemStyle-HorizontalAlign="Left" />
    </Columns>           
                  </asp:GridView>
        </div><br />
   
 
        
                                         
              
</asp:Content>

