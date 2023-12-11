<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="crud._Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
    <title>Home Page</title>

    <!-- Include Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">

    <!-- Include jQuery -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>

    <!-- Include Bootstrap JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    <!-- Your custom JavaScript code -->
    <script>
        function confirmDelete() {
            // Display a confirmation dialog
            var confirmed = confirm('Are you sure you want to delete this record?');

            // If user confirms, proceed with the delete action
            if (confirmed) {
                // Call the server-side click event of the delete button
                <%= Page.ClientScript.GetPostBackEventReference(ButtonDelete, null) %>;
            }

            // Return false to prevent the default postback behavior if the user cancels
            return confirmed;
        }
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <table class="table">
            <tr>
                <td class="col-md-3">Id</td>
                <td class="col-md-6">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvId" runat="server" ControlToValidate="txtId" Display="Dynamic" ErrorMessage="Id is required." />
                    <asp:RegularExpressionValidator ID="revId" runat="server" ControlToValidate="txtId" Display="Dynamic" ErrorMessage="Enter a valid Id." ValidationExpression="\d+" />
                </td>
                <td class="col-md-3"></td>
            </tr>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Name is required." />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Age</td>
                <td>
                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Age is required." />
                    <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Enter a valid age (between 1 and 150)." Type="Integer" MinimumValue="1" MaximumValue="150" />
                </td>
                <td></td>
            </tr>


            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButton ID="rbtnMale" runat="server" Text="Male" />
                    <asp:RadioButton ID="rbtnFemale" runat="server" Text="Female" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Hobbies</td>
                <td>
                    <asp:DropDownList ID="ddlHobbies" runat="server" CssClass="form-control">
                        <asp:ListItem Text="- Select -" Value="" />
                        <asp:ListItem>Football</asp:ListItem>
                        <asp:ListItem>Cricket</asp:ListItem>
                        <asp:ListItem>Games</asp:ListItem>
                        <asp:ListItem>Coding</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
        </table>
        <div class="row">
            <div class="col-md-2">
                <asp:Button ID="ButtonInsert" runat="server" CssClass="btn btn-success btn-block" OnClick="ButtonInsert_Click" Text="Insert" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="ButtonUpdate" runat="server" CssClass="btn btn-warning btn-block" OnClick="ButtonUpdate_Click1" Text="Update" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="ButtonDelete" runat="server" CssClass="btn btn-danger btn-block" OnClick="ButtonDelete_Click1" Text="Delete" OnClientClick="return confirmDelete();" CausesValidation="False" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="ButtonSearch" runat="server" CssClass="btn btn-primary btn-block" OnClick="ButtonSearch_Click1" Text="Search" CausesValidation="False" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="ButtonGetAll" runat="server" CssClass="btn btn-info btn-block" OnClick="ButtonGetAll_Click" Text="Get All" CausesValidation="False" />
            </div>
        </div>

        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" Width="100%">
        </asp:GridView>
    </div>
</asp:Content>
