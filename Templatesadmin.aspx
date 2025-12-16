<%@ Page Title="" Language="C#" MasterPageFile="~/fixitmasterpage.master" AutoEventWireup="true" CodeFile="Templatesadmin.aspx.cs" Inherits="Templatesadmin" %>
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
                            { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:100px;
                           }
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
        height:150px;
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
              <asp:HiddenField ID="HiddenfldBH_Code" runat="server" />
    <div id="header pull-left" style="width: 100%; height: 148px;">
       <p style="background-color:#0d9dbc; height: 9px; width: 100%; margin-bottom: 9px;"><br />
          <img src="images/ggror p.png" style=" margin-left:10px; height: 50px; width:100px" />
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="87%" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
          FIXIT - Expiry Reduction</b></label> 
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 100%; margin-left: 0px;" />
  <table style=" width:100%; margin-top:0px height: 51px; height: 50px;"> 
      <td class="style1"><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
          <td class="style2"> 
          <div id="header pull-right" style="width: 100%; text-align:Left; height: 48px;"> 
              <asp:Label ID="Lblwelcm"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> 
   <br />
           <asp:Label ID="Lblcount"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
          <br />
          <div id="labelStripContainer">
 <uc:Labels ID="Banner" runat="server" /></div>
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
   <asp:Button ID="Btnnav7" CssClass="button"  runat="server"  OnClick="btnsumm" Text="Home" />
   <br />
   <asp:Button ID="btnnav2" CssClass="button" runat="server"  OnClick="btntemp"  Text="Blocking List" />
    <br />
     <%--<asp:Button ID="btnrprt" CssClass="button"  runat="server" OnClick="btnreprt" Text="Unblocking Report" />
       <br />--%>
       <asp:DropDownList ID="ddlreports" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlreport_SelectedIndexChanged" runat="server">
     <asp:ListItem Text="Reports"></asp:ListItem>
      <%--<asp:ListItem Text="Overall Summary Report" Value="sumaryreport"></asp:ListItem>
                         <asp:ListItem Text="Savings(Expiry Reduction)" Value="Stockist master"></asp:ListItem>--%>
                         <asp:ListItem Text="Unblocking Report" Value="btnreprt"></asp:ListItem>
                       <%--<asp:ListItem Text="Inventory Days" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="Sales Expiry" Value="Product master"></asp:ListItem>
                         <asp:ListItem Text="Stockist Reports" Value="Stockist master"></asp:ListItem>
                         <asp:ListItem Text="HQ Reports" Value="Product master"></asp:ListItem>
                        <asp:ListItem Text="Closing Value Trends" Value="closingtrnd"></asp:ListItem>
                         <asp:ListItem Text="Inevitable Expiry" Value="Product master"></asp:ListItem>--%>
                 </asp:DropDownList>
   <br />
   <asp:Button ID="Button5" CssClass="button" runat="server" OnClick="btnloginDetails"  Text="Login Details" />
    <%--<br />
   
     <asp:Button ID="Button6" CssClass="button" runat="server" OnClick="btnApprovalDetails"  Text="Templateconsolidate" />--%>
     <br />
          <asp:Button ID="Button4" CssClass="button"  runat="server" OnClick="btnnotific" Text="Notifications" />
<br />
       <asp:Button ID="btnconta" CssClass="button"  runat="server" OnClick="btncontac" Text="Contact Us" />
      <br />
   <asp:Button ID="btnout" CssClass="button"  runat="server" OnClick="btnoutclick" Text="Logout" />
   </div>
     </table>    
    
<script type="text/javascript">
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
    }
</script>
</p>
</div>
<div style=" text-align:right; height: 15px;"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Bold="true" ToolTip="Export to Excel" CssClass="addbtn" Text="Overall Export to Excel" />
  <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Font-Bold="true" ToolTip="Export Blocking List of this DIVISION" CssClass="addbtn" Text="Export to Excel" />
   <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Font-Bold="true" ToolTip="Export Blocking List of this ZSM" CssClass="addbtn" Text="Export to Excel" />
 </div><br />
