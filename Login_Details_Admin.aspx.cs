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

public partial class Login_Details_Admin : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Banner.ShowShort();
        if (!IsPostBack)
        {

            
            BindGrid();
            binddropdown1();
            //  BindGrid2();
            ViewState["SortDirection"] = "ASC";
            //Button5.Visible = true;
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
                Button3.CssClass += " active";
                break;
            case "Contactus.aspx":
                Button4.CssClass += " active";
                break;
            //case "Approval_BH.aspx":
            //    Button5.CssClass += " active";
            //    break;
        }
    }
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

        StrQrry = "SELECT [DIVISION] , [NOTIFICATION], max([Time]) as Time from [dbo].[Notification$] where (([NOTIFICATION] like '%There%' or [NOTIFICATION] like '%Submitted%' or [NOTIFICATION] like '%awaiting%' or [NOTIFICATION] like '%Approved By Division%' or [NOTIFICATION] like '%Rejected By Division%' or [NOTIFICATION] like '%Rejected By Admin%') and  BH_Code='" + HiddenfldBH_Code.Value.ToString() + "') or [ZSM CODE] = '" + Hidnfldcode.Value.ToString() + "' group by [DIVISION] , [NOTIFICATION]  ORDER BY [Time] DESC;";
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
    public void BindGrid()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";



        StrQrry = @"SELECT 
    li.[ZSM_Code],
    li.[Name],
    li.[Password],
    li.[Division],
    MAX(lr.[Logged in]) AS [LatestLoginString],
    MAX(TRY_CONVERT(datetime, lr.[Logged in], 106)) AS [LatestLogin]
FROM [dbo].[loginID$] li
LEFT JOIN [dbo].[Loginrecord$] lr
    ON li.[Emp_code] = lr.[Emp_code]
GROUP BY 
    li.[ZSM_Code], li.[Name], li.[Password], li.[Division]
ORDER BY MAX(TRY_CONVERT(datetime, lr.[Logged in], 106)) DESC;";
       
        
        //Hidnfldiv.Value.ToString()
        Lblwh.Text = "Login Details " + Hidnfldiv.Value.ToString();

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            ViewState["GridData"] = dtDsStockist;
            Grdemp.DataBind();
            
        }
        string Zsmmcode = dtDsStockist.Rows[1][1].ToString();
        Session["Zsmmcode"] = Zsmmcode;

        string divisionname = dtDsStockist.Rows[1][0].ToString();
        Session["divisionname"] = divisionname;

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        //   Lbldetail.Text = "Employee Code : " + Zsmmcode + "<br />" + "Division : " + divisionname + "";
        string counnt = dtDsStockist.Rows.Count.ToString();
        Lblrows.Text = "Rows : " + counnt;
      
        Grdemp.Visible = true;
        //  btnreview.Visible = true;
       
        Button2.Visible = false;
       

    }
    //protected void ddlmaster_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlval = string.Empty;
    //    ddlval = ddlmasters.SelectedValue.ToString();
    //    Session["ddlses"] = ddlval;
    //    Lblwh.Text = ddlmasters.SelectedItem.ToString();
    //    BindGrid2();
    //}
   
    protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlemp = string.Empty;
        ddlemp = ddlempname.SelectedValue.ToString();
        Session["ddlemp"] = ddlemp;
        Lblwh.Text = ddlempname.SelectedItem.ToString();
        BindGrid2();
        
    }
    
    protected void btnapp(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        
            Response.Redirect("Summary.aspx");
        
    }
   
    protected void btnoutclick(object sender, EventArgs e)
    {
        DateTime logout = DateTime.Now;
        SqlCommand cmdd = new SqlCommand("Logoutrecord_ps", conn);
        cmdd.CommandType = CommandType.StoredProcedure;
        cmdd.Parameters.AddWithValue("@logout", logout.ToString("MMM dd yyyy hh:mm tt"));
        cmdd.Parameters.AddWithValue("@ZSM_CODE", Hidnfldcode.ToString());
        cmdd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
        conn.Open();
        //cmd.ExecuteNonQuery();
        string strRsslt = cmdd.ExecuteNonQuery().ToString();
        conn.Close();
        Response.Redirect("LoginPage.aspx");
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
        StrQrry = " Select Distinct [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME],Round([SALES_2023-06], 0) as [SALES_2025-06],Round([SALES_2023-07], 0) as [SALES_2025-07], Round([SALES_2023-08], 0) as [SALES_2025-08],Round([AVG_SEC_AUG23], 0) as [AVG_SEC_AUG25],Round([CLO_2023_08], 0)  as [CLO_2025_08], Round([CLO_Unit_08], 0) as [CLO_Unit_202508],[Brands],[Tag] FROM [dbo].[TemplateData] where BH_Code='" + HiddenfldBH_Code.Value.ToString() + "' and [ZSM NAME] = '" + Session["ddlemp"] + "';";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Blocking Report of " + Session["ddlemp"] + "_" + DateTime.Now + ".xls";
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

    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void btnloginDetails(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
       // Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Login_Details_Admin.aspx");
    }
    protected void btncontac(object sender, EventArgs e)
    {
       // Hidnfldname.Value = Session["zsmname"].ToString();
       // Hidnfldcode.Value = Session["zcode"].ToString();
       // Hidnfldiv.Value = Session["divi"].ToString();
       // Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Contactus.aspx");
    }
    
    protected void btncancelerror_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("View_DH.aspx");
    }
    public void binddropdown1()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = @"SELECT 
    distinct
    li.[Name]
