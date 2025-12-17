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
using ClosedXML.Excel;

public partial class Fixitreports : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
		if (Session["zsmname"] == null || Session["zcode"] == null ||
                Session["divi"] == null || Session["login"] == null) // or any key you use
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sessionExpired",
                    "alert('Your session has expired. Please login again.'); window.location='Loginpage.aspx';", true);
            }
        if (!IsPostBack)
        {
            Hidnfldname.Value = Session["zsmname"].ToString();
            Hidnfldcode.Value = Session["zcode"].ToString();
            Hidnfldiv.Value = Session["divi"].ToString();
            Hidnfldlogin.Value = Session["login"].ToString();
            HiddenfldBH_Code.Value = Session["BH_Code"].ToString();
            BindGrid2();
            binddropdown1();
            binddropdown2();
            binddropdownbr();
            binddropdowntag();
            Button1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
        }
        string current = System.IO.Path.GetFileName(Request.Path);

        switch (current)
        {
            case "Templatesadmin.aspx":
                btnnav2.CssClass += " active";
                break;
            case "Summary.aspx":
                btnsm.CssClass += " active";
                break;
            case "Login_Details_Admin.aspx":
                Button7.CssClass += " active";
                break;
            //case "Approval_BH.aspx":
            //    Button8.CssClass += " active";
            //    break;
            case "Contactus.aspx":
                btnconta.CssClass += " active";
                break;
            case "NotificationAdmin.aspx":
                Button4.CssClass += " active";
                break;
        }
    }

    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["zsmname"] = Hidnfldname.Value.ToString();
        Session["zcode"] = Hidnfldcode.Value.ToString();
        Session["divi"] = Hidnfldiv.Value.ToString();
        Session["login"] = Hidnfldlogin.Value.ToString();
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
    public void binddropdown1()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct [ZSM NAME] from [dbo].[Templateconsolidate] where Approved = 'Approved' ;";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            ddlempname.DataSource = dtDsStockist;
            ddlempname.DataTextField = "ZSM NAME";
            ddlempname.DataBind();
            ddlempname.Items.Insert(0, "Select");
            //ddlempname.SelectedIndex = 0;
        }

    }
    protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlemp = string.Empty;
        ddlemp = ddlempname.SelectedValue.ToString();
        Session["ddlemp"] = ddlemp;
        Lblwh.Text = ddlempname.SelectedItem.ToString();
        BindGrid3();
    }
    public void binddropdownbr()
    {
        DataSet DsStockist222 = new DataSet();
        DataTable dtDsStockist222 = new DataTable();
        string StrQrry222 = "";
        StrQrry222 = "Select distinct Brands from [dbo].[Templateconsolidate] where Approved = 'Approved';";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt222 = new SqlDataAdapter(StrQrry222, conn);
        adpRpt222.Fill(DsStockist222, "DsStockist222");
        adpRpt222.Fill(dtDsStockist222);
        if (DsStockist222.Tables[0].Rows.Count > 0)
        {
            ddlbrand.DataSource = dtDsStockist222;
            ddlbrand.DataTextField = "Brands";
            ddlbrand.DataBind();
            ddlbrand.Items.Insert(0, "Select");
            //ddlempname.SelectedIndex = 0;
        }

    }
    public void binddropdowntag()
    {
        DataSet DsStockist222 = new DataSet();
        DataTable dtDsStockist222 = new DataTable();
        string StrQrry222 = "";
        StrQrry222 = "Select distinct Tag from [dbo].[Templateconsolidate] where Approved = 'Approved';";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt222 = new SqlDataAdapter(StrQrry222, conn);
        adpRpt222.Fill(DsStockist222, "DsStockist222");
        adpRpt222.Fill(dtDsStockist222);
        if (DsStockist222.Tables[0].Rows.Count > 0)
        {
            ddltag.DataSource = dtDsStockist222;
            ddltag.DataTextField = "Tag";
            ddltag.DataBind();
            ddltag.Items.Insert(0, "Select");
            //ddlempname.SelectedIndex = 0;
        }

    }
    protected void ddltag_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddltags = string.Empty;
        ddltags = ddltag.SelectedValue.ToString();
        Session["tag"] = ddltags;
        Lblwh.Text = ddltag.SelectedItem.ToString();
        BindGridtag();
        // lblnow.Visible = false;
        Grdreport.Visible = true;
    }
    protected void ddlbrnd_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlbrnd = string.Empty;
        ddlbrnd = ddlbrand.SelectedValue.ToString();
        Session["brnd"] = ddlbrnd;
        Lblwh.Text = ddlbrand.SelectedItem.ToString();
        BindGridbr();
       // lblnow.Visible = false;
        Grdreport.Visible = true;
    }
    public void BindGridtag()
    {
        
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct * from [dbo].[Templateconsolidate] where Approved = 'Approved' and [Tag] = '" + Session["tag"] + "';";
        Lblwh.Text = "Unblock List Report of " + Session["tag"];
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdreport.DataSource = dtDsStockist;
            Grdreport.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            Grdreport.DataSource = dtDsStockist;
            Grdreport.DataBind();
            Grdreport.Rows[0].Visible = false;
        }
        Button1.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
        Button5.Visible = false;
        Button6.Visible = true;

    }
    public void BindGridbr()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "Select distinct * from [dbo].[Templateconsolidate] where Approved = 'Approved' and [Brands] = '" + Session["brnd"] + "';";
        Lblwh.Text = "Unblock List Report of "  + Session["brnd"] ;
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);


        if (DsStockist.Tables[0].Rows.Count > 0)
        {
            Grdreport.DataSource = dtDsStockist;
            Grdreport.DataBind();
        }
        else
        {
            dtDsStockist.Rows.Add(dtDsStockist.NewRow());
            Grdreport.DataSource = dtDsStockist;
            Grdreport.DataBind();
            Grdreport.Rows[0].Visible = false;
        }
        Button1.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
        Button5.Visible = true;
        Button6.Visible = false;
    }
    public void BindGrid3()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "Select distinct top (100) * from[dbo].[Templateconsolidate] where Approved = 'Approved' and SALES_DIVISION = '" + Session["ddldiv"] + "' and [ZSM NAME] = '" + Session["ddlemp"] + "';";
        Lblwh.Text = "Unblock List Report of  "+ Session["ddlemp"] ;
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrryy, conn);
        adpRpt.Fill(DsStockistt, "DsStockistt");
        adpRpt.Fill(dtDsStockistt);


        if (DsStockistt.Tables[0].Rows.Count > 0)
        {
            Grdreport.DataSource = dtDsStockistt;
            Grdreport.DataBind();
        }
        else
        {
            dtDsStockistt.Rows.Add(dtDsStockistt.NewRow());
            Grdreport.DataSource = dtDsStockistt;
            Grdreport.DataBind();
            Grdreport.Rows[0].Visible = false;
        } 
        Button1.Visible = false;
        Button2.Visible = false;
        Button3.Visible = true;
        Button5.Visible = false;
        Button6.Visible = false;
        // Lblnote.Visible = false;
    }
    protected void ddldiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddldiv = string.Empty;
        ddldiv = ddldivname.SelectedValue.ToString();
        Session["ddldiv"] = ddldiv;
        Lblwh.Text = ddldivname.SelectedItem.ToString();
        binddropdown1();
        BindGrid1();
    }
    public void BindGrid1()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "Select distinct top (100) * from[dbo].[Templateconsolidate] where Approved = 'Approved' and SALES_DIVISION = '" + Session["ddldiv"] + "';";
        Lblwh.Text = "Unblock List Report of " + Session["ddldiv"];
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrryy, conn);
        adpRpt.Fill(DsStockistt, "DsStockistt");
        adpRpt.Fill(dtDsStockistt);


        if (DsStockistt.Tables[0].Rows.Count > 0)
        {
            Grdreport.DataSource = dtDsStockistt;
            Grdreport.DataBind();
        }
        else
        {
            dtDsStockistt.Rows.Add(dtDsStockistt.NewRow());
            Grdreport.DataSource = dtDsStockistt;
            Grdreport.DataBind();
            Grdreport.Rows[0].Visible = false;
        }
        Button1.Visible = false;
        Button2.Visible = true;
        Button3.Visible = false;
        Button5.Visible = false;
        Button6.Visible = false;
        // Lblnote.Visible = false;
    }
    public void binddropdown2()
    {
        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "Select distinct [SALES_DIVISION] from [dbo].[Templateconsolidate] where Approved = 'Approved';";

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRptt = new SqlDataAdapter(StrQrryy, conn);
        adpRptt.Fill(DsStockistt, "DsStockistt");
        adpRptt.Fill(dtDsStockistt);
        if (DsStockistt.Tables[0].Rows.Count > 0)
        {
            ddldivname.DataSource = dtDsStockistt;
            ddldivname.DataTextField = "SALES_DIVISION";
            ddldivname.DataBind();
            ddldivname.Items.Insert(0, "Select");
            //ddldivname.SelectedIndex = 0;
        }
    }
    protected void changed(object sender, EventArgs e)
    {
        CheckBox chckstatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chckstatus.NamingContainer;
    }
    //protected void ddlmaster_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlval = string.Empty;
    //    ddlval = ddlmasters.SelectedValue.ToString();
    //    Session["ddlses"] = ddlval;
    //    Response.Redirect("Fixitmasters.aspx");
    //}
    //protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string ddlvalrep = string.Empty;
    //    ddlvalrep = ddlreports.SelectedValue.ToString();
    //    Session["ddlsesrep"] = ddlvalrep;
    //    Response.Redirect("Fixitreports.aspx");
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
    private void ExportGridToExcel()
    {
        DataTable dtDsStockist = new DataTable();
        string StrQrry = @"
        SELECT DISTINCT 
            L.[LocationName] AS [LocationName], 
            A.[SALES_GCV_ACC_CODE] AS [CustomerCode], 
            A.[SALES_ACC_NAME] AS [CustomerName], 
            A.[SALES_ProdID] AS [ProductCode], 
            A.[SALES_PROD_NAME] AS [ProductName], 
            'Unblock' AS [Action]
        FROM [Fixit14].[dbo].[Templateconsolidate] A 
        JOIN [Fixit14].[dbo].[Location$] L 
        ON A.[SALES_GCV_ACC_CODE] = L.[Stockist_Code]
        WHERE [Approved] = 'Approved'
    ";

        SqlDataAdapter da = new SqlDataAdapter(StrQrry, ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
        da.Fill(dtDsStockist);

        using (var wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add("Unblocking Report");

            // Insert entire DataTable FAST
            var table = ws.Cell(1, 1).InsertTable(dtDsStockist);
            table.Theme = XLTableTheme.None;   // *** FIX HEADER FONT COLOR ***

            // Style header (row 1)
            var header = ws.Range(1, 1, 1, dtDsStockist.Columns.Count);
            header.Style.Font.Bold = true;
            header.Style.Font.FontColor = XLColor.Black;   // Now this works!
            header.Style.Fill.BackgroundColor = XLColor.LightGray;
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Style entire used range
            var usedRange = ws.RangeUsed();

            usedRange.Style.Font.FontColor = XLColor.Black;

            usedRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            usedRange.Style.Border.InsideBorderColor = XLColor.Black;

            usedRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            usedRange.Style.Border.OutsideBorderColor = XLColor.Black;

            ws.Columns().AdjustToContents(1, 30);

            ExportWorkbook(wb, "Unblocking Report.xlsx");
        }
    }



    public static void ExportWorkbook(XLWorkbook wb, string fileName)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            wb.SaveAs(ms);
            ms.Position = 0;

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType =
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            HttpContext.Current.Response.AddHeader(
                "content-disposition", "attachment; filename=" + fileName);

            ms.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
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
        StrQrry = "    Select Distinct [SALES_DIVISION], MAX([ZSM CODE])[ZSM CODE],MAX([ZSM NAME])[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,MAX([SALES_2023-05]) as[SALES_2025-08],MAX([SALES_2023-06])as [SALES_2025-09],max([SALES_2023-07])as [SALES_2025-10], MAX([CLO_2023_07]) as [CLO_2025_10],MAX([CLO_Unit_07]) as [CLO_Unit_202510],MAX([AVG_SEC_JUL23]) as [AVG_SEC_OCT25], [Brands],[Tag],[Unblock] ,MAX([Liquidation])[Liquidation] ,MAX([ReasonUnblock])[ReasonUnblock],[Approved] from dbo.[Templateconsolidate]  where Approved = 'Approved'  and [BH_Code] = '" + HiddenfldBH_Code.Value.ToString() + "' group by [SALES_DIVISION],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,[Brands],[Tag],[Unblock],[Approved] ;";
        //// StrQrry = " Select Distinct [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,[SALES_2023-05] as[SALES_2023-08],[SALES_2023-06]as [SALES_2023-09],[SALES_2023-07]as [SALES_2023-11], [CLO_2023_07]as [CLO_2023_10],[CLO_Unit_07] as [CLO_Unit_10],[AVG_SEC_JUL23] as [AVG_SEC_OCT23], [Brands],[Tag],[Unblock] ,[Liquidation] ,[ReasonUnblock],[Approved] from dbo.[Templateconsolidate]  where Approved = 'Approved' and SALES_DIVISION = '" + Session["ddldiv"] + "';"; 
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Unblocking Report of " + Session["ddldiv"] + "_" + DateTime.Now + ".xls";
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
            }
        }

        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
        //Grdreport.GridLines = GridLines.Both;
        //Grdreport.HeaderStyle.Font.Bold = true;
        //Grdreport.RenderControl(htmltextwrtter);
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
        StrQrry = "   Select Distinct [SALES_DIVISION], MAX([ZSM CODE])[ZSM CODE],MAX([ZSM NAME])[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,MAX([SALES_2023-05]) as[SALES_2025-08],MAX([SALES_2023-06])as [SALES_2025-09],max([SALES_2023-07])as [SALES_2025-08], MAX([CLO_2023_07]) as [CLO_2025_10],MAX([CLO_Unit_07]) as [CLO_Unit_202510],MAX([AVG_SEC_JUL23]) as [AVG_SEC_OCT25], [Brands],[Tag],[Unblock] ,MAX([Liquidation])[Liquidation] ,MAX([ReasonUnblock])[ReasonUnblock],[Approved] from dbo.[Templateconsolidate]  where Approved = 'Approved'  and [BH_Code] = '" + HiddenfldBH_Code.Value.ToString() + "' and [ZSM NAME] = '" + Session["ddlemp"] + "' group by [SALES_DIVISION],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,[Brands],[Tag],[Unblock],[Approved] ;";
        //     StrQrry = " Select Distinct [SALES_DIVISION], [ZSM CODE],[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,[SALES_2023-05] as[SALES_2023-08],[SALES_2023-0]as [SALES_2023-09],[SALES_2023-07]as [SALES_2023-11], [CLO_2023_07]as [CLO_2023_10],[CLO_Unit_07] as [CLO_Unit_10],[AVG_SEC_JUL23] as [AVG_SEC_OCT23], [Brands],[Tag],[Unblock] ,[Liquidation] ,[ReasonUnblock],[Approved] from dbo.[Templateconsolidate]  where Approved = 'Approved' and SALES_DIVISION = '" + Session["ddldiv"] + "' and [ZSM NAME] = '" + Session["ddlemp"] + "';";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Unblocking Report of " + Session["ddlemp"] +"_" +DateTime.Now + ".xls";
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
            }
        }

        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
        //Grdreport.GridLines = GridLines.Both;
        //Grdreport.HeaderStyle.Font.Bold = true;
        //Grdreport.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        ExportGridToExcel5();
    }
    private void ExportGridToExcel5()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "  Select Distinct [SALES_DIVISION], MAX([ZSM CODE])[ZSM CODE],MAX([ZSM NAME])[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,MAX([SALES_2023-05]) as[SALES_2025-08],MAX([SALES_2023-06])as [SALES_2025-09],max([SALES_2023-07])as [SALES_2025-10], MAX([CLO_2023_07]) as [CLO_2025_10],MAX([CLO_Unit_07]) as [CLO_Unit_202510],MAX([AVG_SEC_JUL23]) as [AVG_SEC_SEP24], [Brands],[Tag],[Unblock] ,MAX([Liquidation])[Liquidation] ,MAX([ReasonUnblock])[ReasonUnblock],[Approved] from dbo.[Templateconsolidate]  where Approved = 'Approved' and Brands = '" + Session["brnd"] + "' group by [SALES_DIVISION],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,[Brands],[Tag],[Unblock],[Approved];";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Unblocking Report of " + Session["brnd"] + "_" + DateTime.Now + ".xls";
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
            }
        }

        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
        //Grdreport.GridLines = GridLines.Both;
        //Grdreport.HeaderStyle.Font.Bold = true;
        //Grdreport.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        ExportGridToExcel6();
    }
    private void ExportGridToExcel6()
    {
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        StrQrry = "  Select Distinct [SALES_DIVISION], MAX([ZSM CODE])[ZSM CODE],MAX([ZSM NAME])[ZSM NAME],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,MAX([SALES_2023-05]) as[SALES_2025-08],MAX([SALES_2023-06])as [SALES_2025-09],max([SALES_2023-07])as [SALES_2025-10], MAX([CLO_2023_07]) as [CLO_2025_10],MAX([CLO_Unit_07]) as [CLO_Unit_202510],MAX([AVG_SEC_JUL23]) as [AVG_SEC_OCT25], [Brands],[Tag],[Unblock] ,MAX([Liquidation])[Liquidation] ,MAX([ReasonUnblock])[ReasonUnblock],[Approved] from dbo.[Templateconsolidate]  where Approved = 'Approved' and Tag = '" + Session["tag"] + "' group by [SALES_DIVISION],[Territory Code],[Territory Name] ,[SALES_GCV_ACC_CODE],[SALES_ACC_NAME] ,[SALES_ProdID], [SALES_PROD_NAME] ,[Brands],[Tag],[Unblock],[Approved];";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Unblocking Report of " + Session["tag"] + "_" + DateTime.Now + ".xls";
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
            }
        }

        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();
        //Grdreport.GridLines = GridLines.Both;
        //Grdreport.HeaderStyle.Font.Bold = true;
        //Grdreport.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void btnnotific(object sender, EventArgs e)
    {
        
        Response.Redirect("NotificationAdmin.aspx");
    }
    protected void btncontac(object sender, EventArgs e)
    {
        
        Response.Redirect("Contactus.aspx");
    }
    protected void btntemp(object sender, EventArgs e)
    {
       
        Response.Redirect("Templatesadmin.aspx");
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
    //protected void btntemp(object sender, EventArgs e)
    //{
    //    Response.Redirect("Templatesadmin.aspx");
    //}
    //protected void btnsettng(object sender, EventArgs e)
    //{
    //    //  Response.Redirect("settings.aspx");
    //}
    protected void btnsumm(object sender, EventArgs e)
    {
        
     Response.Redirect("Summary.aspx");
    }
    public void BindGrid2()
    {

        DataSet DsStockistt = new DataSet();
        DataTable dtDsStockistt = new DataTable();
        string StrQrryy = "";
        StrQrryy = "Select distinct * from [dbo].[Templateconsolidate] where Approved = 'Approved';";
        Lblwh.Text = "Unblock List Report";
        // Lblcount.Text = " Unblocked " + Session["count"] + " from " + Session["countrows"] +" ";
        Lblwelcm.Text = " Welcome " + Hidnfldname.Value.ToString() + "!";
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrryy, conn);
        adpRpt.Fill(DsStockistt, "DsStockistt");
        adpRpt.Fill(dtDsStockistt);


        if (DsStockistt.Tables[0].Rows.Count > 0)
        {
            Grdreport.DataSource = dtDsStockistt;
            Grdreport.DataBind();
        }
        else
        {
            dtDsStockistt.Rows.Add(dtDsStockistt.NewRow());
            Grdreport.DataSource = dtDsStockistt;
            Grdreport.DataBind();
            Grdreport.Rows[0].Visible = false;
        }
        // Lblnote.Visible = false;
        Button1.Visible = true;
        Button2.Visible = false;
        Button3.Visible = false;
        Button3.Visible = false;
        Button5.Visible = false;
        Button6.Visible = false;
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
    protected void Grdreport_Sorting(object sender, GridViewSortEventArgs e)
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
            Grdreport.DataSource = dt;
            Grdreport.DataBind();
        }
    }
   
}