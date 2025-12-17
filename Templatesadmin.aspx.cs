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

public partial class Templatesadmin : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Banner.ShowShort();
        //if (Session["zsmname"] == null || Session["zcode"] == null ||
        //        Session["divi"] == null || Session["login"] == null) // or any key you use
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "sessionExpired",
        //            "alert('Your session has expired. Please login again.'); window.location='Loginpage.aspx';", true);
        //    }
        if (!IsPostBack)
        {
            Hidnfldname.Value = Session["zsmname"] != null ? Session["zsmname"].ToString() : "";
        Hidnfldcode.Value = Session["zcode"] != null ? Session["zcode"].ToString() : "";
        Hidnfldiv.Value = Session["divi"] != null ? Session["divi"].ToString() : "";
        Hidnfldlogin.Value = Session["login"] != null ? Session["login"].ToString() : "";
        HiddenfldBH_Code.Value = Session["BH_Code"] != null ? Session["BH_Code"].ToString() : "";
            //BindGrid();
            //binddropdown1();
            //binddropdown2();
        string welcome = Session["zsmname"] != null ? Session["zsmname"].ToString() : "";
        Lblwelcm.Text = "Welcome " + welcome + "!";
        LoadDivisionDropdown();

        Button1.Visible = true;
        if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
        {
            LoadAllDropdowns();
            BindGridWithFilters();
        }
        else
        {
            // Show empty state or message
            Grdemp.DataSource = null;
            Grdemp.DataBind();
            Lblrows.Text = "Rows : 0";
            Lblwh.Text = "Please select a division";
            Grdrprt.Visible = false;
            Grdemp.Visible = true;
            btnsubmit.Visible = false;
            Lblnote.Visible = false;
            //Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
        }
           
        }
        string current = System.IO.Path.GetFileName(Request.Path);

        switch (current)
        {
            case "Templatesadmin.aspx":
                btnnav2.CssClass += " active";
                break;
            case "Summary.aspx":
                Btnnav7.CssClass += " active";
                break;
            case "Login_Details_Admin.aspx":
                Button5.CssClass += " active";
                break;
            //case "Approval_BH.aspx":
            //    Button6.CssClass += " active";
            //    break;
            case "Contactus.aspx":
                btnconta.CssClass += " active";
                break;
            case "NotificationAdmin.aspx":
                Button4.CssClass += " active";
                break;
        }
    }
    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = @"SELECT A.[SALES_DIVISION], A.[ZSM CODE], A.[ZSM NAME], A.[Territory Code], A.[Territory Name], 
                A.[SALES_GCV_ACC_CODE], A.[SALES_ACC_NAME], A.[SALES_ProdID], A.[SALES_PROD_NAME], 
                ROUND(A.[SALES_2023-06], 0) AS [SALES_2023-09], ROUND(A.[SALES_2023-07], 0) AS [SALES_2023-10], 
                ROUND(A.[SALES_2023-08], 0) AS [SALES_2023-11], ROUND(A.[AVG_SEC_AUG23], 0) AS [AVG_SEC_NOV23], 
                ROUND(A.[CLO_2023_08], 0) AS [CLO_2023_11], ROUND(A.[CLO_Unit_08], 0) AS [CLO_Unit_11], 
                A.[Brands], A.[Tag], 
                CASE WHEN b.Unblock IS NULL THEN 'Blocked' ELSE b.Unblock END AS Unblock, 
                CASE WHEN b.Liquidation IS NULL THEN '-' ELSE b.Liquidation END AS Liquidation, 
                CASE WHEN b.ReasonUnblock IS NULL THEN '-' ELSE b.ReasonUnblock END AS ReasonUnblock, 
                CASE WHEN b.Approved IS NULL THEN '-' ELSE b.Approved END AS Approved,
                CASE 
                WHEN lr.[Logged in] IS NOT NULL THEN 
                    FORMAT(CONVERT(DATETIME, lr.[Logged in]), 'dd-MM-yyyy HH:mm:ss')
                ELSE '-'
                END AS LoginTime,
                -- Submit Time formatted as dd-mm-yyyy
                CASE 
                    WHEN submit.SubmitTime IS NOT NULL THEN 
                        FORMAT(CONVERT(DATETIME, submit.SubmitTime), 'dd-MM-yyyy HH:mm:ss')
                    ELSE NULL
                END AS SubmitTime,
                -- Approval Time formatted as dd-mm-yyyy
                CASE 
                    WHEN approval.ApprovalTime IS NOT NULL THEN 
                        FORMAT(CONVERT(DATETIME, approval.ApprovalTime), 'dd-MM-yyyy HH:mm:ss')
                    ELSE NULL
                END AS ApprovalTime
                FROM TemplateData A 
                LEFT JOIN Templateconsolidate b ON A.[SALES_UNIQUEKEY] = CONCAT(b.[SALES_ProdID], b.[SALES_GCV_ACC_CODE]) 
                LEFT JOIN (SELECT [ZSM_Code], [Logged in] FROM [Loginrecord$] 
                          WHERE [ZSM_Code] IN (SELECT [ZSM_Code] FROM [loginID$])) lr 
                ON A.[ZSM CODE] = lr.[ZSM_Code] 
                LEFT JOIN (SELECT [ZSM CODE], MAX([Time]) AS SubmitTime
                          FROM [Notification$] 
                          WHERE [NOTIFICATION] LIKE '%has Submitted%'
                          GROUP BY [ZSM CODE]) submit 
                ON A.[ZSM CODE] = submit.[ZSM CODE]
                LEFT JOIN (SELECT [ZSM CODE], MAX([Time]) AS ApprovalTime
                          FROM [Notification$] 
                          WHERE [NOTIFICATION] LIKE '%has been Approved By Division Head%'
                          GROUP BY [ZSM CODE]) approval 
                ON A.[ZSM CODE] = approval.[ZSM CODE]";
        Lblwh.Text = " Overall Blocking List";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;

            Grdemp.DataBind();
            Grdemp.Columns[0].Visible = false;
            Grdemp.Columns[1].Visible = false;
            Grdemp.Columns[2].Visible = false;
            Grdemp.Columns[3].Visible = false;
            Grdemp.Columns[5].Visible = false;
            Grdemp.Columns[7].Visible = false;
          //  Grdemp.Columns[15].Visible = false;
        }
        string Zsmmcode = dtDsStockist.Rows[1][1].ToString();
        Session["Zsmmcode"] = Zsmmcode;

        string divisionname = dtDsStockist.Rows[1][0].ToString();
        Session["divisionname"] = divisionname;

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        //   Lbldetail.Text = "Employee Code : " + Zsmmcode + "<br />" + "Division : " + divisionname + "";
        string counnt = dtDsStockist.Rows.Count.ToString();
        Lblrows.Text = "Rows : " + counnt;
        Grdrprt.Visible = false;
        Grdemp.Visible = true;
    //    btnreview.Visible = true;
        btnsubmit.Visible = false;
        Lblnote.Visible = false;
        Button1.Visible = true;
        Button2.Visible = false;
        Button3.Visible = false;
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
    //public void BindGrid2()
    //{

    //    DataSet DsStockistt = new DataSet();
    //    DataTable dtDsStockistt = new DataTable();
    //    string StrQrryy = "";
    //    StrQrryy = "Select * from dbo.[Templatereview] where [ZSM NAME] = '" +  Session["name"] + "';";
    //    Lblwh.Text = "Block/Unblock List Review of " + Session["name"];
    //    // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";

    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrryy, conn);
    //    adpRpt.Fill(DsStockistt, "DsStockistt");
    //    adpRpt.Fill(dtDsStockistt);


    //    if (DsStockistt.Tables[0].Rows.Count > 0)
    //    {
    //        Grdrprt.DataSource = dtDsStockistt;
    //        Grdrprt.DataBind();
    //    }
    //    else
    //    {
    //        dtDsStockistt.Rows.Add(dtDsStockistt.NewRow());
    //        Grdrprt.DataSource = dtDsStockistt;
    //        Grdrprt.DataBind();
    //        Grdrprt.Rows[0].Visible = false;
    //    }

    //    btnsubmit.Visible = true;
    //    Grdrprt.Visible = true;
    //    Lblrows.Visible = true;
    //    // Lblnote.Visible = false;
    //}
    public void BindGrid3()
    {

        DataSet DsStockisttt = new DataSet();
        DataTable dtDsStockisttt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "Select * from dbo.[Templateconsolidate] where [ZSM NAME] = '" + Session["name"] + "';";
        Lblwh.Text = "Block/Unblock List of " + Session["name"];
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrryy, conn);
        adpRpt.Fill(DsStockisttt, "DsStockistt");


        adpRpt.Fill(dtDsStockisttt);


        if (DsStockisttt.Tables[0].Rows.Count > 0)
        {
            Grdrprt.DataSource = dtDsStockisttt;
            Grdrprt.DataBind();
        }
        else
        {
            dtDsStockisttt.Rows.Add(dtDsStockisttt.NewRow());
            Grdrprt.DataSource = dtDsStockisttt;
            Grdrprt.DataBind();
            Grdrprt.Rows[0].Visible = false;
        }

        btnsubmit.Visible = false;
        Grdrprt.Visible = true;
        Lblrows.Visible = true;
        // Lblnote.Visible = false;
    }
    public void BindGrid4()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select  [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME],Round([SALES_2023-06], 0) as [SALES_2023-09],Round([SALES_2023-07], 0) as [SALES_2023-10], Round([SALES_2023-08], 0) as [SALES_2023-11],Round([AVG_SEC_AUG23], 0) as [AVG_SEC_NOV23],Round([CLO_2023_08], 0) as [CLO_2023_11], Round([CLO_Unit_08], 0) as [CLO_Unit_11], [Brands],[Tag] FROM [dbo].[TemplateData] where [BH_Code] = '" + HiddenfldBH_Code.Value.ToString() + "';";
        Lblwh.Text = "Blocking List of " + Session["ddldiv"] + "";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;

            Grdemp.DataBind();
            Grdemp.Columns[0].Visible = false;
            Grdemp.Columns[1].Visible = false;
            Grdemp.Columns[2].Visible = false;
            Grdemp.Columns[3].Visible = false;
            Grdemp.Columns[5].Visible = false;
            Grdemp.Columns[7].Visible = false;
          //  Grdemp.Columns[15].Visible = false;
        }
        // string Zsmmcode = dtDsStockist.Rows[1][1].ToString();
        //  Session["Zsmmcode"] = Zsmmcode;

        //   string divisionname = dtDsStockist.Rows[1][0].ToString();
        //   Session["divisionname"] = divisionname;

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        //   Lbldetail.Text = "Employee Code : " + Zsmmcode + "<br />" + "Division : " + divisionname + "";
        string counnt = dtDsStockist.Rows.Count.ToString();
        Lblrows.Text = "Rows : " + counnt;
        Grdrprt.Visible = false;
        Grdemp.Visible = true;
      //  btnreview.Visible = true;
        btnsubmit.Visible = false;
        Lblnote.Visible = false;
        Button2.Visible = true;
        Button3.Visible = false;
        Button1.Visible = false;

    }
    public void BindGrid5()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "  Select  [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME],Round([SALES_2023-06], 0) as [SALES_2023-09],Round([SALES_2023-07], 0) as [SALES_2023-10], Round([SALES_2023-08], 0) as [SALES_2023-11],Round([AVG_SEC_AUG23], 0) as [AVG_SEC_NOV23],Round([CLO_2023_08], 0) as [CLO_2023_11], Round([CLO_Unit_08], 0) as [CLO_Unit_11], [Brands],[Tag] FROM [dbo].[TemplateData] where [ZSM NAME] = '" + Session["ddlemp"] + "';";
        Lblwh.Text = "Blocking List of " + Session["ddlemp"] + "";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;

            Grdemp.DataBind();
            Grdemp.Columns[0].Visible = false;
            Grdemp.Columns[1].Visible = false;
            Grdemp.Columns[2].Visible = false;
            Grdemp.Columns[3].Visible = false;
            Grdemp.Columns[5].Visible = false;
            Grdemp.Columns[7].Visible = false;
         //   Grdemp.Columns[15].Visible = false;
        }
        // string Zsmmcode = dtDsStockist.Rows[1][1].ToString();
        //  Session["Zsmmcode"] = Zsmmcode;

        //   string divisionname = dtDsStockist.Rows[1][0].ToString();
        //   Session["divisionname"] = divisionname;

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        //   Lbldetail.Text = "Employee Code : " + Zsmmcode + "<br />" + "Division : " + divisionname + "";
        string counnt = dtDsStockist.Rows.Count.ToString();
        Lblrows.Text = "Rows : " + counnt;
        Grdrprt.Visible = false;
        Grdemp.Visible = true;
     //   btnreview.Visible = true;
        btnsubmit.Visible = false;
        Lblnote.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
        Button1.Visible = false;
    }
    //protected void changed(object sender, EventArgs e)
    //{
    //    DropDownList chckstatus = (DropDownList)sender;
    //    GridViewRow row = (GridViewRow)chckstatus.NamingContainer;
    //    DropDownList ddlR = (DropDownList)row.FindControl("ddlliquid");
    //    TextBox txbx = (TextBox)row.FindControl("txtreason");
    //    if (chckstatus.SelectedValue == "Unblock")
    //    {
    //        ddlR.Enabled = true;
    //        txbx.Enabled = true;
    //    }
    //    else
    //    {
    //        ddlR.Enabled = false;
    //        txbx.Enabled = false;
    //    }
    //}
    protected void btnnotific(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("NotificationAdmin.aspx");
    }
    protected void btnreprt(object sender, EventArgs e)
    {
     
        Response.Redirect("Fixitreports.aspx");
    }
    protected void btncontac(object sender, EventArgs e)
    {
        
        Response.Redirect("Contactus.aspx");
    }
    protected void btnsumm(object sender, EventArgs e)
    {
       
        Response.Redirect("Summary.aspx");
    }
    protected void btnoutclick(object sender, EventArgs e)
    {
        DateTime logout = DateTime.Now;
        SqlCommand cmdd = new SqlCommand("Logoutrecord_ps", conn);
        cmdd.CommandType = CommandType.StoredProcedure;
        cmdd.Parameters.AddWithValue("@logout", logout.ToString("MMM dd yyyy hh:mm tt"));
        cmdd.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
        cmdd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
        conn.Open();
        //cmd.ExecuteNonQuery();
        string strRsslt = cmdd.ExecuteNonQuery().ToString();
        conn.Close();
        Response.Redirect("LoginPage.aspx");
    }
    //protected void btnsubmit_Click(object sender, EventArgs e)
    //{
    //    SqlCommand cmd1 = new SqlCommand("templateps_submitadmin", conn);
    //    cmd1.CommandType = CommandType.StoredProcedure;
    //    cmd1.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
    //    cmd1.Parameters.AddWithValue("@Unblocked_Percentage", Session["rounded"].ToString());
    //    conn.Open();
    //    //cmd.ExecuteNonQuery();
    //    string strRslt = cmd1.ExecuteNonQuery().ToString();
    //    conn.Close();
    //    btnsubmit.Visible = false;
    //    BindGrid3();
    // //   Lblanswer.Text = "You have Completed Unblocking Successfully!";
    //    Lblnote.Visible = false;
    //    Lblrows.Visible = false;
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
    private void ExportGridToExcel()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string where = " WHERE 1=1  and b.SALES_ProdID IS NULL";
      
        string StrQrry = "";
        StrQrry = @"WITH Consolidated AS (
    SELECT 
        [SALES_ProdID], [SALES_GCV_ACC_CODE],
        MAX(Unblock) AS Unblock,
        MAX(ReasonUnblock) AS ReasonUnblock,
        MAX(Approved) AS Approved,
        MAX(Submit_Time) AS Submit_Time,
        MAX(Approved_Time) AS Approved_Time
    FROM [dbo].[Templateconsolidate]
    GROUP BY [SALES_ProdID], [SALES_GCV_ACC_CODE]
)
SELECT 
    A.[SALES_DIVISION], A.[ZSM CODE], A.[ZSM NAME],
    A.[Territory Code], A.[Territory Name],
    A.[SALES_GCV_ACC_CODE], A.[SALES_ACC_NAME],
    A.[SALES_ProdID], A.[SALES_PROD_NAME],
     ROUND(A.[SALES_2023-06], 0) AS [SALES_2025-09],
    ROUND(A.[SALES_2023-07], 0) AS [SALES_2025-10],
    ROUND(A.[SALES_2023-08], 0) AS [SALES_2025-11],
    ROUND(A.[AVG_SEC_AUG23], 0) AS [AVG_SEC_NOV25],
    ROUND(A.[CLO_2023_08], 0) AS [CLO_2025_11],
    ROUND(A.[CLO_Unit_08], 0) AS [CLO_Unit_11],
    A.[INVENTORY_DAYS] AS [Inventory Days], A.[Tag] AS [Additional Info],
    COALESCE(b.Unblock, 'Blocked') AS [Unblock],
    
    COALESCE(b.ReasonUnblock, '-') AS [ReasonUnblock],
    COALESCE(b.Approved, '-') AS [Approved],
    b.[Submit_Time],
    b.[Approved_Time]