<div style=" text-align:left;" class="main-content"> 
   <hr style="width: 1499px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px; height: -16px;" />
    
    <asp:Label ID="Label1" Font-Size="Medium" Font-Bold="true" Text="Division:" Font-Names="calibri" runat="server"></asp:Label> 
    <asp:DropDownList ID="ddlDivision" Width="120px" CssClass="ddl" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlDivision_SelectedIndexChanged">
                 </asp:DropDownList>
                  <script type="text/javascript">
                      $('#<%=ddlDivision.ClientID %>').chosen();
                </script>
    <asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="ZSM Name:" Font-Names="calibri" runat="server"></asp:Label>
    <asp:DropDownList ID="ddlempname" CssClass="ddl" Width="120px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlemp_SelectedIndexChanged">
    </asp:DropDownList>
     <script type="text/javascript">
         $('#<%=ddlempname.ClientID %>').chosen();
                </script>

    <asp:Label ID="Label3" Font-Size="Medium" Font-Bold="true" Text="Stockist Name:" Font-Names="calibri" runat="server" Style="margin-left:20px;"></asp:Label>
    <asp:DropDownList ID="ddlStockist" CssClass="ddl" Width="120px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStockist_SelectedIndexChanged">
        <asp:ListItem Text="All Stockists" Value=""></asp:ListItem>
    </asp:DropDownList>
    <script type="text/javascript">
        $('#<%=ddlStockist.ClientID %>').chosen();
                </script>
    

    <asp:Label ID="Label4" Font-Size="Medium" Font-Bold="true" Text="Product Name:" Font-Names="calibri" runat="server" Style="margin-left:20px;"></asp:Label>
    <asp:DropDownList ID="ddlProduct" CssClass="ddl" Width="120px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
        <asp:ListItem Text="All Products" Value=""></asp:ListItem>
    </asp:DropDownList>
    <script type="text/javascript">
        $('#<%=ddlProduct.ClientID %>').chosen();
                </script>

    <asp:Label ID="Label5" Font-Size="Medium" Font-Bold="True" Text="Status:" 
        Font-Names="calibri" runat="server" Style="margin-left:20px;" Visible="False"></asp:Label>
    <asp:DropDownList ID="ddlStatus" CssClass="ddl" Width="120px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"  Visible="False">
        <asp:ListItem Text="All Status" Value=""></asp:ListItem>
    </asp:DropDownList>
    <script type="text/javascript">
        $('#<%=ddlStatus.ClientID %>').chosen();
                </script>

    <asp:Label ID="Label6" Font-Size="Medium" Font-Bold="true" Text="Tag:" Font-Names="calibri" runat="server" Style="margin-left:20px;"></asp:Label>
    <asp:DropDownList ID="ddlTag" CssClass="ddl" Width="120px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTag_SelectedIndexChanged">
        <asp:ListItem Text="All Tags" Value=""></asp:ListItem>
    </asp:DropDownList>
    <script type="text/javascript">
        $('#<%=ddlTag.ClientID %>').chosen();
                </script>

    <asp:Button ID="btnReset" runat="server" Text="Reset Filters" CssClass="btn" OnClick="btnReset_Click" Style="margin-left:20px;" />

    <hr style="width: 1499px; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px; height: -16px;" />
  
  <asp:Label ID="Lblrows"  Font-Size="Medium" Font-Bold="true" CssClass="rigg" Font-Names="calibri" runat="server"></asp:Label>

   <center>  <asp:Label ID="Lblwh" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center>  
 
   <br />
      
    <asp:GridView ID="Grdemp" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2" HeaderStyle-CssClass="frozen-header" 
            AlternatingRowStyle-ForeColor="Black" AutoGenerateColumns="false"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white"  RowStyle-Font-Size="11 px" HeaderStyle-Font-Size="13 px"
            RowStyle-BorderColor="#f2f2f2" runat="server" 
            Height="50px" Width="1506px" AllowSorting="true" OnSorting="Grdemp_Sorting">

            <Columns>
                <asp:BoundField DataField="SALES_DIVISION"   ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Division" HeaderStyle-Width="30px" SortExpression="SALES_DIVISION" />
             <asp:BoundField DataField="ZSM CODE"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Zsm Code"  HeaderStyle-Width="30px" SortExpression="ZSM CODE" />
             <asp:BoundField DataField="ZSM NAME"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Zsm Name"  HeaderStyle-Width="30px" SortExpression="ZSM NAME" />
              <asp:BoundField DataField="Territory Code"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Code"  HeaderStyle-Width="100px" SortExpression="Territory Code" />
           <asp:BoundField DataField="Territory Name"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name"  HeaderStyle-Width="100px" SortExpression="Territory Name" />
            <asp:BoundField DataField="SALES_GCV_ACC_CODE"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Code"  HeaderStyle-Width="60px" SortExpression="SALES_GCV_ACC_CODE" />
               <asp:BoundField DataField="SALES_ACC_NAME"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name"  HeaderStyle-Width="120px" SortExpression="SALES_ACC_NAME" />
                <asp:BoundField DataField="SALES_ProdID"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Code"  HeaderStyle-Width="10px" SortExpression="SALES_ProdID" />
                <asp:BoundField DataField="SALES_PROD_NAME"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name"  HeaderStyle-Width="110px" SortExpression="SALES_PROD_NAME" />
         <asp:BoundField DataField="SALES_2023-09"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)"  HeaderStyle-Width="150px" SortExpression="SALES_2023-09" />
                <asp:BoundField DataField="SALES_2023-10"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)"  HeaderStyle-Width="150px" SortExpression="SALES_2023-10" />
              <asp:BoundField DataField="SALES_2023-11"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales NOV-25(V)"  HeaderStyle-Width="150px" SortExpression="SALES_2023-11" />
       <asp:BoundField DataField="AVG_SEC_NOV23"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months"  HeaderStyle-Width="180px" SortExpression="AVG_SEC_NOV23" />
           <asp:BoundField DataField="CLO_2023_11"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (V)"  HeaderStyle-Width="150px" SortExpression="CLO_2023_11" />
               <asp:BoundField DataField="CLO_Unit_11"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (U)"  HeaderStyle-Width="150px" SortExpression="CLO_Unit_11" />
            <asp:BoundField DataField="Brands"  ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"  HeaderText="Brands" ItemStyle-Width= "150px"  HeaderStyle-Width="150px" SortExpression="Brands" />
               <asp:BoundField DataField="Tag"  ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"  HeaderText="Tag" ItemStyle-Width= "150px"  HeaderStyle-Width="150px" SortExpression="Tag" />
               <asp:BoundField DataField="Approved"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="Status"  HeaderStyle-Width="100px" SortExpression="Approved" />
               <%--<asp:BoundField DataField="LoginTime" SortExpression="LoginTime"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="left" DataFormatString="{0:dd-MMM-yyyy HH:mm}" HtmlEncode="false"  HeaderText="Login Time" ItemStyle-Width= "150px"  HeaderStyle-Width="150px" />
               --%><asp:BoundField DataField="Submit_Time" SortExpression="Submit_Time"  DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" HtmlEncode="false" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"  HeaderText="Submit Time" ItemStyle-Width= "150px"  HeaderStyle-Width="150px" />
               <asp:BoundField DataField="Approved_Time" SortExpression="Approved_Time"  DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" HtmlEncode="false" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"  HeaderText="Approval Time" ItemStyle-Width= "150px"  HeaderStyle-Width="150px" />

           <%--   <asp:TemplateField HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderText="Unblock">
                                       <ItemTemplate>  
                          <center> <asp:DropDownList ID="ddlUnblock" AutoPostBack="true" OnSelectedIndexChanged="changed" CssClass="ddl"  runat="server">
                 </asp:DropDownList> </center> 
                    </ItemTemplate>  
                </asp:TemplateField>  
                 <asp:TemplateField HeaderStyle-Width="30px"  HeaderStyle-HorizontalAlign="Center" HeaderText="Liquidation Plan(Month)"> 
                                       <ItemTemplate>  
                       <center> <asp:DropDownList ID="ddlliquid" Enabled="false" CssClass="ddl"  runat="server">
                 </asp:DropDownList> </center> 
                    </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center"  HeaderText="Reason for Unblock"> 
                                       <ItemTemplate>  
                         <asp:TextBox ID="txtreason" CssClass="ddl" Enabled="false" runat="server"></asp:TextBox> 
                    </ItemTemplate>  
                </asp:TemplateField>--%>
                          </Columns>           
