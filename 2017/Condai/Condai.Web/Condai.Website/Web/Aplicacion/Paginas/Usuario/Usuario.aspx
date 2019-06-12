<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Aplicacion/Paginas/MasterPage/Condai.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Condai.Web.Web.Aplicacion.Paginas.Usuario.Usuario" %>

<asp:Content ID="conPrincipal" ContentPlaceHolderID="head" runat="server">
    <!-- link : Condai Usuario -->
    <link href="../../../../style/Aplicacion/Usuario/Usuario.css" rel="stylesheet" />
    <script>
        setTimeout(function () {
            $('#hdfUsuario').val('1');
        }, 700);
    </script>
</asp:Content>
<asp:Content ID="conSecundario" ContentPlaceHolderID="cphPrincipal" runat="server">
    <!-- Service -->
    <asp:ScriptManager ID="scrPrincipal" runat="server" EnablePageMethods="true" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" EnablePartialRendering="true">
        <Services>
            <asp:ServiceReference Path="~/servicios/Aplicacion/MasterPage/MasterPage.svc" />
            <asp:ServiceReference Path="~/servicios/Aplicacion/Seguridad/Seguridad.svc" />            
        </Services>
    </asp:ScriptManager>
    <!-- Usuarios -->
    <div class="divPrincipal">
        <h3 class="titulo">Cuéntanos quién eres</h3>
        <div id="divVerUsuario" class="contenidoIzq" style="display: block">
            <table class="tblInput">
                <tr>
                    <td class="labelTitulo">Usuario: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblUsuario"></label>
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Descripción: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblDescripcion"></label>
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Nombre: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblNombre"></label>
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Apellido: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblApellido"></label>
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Email: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblCorreo"></label>
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Teléfono: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblTelefono"></label>
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Fecha último ingreso: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblFechaUltimoIngreso"></label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="botonModificar buttonStyle buttonStyleLeft">
                        <input id="btnModificarUsuario" type="button" class="btn btn-primary buttonStyle" value="Modificar" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divEditarUsuario" class="contenidoIzq" style="display: none">
            <table class="tblInput">
                <tr>
                    <td class="labelTitulo">Usuario: </td>
                    <td class="labelIngreso labelUsuario">
                        <label id="lblinfoUsuario"></label>                        
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Descripción: </td>
                    <td class="textboxIngreso">
                        <input id="txtDescripcion" maxlength="50" class="form-control txtIngreso" placeholder="Descripción" />
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Nombre: </td>
                    <td class="textboxIngreso">
                        <input id="txtNombre" maxlength="25" class="form-control txtIngreso" placeholder="Nombre" />
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Apellido: </td>
                    <td class="textboxIngreso">
                        <input id="txtApellido" maxlength="25" class="form-control txtIngreso" placeholder="Apellido" />
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Email: </td>
                    <td class="textboxIngreso">
                        <input id="txtCorreo" maxlength="50" class="form-control txtIngreso" placeholder="Email" />
                    </td>
                </tr>
                <tr>
                    <td class="labelTitulo">Teléfono: </td>
                    <td class="textboxIngreso">
                        <input id="txtTelefono" maxlength="10" class="form-control txtIngreso" placeholder="Teléfono" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="textboxIngreso buttonStyle">
                        <input id="btnActualizarUsuario" type="button" class="btn btn-primary buttonStyle" value="Guardar" />
                        <input id="btnCancelar" type="button" class="btn btn-primary buttonStyle" value="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="contenidoDer">
            <div>
                <div id="btnVerSubirImagen" class="divCamera">
                    <a id="btnUploadImage" class="icon icon-camera btnCamera"></a>
                </div>
                <img id="imgUsuarioPerfil" src=""
                    class="imagenAvatar" />
            </div>
            <div id="divNombrePass">
                <div class="titulo">
                    <label id="lblNombreParaFoto"></label>    
                </div>
                <div id="divVerCambioPass" class="cambioDeContrasena" style="display: block">
                    <input id="btnCambiarContrasena" type="button" class="btn btn-primary buttonStyle" value="Cambiar contraseña" />
                </div>
                <div id="divCambioPass" class="cambioDeContrasena" style="display: none;">
                <h5 class="tblInputContrasena">Cambiar Contraseña </h5>
                <table class="tblCambioPass">
                    <tr>
                        <td class="labelTituloPass">Contraseña actual </td>
                        <td class="textoPass">
                            <input id="txtContrasenaActual" type="password" class="form-control txtIngreso" placeholder="Contraseña actual" />
                        </td>
                    </tr>
                    <tr>
                        <td class="labelTituloPass">Contraseña nueva </td>
                        <td class="textoPass">
                            <input id="txtNuevaContrasena" type="password" class="form-control txtIngreso" placeholder="Contraseña nueva" />
                        </td>
                    </tr>
                    <tr>
                        <td class="labelTituloPass">Confirmar </td>
                        <td class="textoPass">
                            <input id="txtNuevaConfirma" type="password" class="form-control txtIngreso" placeholder="Confirmar contraseña" />
                        </td>
                    </tr>
                </table>
                <input id="btnGuardarContrasena" type="button" class="btn btn-primary buttonStyle" value="Guardar" />
                <input id="btnCancelarGuardarCon" type="button" class="btn btn-primary buttonStyle" value="Cancelar" />
            </div>
            </div>
             <div id="divUploadImage">
                <!--File upload Control -->
                <asp:FileUpload ID="fupImagenUsuario" runat="server" CssClass="fileUpload"/>
                <!-- Buttons Upload -->
                <asp:Button ID="btnSubirImagen" runat="server" Text="Guardar" class="btn btn-primary buttonStyle" OnClick="btnSubirImagen_Click" />
                <input id="btnSubirImagenCancelar" type="button" class="btn btn-primary buttonStyle" value="Cancelar" />
            </div>
        </div>
    </div>
</asp:Content>