FROM [dbo].[TemplateData] A
LEFT JOIN Consolidated b 
    ON A.[SALES_ProdID] = b.[SALES_ProdID]
   AND A.[SALES_GCV_ACC_CODE] = b.[SALES_GCV_ACC_CODE] and b.Unblock <>'Unblock'
";
        // Division
        if (ddlDivision.SelectedIndex > 0)
        {
            where += " AND A.[SALES_DIVISION] = '" + ddlDivision.SelectedValue + "' ";
        }

        // ZSM
        if (ddlempname.SelectedIndex > 0)
        {
            where += " AND A.[ZSM NAME] = '" + ddlempname.SelectedValue + "' ";
        }

        // Stockist
        if (ddlStockist.SelectedIndex > 0)
        {
            where += " AND A.[SALES_ACC_NAME] = '" + ddlStockist.SelectedValue + "' ";
        }

        // Product
        if (ddlProduct.SelectedIndex > 0)
        {
            where += " AND A.[SALES_PROD_NAME] = '" + ddlProduct.SelectedValue + "' ";
        }

        // Status
        if (ddlStatus.SelectedIndex > 0)
        {
            where += " AND b.[Approved] = '" + ddlStatus.SelectedValue + "' ";
        }

        // Tag
        if (ddlTag.SelectedIndex > 0)
        {
            where += " AND A.[Tag] = '" + ddlTag.SelectedValue + "' ";
        }
        StrQrry = StrQrry + where;
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "";
        if (ddlempname.SelectedIndex > 0)
        {
            FileName = "Blocking Report of " + Session["ddlemp"] + "_" + DateTime.Now + ".xls";
        }
        else
        {
            FileName = "Blocking Report of " + ddlDivision.SelectedValue + "_" + DateTime.Now + ".xls";
        }
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-Disposition", "inline;  filename=" + FileName);
        DataGrid dg = new DataGrid();
        dg.DataSource = dtDsStockist;
        dg.DataBind();
        foreach (DataGridItem item in dg.Items)
        {
            for (int j = 0; j < item.Cells.Count; j++)
            {
                item.Cells[j].Attributes.Add("style", "mso-number-format:\\@");
                item.Cells[9].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[10].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[11].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[12].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[13].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[14].Attributes.Add("style", "mso-number-format:'#,##0'");
            }
        }
       
        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
       // Grdemp.GridLines = GridLines.Both;
        //Grdemp.HeaderStyle.Font.Bold = true;
        //Grdemp.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExportGridToExcel2();
    }
    private void ExportGridToExcel2()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();

        string StrQrry = "";
        StrQrry = " Select distinct [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME],Round([SALES_2023-06], 0) as [SALES_2025-08],Round([SALES_2023-07], 0) as [SALES_2025-09], Round([SALES_2023-08], 0) as [SALES_2025-10],Round([AVG_SEC_AUG23], 0) as [AVG_SEC_OCT25],Round([CLO_2023_08], 0)  as [CLO_2025_10], Round([CLO_Unit_08], 0) as [CLO_Unit_202510], [Brands],[Tag] FROM [dbo].[TemplateData] where [BH_Code] = '" + HiddenfldBH_Code.Value.ToString() + "';";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Blocking Report of " + Session["ddldiv"] + "_" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-Disposition", "inline;  filename=" + FileName);
        DataGrid dg = new DataGrid();
        dg.DataSource = dtDsStockist;
        dg.DataBind();
        foreach (DataGridItem item in dg.Items)
        {
            for (int j = 0; j < item.Cells.Count; j++)
            {
                item.Cells[j].Attributes.Add("style", "mso-number-format:\\@");
                item.Cells[9].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[10].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[11].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[12].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[13].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[14].Attributes.Add("style", "mso-number-format:'#,##0'");
            }
        }

        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
        // Grdemp.GridLines = GridLines.Both;
        //Grdemp.HeaderStyle.Font.Bold = true;
        //Grdemp.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ExportGridToExcel3();
    }
    private void ExportGridToExcel3()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();

        string StrQrry = "";
        string where = " WHERE 1=1 and b.SALES_ProdID IS NULL ";
        StrQrry = @"WITH Consolidated AS (
    SELECT 
        [SALES_ProdID], [SALES_GCV_ACC_CODE],
        MAX(Unblock) AS Unblock,
        MAX(Liquidation) AS Liquidation,
        MAX(ReasonUnblock) AS ReasonUnblock,
        MAX(Approved) AS Approved,
        MAX(Submit_Time) AS Submit_Time,
        MAX(Approved_Time) AS Approved_Time
    FROM [dbo].[Templateconsolidate]
    GROUP BY [SALES_ProdID], [SALES_GCV_ACC_CODE]
)
SELECT 
    A.[SALES_DIVISION], A.[ZSM CODE], A.[ZSM NAME],
    A.[Territory Code], A.[Territory Name],
    A.[SALES_GCV_ACC_CODE], A.[SALES_ACC_NAME],
    A.[SALES_ProdID], A.[SALES_PROD_NAME],
     ROUND(A.[SALES_2023-06], 0) AS [SALES_2025-09],
    ROUND(A.[SALES_2023-07], 0) AS [SALES_2025-10],
    ROUND(A.[SALES_2023-08], 0) AS [SALES_2025-11],
    ROUND(A.[AVG_SEC_AUG23], 0) AS [AVG_SEC_NOV25],
    ROUND(A.[CLO_2023_08], 0) AS [CLO_2025_11],
    ROUND(A.[CLO_Unit_08], 0) AS [CLO_Unit_11],
    A.[Brands], A.[Tag],
    COALESCE(b.Unblock, 'Blocked') AS [Unblock],
    COALESCE(b.Liquidation, '-') AS [Liquidation],
    COALESCE(b.ReasonUnblock, '-') AS [ReasonUnblock],
    COALESCE(b.Approved, '-') AS [Approved],
    b.[Submit_Time],
    b.[Approved_Time]
