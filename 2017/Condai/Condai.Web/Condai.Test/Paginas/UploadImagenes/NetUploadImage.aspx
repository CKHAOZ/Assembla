﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetUploadImage.aspx.cs" Inherits="Condai.Web.Test.Paginas.UploadImagenes.NetUploadImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
    </form>
</body>
</html>
