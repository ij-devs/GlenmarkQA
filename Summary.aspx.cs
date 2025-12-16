using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.IO;
using System.Data.Sql;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


public partial class Summary : System.Web.UI.Page
{
    public string zsmname
    {
        get
        {
            if (Request.Cookies["zsmname"] != null)
                return Request.Cookies["zsmname"].Value;
            return "";
        }
    }

    public string zcode
    {
        get
        {
            if (Request.Cookies["zcode"] != null)
                return Request.Cookies["zcode"].Value;
            return "";
        }
    }
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Banner.ShowShort();
        
        if (!IsPostBack)
        {
          
            //Hidnfldname.Value = Session["zsmname"].ToString();
            //Hidnfldcode.Value = Session["zcode"].ToString();
            //Hidnfldiv.Value = Session["divi"].ToString();
            //Hidnfldlogin.Value = Session["login"].ToString();
            LoadDropdowns();
            btndisapp.Visible = false;
            BindGrid3();
           
            ViewState["SortDirection"] = "ASC";
            
        }
        string current = System.IO.Path.GetFileName(Request.Path);

        switch (current)
        {
            case "Templatesadmin.aspx":
                btnnav2.CssClass += " active";
                break;
            case "Summary.aspx":
                Button2.CssClass += " active";
                break;
            case "Login_Details_Admin.aspx":
                Button3.CssClass += " active";
                break;
            //case "Approval_BH.aspx":
            //    Button5.CssClass += " active";
            //    break;
            case "Contactus.aspx":
                btnconta.CssClass += " active";
                break;
            case "NotificationAdmin.aspx":
                Button1.CssClass += " active";
                break;
        }
    }
    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["zsmname"] = Hidnfldname.Value.ToString();
        //Session["zcode"] = Hidnfldcode.Value.ToString();
        //Session["divi"] = Hidnfldiv.Value.ToString();
        //Session["login"] = Hidnfldlogin.Value.ToString();
        string ddlvalrep = string.Empty;
        ddlvalrep = ddlreports.SelectedValue.ToString();
        if (ddlvalrep == "btnreprt")
        {
            Response.Redirect("Fixitreports.aspx");
        }
        if (ddlvalrep == "sumaryreport")
        {
            Response.Redirect("overallsumar.aspx");
        }
        
        Session["ddlsesrep"] = ddlvalrep;
        //Response.Redirect("Fixitreports.aspx");
    }
    //public void binddropdown4()
    //{
    //    DataSet DsStockist222 = new DataSet();
    //    DataTable dtDsStockist222 = new DataTable();
    //    string StrQrry222 = "";
    //    StrQrry222 = "Select distinct Brands from [dbo].[Templateconsolidate] ;";

    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt222 = new SqlDataAdapter(StrQrry222, conn);
    //    adpRpt222.Fill(DsStockist222, "DsStockist222");
    //    adpRpt222.Fill(dtDsStockist222);
    //    if (DsStockist222.Tables[0].Rows.Count > 0)
    //    {
    //        ddlbrand.DataSource = dtDsStockist222;
    //        ddlbrand.DataTextField = "Brands";
    //        ddlbrand.DataBind();
    //        ddlbrand.Items.Insert(0, "Select");
    //        //ddlempname.SelectedIndex = 0;
    //    }

    //}
    //public void binddropdown()
    //{
    //    DataSet DsStockist222 = new DataSet();
    //    DataTable dtDsStockist222 = new DataTable();
    //    string StrQrry222 = "";
    //    StrQrry222 = "Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] ;";

    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt222 = new SqlDataAdapter(StrQrry222, conn);
    //    adpRpt222.Fill(DsStockist222, "DsStockist222");
    //    adpRpt222.Fill(dtDsStockist222);
    //    if (DsStockist222.Tables[0].Rows.Count > 0)
    //    {
    //        ddlempname.DataSource = dtDsStockist222;
    //        ddlempname.DataTextField = "ZSM NAME";
    //        ddlempname.DataBind();
    //        ddlempname.Items.Insert(0, "Select");
    //        //ddlempname.SelectedIndex = 0;
    //    }

    //}
    protected void btnShowNotification_Click(object sender, EventArgs e)
    {
        BindGridnotif();
        notificationBadge.Style["display"] = "none"; // Hide badge after clicking
        notificationPopup.Style["display"] = "block";
    }
    protected void btnCloseNotification_Click(object sender, EventArgs e)
    {
        notificationPopup.Style["display"] = "none";
    }
    public void BindGridnotif()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";

        StrQrry = "SELECT [NOTIFICATION], Max([Time]) as Time from [dbo].[Notification$] where [NOTIFICATION] not like 'You have Changed your Password to %' group by [DIVISION] , [ZSM CODE] ,[NOTIFICATION] ORDER BY [Time] DESC;";
        //     Lblwh.Text = "Approval Request";where [Unblocked Percentage] <= " + Session["ddlpercent"] + " and Division = '" + Session["ddldiv"] + "'

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            notific.DataSource = dtDsStockist;
            // notific.Columns[1].Visible = false;
            notific.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            notific.DataSource = dtDsStockist;
            notific.DataBind();
        }

    }
    //public void binddropdown3()
    //{
    //    DataSet DsStockist222 = new DataSet();
    //    DataTable dtDsStockist222 = new DataTable();
    //    string StrQrry222 = "";
    //    StrQrry222 = "Select distinct Tag from [dbo].[Templateconsolidate] ;";

    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt222 = new SqlDataAdapter(StrQrry222, conn);
    //    adpRpt222.Fill(DsStockist222, "DsStockist222");
    //    adpRpt222.Fill(dtDsStockist222);
    //    if (DsStockist222.Tables[0].Rows.Count > 0)
    //    {
    //        ddltag.DataSource = dtDsStockist222;
    //        ddltag.DataTextField = "Tag";
    //        ddltag.DataBind();
    //        ddltag.Items.Insert(0, "Select");
    //        //ddlempname.SelectedIndex = 0;
    //    }

    //}
    protected void btntemp(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Templatesadmin.aspx");
    }
    //protected void btnsettng(object sender, EventArgs e)
    //{
    //  //  Response.Redirect("settings.aspx");
    //}
    protected void ddldiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindZSM();
        BindBrands();
        BindTags();
        Bind_Status();
        BindGrid3(); // refresh grid too
    }
     protected void ddlbrnd_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindZSM();
        BindBrands();
        BindTags();
        Bind_Status();
        BindGrid3(); // refresh grid too
    }
     protected void ddltag_SelectedIndexChanged(object sender, EventArgs e)
     {
         BindZSM();
         BindBrands();
         BindTags();
         Bind_Status();
         BindGrid3(); // refresh grid too
     }
    protected void ddlpercent_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ddlpercent"] = ddlpercent.SelectedValue;
        BindZSM();
        BindBrands();
        BindTags();
        Bind_Status();
        BindGrid3(); // refresh grid too
    }

    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindZSM();
        BindBrands();
        BindTags();
        Bind_Status();
        BindGrid3(); // refresh grid too
    }
    //public void BindStatus()
    //{
    //    DataSet DsStockist = new DataSet();
    //    DataTable dtDsStockist = new DataTable();
    //    string StrQrry = "";
    //    if (Session["ddlstatus"] == null || string.IsNullOrEmpty(Session["ddlstatus"].ToString()))
    //    {
    //        StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate]);";
    //    }
    //    else
    //    {
    //        if (ddlstatus.SelectedIndex == 0)
    //        {
    //            StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate]);";

    //        }
    //        else
    //        {
    //            StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where [Approved] = '" + Session["ddlstatus"] + "');";
    //        }
    //    }

    //    Lblwh.Text = "Approval Request";
    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
    //    adpRpt.Fill(DsStockist, "DsStockist");
    //    adpRpt.Fill(dtDsStockist);

    //    Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
    //    //Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
    //    if (DsStockist.Tables[0].Rows.Count > 0)
    //    {
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.Columns[1].Visible = false;
    //        Grdemp.DataBind();

    //        // ✅ Set ViewState here
    //        ViewState["GridData"] = dtDsStockist;
    //    }
    //    else
    //    {
    //        dtDsStockist.Rows.Add(dtDsStockist.NewRow());
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.DataBind();
    //        Grdemp.Rows[0].Visible = false;
    //        lblnow.Text = "NO DATA";
    //        lblnow.Visible = true;

    //        // ✅ Still set empty table to avoid null ViewState
    //        ViewState["GridData"] = dtDsStockist;
    //    }

    //}
    //    public void BindGrid9()
    //{
    //    DataSet DsStockist = new DataSet();
    //    DataTable dtDsStockist = new DataTable();
    //    string StrQrry = "";
    //    if (Session["brnd"] == null || string.IsNullOrEmpty(Session["brnd"].ToString()))
    //    {
    //        StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate]);";
    //    }
    //    else
    //    {
    //        if (ddlbrand.SelectedIndex == 0)
    //        {
    //            StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate]);";
 
    //        }
    //        else
    //        {
    //            StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where [Brands] = '" + Session["brnd"] + "');";
    //        }
    //    }
        
    //    Lblwh.Text = "Approval Request";
    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
    //    adpRpt.Fill(DsStockist, "DsStockist");
    //    adpRpt.Fill(dtDsStockist);

    //    Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
    //    //Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() + "<br />" + "Division : " + Hidnfldiv.Value.ToString() + "";
    //    if (DsStockist.Tables[0].Rows.Count > 0)
    //    {
    //       Grdemp.DataSource = dtDsStockist;
    //        Grdemp.Columns[1].Visible = false;
    //        Grdemp.DataBind();

    //        // ✅ Set ViewState here
    //        ViewState["GridData"] = dtDsStockist;
    //    }
    //    else
    //    {
    //        dtDsStockist.Rows.Add(dtDsStockist.NewRow());
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.DataBind();
    //        Grdemp.Rows[0].Visible = false;
    //         lblnow.Text = "NO DATA";
    //              lblnow.Visible = true;

    //              // ✅ Still set empty table to avoid null ViewState
    //              ViewState["GridData"] = dtDsStockist;
    //    }

    //}
    //    public void BindGrid10()
    //    {
    //        DataSet DsStockist = new DataSet();
    //        DataTable dtDsStockist = new DataTable();
    //        string StrQrry = "";
    //        StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where [Tag] = '" + Session["tag"] + "');";
    //        Lblwh.Text = "Approval Request";
    //        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
    //        adpRpt.Fill(DsStockist, "DsStockist");
    //        adpRpt.Fill(dtDsStockist);

    //        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
    //       // Lbldetail.Text = "Employee Code : " + Hidnfldcode.Value.ToString() ;
    //        if (DsStockist.Tables[0].Rows.Count > 0)
    //        {
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.Columns[1].Visible = false;
    //        Grdemp.DataBind();
    //        // ✅ Set ViewState here
    //        ViewState["GridData"] = dtDsStockist;
    //        }
    //        else
    //        {
    //            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
    //            Grdemp.DataSource = dtDsStockist;
    //            Grdemp.DataBind();
    //            Grdemp.Rows[0].Visible = false;
    //             lblnow.Text = "NO DATA";
    //              lblnow.Visible = true;
    //              // ✅ Still set empty table to avoid null ViewState
    //              ViewState["GridData"] = dtDsStockist;
    //        }

    //    }