FROM [dbo].[TemplateData] A
LEFT JOIN Consolidated b 
    ON A.[SALES_ProdID] = b.[SALES_ProdID]
   AND A.[SALES_GCV_ACC_CODE] = b.[SALES_GCV_ACC_CODE]  ";
        // Division
        if (ddlDivision.SelectedIndex > 0)
        {
            where += " AND A.[SALES_DIVISION] = '" + ddlDivision.SelectedValue + "' ";
        }

        // ZSM
        if (ddlempname.SelectedIndex > 0)
        {
            where += " AND A.[ZSM NAME] = '" + ddlempname.SelectedValue + "' ";
        }

        // Stockist
        if (ddlStockist.SelectedIndex > 0)
        {
            where += " AND A.[SALES_ACC_NAME] = '" + ddlStockist.SelectedValue + "' ";
        }

        // Product
        if (ddlProduct.SelectedIndex > 0)
        {
            where += " AND A.[SALES_PROD_NAME] = '" + ddlProduct.SelectedValue + "' ";
        }

        // Status
        if (ddlStatus.SelectedIndex > 0)
        {
            where += " AND b.[Approved] = '" + ddlStatus.SelectedValue + "' ";
        }

        // Tag
        if (ddlTag.SelectedIndex > 0)
        {
            where += " AND A.[Tag] = '" + ddlTag.SelectedValue + "' ";
        }
        StrQrry = StrQrry + where;
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "";
        if (ddlempname.SelectedIndex > 0)
        {
            FileName = "Blocking Report of " + Session["ddlemp"] + "_" + DateTime.Now + ".xls";
        }
        else 
        {
            FileName = "Blocking Report of " + ddlDivision.SelectedValue + "_" + DateTime.Now + ".xls";
        }
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-Disposition", "inline;  filename=" + FileName);
        DataGrid dg = new DataGrid();
        dg.DataSource = dtDsStockist;
        dg.DataBind();
        foreach (DataGridItem item in dg.Items)
        {
            for (int j = 0; j < item.Cells.Count; j++)
            {
                item.Cells[j].Attributes.Add("style", "mso-number-format:\\@");
                item.Cells[9].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[10].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[11].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[12].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[13].Attributes.Add("style", "mso-number-format:'#,##0'");
                item.Cells[14].Attributes.Add("style", "mso-number-format:'#,##0'");
            }
        }

        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
        // Grdemp.GridLines = GridLines.Both;
        //Grdemp.HeaderStyle.Font.Bold = true;
        //Grdemp.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }   
    //protected void btncancel_Click(object sender, EventArgs e)
    //{

    //    SqlCommand cmd1 = new SqlCommand("templateps_delete", conn);
    //    cmd1.CommandType = CommandType.StoredProcedure;
    //    cmd1.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
    //    conn.Open();
    //    //cmd.ExecuteNonQuery();
    //    string strRslt = cmd1.ExecuteNonQuery().ToString();
    //    conn.Close();


    //}
    //protected void btnok_Click(object sender, EventArgs e)
    //{

    //    SqlCommand cmd1 = new SqlCommand("templateps_approval", conn);
    //    cmd1.CommandType = CommandType.StoredProcedure;
    //    cmd1.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
    //    cmd1.Parameters.AddWithValue("@Unblocked_Percentage", Session["rounded"].ToString());
    //    conn.Open();
    //    //cmd.ExecuteNonQuery();
    //    string strRslt = cmd1.ExecuteNonQuery().ToString();
    //    conn.Close();
    //    Lblnote.Visible = true;
    //  //  Lblanswer.Text = "You have Completed Unblocking Successfully!";
    //    BindGrid3();
    //    Lblrows.Visible = true;
    //    btnsubmit.Visible = false;
    //}
    //protected void btnokerror_Click(object sender, EventArgs e)
    //{
    //    string apprv = string.Empty;
    //    apprv = "Approved";
    //    SqlCommand cmd1 = new SqlCommand("templateps_approvalforzero", conn);
    //    cmd1.CommandType = CommandType.StoredProcedure;
    //    cmd1.Parameters.AddWithValue("@Division", Session["divv"].ToString());
    //    cmd1.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.Value.ToString());
    //    cmd1.Parameters.AddWithValue("@Approved", apprv.ToString());
    //    cmd1.Parameters.AddWithValue("@ZSM_NAME", Hidnfldname.Value.ToString());
    //    cmd1.Parameters.AddWithValue("@Unblocked_Percentage", Session["rounded"].ToString());
    //    conn.Open();
    //    //cmd.ExecuteNonQuery();
    //    string strRslt = cmd1.ExecuteNonQuery().ToString();
    //    conn.Close();
    //    Grdemp.Visible = false;
    // //   btnreview.Visible = false;
    //    //BindGrid2();
    //    Grdrprt.Visible = true;
    //    Lblnote.Visible = false;
    //   // Lblanswer.Text = "Please click on Submit to Complete Unblocking Successfully!";
    //    Lblrows.Visible = true;
    //}
    protected void btncancelerror_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("Templatesadmin.aspx");

    }
    //protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlemp = string.Empty;
    //    ddlemp = ddlempname.SelectedValue.ToString();
    //    Session["ddlemp"] = ddlemp;
    //    Lblwh.Text = ddlempname.SelectedItem.ToString();
    //    BindGrid5();
    //}
    //public void binddropdown1()
    //{
    //    DataSet DsStockist = new DataSet();
    //    DataTable dtDsStockist = new DataTable();
    //    string StrQrry = "";
    //    StrQrry = "Select distinct[ZSM CODE],[ZSM NAME] FROM [dbo].[TemplateData] where [BH_Code] = '" + HiddenfldBH_Code.Value.ToString() + "' and [ZSM NAME] is not null;";

    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
    //    adpRpt.Fill(DsStockist, "DsStockist");
    //    adpRpt.Fill(dtDsStockist);
    //    if (DsStockist.Tables[0].Rows.Count > 0)
    //    {
    //        ddlempname.DataSource = dtDsStockist;
    //        ddlempname.DataTextField = "ZSM NAME";
    //        ddlempname.DataBind();
    //        ddlempname.Items.Insert(0, "Select");
    //        //ddlempname.SelectedIndex = 0;
    //    }

    //}
    //protected void ddldiv_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddldiv = string.Empty;
    //    ddldiv = ddldivname.SelectedValue.ToString();
    //    Session["ddldiv"] = ddldiv;
    //    Lblwh.Text = ddldivname.SelectedItem.ToString();
    //    binddropdown1();
    //    BindGrid4();
    //}
    //public void binddropdown2()
    //{
    //    DataSet DsStockistt = new DataSet();
    //    DataTable dtDsStockistt = new DataTable();
    //    string StrQrryy = "";
    //    StrQrryy = "Select distinct [SALES_DIVISION] FROM [dbo].[TemplateData] where [SALES_DIVISION] is not null;";

    //    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    //    SqlDataAdapter adpRptt = new SqlDataAdapter(StrQrryy, conn);
    //    adpRptt.Fill(DsStockistt, "DsStockistt");
    //    adpRptt.Fill(dtDsStockistt);
    //    if (DsStockistt.Tables[0].Rows.Count > 0)
    //    {
    //        ddldivname.DataSource = dtDsStockistt;
    //        ddldivname.DataTextField = "SALES_DIVISION";
    //        ddldivname.DataBind();
    //        ddldivname.Items.Insert(0, "Select");
    //        //ddldivname.SelectedIndex = 0;
    //    }
    //}
    protected void btnApprovalDetails(object sender, EventArgs e)
    {

        Response.Redirect("Approval_BH.aspx");
    }
    protected void btnloginDetails(object sender, EventArgs e)
    {

        Response.Redirect("Login_Details_Admin.aspx");
    }
    protected void btntemp(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Templatesadmin.aspx");
    }

    // Update the dropdown change events for bidirectional filtering
    protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlemp = string.IsNullOrEmpty(ddlempname.SelectedValue) ? "" : ddlempname.SelectedValue;
        Session["ddlemp"] = ddlemp;
        Lblwh.Text = string.IsNullOrEmpty(ddlempname.SelectedValue) ? "Blocking List of " + Hidnfldiv.Value.ToString() : "Blocking List of " + ddlempname.SelectedItem.Text;

        // Update ALL dependent dropdowns dynamically
        UpdateAllDropdowns();
        BindGridWithFilters();
    }
    private void LoadDivisionDropdown()
    {
        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        string query = "SELECT DISTINCT [SALES_DIVISION] FROM [dbo].[TemplateData] WHERE [SALES_DIVISION] IS NOT NULL ORDER BY [SALES_DIVISION]";

        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                adp.Fill(dt);
            }
        }

        ddlDivision.DataSource = dt;
        ddlDivision.DataTextField = "SALES_DIVISION";
        ddlDivision.DataValueField = "SALES_DIVISION";
        ddlDivision.DataBind();

        // Set default selection - either from session or first item
        if (Session["SelectedDivision"] != null)
        {
            ddlDivision.SelectedValue = Session["SelectedDivision"].ToString();
        }
        else
        {
            ddlDivision.Items.Insert(0, new ListItem("Select Division", ""));
            ddlDivision.SelectedIndex = 0;
        }
    }

    // Division dropdown change event
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedDivision = string.IsNullOrEmpty(ddlDivision.SelectedValue) ? "" : ddlDivision.SelectedValue;
        Session["SelectedDivision"] = selectedDivision;

        Lblwh.Text = string.IsNullOrEmpty(selectedDivision) ?
            "Overall Blocking List" :
            "Blocking List of " + ddlDivision.SelectedItem.Text;

        // Update ALL dependent dropdowns based on selected division
        UpdateAllDropdowns();
        BindGridWithFilters();
    }

    protected void ddlStockist_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Update ALL dependent dropdowns dynamically
        UpdateAllDropdowns();
        BindGridWithFilters();
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Update ALL dependent dropdowns dynamically
        UpdateAllDropdowns();
        BindGridWithFilters();
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateAllDropdowns();
        
        BindGridWithFilters();
    }

    protected void ddlTag_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Update ALL dependent dropdowns dynamically
        UpdateAllDropdowns();
        BindGridWithFilters();
    }

    // New method to update ALL dropdowns based on current selections
    private void UpdateAllDropdowns()
    {
        BindStockistDropdown();
        BindProductDropdown();
        BindTagDropdown();
        BindZSMDropdown();
        BindStatusDropdown();
    }

    private void BindZSMDropdown()
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT DISTINCT [ZSM NAME] FROM [dbo].[TemplateData] WHERE [ZSM NAME] IS NOT NULL");

        List<SqlParameter> parameters = new List<SqlParameter>();

        // Use selected division instead of session
        if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
        {
            query.Append(" AND [SALES_DIVISION] = @Division");
            parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
        }

        // Apply other filters
        if (!string.IsNullOrEmpty(ddlStockist.SelectedValue))
        {
            query.Append(" AND [SALES_ACC_NAME] = @StockistName");
            parameters.Add(new SqlParameter("@StockistName", ddlStockist.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
        {
            query.Append(" AND [SALES_PROD_NAME] = @ProductName");
            parameters.Add(new SqlParameter("@ProductName", ddlProduct.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlTag.SelectedValue))
        {
            query.Append(" AND [Tag] = @Tag");
            parameters.Add(new SqlParameter("@Tag", ddlTag.SelectedValue));
        }

        query.Append(" ORDER BY [ZSM NAME]");

        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
        }

        string currentSelection = ddlempname.SelectedValue;

        ddlempname.DataSource = dt;
        ddlempname.DataTextField = "ZSM NAME";
        ddlempname.DataValueField = "ZSM NAME";
        ddlempname.DataBind();
        ddlempname.Items.Insert(0, new ListItem("All ZSM", ""));

        if (!string.IsNullOrEmpty(currentSelection) && ddlempname.Items.FindByValue(currentSelection) != null)
        {
            ddlempname.SelectedValue = currentSelection;
        }
        else if (string.IsNullOrEmpty(currentSelection))
        {
            ddlempname.SelectedIndex = 0;
        }
    }

    // Update Stockist dropdown to use selected division
    private void BindStockistDropdown()
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT DISTINCT [SALES_ACC_NAME] FROM [dbo].[TemplateData] WHERE [SALES_ACC_NAME] IS NOT NULL");

        List<SqlParameter> parameters = new List<SqlParameter>();

        // Use selected division instead of session
        if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
        {
            query.Append(" AND [SALES_DIVISION] = @Division");
            parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
        }

        // Apply other filters
        if (!string.IsNullOrEmpty(ddlempname.SelectedValue))
        {
            query.Append(" AND [ZSM NAME] = @ZSMName");
            parameters.Add(new SqlParameter("@ZSMName", ddlempname.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
        {
            query.Append(" AND [SALES_PROD_NAME] = @ProductName");
            parameters.Add(new SqlParameter("@ProductName", ddlProduct.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlTag.SelectedValue))
        {
            query.Append(" AND [Tag] = @Tag");
            parameters.Add(new SqlParameter("@Tag", ddlTag.SelectedValue));
        }

        query.Append(" ORDER BY [SALES_ACC_NAME]");

        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
        }

        string currentSelection = ddlStockist.SelectedValue;

        ddlStockist.DataSource = dt;
        ddlStockist.DataTextField = "SALES_ACC_NAME";
        ddlStockist.DataValueField = "SALES_ACC_NAME";
        ddlStockist.DataBind();
        ddlStockist.Items.Insert(0, new ListItem("All Stockists", ""));

        if (!string.IsNullOrEmpty(currentSelection) && ddlStockist.Items.FindByValue(currentSelection) != null)
        {
            ddlStockist.SelectedValue = currentSelection;
        }
        else
        {
            ddlStockist.SelectedIndex = 0;
        }
    }

    // Similarly update Product and Tag dropdown methods...

    private void BindProductDropdown()
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT DISTINCT [SALES_PROD_NAME] FROM [dbo].[TemplateData] WHERE [SALES_PROD_NAME] IS NOT NULL");

        List<SqlParameter> parameters = new List<SqlParameter>();

        // Use selected division instead of session
        if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
        {
            query.Append(" AND [SALES_DIVISION] = @Division");
            parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
        }

        // Apply other filters...
        if (!string.IsNullOrEmpty(ddlempname.SelectedValue))
        {
            query.Append(" AND [ZSM NAME] = @ZSMName");
            parameters.Add(new SqlParameter("@ZSMName", ddlempname.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlStockist.SelectedValue))
        {
            query.Append(" AND [SALES_ACC_NAME] = @StockistName");
            parameters.Add(new SqlParameter("@StockistName", ddlStockist.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlTag.SelectedValue))
        {
            query.Append(" AND [Tag] = @Tag");
            parameters.Add(new SqlParameter("@Tag", ddlTag.SelectedValue));
        }

        query.Append(" ORDER BY [SALES_PROD_NAME]");

        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
        }

        string currentSelection = ddlProduct.SelectedValue;

        ddlProduct.DataSource = dt;
        ddlProduct.DataTextField = "SALES_PROD_NAME";
        ddlProduct.DataValueField = "SALES_PROD_NAME";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("All Products", ""));

        if (!string.IsNullOrEmpty(currentSelection) && ddlProduct.Items.FindByValue(currentSelection) != null)
        {
            ddlProduct.SelectedValue = currentSelection;
        }
        else
        {
            ddlProduct.SelectedIndex = 0;
        }
    }

    private void BindTagDropdown()
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT DISTINCT [Tag] FROM [dbo].[TemplateData] WHERE [Tag] IS NOT NULL AND [Tag] != ''");

        List<SqlParameter> parameters = new List<SqlParameter>();

        // Use selected division instead of session
        if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
        {
            query.Append(" AND [SALES_DIVISION] = @Division");
            parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
        }

        // Apply other filters...
        if (!string.IsNullOrEmpty(ddlempname.SelectedValue))
        {
            query.Append(" AND [ZSM NAME] = @ZSMName");
            parameters.Add(new SqlParameter("@ZSMName", ddlempname.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlStockist.SelectedValue))
        {
            query.Append(" AND [SALES_ACC_NAME] = @StockistName");
            parameters.Add(new SqlParameter("@StockistName", ddlStockist.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
        {
            query.Append(" AND [SALES_PROD_NAME] = @ProductName");
            parameters.Add(new SqlParameter("@ProductName", ddlProduct.SelectedValue));
        }

        query.Append(" ORDER BY [Tag]");

        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
        }

        string currentSelection = ddlTag.SelectedValue;

        ddlTag.DataSource = dt;
        ddlTag.DataTextField = "Tag";
        ddlTag.DataValueField = "Tag";
        ddlTag.DataBind();
        ddlTag.Items.Insert(0, new ListItem("All Tags", ""));

        if (!string.IsNullOrEmpty(currentSelection) && ddlTag.Items.FindByValue(currentSelection) != null)
        {
            ddlTag.SelectedValue = currentSelection;
        }
        else
        {
            ddlTag.SelectedIndex = 0;
        }
    }
    private void BindStatusDropdown()
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT DISTINCT Approved FROM [dbo].[Templateconsolidate] WHERE [Approved] ='-'");

        List<SqlParameter> parameters = new List<SqlParameter>();

        // Use selected division instead of session
        if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
        {
            query.Append(" AND [SALES_DIVISION] = @Division");
            parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
        }

        // Apply other filters
        if (!string.IsNullOrEmpty(ddlempname.SelectedValue))
        {
            query.Append(" AND [ZSM NAME] = @ZSMName");
            parameters.Add(new SqlParameter("@ZSMName", ddlempname.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
        {
            query.Append(" AND [SALES_PROD_NAME] = @ProductName");
            parameters.Add(new SqlParameter("@ProductName", ddlProduct.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlTag.SelectedValue))
        {
            query.Append(" AND [Tag] = @Tag");
            parameters.Add(new SqlParameter("@Tag", ddlTag.SelectedValue));
        }
        if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
        {
            query.Append(" AND [Approved] = @Approved");
            parameters.Add(new SqlParameter("@Approved", ddlStatus.SelectedValue));
        }

        query.Append(" ORDER BY [Approved]");

        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
        }

        string currentSelection = ddlStatus.SelectedValue;

        ddlStatus.DataSource = dt;
        ddlStatus.DataTextField = "Approved";
        ddlStatus.DataValueField = "Approved";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("All Status", ""));

        if (!string.IsNullOrEmpty(currentSelection) && ddlStatus.Items.FindByValue(currentSelection) != null)
        {
            ddlStatus.SelectedValue = currentSelection;
        }
        else
        {
            ddlStatus.SelectedIndex = 0;
        }
    }

    // Update LoadAllDropdowns to use division filter
    private void LoadAllDropdowns()
    {
        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connString))
        {
            con.Open();

            // Build queries with division filter
            StringBuilder baseQuery = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            baseQuery.Append("SELECT DISTINCT {0} FROM [dbo].[TemplateData] WHERE 1=1");

            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
            {
                baseQuery.Append(" AND [SALES_DIVISION] = @Division");
                parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
            }
            baseQuery.Append(" ORDER BY {0}");

            // Load ZSM Names
            string zsmQuery = string.Format(baseQuery.ToString(), "[ZSM NAME]");
            SqlDataAdapter daZsm = new SqlDataAdapter(zsmQuery, con);
            daZsm.SelectCommand.Parameters.AddRange(parameters.ToArray());
            DataTable dtZsm = new DataTable();
            daZsm.Fill(dtZsm);
            ddlempname.DataSource = dtZsm;
            ddlempname.DataTextField = "ZSM NAME";
            ddlempname.DataValueField = "ZSM NAME";
            ddlempname.DataBind();
            ddlempname.Items.Insert(0, new ListItem("All ZSM", ""));
            ddlempname.SelectedIndex = 0;

            // Reset parameters for next query
            parameters.Clear();

            // Load Stockist Names
            string stockistQuery = string.Format(baseQuery.ToString(), "[SALES_ACC_NAME]");
            SqlDataAdapter daStockist = new SqlDataAdapter(stockistQuery, con);
            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
            {
                daStockist.SelectCommand.Parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
            }
            DataTable dtStockist = new DataTable();
            daStockist.Fill(dtStockist);
            ddlStockist.DataSource = dtStockist;
            ddlStockist.DataTextField = "SALES_ACC_NAME";
            ddlStockist.DataValueField = "SALES_ACC_NAME";
            ddlStockist.DataBind();
            ddlStockist.Items.Insert(0, new ListItem("All Stockists", ""));
            ddlStockist.SelectedIndex = 0;

            // Similar updates for Product, Status, and Tag dropdowns...
            // [Rest of your existing LoadAllDropdowns code with division filter applied]
            // Load Product Names
            string ProductQuery = string.Format(baseQuery.ToString(), "[SALES_PROD_NAME]");
            SqlDataAdapter daproduct = new SqlDataAdapter(ProductQuery, con);
            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
            {
                daproduct.SelectCommand.Parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
            }
            DataTable dtProduct = new DataTable();
            daproduct.Fill(dtProduct);
            ddlProduct.DataSource = dtProduct;
            ddlProduct.DataTextField = "SALES_PROD_NAME";
            ddlProduct.DataValueField = "SALES_PROD_NAME";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("All Products", ""));
            ddlProduct.SelectedIndex = 0;

            // Load Tag 
            string TagQuery = string.Format(baseQuery.ToString(), "[Tag]");
            SqlDataAdapter daTag = new SqlDataAdapter(TagQuery, con);
            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
            {
                daTag.SelectCommand.Parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));
            }
            DataTable dtTag = new DataTable();
            daTag.Fill(dtTag);
            ddlTag.DataSource = dtTag;
            ddlTag.DataTextField = "Tag";
            ddlTag.DataValueField = "Tag";
            ddlTag.DataBind();
            ddlTag.Items.Insert(0, new ListItem("All Products", ""));
            ddlTag.SelectedIndex = 0;
        }
    }

    public void BindGridWithFilters()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();

        // Check if division is selected
        if (string.IsNullOrEmpty(ddlDivision.SelectedValue))
        {
            // No division selected - show empty grid
            Grdemp.DataSource = null;
            Grdemp.DataBind();
            Lblrows.Text = "Rows : 0";
            Lblwh.Text = "Please select a division";
            return; // Exit early
        }

        StringBuilder StrQrry = new StringBuilder();
        List<SqlParameter> parameters = new List<SqlParameter>();

        string view = Session["View"] != null ? Session["View"].ToString() : "";

        StrQrry.Append(@"
WITH Consolidated AS (
    SELECT 
        [SALES_ProdID], [SALES_GCV_ACC_CODE],
        MAX(Unblock) AS Unblock,
        MAX(Liquidation) AS Liquidation,
        MAX(ReasonUnblock) AS ReasonUnblock,
        MAX(Approved) AS Approved,
        MAX(Submit_Time) AS Submit_Time,
        MAX(Approved_Time) AS Approved_Time
    FROM [dbo].[Templateconsolidate]
    GROUP BY [SALES_ProdID], [SALES_GCV_ACC_CODE]
)
SELECT 
    A.[SALES_DIVISION], A.[ZSM CODE], A.[ZSM NAME],
    A.[Territory Code], A.[Territory Name],
    A.[SALES_GCV_ACC_CODE], A.[SALES_ACC_NAME],
    A.[SALES_ProdID], A.[SALES_PROD_NAME],
    ROUND(A.[SALES_2023-06], 0) AS [SALES_2023-09],
    ROUND(A.[SALES_2023-07], 0) AS [SALES_2023-10],
    ROUND(A.[SALES_2023-08], 0) AS [SALES_2023-11],
    ROUND(A.[AVG_SEC_AUG23], 0) AS [AVG_SEC_NOV23],
    ROUND(A.[CLO_2023_08], 0) AS [CLO_2023_11],
    ROUND(A.[CLO_Unit_08], 0) AS [CLO_Unit_11],
     A.[INVENTORY_DAYS] AS [Inventory Days], A.[Tag] AS [Additional Info],
    COALESCE(b.Unblock, 'Blocked') AS [Unblock],
    COALESCE(b.Liquidation, '-') AS [Liquidation],
    COALESCE(b.ReasonUnblock, '-') AS [ReasonUnblock],
    COALESCE(b.Approved, '-') AS [Approved],
    b.[Submit_Time],
    b.[Approved_Time]
FROM [dbo].[TemplateData] A
LEFT JOIN Consolidated b 
    ON A.[SALES_ProdID] = b.[SALES_ProdID]
   AND A.[SALES_GCV_ACC_CODE] = b.[SALES_GCV_ACC_CODE]
WHERE A.[SALES_DIVISION] = @Division
  AND b.SALES_ProdID IS NULL   
");


        // Add division parameter (required)
        parameters.Add(new SqlParameter("@Division", ddlDivision.SelectedValue));

        // Apply other filters
        string filterCondition = BuildFilterConditionWithParameters(parameters);
        StrQrry.Append(filterCondition);

        StrQrry.Append(" ORDER BY A.[Territory Code], A.[SALES_GCV_ACC_CODE], A.[SALES_ProdID]");

        string connString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand(StrQrry.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataAdapter adpRpt = new SqlDataAdapter(cmd))
                {
                    adpRpt.Fill(DsStockist, "DsStockist");
                    adpRpt.Fill(dtDsStockist);
                }
            }
        }

        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            ViewState["GridData"] = dtDsStockist;
            Grdemp.DataBind();
            Grdemp.Columns[0].Visible = false;
            Grdemp.Columns[1].Visible = false;
            Grdemp.Columns[3].Visible = false;
            Grdemp.Columns[5].Visible = false;
            Grdemp.Columns[7].Visible = false;
        }
        else
        {
            Grdemp.DataSource = null;
            Grdemp.DataBind();
            Lblwh.Text = "Please select a division";
        }

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        string counnt = dtDsStockist.Rows.Count.ToString();
        Lblrows.Text = "Rows : " + counnt;
        Grdrprt.Visible = false;
        Grdemp.Visible = true;
        btnsubmit.Visible = false;
        Lblnote.Visible = false;
        Button1.Visible = true;
        Button2.Visible = false;
        Button3.Visible = false;
        
    }

    private string BuildFilterConditionWithParameters(List<SqlParameter> parameters)
    {
        StringBuilder whereClause = new StringBuilder();

        if (!string.IsNullOrEmpty(ddlempname.SelectedValue))
        {
            whereClause.Append(" AND A.[ZSM NAME] = @ZSMName");
            parameters.Add(new SqlParameter("@ZSMName", ddlempname.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlStockist.SelectedValue))
        {
            whereClause.Append(" AND A.[SALES_ACC_NAME] = @StockistName");
            parameters.Add(new SqlParameter("@StockistName", ddlStockist.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
        {
            whereClause.Append(" AND A.[SALES_PROD_NAME] = @ProductName");
            parameters.Add(new SqlParameter("@ProductName", ddlProduct.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
        {
            whereClause.Append(" AND B.[Approved] = @Approved");
            parameters.Add(new SqlParameter("@Approved", ddlStatus.SelectedValue));
        }

        if (!string.IsNullOrEmpty(ddlTag.SelectedValue))
        {
            whereClause.Append(" AND A.[Tag] = @Tag");
            parameters.Add(new SqlParameter("@Tag", ddlTag.SelectedValue));
        }

        return whereClause.ToString();
    }

    private string BuildFilterCondition()
    {
        StringBuilder whereClause = new StringBuilder();

        if (!string.IsNullOrEmpty(ddlempname.SelectedValue))
        {
            whereClause.Append(" AND A.[ZSM NAME] = '" + ddlempname.SelectedValue + "'");
        }

        if (!string.IsNullOrEmpty(ddlStockist.SelectedValue))
        {
            whereClause.Append(" AND A.[SALES_ACC_NAME] = '" + ddlStockist.SelectedValue + "'");
        }

        if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
        {
            whereClause.Append(" AND A.[SALES_PROD_NAME] = '" + ddlProduct.SelectedValue + "'");
        }

        if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
        {
            if (ddlStatus.SelectedValue == "Blocked")
            {
                whereClause.Append(" AND (b.Unblock IS NULL OR b.Unblock = 'Blocked')");
            }
            else
            {
                whereClause.Append(" AND b.Unblock = '" + ddlStatus.SelectedValue + "'");
            }
        }

        if (!string.IsNullOrEmpty(ddlTag.SelectedValue))
        {
            whereClause.Append(" AND A.[Tag] = '" + ddlTag.SelectedValue + "'");
        }

        return whereClause.ToString();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        // Reset all dropdowns to "All" options
        ddlDivision.SelectedIndex = 0;
        ddlempname.SelectedIndex = 0;
        ddlStockist.SelectedIndex = 0;
        ddlProduct.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        ddlTag.SelectedIndex = 0;
        //Button1.Visible = false;
        // Reset session values
        Session["SelectedDivision"] = null;
        Session["ddlemp"] = null;

        // Reload dropdowns with all data
        LoadDivisionDropdown();
        LoadAllDropdowns();

        // Bind grid with no filters (show all data)
        BindGridWithFilters();

        // Reset label text
        Lblwh.Text = "Please select a division";
        Button3.Visible = false;
    }
    protected void Grdemp_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = ViewState["GridData"] as DataTable;

        if (dt != null)
        {
            string sortDirection = "ASC";

            // Toggle sorting direction
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                sortDirection = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }

            ViewState["SortExpression"] = e.SortExpression;
            ViewState["SortDirection"] = sortDirection;

            dt.DefaultView.Sort = e.SortExpression + " " + sortDirection;
            Grdemp.DataSource = dt;
            Grdemp.DataBind();
        }
    }
}