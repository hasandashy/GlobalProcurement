﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emailTest.aspx.cs" Inherits="SGA.emailTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label id="lblUserId" runat="server"></asp:Label>
          <asp:ImageButton ID="imb" runat="server" 
            ImageUrl="~/Images/btn-register-here.png" onclick="imb_Click" />
    </div>
    </form>
</body>
</html>
