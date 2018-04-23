<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>How to sort columns with integer and string type values  using the CustomColumnSort event of ASPxGridView</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False"             
			oncustomcolumnsort="grid_CustomColumnSort">
			<Columns>
				<dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="0">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Objects" VisibleIndex="1">
					<Settings  AllowSort="True" SortMode="Custom" />
				</dx:GridViewDataTextColumn>                
				<dx:GridViewDataTextColumn FieldName="ObjectType" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
			</Columns>            
		</dx:ASPxGridView>
	</div>
	</form>
</body>
</html>