</asp:GridView>
        </div><br /><%--<asp:Button ID="btnreview" CssClass="addbtn"  runat="server" Text="Review" 
        onclick="btnreview_Click" />  --%>
         <center>  <asp:Label ID="Lblnote" Font-Size="Large" Font-Bold="true"  ForeColor="Green" Font-Names="calibri" runat="server">Your Unblocking list has been sent for Approval</asp:Label></center>
       
 <center>  <asp:Label ID="Lblanswer" Font-Size="Large" Font-Bold="true"  ForeColor="Green" Font-Names="calibri" runat="server"></asp:Label></center>
         <asp:GridView ID="Grdrprt" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true"
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
            AlternatingRowStyle-ForeColor="Black" RowStyle-Font-Size="Small"  AutoGenerateColumns="false"   
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white" 
            RowStyle-BorderColor="#f2f2f2" runat="server"
            Height="50px" Width="1506px" >
         <Columns>             
            <asp:BoundField DataField="Territory Name" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Territory Name"  HeaderStyle-Width="120px" />       
               <asp:BoundField DataField="SALES_ACC_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Stockist Name"  HeaderStyle-Width="120px" />
                <asp:BoundField DataField="SALES_PROD_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="Product Name"  HeaderStyle-Width="120px" />
               <asp:BoundField DataField="SALES_2023-06" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right"  HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales SEP-25(V)"  HeaderStyle-Width="200px" />
                <asp:BoundField DataField="SALES_2023-07" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales OCT-25(V)"  HeaderStyle-Width="200px" />
              <asp:BoundField DataField="SALES_2023-08" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Pri Sales NOV-25(V)"  HeaderStyle-Width="200px" />
               <asp:BoundField DataField="AVG_SEC_AUG23" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Avg.Secondary 3 months(V)"  HeaderStyle-Width="200px" />
               <asp:BoundField DataField="CLO_2023_08" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (V)"  HeaderStyle-Width="200px" />
                <asp:BoundField DataField="CLO_Unit_08" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Closing NOV-25 (U)"  HeaderStyle-Width="200px" />
                   <asp:BoundField DataField="Brands" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"  HeaderText="Brands" ItemStyle-Width= "150px"  HeaderStyle-Width="150px" />
               <asp:BoundField DataField="Tag" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"  HeaderText="Tag" ItemStyle-Width= "150px"  HeaderStyle-Width="150px" />

                    <asp:BoundField DataField="Unblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="Unblock"  HeaderStyle-Width="100px" />
              <asp:BoundField DataField="Liquidation" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="Liquidation Plan(Month)"  HeaderStyle-Width="100px" />
               <asp:BoundField DataField="ReasonUnblock" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="Reason For Unblock"  HeaderStyle-Width="100px" />
        </Columns>    
                  </asp:GridView><br />

   <asp:Button ID="btnsubmit" CssClass="addbtn"  runat="server" Text="Submit" 
        />  
 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>    
           <ajaxToolkit:ModalPopupExtender  ID="ModalPopupExtender1" runat="server" CancelControlID= "btntcancel"
            PopupControlID="Popup" TargetControlID="Btnnav6" BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>
              <div id="Popup" class="modalpopup" >
            <br />
  <center> <label  id="lblwarning" style="font-size:30px; vertical-align:baseline; font-weight:bold; color:Red; font-family:Calibri;" >You have Unblocked 100% or Above</label></center> <br />
             <center>   <asp:Button ID="btnok" CssClass="popbtn"  runat="server" Text="OK"  />    
               <asp:Button ID="btntcancel" CssClass="hidden" runat="server"   />
          <asp:Button ID="btncancel" CssClass="popbtn"  runat="server" Text="Cancel"  /> </center> 
              </div>
                <ajaxToolkit:ModalPopupExtender  ID="ModalPopupExtender2" runat="server" CancelControlID= "btnokcancelerror"
            PopupControlID="error" TargetControlID="Btnnav6" BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>
              <div id="error" class="modalpopup" >
            
  <center> <label id= "lblerror" style="font-size:30px; vertical-align:baseline; font-weight:bold; color:Red; font-family:Calibri;" >You have Selected Nothing to Unblock </label></center> <br />
          <center>  
               <asp:Button ID="btnokerror" CssClass="popbtn2"  runat="server" Text="OK I Know" />
               <asp:Button ID="btnokcancelerror" CssClass="popblbtn"  runat="server" Text="Cancel"  />   </center>   
              </div>
  
</asp:Content>


