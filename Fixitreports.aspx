<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="Fixitreports.aspx.cs" Inherits="Fixitreports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js" 
    integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" 
    integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" /> 
<style type="text/css">
      .sidenav {
  height:100%;
  width: 0;
  position: fixed;
  z-index: 1000;
  top: 10;
  left: 0; 
  background-color:#0d9dbc;
  overflow-x: hidden;
  transition: 0.5s;
  border-radius: 0px 10px 0px 0px;
  padding-top:60px;
}

.sidenav a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 25px;
  color:White;
  display: block;
  transition: 0.3s;
}

.sidenav a:hover {
  color:#0d9dbc;
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
  color: White !important;
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
                           </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="Hidnfldname" runat="server" />
        <asp:HiddenField ID="Hidnfldcode" runat="server" />
            <asp:HiddenField ID="Hidnfldiv" runat="server" />
              <asp:HiddenField ID="Hidnfldlogin" runat="server" />
              <asp:HiddenField ID="HiddenfldBH_Code" runat="server" />
    <div id="header pull-left" style="width: 100%">
       <p style="background-color:#0d9dbc; height: 9px; width: 100%; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="87%" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
         FIXIT - Expiry Reduction</b></label> 
        </asp:Panel>
  <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 100%; margin-left: 0px;" />
  <table style=" width:100%; margin-top:0px; top: 86px;"> <td class="style1"><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
     
        <td> <div id="header pull-right" style="width:100%;text-align:left;">
      <asp:Label ID="Label1"  Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
 <asp:Label ID="Lblwelcm"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Lbldetail"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        </td><td></td>
                   <div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
   <%--<asp:DropDownList ID="ddlmasters" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlmaster_SelectedIndexChanged" runat="server">
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
   <br />
   <asp:Button ID="btnnav2" CssClass="button" runat="server"  OnClick="btntemp"  Text="Templates" />
  --%>
  
  <%--  <asp:Button ID="btnnav4" CssClass="button"  runat="server"  OnClick="btnsettng" Text="Settings" />
    <br />--%>
   <asp:Button ID="btnsm" CssClass="button"  runat="server" OnClick="btnsumm" Text="Home" />
     <br />
      <asp:Button ID="btnnav2" CssClass="button" runat="server"  OnClick="btntemp"  Text="Blocking List" />
  <br />
   <asp:DropDownList ID="ddlreports" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlreport_SelectedIndexChanged" runat="server">
     <asp:ListItem Text="Reports"></asp:ListItem>
      <%--<asp:ListItem Text="Overall Summary Report" Value="sumaryreport"></asp:ListItem>--%>
                         <%--<asp:ListItem Text="Savings(Expiry Reduction)" Value="Stockist master"></asp:ListItem>--%>
                         <asp:ListItem Text="Unblocking Report" Value="btnreprt"></asp:ListItem>
                       <%--<asp:ListItem Text="Inventory Days" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Sales Expiry" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Stockist Reports" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="HQ Reports" Value="Product master"></asp:ListItem>
                        <asp:ListItem Text="Closing Value Trends" Value="closingtrnd"></asp:ListItem>
                         <asp:ListItem Text="Inevitable Expiry" Value="Product master"></asp:ListItem>--%>
                 </asp:DropDownList>
   <br />
   <asp:Button ID="Button7" CssClass="button" runat="server" OnClick="btnloginDetails"  Text="Login Details" />
    <%--<br />
   
     <asp:Button ID="Button8" CssClass="button" runat="server" OnClick="btnApprovalDetails"  Text="Templateconsolidate" />--%>
     <br />
   <asp:Button ID="Button4" CssClass="button"  runat="server" OnClick="btnnotific" Text="Notifications" />
<br />
       <asp:Button ID="btnconta" CssClass="button"  runat="server" OnClick="btncontac" Text="Contact Us" />
      <br />
   <asp:Button ID="btnout" CssClass="button"  runat="server" OnClick="btnoutclick" Text="Logout" />
   </div>
     </table>    <script type="text/javascript">
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
    }