//    public void binddropdown2()
//    {
//        DataSet DsStockistt = new DataSet();
//        DataTable dtDsStockistt = new DataTable();
//        string StrQrry = "";
//        try
//        {
//            string ddlper = Session["ddlpercent"].ToString();

//            switch (ddlper)
//            {
//                case "0": // Below 30%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$]  ";
//                    break;
//                case "30": // Below 30%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] < 30"; //[Approved] = 'Approved' AND 
//                    break;

//                case "40": // 30% - 40%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 30 AND [Unblocked Percentage] < 40";//[Approved] = 'Approved' AND 
//                    break;

//                case "50": // 40% - 50%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 40 AND [Unblocked Percentage] < 50";//[Approved] = 'Approved' AND  
//                    break;

//                case "60": // 50% - 60%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 50 AND [Unblocked Percentage] < 60";//[Approved] = 'Approved' AND 
//                    break;

//                case "70": // 60% - 70%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 60 AND [Unblocked Percentage] < 70";//[Approved] = 'Approved' AND 
//                    break;

//                case "80": // 70% - 80%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 70 AND [Unblocked Percentage] < 80";//[Approved] = 'Approved' AND 
//                    break;

//                case "90": // 80% - 90%
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 80 AND [Unblocked Percentage] < 90";//[Approved] = 'Approved' AND 
//                    break;

//                case "91": // 90% & Above
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 90";//[Approved] = 'Approved' AND 
//                    break;

//                default:
//                    StrQrry = "SELECT DISTINCT Division FROM [dbo].[Approvallist$] ";//WHERE [Approved] = 'Approved'
//                    break;
//            }

//        }
//         catch (Exception ex)
//        {
//            StrQrry = "Select distinct Division from [dbo].[Approvallist$];";
//        }  
//        //else
//        //{
//        //    StrQrryy = "Select distinct Division from [dbo].[Approvallist$];";
//        //}
//        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
//        SqlDataAdapter adpRptt = new SqlDataAdapter(StrQrry, conn);
//        adpRptt.Fill(DsStockistt, "DsStockistt");
//        adpRptt.Fill(dtDsStockistt);
//        if (DsStockistt.Tables[0].Rows.Count > 0)
//        {
//            ddldivname.DataSource = dtDsStockistt;
//            ddldivname.DataTextField = "Division";
//            ddldivname.DataBind();
//            ddldivname.Items.Insert(0, "Select");
//            //ddldivname.SelectedIndex = 0;
//        }
//        else
//        {
//            string nodata = string.Empty;
//            nodata = "NO DATA";
//            nodata = ddldivname.Text; 
//        }
//        binddropdown1();
//    }
//      public void binddropdown1()
//    {
//        DataSet DsStockist = new DataSet();
//        DataTable dtDsStockist = new DataTable();
//        string StrQrry = "";
//        try
//        {
//            string ddlper = Session["ddlpercent"].ToString();

//switch (ddlper)
//{
//    case "0": // Below 30%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$]  ";
//                    break;
//                case "30": // Below 30%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] < 30"; //[Approved] = 'Approved' AND 
//                    break;

//                case "40": // 30% - 40%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 30 AND [Unblocked Percentage] < 40";//[Approved] = 'Approved' AND 
//                    break;

//                case "50": // 40% - 50%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 40 AND [Unblocked Percentage] < 50";//[Approved] = 'Approved' AND  
//                    break;

//                case "60": // 50% - 60%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 50 AND [Unblocked Percentage] < 60";//[Approved] = 'Approved' AND 
//                    break;

//                case "70": // 60% - 70%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 60 AND [Unblocked Percentage] < 70";//[Approved] = 'Approved' AND 
//                    break;

//                case "80": // 70% - 80%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 70 AND [Unblocked Percentage] < 80";//[Approved] = 'Approved' AND 
//                    break;

//                case "90": // 80% - 90%
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 80 AND [Unblocked Percentage] < 90";//[Approved] = 'Approved' AND 
//                    break;

//                case "91": // 90% & Above
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 90";//[Approved] = 'Approved' AND 
//                    break;

//                default:
//                    StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] ";//WHERE [Approved] = 'Approved'
//                    break;
//}

//        }
//        catch (Exception ex)
//        {
//            StrQrry = "Select distinct ZSM_Name from [dbo].[Approvallist$] where [Approved] = 'Approved' and  Division = '" + Session["ddldiv"] + "';";
//        }
//        //else
//        //{
//        //    StrQrry = "Select distinct ZSM_Name from [dbo].[Approvallist$] where  Division = '" + Session["ddldiv"] + "';";
//        //}
//        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
//        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
//        adpRpt.Fill(DsStockist, "DsStockist");
//        adpRpt.Fill(dtDsStockist);
//        if (DsStockist.Tables[0].Rows.Count > 0)
//        {
//            ddlempname.DataSource = dtDsStockist;
//            ddlempname.DataTextField = "ZSM_Name";
//            ddlempname.DataBind();
//            ddlempname.Items.Insert(0, "Select");
//            //ddlempname.SelectedIndex = 0;
//        }
//        if (DsStockist.Tables[0].Rows.Count == 0)
//        {
//            string nodata = string.Empty;
//            nodata = "NO DATA";
//            nodata = ddlempname.Text; 
//        }

