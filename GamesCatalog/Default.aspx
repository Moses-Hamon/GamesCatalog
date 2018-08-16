<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GamesCatalog.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3 class="display-3">Game Record Editor</h3>

            <%-- ID Name Platform Cost Released --%>

            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text bg-primary">ID</span>
                </div>
                <%--<input type="text" class="form-control" />--%>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text bg-primary">Name</span>
                </div>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"  />
            </div>

            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text bg-primary">Platform</span>
                </div>
                <asp:TextBox ID="txtPlatform" runat="server" CssClass="form-control" />
            </div>

            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text bg-primary">Cost</span>
                </div>
                <asp:TextBox ID="txtCost" runat="server" CssClass="form-control" />
            </div>

            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text bg-primary">Released</span>
                </div>
                <asp:TextBox ID="txtReleased" runat="server" CssClass="form-control" />
            </div>

            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">Select by ID</span>
                </div>
                <asp:TextBox ID="txtSelected" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnLoad" runat="server" Text="Load" CssClass="btn text-dark" OnClick="btnLoad_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" OnClick="btnSave_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn" OnClick="btnClear_Click" />





        </div>
    </form>
</body>
</html>