FROM [dbo].[loginID$] li
LEFT JOIN [dbo].[Loginrecord$] lr
    ON li.[Emp_code] = lr.[Emp_code]";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            ddlempname.DataSource = dtDsStockist;
            ddlempname.DataTextField = "Name";
            ddlempname.DataBind();
            ddlempname.Items.Insert(0, "Select");
            //ddlempname.SelectedIndex = 0;
        }

    }

    public void BindGrid2()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        if (ddlempname.SelectedIndex > 0)
        {

            StrQrry = @"SELECT 
    li.[ZSM_Code],
    li.[Name],
    li.[Password],
    li.[Division],
    MAX(lr.[Logged in]) AS [LatestLoginString],
    MAX(TRY_CONVERT(datetime, lr.[Logged in], 106)) AS [LatestLogin]
FROM [dbo].[loginID$] li
LEFT JOIN [dbo].[Loginrecord$] lr
    ON li.[Emp_code] = lr.[Emp_code] where li.[Name]='" + ddlempname.SelectedValue + @"'
GROUP BY 
    li.[ZSM_Code], li.[Name], li.[Password], li.[Division]
ORDER BY MAX(TRY_CONVERT(datetime, lr.[Logged in], 106))  ;";
        }
        else
        {
            StrQrry = @"SELECT 
    li.[ZSM_Code],
    li.[Name],
    li.[Password],
    li.[Division],
    MAX(lr.[Logged in]) AS [LatestLoginString],
    MAX(TRY_CONVERT(datetime, lr.[Logged in], 106)) AS [LatestLogin]
FROM [dbo].[loginID$] li
LEFT JOIN [dbo].[Loginrecord$] lr
    ON li.[Emp_code] = lr.[Emp_code]
GROUP BY 
    li.[ZSM_Code], li.[Name], li.[Password], li.[Division]
ORDER BY MAX(TRY_CONVERT(datetime, lr.[Logged in], 106)) DESC";
        }
            Lblwh.Text = "Login Details " + Hidnfldiv.Value.ToString() + "";  
       
        

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdemp.DataSource = dtDsStockist;
            ViewState["GridData"] = dtDsStockist;
            Grdemp.DataBind();
           
        }
        // string Zsmmcode = dtDsStockist.Rows[1][1].ToString();
        //  Session["Zsmmcode"] = Zsmmcode;

        //   string divisionname = dtDsStockist.Rows[1][0].ToString();
        //   Session["divisionname"] = divisionname;

        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        //   Lbldetail.Text = "Employee Code : " + Zsmmcode + "<br />" + "Division : " + divisionname + "";
        string counnt = dtDsStockist.Rows.Count.ToString();
        Lblrows.Text = "Rows : " + counnt;
        
        Grdemp.Visible = true;
        //  btnreview.Visible = true;
        
        Button2.Visible = true;

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
    protected void btnApprovalDetails(object sender, EventArgs e)
    {
        
        Response.Redirect("Approval_BH.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
    private void ExportGridToExcel()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = @"SELECT 
    li.[ZSM_Code],
    li.[Name],
    li.[Password],
    li.[Division],
    MAX(lr.[Logged in]) AS [LatestLoginString],
    MAX(TRY_CONVERT(datetime, lr.[Logged in], 106)) AS [LatestLogin]
FROM [dbo].[loginID$] li
LEFT JOIN [dbo].[Loginrecord$] lr
    ON li.[Emp_code] = lr.[Emp_code]
GROUP BY 
    li.[ZSM_Code], li.[Name], li.[Password], li.[Division]
ORDER BY MAX(TRY_CONVERT(datetime, lr.[Logged in], 106)) DESC;";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);

        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";

        // Fix: Remove invalid characters from filename
        string FileName = "Blocking Report of " + Session["divi"] + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "inline; filename=" + FileName);

        DataGrid dg = new DataGrid();
        dg.DataSource = dtDsStockist;
        dg.DataBind();

        // FIX: Remove the specific cell formatting for indices 9-14 since you only have 5 columns
        foreach (DataGridItem item in dg.Items)
        {
            for (int j = 0; j < item.Cells.Count; j++)
            {
                item.Cells[j].Attributes.Add("style", "mso-number-format:\\@");
            }
            
        }

        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
    }
    protected void btntemp(object sender, EventArgs e)
    {
        //Hidnfldname.Value = Session["zsmname"].ToString();
        //Hidnfldcode.Value = Session["zcode"].ToString();
        //Hidnfldiv.Value = Session["divi"].ToString();
        //Hidnfldlogin.Value = Session["login"].ToString();
        Response.Redirect("Templatesadmin.aspx");
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
}