</script>
</div>
<div style=" text-align:right;"> 
 <table><td></td><td style=" width:1500px; text-align:right"><asp:Label ID="Lblcount"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> 
 <asp:Label ID="lblchecked"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> <asp:Label ID="Lblrows"  Font-Size="Medium" Font-Bold="true" CssClass="rigg" Font-Names="calibri" runat="server"></asp:Label></td>
  </table>
 <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>    
 <div style=" text-align:right; height: 15px;"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Bold="true" CssClass="addbtn" Text="Export to Excel" />
   <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Font-Bold="true" ToolTip="Export Blocking/Unblocking List of this DIVISION" CssClass="addbtn" Text="Export to Excel" />
   <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Font-Bold="true" ToolTip="Export Blocking/Unblocking List of this ZSM" CssClass="addbtn" Text="Export to Excel" />
      <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Font-Bold="true" ToolTip="Export Blocking/Unblocking List of this Tag" CssClass="addbtn" Text="Export to Excel" />
   <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Font-Bold="true" ToolTip="Export Blocking/Unblocking List of this Brand" CssClass="addbtn" Text="Export to Excel" />
 </div>
      <center>  <asp:Label ID="Lblwh"  Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>
   <br />
   <hr style="width: 100%; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px; height: -16px;" />
   <div style=" text-align:left; height:50px;"> 
         <asp:Label ID="Label4" Font-Size="Medium" Font-Bold="true" Text="Brands:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddlbrand" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlbrnd_SelectedIndexChanged">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddlbrand.ClientID %>').chosen();
                </script>  
                  <asp:Label ID="Label5" Font-Size="Medium" Font-Bold="true" Text="Tags:" Font-Names="calibri" runat="server"></asp:Label>
 <asp:DropDownList ID="ddltag" CssClass="ddl" Width="150px" runat="server" AutoPostBack="true"  onselectedindexchanged="ddltag_SelectedIndexChanged">
                 </asp:DropDownList>
                 <script type="text/javascript">
                     $('#<%=ddltag.ClientID %>').chosen();
                </script>
                <asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="Division:" Font-Names="calibri" runat="server"></asp:Label> <asp:DropDownList ID="ddldivname" Width="150px" CssClass="ddl" runat="server" AutoPostBack="true"  onselectedindexchanged="ddldiv_SelectedIndexChanged">
                 </asp:DropDownList>       <script type="text/javascript">
                                               $('#<%=ddldivname.ClientID %>').chosen();
                </script> 
 <asp:Label ID="Label3" Font-Size="Medium" Font-Bold="true" Text="ZSM Name:" Font-Names="calibri" runat="server"></asp:Label><asp:DropDownList ID="ddlempname" Width="150px" CssClass="ddl"  runat="server" AutoPostBack="true"  onselectedindexchanged="ddlemp_SelectedIndexChanged">
                 </asp:DropDownList>       <script type="text/javascript">
                                               $('#<%=ddlempname.ClientID %>').chosen();
                </script> 
                           
                </div>
    <asp:GridView ID="Grdreport" HeaderStyle-BackColor="#0d9dbc"  RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="left"
            HeaderStyle-BorderColor="#f2f2f2"  HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"   HeaderStyle-CssClass="frozen-header" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2" 
            AlternatingRowStyle-ForeColor="Black"     RowStyle-Font-Size="11 px" HeaderStyle-Font-Size="13 px" 
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server" AutoGenerateColumns="false"  
            Height="50px" Width="1500px" AllowSorting="true" OnSorting="Grdreport_Sorting">
            <Columns >     
               <asp:BoundField DataField="SALES_DIVISION"  ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Division"  HeaderStyle-Width="100px" SortExpression="SALES_DIVISION" />
               <asp:BoundField DataField="Territory Name"  ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name"  HeaderStyle-Width="100px" SortExpression="Territory Name" />                    
              <asp:BoundField DataField="ZSM NAME"  ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="ZSM Name"  HeaderStyle-Width="100px" SortExpression="ZSM NAME" />
             <asp:BoundField DataField="SALES_ACC_NAME"  ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name"  HeaderStyle-Width="100px" SortExpression="SALES_ACC_NAME" />
                <asp:BoundField DataField="SALES_PROD_NAME"  ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name"  HeaderStyle-Width="100px" SortExpression="SALES_PROD_NAME" />
             <asp:BoundField DataField="SALES_2023-05"  ItemStyle-HorizontalAlign="Right"  HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)"  HeaderStyle-Width="200px" SortExpression="SALES_2023-05" />
                <asp:BoundField DataField="SALES_2023-06"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)"  HeaderStyle-Width="200px" SortExpression="SALES_2023-06" />
              <asp:BoundField DataField="SALES_2023-07"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales NOV-25(V)"  HeaderStyle-Width="200px" SortExpression="SALES_2023-07" />
               <asp:BoundField DataField="AVG_SEC_JUL23"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="center" HeaderText="Avg.Secondary 3 months(V)"  HeaderStyle-Width="200px" SortExpression="AVG_SEC_JUL23" />
               <asp:BoundField DataField="CLO_2023_07"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (V)"  HeaderStyle-Width="200px" SortExpression="CLO_2023_07" />
             <asp:BoundField DataField="CLO_Unit_07"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (U)"  HeaderStyle-Width="200px" SortExpression="CLO_Unit_07" />
                <asp:BoundField DataField="Unblock"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Unblock"  HeaderStyle-Width="70px" SortExpression="Unblock" />
              <asp:BoundField DataField="ReasonUnblock"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Reason For Unblock"  HeaderStyle-Width="100px" SortExpression="ReasonUnblock" />
            </Columns>           
</asp:GridView>
     <hr style="width: 100%; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px;" />
      </div>
</asp:Content>