//    }
//      public void binddropdown5()
//      {
//          DataSet DsStockistt = new DataSet();
//          DataTable dtDsStockistt = new DataTable();
//          string StrQrry = "";
          
//              StrQrry = "Select distinct Approved from [dbo].[Approvallist$];";
          
//          //else
//          //{
//          //    StrQrryy = "Select distinct Approved from [dbo].[Approvallist$];";
//          //}
//          string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
//          SqlDataAdapter adpRptt = new SqlDataAdapter(StrQrry, conn);
//          adpRptt.Fill(DsStockistt, "DsStockistt");
//          adpRptt.Fill(dtDsStockistt);
//          if (DsStockistt.Tables[0].Rows.Count > 0)
//          {
//              ddlstatus.DataSource = dtDsStockistt;
//              ddlstatus.DataTextField = "Approved";
//              ddlstatus.DataBind();
//              ddlstatus.Items.Insert(0, "Select");
//              //ddlstatus.SelectedIndex = 0;
//          }
//          else
//          {
//              string nodata = string.Empty;
//              nodata = "NO DATA";
//              nodata = ddlstatus.Text;
//          }
//          binddropdown1();
//      }
    protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindZSM();
        BindBrands();
        BindTags();
        Bind_Status();
        BindGrid3(); // refresh grid too
    }
    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
       string admin = string.Empty;
       admin = ""+ Session["zcode"];
        string StrQrry = "";
        if (admin == "Admin" || admin == "90248986" || admin == "90038190" || admin == "Admin1")
            {
                StrQrry = "Select distinct * from [dbo].[Approvallist$]  where [Approved] != 'Adminblock' ";//where [Approved] = 'Approved' and  [Unblocked Percentage] >= 70;
        }
         //else
        //{
       //    StrQrry = "Select distinct * from [dbo].[Approvallist$] where [ZSM CODE] = '" + Session["zcode"] + "';";
      //}
        Lblwh.Text = "Approval Request Summary";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
    //  Lbldetail.Text = "Division : " + Session["divi"] + "";
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            Grdemp.Columns[1].Visible = false;
            Grdemp.DataBind();
            
            ViewState["GridData"] = dtDsStockist;
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            Grdemp.DataSource = dtDsStockist;
            Grdemp.DataBind();
            Grdemp.Rows[0].Visible = false;
            lblnow.Text = "NO ZSM's with more than 0% approval";
            lblnow.Visible = true;
            // ✅ Still set empty table to avoid null ViewState
            ViewState["GridData"] = dtDsStockist;
        }

    }
    // public void BindGridper()
    //{
    //    DataSet DsStockist = new DataSet();
    //    DataTable dtDsStockist = new DataTable();
    //   string admin = string.Empty;
    //   admin = ""+ Session["zcode"];
    //    string StrQrry = "";
    //    string ddlper = Session["ddlpercent"].ToString();

    //    switch (ddlper)
    //    {
    //        case "0": // Below 30%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$]  ";
    //            break;
    //        case "30": // Below 30%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] < 30"; //[Approved] = 'Approved' AND 
    //            break;

    //        case "40": // 30% - 40%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 30 AND [Unblocked Percentage] < 40";//[Approved] = 'Approved' AND 
    //            break;

    //        case "50": // 40% - 50%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 40 AND [Unblocked Percentage] < 50";//[Approved] = 'Approved' AND  
    //            break;

    //        case "60": // 50% - 60%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 50 AND [Unblocked Percentage] < 60";//[Approved] = 'Approved' AND 
    //            break;

    //        case "70": // 60% - 70%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 60 AND [Unblocked Percentage] < 70";//[Approved] = 'Approved' AND 
    //            break;

    //        case "80": // 70% - 80%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 70 AND [Unblocked Percentage] < 80";//[Approved] = 'Approved' AND 
    //            break;

    //        case "90": // 80% - 90%
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 80 AND [Unblocked Percentage] < 90";//[Approved] = 'Approved' AND 
    //            break;

    //        case "91": // 90% & Above
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE [Unblocked Percentage] >= 90";//[Approved] = 'Approved' AND 
    //            break;

    //        default:
    //            StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] ";//WHERE [Approved] = 'Approved'
    //            break;
    //    }


    //    //else
    //    //{
    //    //    StrQrry = "Select distinct * from [dbo].[Approvallist$] where [ZSM CODE] = '" + Session["zcode"] + "';";
    //    //}
    //    Lblwh.Text = "Approval Request Summary";
    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
    //    adpRpt.Fill(DsStockist, "DsStockist");
    //    adpRpt.Fill(dtDsStockist);
    //    Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
    ////    Lbldetail.Text = "Division : " + Session["divi"] + "";
    //    if (DsStockist.Tables[0].Rows.Count > 0)
    //    {
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.Columns[1].Visible = false;
    //        Grdemp.DataBind();
            
    //        ViewState["GridData"] = dtDsStockist;
    //    }
    //    else
    //    {
    //        dtDsStockist.Rows.Add(dtDsStockist.NewRow());
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.DataBind();
    //        Grdemp.Rows[0].Visible = false;
    //        lblnow.Text = "NO ZSM's with more than " + Session["ddlpercent"] + " approval";
    //        lblnow.Visible = true;
    //        // ✅ Still set empty table to avoid null ViewState
    //        ViewState["GridData"] = dtDsStockist;
    //    }
    //    binddropdown2();
    //    binddropdown1();
    //}
    public void BindGrid3()
    {
        string welcome = "";
        // ✅ Show grid only when Division is selected
        if (ddldivname.SelectedIndex == 0 || string.IsNullOrEmpty(ddldivname.SelectedValue))
        {
            welcome = zsmname != null ? zsmname : "";
            Lblwelcm.Text = "Welcome " + welcome + "!";
            Grdemp.DataSource = null;
            Grdemp.DataBind();
            Grdemp.Visible = false;
            lblnow.Text = "Please select a Division to view data.";
            lblnow.Visible = true;
            return;
        }
        welcome = zsmname != null ? zsmname : "";
        Lblwelcm.Text = "Welcome " + welcome + "!";
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();

        string StrQrry = BuildQuery();

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            Grdemp.DataBind();
            Grdemp.Visible = true;
            Grdemp.Columns[1].Visible = false;

            
            
            ViewState["GridData"] = dtDsStockist;
            lblnow.Visible = false;
        }
        else
        {
            Grdemp.DataSource = null;
            Grdemp.DataBind();
            Grdemp.Visible = false;

            lblnow.Text = "No results found with selected filters.";
            lblnow.Visible = true;
            ViewState["GridData"] = dtDsStockist;
        }
    }



    //public void BindGrid4()
    //{
    //    DataSet DsStockist = new DataSet();
    //    DataTable dtDsStockist = new DataTable();
    //    string StrQrry = "";
    //    //StrQrry = "Select distinct * from [dbo].[Approvallist$] where ZSM_Name = '" + Session["ddlemp"] + "';";

    //    if (Session["ddlemp"] == null || string.IsNullOrEmpty(Session["ddlemp"].ToString()))
    //    {
    //        StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate]);";
    //    }
    //    else
    //    {
    //        if (ddlempname.SelectedIndex == 0) 
    //        {
    //            StrQrry = "SELECT DISTINCT * " +
    //          "FROM [dbo].[Approvallist$] " +
    //          "WHERE ZSM_Name IN (" +
    //          "    SELECT DISTINCT [ZSM NAME] " +
    //          "    FROM [dbo].[Templateconsolidate]  )";
            
    //        }
    //        else
    //        {
    //            //StrQrry = "Select * from Approvallist$ where ZSM_Name in (Select distinct [ZSM NAME] from [dbo].[Templateconsolidate]);";
    //            StrQrry = "SELECT DISTINCT * " +
    //          "FROM [dbo].[Approvallist$] " +
    //          "WHERE ZSM_Name IN (" +
    //          "    SELECT DISTINCT [ZSM NAME] " +
    //          "    FROM [dbo].[Templateconsolidate] " +
    //          "    WHERE ZSM_Name = '" + Session["ddlemp"] + "')";
    //        }

    //    }
    //    Lblwh.Text = "Approval Request";

    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
    //    adpRpt.Fill(DsStockist, "DsStockist");
    //    adpRpt.Fill(dtDsStockist);
    //    Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
   
    //    if (DsStockist.Tables[0].Rows.Count > 0)
    //    {
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.Columns[1].Visible = false;
    //        Grdemp.DataBind();
            
    //        ViewState["GridData"] = dtDsStockist;
    //    }
    //    else
    //    {
    //        dtDsStockist.Rows.Add(dtDsStockist.NewRow());
    //        Grdemp.DataSource = dtDsStockist;
    //        Grdemp.DataBind();
    //        Grdemp.Rows[0].Visible = false;
    //        lblnow.Text = "NO DATA";
    //        lblnow.Visible = true;
    //        // ✅ Still set empty table to avoid null ViewState
    //        ViewState["GridData"] = dtDsStockist;
    //    }

    //}
    //protected void ddlmaster_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlval = string.Empty;
    //    ddlval = ddlmasters.SelectedValue.ToString();
    //    Session["ddlses"] = ddlval;
    //    Lblwh.Text = ddlmasters.SelectedItem.ToString();
    //    //  BindGrid2();
    //}
    protected void changed(object sender, EventArgs e)
    {
        CheckBox chckstatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chckstatus.NamingContainer;
    }
    protected void btnoutclick(object sender, EventArgs e)
    {
        DateTime logout = DateTime.Now;
        SqlCommand cmdd = new SqlCommand("Logoutrecord_ps", conn);
        cmdd.CommandType = CommandType.StoredProcedure;
        cmdd.Parameters.AddWithValue("@logout", logout.ToString("MMM dd yyyy hh:mm tt"));
        cmdd.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
        cmdd.Parameters.AddWithValue("@Datetime", Hidnfldlogin.Value.ToString());
        conn.Open();
        //cmd.ExecuteNonQuery();
        string strRsslt = cmdd.ExecuteNonQuery().ToString();
        conn.Close();
        Response.Redirect("LoginPage.aspx");
    }
    protected void Grdemp_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        DateTime Submitt = DateTime.Now;
        string[] arg = new string[4];

        arg = e.CommandArgument.ToString().Split(';');
        if (arg.Length > 3)
        {
            Session["ZSM CODE"] = arg[0];
            Session["ZSM_Name"] = arg[1];
            Session["Unblocked Percentage"] = arg[2];
            Session["Approvedview"] = arg[3];
        }
        string id = "";
        string name = "";
        string approved = "";
        if (e.CommandName == "btncApproved")
        {


            id = arg[0].ToString();
            approved = arg[3].ToString();
            SqlCommand cmd = new SqlCommand("templateps_approvaldone", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ZSM_CODE", id.ToString());
            cmd.Parameters.AddWithValue("@approv", approved.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            string strRslt = cmd.ExecuteNonQuery().ToString();
            conn.Close();
           // BindGridper();
            //Hidnfldname.Value = Session["zsmname"].ToString();
            //Hidnfldcode.Value = Session["zcode"].ToString();
            //Hidnfldiv.Value = Session["divi"].ToString();
            //Hidnfldlogin.Value = Session["login"].ToString();
           //Response.Redirect("Summary.aspx");
            BindGrid3();
        }
        if (e.CommandName == "btncNotApproved")
        {
            

            id = arg[0].ToString();
            approved = arg[3].ToString();
            SqlCommand cmd = new SqlCommand("templateps_approvalnotdoneadmin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ZSM_CODE", id.ToString());
            cmd.Parameters.AddWithValue("@approv", approved.ToString());
            cmd.Parameters.AddWithValue("@Submittime", Submitt.ToString("MMM dd yyyy hh:mm tt"));
            conn.Open();
            cmd.ExecuteNonQuery();
            string strRslt = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            SqlCommand cmdt = new SqlCommand("SELECT * FROM [dbo].[loginID$] where ZSM_Code = '" + id.ToString() + "';", conn);
            conn.Open();
            SqlDataReader read = cmdt.ExecuteReader();
            var logintbl = new DataTable();
            logintbl.Load(read);
            if (logintbl.Rows.Count > 0)
            {
                TableRow lgtbrw1 = new TableRow();
                for (int i = 0; i < logintbl.Rows.Count; i++)
                {

                    string clientEmail = logintbl.Rows[i][7].ToString();
                    Session["clientEmail"] = clientEmail;
                    string ZSMname = logintbl.Rows[i][3].ToString();
                    Session["ZSMname"] = ZSMname;
                    string ZSMcode = logintbl.Rows[i][2].ToString();
                    Session["ZSMcode"] = ZSMcode;
                }
            }
            SqlCommand cmdt2 = new SqlCommand("SELECT * FROM [dbo].[Approvallist$] where [ZSM CODE] = '" + id.ToString() + "';", conn);
            SqlDataReader read2 = cmdt2.ExecuteReader();
            var logintbl2 = new DataTable();
            logintbl2.Load(read2);
           // if (logintbl2.Rows.Count > 0)
           // {
           //     TableRow lgtbrw12 = new TableRow();
           //     for (int i = 0; i < logintbl2.Rows.Count; i++)
           //     {
            string divzsm = logintbl2.Rows[0][0].ToString();
            Session["divzsm"] = divzsm;
              string percentagezsm = logintbl2.Rows[0][6].ToString();
                 Session["percentagezsm"] = percentagezsm;
           //     }
           // }
                 conn.Close();
                 string messageBody = "Dear " + Session["ZSMname"].ToString() + "," + Environment.NewLine + Environment.NewLine + "Hope this email finds you well.Thanks for your support, one of the pivotal initiatives taken over by the company is to reduce ‘Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)’ which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + Environment.NewLine + "Your response to the unblocking of stockiest pack combinations was sent to the Distribution Head for approval as the % of stockiest-pack combinations requested to be unblocked exceeds 0%." + Environment.NewLine + " The current approval status stands: Admin Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + percentagezsm + "%" + Environment.NewLine + "Status: Rejected by Distribution Head" + Environment.NewLine + Environment.NewLine + "Kindly review the unblocking list and submit the response again." + Environment.NewLine + "In case of any queries please write to me or Rohan." + Environment.NewLine;
           // //string messmob = txtmob.Text;
          SqlCommand cmdemail = new SqlCommand("select top (1)* from PortforEmail;", conn);
          conn.Open();
          SqlDataReader reademail = cmdemail.ExecuteReader();
          var readl = new DataTable();
          readl.Load(reademail);
          string smtpclnt = readl.Rows[0][1].ToString();
          //    Session["smtpclnt"] = smtpclnt;
          string smtphost = readl.Rows[0][2].ToString();
          //   Session["smtphost"] = smtphost;
          string smtpnoport = readl.Rows[0][3].ToString();
          //   Session["smtpnoport"] = smtpnoport;
          string emailusername = readl.Rows[0][4].ToString();
          //   Session["emailusername"] = emailusername;
          string emailuserpass = readl.Rows[0][5].ToString();
          //   Session["emailuserpass"] = emailuserpass;
          string smtpenable = readl.Rows[0][6].ToString();
          //   Session["smtpenable"] = smtpenable;
          conn.Close();
          MailMessage mail = new MailMessage();
          mail.From = new MailAddress(emailusername);
          mail.To.Add(Session["clientEmail"].ToString()); // Client's email
          //mail.To.Add("anjali.mishra@gcvlife.in"); // Your email address
          mail.Subject = "AutoReply Fixit:- Your Unblocking List has been Rejected ";
          mail.Body = messageBody + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Team Fixit | Gregor Analytics";

          string Valueportno = smtpnoport;
          int intValueportno = int.Parse(Valueportno);
          string Valuebool = smtpenable;
          bool boolValenable = bool.Parse(Valuebool);
          //  SmtpClient smtp = new SmtpClient();
          SmtpClient smtpClient = new SmtpClient(smtpclnt);
          smtpClient.Host = smtphost; // Set your SMTP server address
          smtpClient.Port = intValueportno; // Set the SMTP port (usually 587 for TLS)
          smtpClient.Credentials = new NetworkCredential(emailusername, emailuserpass);
          smtpClient.EnableSsl = boolValenable;
try
{
          smtpClient.Send(mail);
             }
                   catch
                   {
                   }
           // MailMessage mail = new MailMessage();
           // mail.From = new MailAddress("anjali.mishra@gcvlife.in");
           // mail.To.Add(Session["clientEmail"].ToString()); // Client's email
           // //mail.To.Add("anjali.mishra@gcvlife.in"); // Your email address
           // mail.Subject = "AutoReply Fixit:- Your Unblocking List has been Rejected ";
           // mail.Body = messageBody + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Team Fixit | Gregor Analytics";


           // //  SmtpClient smtp = new SmtpClient();
           // SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
           // smtpClient.Host = "smtp.gmail.com"; // Set your SMTP server address
           // smtpClient.Port = 587; // Set the SMTP port (usually 587 for TLS)
           // smtpClient.Credentials = new NetworkCredential("anjali.mishra@gcvlife.in", "Anja@321");
           // smtpClient.EnableSsl = true;

           // smtpClient.Send(mail);
           //// BindGridper();
           // // Optionally, provide feedback to the user

           // if (logintbl.Rows.Count > 0)
           // {
           //     TableRow lgtbrw1 = new TableRow();
           //     for (int i = 0; i < logintbl.Rows.Count; i++)
           //     {

           //         string clientEmailcc = logintbl.Rows[i][8].ToString();
           //         Session["clientEmailcc"] = clientEmailcc;
           //     }
           // }
           string Sy = "";
           // ///////////////////////////////////////////////////////////write submitted mail------------------------------------------------start from here 29-08-23
         //  Sy = "SELECT * FROM [dbo].[loginID$] where Division = '" + Hidnfldiv.Value.ToString() + "' and Username like 'DH%';";
           // string connnn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
           // SqlDataAdapter adpt = new SqlDataAdapter(Sy, connnn);
           // DataTable dataTable = new DataTable();
           // adpt.Fill(dataTable);
           // string dhcode = dataTable.Rows[0][2].ToString();
           // string dhname = dataTable.Rows[0][3].ToString();
           // string dhpass = dataTable.Rows[0][4].ToString();
           // string dhemail = dataTable.Rows[0][7].ToString();
           // MailMessage mailtoclient = new MailMessage();
           // mailtoclient.From = new MailAddress("anjali.mishra@gcvlife.in"); // Client's email
           // //  mail.From = new MailAddress("anjali.mishra@gcvlife.in");
           // mailtoclient.To.Add(Session["clientEmailcc"].ToString()); // Your email address
           // mailtoclient.Subject = "AutoReply Fixit:- Admin has Rejected " + Hidnfldname.Value.ToString() + "'s Unblocking List";
           // mailtoclient.Body = "Dear " + dhname + "," + Environment.NewLine + Environment.NewLine + "Thanks for your support to one of the pivotal initiatives taken over by the company is to reduce 'Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)' which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + "The unblocking list of " + Hidnfldname.Value.ToString() + " has been Rejected by Distribution Head, as the percentage of stockiest-pack combinations requested to be unblocked by this ZSM surpasses 60%." + Environment.NewLine + Environment.NewLine + Environment.NewLine + " The current approval status stands: Admin Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + Session["percentagezsm"].ToString() + "%" + Environment.NewLine + "Status: Rejected by Distribution Head." + Environment.NewLine + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Team Fixit | Gregor Analytics";
          ///////////////////////////////////////////////////////////write submitted mail------------------------------------------------start from here 29-08-23
           Sy = "SELECT * FROM [dbo].[loginID$] where Division = '" + divzsm + "' and Username like 'DH%';";
          string connnn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
          SqlDataAdapter adpt = new SqlDataAdapter(Sy, connnn);
          DataTable dataTable = new DataTable();
          adpt.Fill(dataTable);
          string dhcode = dataTable.Rows[0][2].ToString();
          string dhname = dataTable.Rows[0][3].ToString();
          string dhpass = dataTable.Rows[0][4].ToString();
          string dhemail = dataTable.Rows[0][7].ToString();
          MailMessage mailtoclient = new MailMessage();
          mailtoclient.From = new MailAddress(emailusername); // Client's email
          //  mail.From = new MailAddress("anjali.mishra@gcvlife.in");
          mailtoclient.To.Add(dhemail); // Your email address
          mailtoclient.Subject = "AutoReply Fixit:- Admin has Rejected " + Session["ZSMname"].ToString() + "'s Unblocking List";
          mailtoclient.Body = "Dear " + dhname + "," + Environment.NewLine + Environment.NewLine + "Thanks for your support to one of the pivotal initiatives taken over by the company is to reduce 'Expiry returns (Expiry + Short Expiry+ Near Expiry + Damaged goods)' which currently stands at levels higher than the industry average of 1.5% - 2%." + Environment.NewLine + "The unblocking list of " + Session["ZSMname"].ToString() + " has been Rejected by Distribution Head, as the percentage of stockiest-pack combinations requested to be unblocked by this ZSM surpasses 0%." + Environment.NewLine + Environment.NewLine + Environment.NewLine + " The current approval status stands: Admin Rejected" + Environment.NewLine + Environment.NewLine + "Response Details for your ready reference:" + Environment.NewLine + Environment.NewLine + "% to be Unblocked: " + percentagezsm + "%" + Environment.NewLine + "Status: Rejected by Distribution Head." + Environment.NewLine + Environment.NewLine + "Thanks and regards," + Environment.NewLine + "Team Fixit | Gregor Analytics";

          SmtpClient smtpClientfromus = new SmtpClient(smtpclnt);
          smtpClientfromus.Host = smtphost; // Set your SMTP server address
          smtpClientfromus.Port = intValueportno; // Set the SMTP port (usually 587 for TLS)
          smtpClientfromus.Credentials = new NetworkCredential(emailusername, emailuserpass);
          smtpClientfromus.EnableSsl = boolValenable;
            try
            {
          //smtpClientfromus.Send(mailtoclient);
             }
                   catch
                   {
                   }
            //Hidnfldname.Value = Session["zsmname"].ToString();
            //Hidnfldcode.Value = Session["zcode"].ToString();
            //Hidnfldiv.Value = Session["divi"].ToString();
            //Hidnfldlogin.Value = Session["login"].ToString();
            //Response.Redirect("Summary.aspx");
            BindGrid3();
        }
        if (e.CommandName == "btncview")
        {
            if (Grdrprt.Visible == false)
            {
                id = arg[0].ToString();
                approved = arg[3].ToString();
                name = arg[1].ToString();
                Session["ZSM_Name"] = name;
                Session["code"] = id;
                Session["approved"] = approved;
                BindGrid2();
                lblnow.Visible = true;
                Grdrprt.Visible = true;
                btndisapp.Visible = true;
            }
            else
            {
                lblnow.Visible = false;
                Grdrprt.Visible = false;
                btndisapp.Visible = false;
            }
        }
    }
    protected void Grdemp_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox Checkedboxx = (CheckBox)e.Row.FindControl("Checkedbox");
            Button btnapp = (Button)e.Row.FindControl("btnApproved");
            Button btndnt = (Button)e.Row.FindControl("btnNotApproved");
         //   GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            ImageButton btnview = (ImageButton)e.Row.FindControl("btnview");
            //DataRowView dr = (DataRowView)e.Row.DataItem;
            //e.Row.Cells[4].Text = dr["Approved"].ToString();
            //string vall = string.Empty;
            //vall = (string)dr["Approved"];
            if (e.Row.Cells[7].Text == "Pending")
            {
                btnapp.Visible = true;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
                Checkedboxx.Visible = false;
               
            }
            else if (e.Row.Cells[7].Text == "Rejected")
            {
                Checkedboxx.Visible = true;
                btnapp.Visible = false;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
                btndnt.ForeColor = System.Drawing.Color.White;
                btndnt.BackColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[7].Text == "AdminRejected")
            {
                btnapp.Visible = false;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
                Checkedboxx.Visible = true;
                btndnt.ForeColor = System.Drawing.Color.White;
                btndnt.BackColor = System.Drawing.Color.Gray;
            }
            else if (e.Row.Cells[7].Text == "Approved")
            {
                btnapp.Visible = false;
                btndnt.Visible = true;
                btnapp.Enabled = true;
                btndnt.Enabled = true;
                btnview.Visible = true;
                Checkedboxx.Visible = false;
                //btndnt.Visible = false;
                //btnapp.Visible = true;
                //btnapp.Enabled = false;
                //btndnt.Enabled = false;
                //Checkedboxx.Visible = true;
                //btnview.Visible = true;
                //btnapp.ForeColor = System.Drawing.Color.White;
                //btnapp.BackColor = System.Drawing.Color.Gray;
            }
        }

    }
    //protected void btnmaster(object sender, EventArgs e)
    //{
    //    Response.Redirect("Fixitmasters.aspx");
    //}
    protected void btnnotific(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("NotificationAdmin.aspx");
    }
    protected void Grdemp_NEERowdatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            conn.Open();
            DropDownList DropDownList2 = (e.Row.FindControl("ddlblock") as DropDownList);
            SqlCommand cmd1 = new SqlCommand("Select * from BlockAdmin;", conn);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            conn.Close();
            DropDownList2.DataSource = dt1;

            DropDownList2.DataTextField = "Block";
            DropDownList2.DataValueField = "Block";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Unblock", "0"));
        }
    }
    protected void btndisapp_Click(object sender, EventArgs e)
    {

        var checkedbox = 0;
        var count = 0;
        foreach (GridViewRow row in Grdrprt.Rows)
        {
            count++;
            DropDownList chckhrw = (DropDownList)row.FindControl("ddlblock");
            if (chckhrw.SelectedValue == "Admin Block")
            {

                checkedbox++;
                string namevalue0 = row.Cells[0].Text;
                namevalue0 = namevalue0.Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").Replace("'", "%").ToString();
                string namevalue1 = row.Cells[1].Text;
                namevalue1 = namevalue1.Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").Replace("'", "%").ToString();
                string namevalue2 = row.Cells[2].Text;
                namevalue2 = namevalue2.Replace("&nbsp;", string.Empty).Replace("&#39;", "'").Replace("&#160;", "  ").Replace("'", "%").ToString();
                DropDownList ddlblock = (DropDownList)row.FindControl("ddlblock");
                string ddlunb = ddlblock.SelectedValue;
                string adminblock = string.Empty;
                adminblock = "Adminblock";
                DateTime Submitt = DateTime.Now;
                DataSet Dsvals = new DataSet();
                DataTable dtDsvals = new DataTable();
                string Svals = "";
                Svals = "Select Distinct [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME],Round([SALES_2023-05], 0) as [SALES_2023-05],Round([SALES_2023-06], 0) as [SALES_2023-06], Round([SALES_2023-07], 0) as [SALES_2023-07],Round([AVG_SEC_JUL23], 0) as [AVG_SEC_JUL23],Round([CLO_2023_07], 0) as [CLO_2023_07], Round([CLO_Unit_07], 0) as [CLO_Unit_07] FROM [dbo].[Templateconsolidate] where [ZSM CODE] =  '" + Session["code"].ToString() + "' and  [Territory Name]='" + namevalue0.Replace("&amp;", "&") + "' and [SALES_ACC_NAME]='" + namevalue1.Replace("&amp;", "&") + "' and [SALES_PROD_NAME] like'" + namevalue2.Replace("'", "''").Replace("&amp;", "&") + "%' and [Approved] = '" +Session["approved"].ToString() + "';";
                SqlDataAdapter adpRpt13 = new SqlDataAdapter(Svals, conn);
                adpRpt13.Fill(Dsvals, "dtDsvals");
                adpRpt13.Fill(dtDsvals);
                string Accid = dtDsvals.Rows[0][5].ToString();
                namevalue1 = namevalue1.Replace("&amp;", "&").Replace("&#160;", "  ").Replace("'", "%");
                string terrid = dtDsvals.Rows[0][3].ToString();
                namevalue0 = namevalue0.Replace("&amp;", "&").Replace("&#160;", "  ").Replace("'", "%");
                string Prodid = dtDsvals.Rows[0][7].ToString();
                namevalue2 = namevalue2.Replace("&amp;", "&").Replace("&#160;", "  ").Replace("'", "%");
                SqlCommand cmd1 = new SqlCommand("adminblock_ps", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@SALES_DIVISION", Hidnfldiv.Value.ToString());
                cmd1.Parameters.AddWithValue("@ZSM_CODE",  Session["code"].ToString());
                cmd1.Parameters.AddWithValue("@ZSM_NAME", Session["ZSMNAME"].ToString());
                cmd1.Parameters.AddWithValue("@Territory_Code", terrid);
                cmd1.Parameters.AddWithValue("@SALES_GCV_ACC_CODE", Accid);
                cmd1.Parameters.AddWithValue("@SALES_ProdID", Prodid);
                 cmd1.Parameters.AddWithValue("@Unblock", ddlunb.ToString());
                cmd1.Parameters.AddWithValue("@Approved", adminblock.ToString());     
                cmd1.Parameters.AddWithValue("@Submittime", Submitt.ToString("MMM dd yyyy hh:mm tt"));
                conn.Open();
                // cmd1.ExecuteNonQuery();
                string strRslt = cmd1.ExecuteNonQuery().ToString();
                conn.Close();
            
                btndisapp.Visible = false;
                Grdrprt.Visible = false;
                lblnow.Visible = false;
                BindGrid3();
             
            }

        }
    }
    //protected void btnreprt(object sender, EventArgs e)
    //{
    //    Session["zsmname"] = Hidnfldname.Value.ToString();
    //    Session["zcode"] = Hidnfldcode.Value.ToString();
    //    Session["divi"] = Hidnfldiv.Value.ToString();
    //    Session["login"] = Hidnfldlogin.Value.ToString();
    //    Response.Redirect("Fixitreports.aspx");
    //}
    protected void btncontac(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Contactus.aspx");
    }
    public void BindGrid2()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";

        StrQrryy = "Select distinct * from dbo.[Templateconsolidate] where [ZSM CODE]  = '" + Session["code"] + "' and Approved = '" + Session["approved"] + "';";
        lblnow.Text = "Unblocking List of " + Session["ZSMNAME"];
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrryy, conn);
        adpRpt.Fill(DsStockistt, "DsStockistt");
        adpRpt.Fill(dtDsStockistt);


        if (DsStockistt.Tables[0].Rows.Count > 0)
        {
            Grdrprt.DataSource = dtDsStockistt;
            Grdrprt.DataBind();
            
            ViewState["GridData"] = dtDsStockistt;
        }
        else
        {
            dtDsStockistt.Rows.Add(dtDsStockistt.NewRow());
            Grdrprt.DataSource = dtDsStockistt;
            Grdrprt.DataBind();
            Grdrprt.Rows[0].Visible = false;
            lblnow.Text = "NO DATA";
            lblnow.Visible = true;
            // ✅ Still set empty table to avoid null ViewState
            ViewState["GridData"] = dtDsStockistt;
        }

      //  btnsubmit.Visible = true;
        Grdrprt.Visible = true;
        //Lblrows.Visible = false;
        // Lblnote.Visible = false;
    }

    protected void Grdrprt_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = ViewState["GridData"] as DataTable;
        if (dt != null)
        {
            string sortDirection = ViewState["SortDirection"] as string ?? "ASC";

            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                // Toggle sort direction
                sortDirection = (sortDirection == "ASC") ? "DESC" : "ASC";
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = e.SortExpression;

            dt.DefaultView.Sort = e.SortExpression + " " + sortDirection;
            Grdrprt.DataSource = dt;
            Grdrprt.DataBind();
        }
    }

    protected void Grdemp_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = ViewState["GridData"] as DataTable;
        if (dt != null)
        {
            string sortDirection = ViewState["SortDirection"] as string ?? "ASC";

            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                // Toggle sort direction
                sortDirection = (sortDirection == "ASC") ? "DESC" : "ASC";
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = e.SortExpression;

            dt.DefaultView.Sort = e.SortExpression + " " + sortDirection;
            Grdemp.DataSource = dt;
            Grdemp.DataBind();
        }
    }
    protected void btnApprovalDetails(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Approval_BH.aspx");
    }
    protected void btnloginDetails(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Login_Details_Admin.aspx");
    }
    /////////////////////////////////////////////////////
    ////////////////////////////////////////////////////
    //private string BuildQuery()
    //{
    //    // If Division not selected, return dummy query
    //    if (ddldivname.SelectedIndex == 0 || string.IsNullOrEmpty(ddldivname.SelectedValue))
    //    {
    //        return "SELECT TOP 0 * FROM [dbo].[Approvallist$] ";
            
    //    }

    //    // ✅ Start main query
    //    string StrQrry = "SELECT DISTINCT * FROM [dbo].[Approvallist$] WHERE 1=1";
    //    StrQrry += " AND [Approved] != 'Adminblock'";
    //    // ✅ Division filter (mandatory)
    //    StrQrry += " AND [Division] = '" + ddldivname.SelectedValue + "'";

    //    // ✅ Percent filter with ranges
    //    if (Session["ddlpercent"] != null)
    //    {
    //        string ddlper = Session["ddlpercent"].ToString();
    //        switch (ddlper)
    //        {
    //            case "30": StrQrry += " AND [Unblocked Percentage] < 30"; break;
    //            case "40": StrQrry += " AND [Unblocked Percentage] >= 30 AND [Unblocked Percentage] < 40"; break;
    //            case "50": StrQrry += " AND [Unblocked Percentage] >= 40 AND [Unblocked Percentage] < 50"; break;
    //            case "60": StrQrry += " AND [Unblocked Percentage] >= 50 AND [Unblocked Percentage] < 60"; break;
    //            case "70": StrQrry += " AND [Unblocked Percentage] >= 60 AND [Unblocked Percentage] < 70"; break;
    //            case "80": StrQrry += " AND [Unblocked Percentage] >= 70 AND [Unblocked Percentage] < 80"; break;
    //            case "90": StrQrry += " AND [Unblocked Percentage] >= 80 AND [Unblocked Percentage] < 90"; break;
    //            case "91": StrQrry += " AND [Unblocked Percentage] >= 90"; break;
    //        }
    //    }

    //    // ✅ ZSM filter
    //    if (ddlempname.SelectedIndex > 0)
    //        StrQrry += " AND [ZSM_Name] = '" + ddlempname.SelectedValue + "'";

        

    //    // ✅ Status filter
    //    if (ddlstatus.SelectedIndex > 0)
    //        StrQrry += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

    //    return StrQrry;
    //}

    private string BuildQuery() // older Build quey in abvoe comment part
    {
        // 🧩 1️⃣ If Division not selected, return dummy query
        if (ddldivname.SelectedIndex == 0 || string.IsNullOrEmpty(ddldivname.SelectedValue))
        {
            return "SELECT TOP 0 * FROM [dbo].[Approvallist$]";
        }

        // 🧩 2️⃣ Start base query with aggregations
        string StrQrry = @"
SELECT 
      [Division],
      [ZSM CODE],
      [ZSM_Name],
      MAX(CAST([Unblocked] AS INT)) AS [Unblocked],
    MAX(CAST([Blocked] AS INT)) AS [Blocked],
    MAX(CAST([Total] AS INT)) AS [Total],

    MAX(CAST([Unblocked Percentage] AS DECIMAL(10,0))) AS [Unblocked Percentage],
      MAX([Approved])              AS [Approved],
      MAX([BH_Code])               AS [BH_Code],
      MAX([Submit_Time])           AS [Submit_Time],
      MAX([Approved_Time])         AS [Approved_Time],
 MAX([Remark])         AS [Remark],

    MAX(CAST(NO_Of_DOH AS INT)) AS NO_Of_DOH,
    MAX(CAST(NO_Of_Newadd AS INT)) AS NO_Of_Newadd,
Min(CAST(blocked_Percentage AS float)) AS blocked_Percentage
FROM [dbo].[Approvallist$]
WHERE 1=1";

        // 🧩 3️⃣ Apply static filter for Admin
        StrQrry += " AND [Approved] <> 'Adminblock'";

        // 🧩 4️⃣ Apply Division filter (mandatory)
        StrQrry += " AND [Division] = '" + ddldivname.SelectedValue + "'";

        // 🧩 5️⃣ Apply Unblocked Percentage range filter
        if (Session["ddlpercent"] != null)
        {
            string ddlper = Session["ddlpercent"].ToString();
            switch (ddlper)
            {
                case "30": StrQrry += " AND [Unblocked Percentage] < 30"; break;
                case "40": StrQrry += " AND [Unblocked Percentage] >= 30 AND [Unblocked Percentage] < 40"; break;
                case "50": StrQrry += " AND [Unblocked Percentage] >= 40 AND [Unblocked Percentage] < 50"; break;
                case "60": StrQrry += " AND [Unblocked Percentage] >= 50 AND [Unblocked Percentage] < 60"; break;
                case "70": StrQrry += " AND [Unblocked Percentage] >= 60 AND [Unblocked Percentage] < 70"; break;
                case "80": StrQrry += " AND [Unblocked Percentage] >= 70 AND [Unblocked Percentage] < 80"; break;
                case "90": StrQrry += " AND [Unblocked Percentage] >= 80 AND [Unblocked Percentage] < 90"; break;
                case "91": StrQrry += " AND [Unblocked Percentage] >= 90"; break;
            }
        }

        // 🧩 6️⃣ Apply ZSM Name filter
        if (ddlempname.SelectedIndex > 0)
            StrQrry += " AND [ZSM_Name] = '" + ddlempname.SelectedValue + "'";

        // 🧩 7️⃣ Apply Status filter
        if (ddlstatus.SelectedIndex > 0)
            StrQrry += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

        // 🧩 8️⃣ Add GROUP BY clause at the end
        StrQrry += @"
GROUP BY 
      [Division],
      [ZSM CODE],
      [ZSM_Name];";

        return StrQrry;
    }

    private void LoadDropdowns()
    {
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            con.Open();

            // Division
            SqlDataAdapter daDiv = new SqlDataAdapter("SELECT DISTINCT [Division] FROM [dbo].[Approvallist$] where [Approved] !='Adminblock' order by Division ASC", con);
            DataTable dtDiv = new DataTable();
            daDiv.Fill(dtDiv);
            ddldivname.DataSource = dtDiv;
            ddldivname.DataTextField = "Division";
            ddldivname.DataValueField = "Division";
            ddldivname.DataBind();
            ddldivname.Items.Insert(0, new ListItem("All", "0"));

            // ZSM
            SqlDataAdapter daZsm = new SqlDataAdapter("SELECT DISTINCT [ZSM Name] FROM [dbo].[Templateconsolidate] where [Approved] !='Adminblock'", con);
            DataTable dtZsm = new DataTable();
            daZsm.Fill(dtZsm);
            ddlempname.DataSource = dtZsm;
            ddlempname.DataTextField = "ZSM Name";
            ddlempname.DataValueField = "ZSM Name";
            ddlempname.DataBind();
            ddlempname.Items.Insert(0, new ListItem("All", "0"));

            // Brands
            SqlDataAdapter daBrand = new SqlDataAdapter("SELECT DISTINCT [Brands] FROM [dbo].[Templateconsolidate] where [Approved] !='Adminblock'", con);
            DataTable dtBrand = new DataTable();
            daBrand.Fill(dtBrand);
            ddlbrand.DataSource = dtBrand;
            ddlbrand.DataTextField = "Brands";
            ddlbrand.DataValueField = "Brands";
            ddlbrand.DataBind();
            ddlbrand.Items.Insert(0, new ListItem("All", "0"));

            // Tags
            SqlDataAdapter daTag = new SqlDataAdapter("SELECT DISTINCT [Tag] FROM [dbo].[Templateconsolidate] where [Approved] !='Adminblock'", con);
            DataTable dtTag = new DataTable();
            daTag.Fill(dtTag);
            ddltag.DataSource = dtTag;
            ddltag.DataTextField = "Tag";
            ddltag.DataValueField = "Tag";
            ddltag.DataBind();
            ddltag.Items.Insert(0, new ListItem("All", "0"));

            // Status
            SqlDataAdapter daStatus = new SqlDataAdapter("SELECT DISTINCT [Approved] FROM [dbo].[Templateconsolidate] where [Approved] !='Adminblock'", con);
            DataTable dtStatus = new DataTable();
            daStatus.Fill(dtStatus);
            ddlstatus.DataSource = dtStatus;
            ddlstatus.DataTextField = "Approved";
            ddlstatus.DataValueField = "Approved";
            ddlstatus.DataBind();
            ddlstatus.Items.Insert(0, new ListItem("All", "0"));
        }
    }
    private string BuildFilterCondition_Approvallist()
    {
        string where = " WHERE 1=1 ";

        // ✅ Percent ranges
        string ddlper = Session["ddlpercent"] != null ? Session["ddlpercent"].ToString() : "0";
        switch (ddlper)
        {
            case "30": where += " AND [Unblocked Percentage] < 30"; break;
            case "40": where += " AND [Unblocked Percentage] >= 30 AND [Unblocked Percentage] < 40"; break;
            case "50": where += " AND [Unblocked Percentage] >= 40 AND [Unblocked Percentage] < 50"; break;
            case "60": where += " AND [Unblocked Percentage] >= 50 AND [Unblocked Percentage] < 60"; break;
            case "70": where += " AND [Unblocked Percentage] >= 60 AND [Unblocked Percentage] < 70"; break;
            case "80": where += " AND [Unblocked Percentage] >= 70 AND [Unblocked Percentage] < 80"; break;
            case "90": where += " AND [Unblocked Percentage] >= 80 AND [Unblocked Percentage] < 90"; break;
            case "91": where += " AND [Unblocked Percentage] >= 90"; break;
        }

        if (ddldivname.SelectedIndex > 0)
            where += " AND [Division] = '" + ddldivname.SelectedValue + "'";

        if (ddlstatus.SelectedIndex > 0)
            where += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

        return where;
    }
    private string BuildFilterCondition_Template()
    {
        string where = " WHERE 1=1 ";

        // ✅ Division filter (map to SALES_DIVISION)
        if (ddldivname.SelectedIndex > 0)
            where += " AND [SALES_DIVISION] = '" + ddldivname.SelectedValue + "'";

        // ✅ ZSM filter
        if (ddlempname.SelectedIndex > 0)
            where += " AND [ZSM NAME] = '" + ddlempname.SelectedValue + "'";

        // ✅ Brand filter
        if (ddlbrand.SelectedIndex > 0)
            where += " AND [Brands] = '" + ddlbrand.SelectedValue + "'";

        // ✅ Tag filter
        if (ddltag.SelectedIndex > 0)
            where += " AND [Tag] = '" + ddltag.SelectedValue + "'";

        // ✅ Status filter (map Approved from Templateconsolidate if exists)
        if (ddlstatus.SelectedIndex > 0)
            where += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

        return where;
    }

    public void BindDivisions()
    {
        string query = "SELECT DISTINCT [Division] FROM [dbo].[Approvallist$] WHERE 1=1";

        if (ddlempname.SelectedIndex > 0)
            query += " AND [ZSM_Name] = '" + ddlempname.SelectedValue + "'";

        if (ddlbrand.SelectedIndex > 0)
            query += " AND [Brand] = '" + ddlbrand.SelectedValue + "'";

        if (ddltag.SelectedIndex > 0)
            query += " AND [Tag] = '" + ddltag.SelectedValue + "'";

        if (ddlstatus.SelectedIndex > 0)
            query += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

        FillDropdown(ddldivname, query, "Division");
    }

    public void BindZSM()
    {
        string query = "SELECT DISTINCT [ZSM Name] FROM [dbo].[Templateconsolidate] WHERE 1=1";

        if (ddldivname.SelectedIndex > 0)
            query += " AND [SALES_DIVISION] = '" + ddldivname.SelectedValue + "'";

        if (ddlbrand.SelectedIndex > 0)
            query += " AND [Brands] = '" + ddlbrand.SelectedValue + "'";

        if (ddltag.SelectedIndex > 0)
            query += " AND [Tag] = '" + ddltag.SelectedValue + "'";

        if (ddlstatus.SelectedIndex > 0)
            query += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

        FillDropdown(ddlempname, query, "ZSM Name");
    }

    public void BindBrands()
    {
        string query = "SELECT DISTINCT [Brands] FROM [dbo].[Templateconsolidate] WHERE 1=1";

        if (ddldivname.SelectedIndex > 0)
            query += " AND [SALES_DIVISION] = '" + ddldivname.SelectedValue + "'";

        if (ddlempname.SelectedIndex > 0)
            query += " AND [ZSM NAME] = '" + ddlempname.SelectedValue + "'";

        if (ddltag.SelectedIndex > 0)
            query += " AND [Tag] = '" + ddltag.SelectedValue + "'";

        if (ddlstatus.SelectedIndex > 0)
            query += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

        FillDropdown(ddlbrand, query, "Brands");
    }

    public void BindTags()
    {
        string query = "SELECT DISTINCT [Tag] FROM [dbo].[Templateconsolidate] WHERE [Tag] IS NOT NULL AND [Tag] != ''";

        if (ddldivname.SelectedIndex > 0)
            query += " AND [SALES_DIVISION] = '" + ddldivname.SelectedValue + "'";

        if (ddlempname.SelectedIndex > 0)
            query += " AND [ZSM NAME] = '" + ddlempname.SelectedValue + "'";

        if (ddlbrand.SelectedIndex > 0)
            query += " AND [Brands] = '" + ddlbrand.SelectedValue + "'";

        if (ddlstatus.SelectedIndex > 0)
            query += " AND [Approved] = '" + ddlstatus.SelectedValue + "'";

        FillDropdown(ddltag, query, "Tag");
    }

    public void Bind_Status()
    {
        string query = "SELECT DISTINCT [Approved] FROM [dbo].[Approvallist$] WHERE 1=1";

        if (ddldivname.SelectedIndex > 0)
            query += " AND [Division] = '" + ddldivname.SelectedValue + "'";

        if (ddlempname.SelectedIndex > 0)
            query += " AND [ZSM_Name] = '" + ddlempname.SelectedValue + "'";

        if (ddlbrand.SelectedIndex > 0)
            query += " AND [Brand] = '" + ddlbrand.SelectedValue + "'";

        if (ddltag.SelectedIndex > 0)
            query += " AND [Tag] = '" + ddltag.SelectedValue + "'";

        FillDropdown(ddlstatus, query, "Approved");
    }


    private void FillDropdown(DropDownList ddl, string query, string textField)
    {
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlDataAdapter adp = new SqlDataAdapter(query, conn))
        {
            adp.Fill(dt);
        }

        string currentSelection = ddl.SelectedValue; // remember previous selection

        ddl.DataSource = dt;
        ddl.DataTextField = textField;
        ddl.DataValueField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("All", ""));

        // restore selection
        if (!string.IsNullOrEmpty(currentSelection) && ddl.Items.FindByValue(currentSelection) != null)
            ddl.SelectedValue = currentSelection;
        else
            ddl.SelectedIndex = 0;
    }


    protected void btnResetFilters_Click(object sender, EventArgs e)
    {
        // Reset dropdowns
        ddlpercent.SelectedIndex = -1;
        ddldivname.SelectedIndex = -1;
        ddlempname.SelectedIndex = -1;
        ddlbrand.SelectedIndex = -1;
        ddltag.SelectedIndex =-1;
        ddlstatus.SelectedIndex = -1;

        // Reset session values too (if you store filter selections in session)
        //Session["ddlpercent"] = null;
        //Session["ddldiv"] = null;
        //Session["ddlemp"] = null;
        //Session["ddlbrand"] = null;
        //Session["ddltag"] = null;
        //Session["ddlstatus"] = null;

        // Rebind dropdowns and grid with no filters
        //BindDivisions();
        //BindZSM();
        //BindBrands();
        //BindTags();
        //Bind_Status();
        LoadDropdowns();
        btndisapp.Visible = false;
        BindGrid3();
        
    }

    protected void btnhome(object sender, EventArgs e)
    {
        //string view = Session["View"].ToString();
        //if (view == "BH_View")
        //{
        //    Response.Redirect("BH_View.aspx");
        //}
        //else if (view == "Summary")
        //{
            Response.Redirect("Summary.aspx");
        //}
    }

    protected void FilterChanged(object sender, EventArgs e)
    {
        // Rebind dropdowns based on current selections
        BindZSM();
        BindBrands();
        BindTags();
        Bind_Status();
        BindDivisions(); // Division depends on all other filters too

        // Finally update grid
        BindGrid3();
    }




}