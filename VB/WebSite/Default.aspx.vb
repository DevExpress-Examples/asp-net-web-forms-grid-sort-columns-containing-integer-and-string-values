Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private dataSource As DataTable = CreateDataSource()
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		AddHandler grid.DataBinding, AddressOf grid_DataBinding
		grid.DataBind()
	End Sub

	Private Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		TryCast(sender, ASPxGridView).DataSource = dataSource
	End Sub

	Private Shared Function CreateDataSource() As DataTable
		Dim t As New DataTable("customDataTable")

		t.Columns.Add("ID", GetType(Integer))
		t.Columns.Add("Objects", GetType(Object))
		t.Columns.Add("ObjectType", GetType(Object))

		AddDataRow(t, 1)
		AddDataRow(t, "12")
		AddDataRow(t, "aaa")
		AddDataRow(t, "abc")
		AddDataRow(t, "4")
		AddDataRow(t, "21")
		AddDataRow(t, "prks")
		AddDataRow(t, "15")
		AddDataRow(t, 2)
		AddDataRow(t, "g3")
		AddDataRow(t, 15)
		AddDataRow(t, "11ss")
		AddDataRow(t, "23")
		AddDataRow(t, "zzz")
		AddDataRow(t, "15")
		AddDataRow(t, "saq")
		AddDataRow(t, "62")
		AddDataRow(t, "wa")
		AddDataRow(t, 18)
		AddDataRow(t, 7)

		Return t
	End Function
	Protected Sub grid_CustomColumnSort(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
		If e.Column.FieldName <> "Objects" Then
			Return
		End If

		Dim type1 As Type = e.Value1.GetType()
		Dim type2 As Type = e.Value2.GetType()
		If (type1 Is type2) AndAlso (type1 Is GetType(Integer)) Then
			e.Handled = False
			Return
		End If

		Dim parseResult1 As Integer
		Dim parseResult2 As Integer
		Dim value1IsNumber As Boolean = Int32.TryParse(TryCast(e.Value1.ToString(), String), parseResult1)
		Dim value2IsNumber As Boolean = Int32.TryParse(TryCast(e.Value2.ToString(), String), parseResult2)

		e.Handled = True
		If value1IsNumber AndAlso (Not value2IsNumber) Then
			e.Result = -1
		ElseIf (Not value1IsNumber) AndAlso value2IsNumber Then
			e.Result = 1
		ElseIf value1IsNumber AndAlso value2IsNumber Then
			If (parseResult1 < parseResult2) Then e.Result = -1 Else e.Result = 1
		Else
			e.Handled = False
		End If
	End Sub
	Private Shared Sub AddDataRow(ByVal t As DataTable, ByVal value As Object)
		t.Rows.Add(t.Rows.Count, value, value.GetType().ToString().Substring(("System.").Length))
	End Sub
End Class
