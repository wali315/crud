<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="crud.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-body">
                <h2 class="card-title">Signup</h2>
                <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>

                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-2" placeholder="Email"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control mb-2" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:Button ID="btnSignup" runat="server" Text="Signup" OnClick="btnSignup_Click" CssClass="btn btn-success btn-block mb-3" />
                <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx" CssClass="text-info">Already have an account? Login here.</asp:HyperLink>

            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-W7GzMSBDmEXsfLsE9EyIM4NlKTpf35b4FFtFZ1bE5d+6d1+4Fl9eI7ccUqPc9bD" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgydDFYnI93n0w2CkBCURzufq5hTUEfGVIx4FShpG9tA4zc/K9LDAIh0Ib6J" crossorigin="anonymous"></script>
</body>
</html>