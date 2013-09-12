using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DummyData_Users_ObjectHydrator;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Data;
using System.ComponentModel;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TestEpplusBtn_Click(object sender, EventArgs e)
    {
        using (ExcelPackage pck = new ExcelPackage())
        {
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");

            //IEnumerable<UserModel> data = new Users().GetMultiple(50).AsEnumerable<UserModel>();
            DataTable userTable = Helper.ToDataTable(new Users().GetMultiple(50));
            ws.Cells["A1"].LoadFromDataTable(userTable, true);

            //Create the worksheet

            //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
            //Collection<UserModel> userCollection = new Collection<UserModel>(new Users().GetMultiple(50));
            //ws.Cells["A1"].LoadFromCollection(userCollection);

            ////Format the header for column 1-3
            //using (ExcelRange rng = ws.Cells["A1:D1"])
            //{
            //    rng.Style.Font.Bold = true;
            //    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
            //    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
            //    rng.Style.Font.Color.SetColor(Color.White);
            //}

            ////Example how to Format Column 1 as numeric 
            //using (ExcelRange col = ws.Cells[2, 1, 2 + tbl.Rows.Count, 1])
            //{
            //    //col.Style.Numberformat.Format = "#,##0.00";
            //    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //}

            //Write it back to the client
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
    }


}
public static class Helper
{
    public static DataTable ToDataTable<T>(this IList<T> list)
    {
        PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        for (int i = 0; i < props.Count; i++)
        {
            PropertyDescriptor prop = props[i];
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in list)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = props[i].GetValue(item) ?? DBNull.Value;
            table.Rows.Add(values);
        }
        return table;
    }
}