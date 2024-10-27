<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Error" %>
<html>
<body>
    <h1>Oops</h1>
    <%# ViewData.StackTrace %> <br />
    <%# ViewData.Source %> <br />
</body>
</html>
