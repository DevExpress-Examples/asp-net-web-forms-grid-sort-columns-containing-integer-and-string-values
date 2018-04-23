using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
	private DataTable dataSource = CreateDataSource();
	protected void Page_Load(object sender, EventArgs e) {
		grid.DataBinding += new EventHandler(grid_DataBinding);
		grid.DataBind();
	}

	void grid_DataBinding(object sender, EventArgs e) {
		(sender as ASPxGridView).DataSource = dataSource;
	}

	private static DataTable CreateDataSource() {
		DataTable t = new DataTable("customDataTable");

		t.Columns.Add("ID", typeof(int));
		t.Columns.Add("Objects", typeof(object));
		t.Columns.Add("ObjectType", typeof(object));

		AddDataRow(t, 1);
		AddDataRow(t, "12");
		AddDataRow(t, "aaa");
		AddDataRow(t, "abc");
		AddDataRow(t, "4");
		AddDataRow(t, "21");
		AddDataRow(t, "prks");
		AddDataRow(t, "15");
		AddDataRow(t, 2);
		AddDataRow(t, "g3");
		AddDataRow(t, 15);
		AddDataRow(t, "11ss");
		AddDataRow(t, "23");
		AddDataRow(t, "zzz");
		AddDataRow(t, "15");
		AddDataRow(t, "saq");
		AddDataRow(t, "62");
		AddDataRow(t, "wa");
		AddDataRow(t, 18);
		AddDataRow(t, 7);

		return t;
	}
	protected void grid_CustomColumnSort(object sender, CustomColumnSortEventArgs e) {
		if (e.Column.FieldName != "Objects")
			return;

		Type type1 = e.Value1.GetType();
		Type type2 = e.Value2.GetType();
		if ((type1 == type2) && (type1 == typeof(int))) {
			e.Handled = false;
			return;
		}

		int parseResult1;
		int parseResult2;
		bool value1IsNumber = Int32.TryParse(e.Value1.ToString() as string, out parseResult1);
		bool value2IsNumber = Int32.TryParse(e.Value2.ToString() as string, out parseResult2);

		e.Handled = true;
		if (value1IsNumber && !value2IsNumber)
			e.Result = -1;
		else if (!value1IsNumber && value2IsNumber)
			e.Result = 1;
		else if (value1IsNumber && value2IsNumber)
			e.Result = parseResult1 < parseResult2 ? -1 : 1;
		else
			e.Handled = false;
	}
	private static void AddDataRow(DataTable t, object value) {
		t.Rows.Add(t.Rows.Count, value, value.GetType().ToString().Substring(("System.").Length));
	}
}
