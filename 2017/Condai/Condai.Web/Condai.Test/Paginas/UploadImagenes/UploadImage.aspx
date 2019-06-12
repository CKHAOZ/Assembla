<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImage.aspx.cs" Inherits="Condai.Web.Test.Paginas.UploadImagenes.UploadImage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Image</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" language="javascript">
    $(window).load(function(){

     $(function() {
         $('#inpImagen').change(function (e) {
          addImage(e); 
         });

         function addImage(e){
          var file = e.target.files[0],
          imageType = /image.*/;
    
          if (!file.type.match(imageType))
           return;
  
          var reader = new FileReader();
          reader.onload = fileOnload;
          reader.readAsDataURL(file);
         }
  
         function fileOnload(e) {
             var result = e.target.result;
             $('#hdfRuta').val(result);
             $('#imgSalida').attr("src",result);
         }
        });
      });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField Value="" runat="server" ID="hdfRuta" />
        <input name="file-input" id="inpImagen" type="file" />
        <br />
        <img id="imgSalida" width="50%" height="50%" src="" />
        <br />
        <asp:Button ID="btnCargarImagen" runat="server" Text="Oh DU" OnClick="btnCargarImagen_Click"></asp:Button>
    </form>
</body>
</html>