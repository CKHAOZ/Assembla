<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Condai.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Condai</title>

    <!-- Ico Page -->
    <link rel="shortcut icon" type="image/x-icon" href="image/General/Condai.ico" />

    <!-- link : General -->
    <link href="content/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="content/bootstrap/bootstrap-theme.css" rel="stylesheet" />
    <link href="content/toastr/toastr.css" rel="stylesheet" />
    <link href="content/jqueryUi/jquery-ui.min.css" rel="stylesheet" />
    <link href="content/jqueryUi/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="content/jqueryUi/jquery-ui.theme.min.css" rel="stylesheet" />

    <!-- link : Condai -->
    <link href="content/icoMoon/IcoMoon.css" rel="stylesheet" />
    <link href="Style/Aplicacion/Login/Login.css" rel="stylesheet" />
    <link href="style/General/Cargando/Cargando.css" rel="stylesheet" />
    <link href="style/General/Cargando/paceBounce.css" rel="stylesheet" />
</head>
<body>
    <form id="frmLogin" runat="server" data-toggle="validator" role="form" class="frmLoginClass" >
        <div class="divLogo">
            <div class="divLogoCirculo">
                <a id="btnSHC" runat="server" href='../Login.aspx' class="handIcon">
                    <img src="image/General/SHCLogo.png" class="LogoCondai" />
                </a>
            </div>
        </div>
        <!-- Page Login -->
        <div class="bodyLogin">
            <!-- Home -->
            <div id="divHome" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>CONDAI</h3>
                        <br />
                        <div class="textoPlano">
                            CONDAI es el sistema de información que permite a sus clientes la competitividad requerida para su negocio, permite 
                                conocer en forma oportuna y rapida procesos dentro de la organización para toma de desiciones, esto es posible debido a que Condai convierte sus datos en información.
                        </div>
                    </div>
                </div>
            </div>
            <!-- Mision -->
            <div id="divMision" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Misión</h3>
                        <br />
                        <div class="textoPlano">
                            En SHC (Software Hecho en Colombia) desarrollamos soluciones tecnológicas para nuestros clientes a partir de sus necesidades,
                                con el propósito de brindar herramientas innovadoras que certifican la veracidad de su información.
                        </div>
                    </div>
                </div>
            </div>
            <!-- Visión -->
            <div id="divVision" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Visión</h3>
                    </div>
                    <br />
                    <div class="textoPlanoCentrado">
                        Convertimos datos en información.
                    </div>
                </div>
            </div>
            <!-- Mobile -->
            <div id="divMobile" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Dispositivos móviles</h3>
                        <br />
                        <div class="textoPlano">
                            ¿Quiere tener información de su empresa al alcance de su mano?

                           Con Condai como sistema de información puede llevar sus procesos tecnologicos al siguiente nivel, 
                            puede conocer información oportuna de su compañia al alcance de su dispositivo móvil.
                        </div>
                    </div>
                </div>
            </div>
            <!-- Instagram -->
            <div id="divInstagram" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <br />
                        <a href='https://instagram.com/shc_colombia' target="_blank" class="handIcon">
                            <span class="icon icon-instagram iconoTituloDiv handIcon" />
                        </a>
                        <h3>Instagram</h3>
                        <br />
                    </div>
                </div>
            </div>
            <!-- Twitter -->
            <div id="divTwitter" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <br />
                        <a href='https://twitter.com/SHC_Software' target="_blank" class="handIcon">
                            <span class="icon icon-twitter iconoTituloDiv handIcon" />
                        </a>
                        <h3>Twitter</h3>
                        <br />
                    </div>
                </div>
            </div>
            <!-- Facebook -->
            <div id="divFacebook" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <br />
                        <a href='https://www.facebook.com/SHCSoftware' target="_blank" class="handIcon">
                            <span class="icon icon-facebook iconoTituloDiv handIcon" />
                        </a>
                        <h3>Facebook</h3>
                        <br />
                    </div>
                </div>
            </div>
            <!-- Contactenos -->
            <div id="divContactenosInicio" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Contactar con el equipo de SHC Colombia</h3>
                        <br />
                        <br />
                        <h4>¿En que podemos ayudarte?</h4>
                        <br />
                        <br />
                        <asp:Button ID="btnConContinuar" runat="server" OnClientClick="javascript:return false;"
                            class="BotonContacto divLogoCirculoContacto" Text=">" ToolTip="Continuar"></asp:Button>
                    </div>
                </div>
            </div>
            <!-- Cuentanos Quien eres -->
            <div id="divContactenosQuienEs" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Cuéntanos quién eres</h3>
                        <br />
                        <input type="text" id="txtNombre" class="form-control TextoContacto" placeholder="Nombres y Apellidos" />
                        <input type="text" id="txtOcupacion" class="form-control TextoContacto" placeholder="Ocupación" />
                        <input type="text" id="txtPais" class="form-control TextoContacto" placeholder="País" />
                        <input type="text" id="txtTelefono" maxlength="10" class="form-control TextoContacto" placeholder="Teléfono" />
                        <input type="text" id="txtCorreo" class="form-control TextoContacto" placeholder="Email" />
                        <br />
                        <input id="btnQuienContinuar" class="btn btn-primary buttonLogin" value="Continuar" type="button" />
                    </div>
                </div>
            </div>
            <!-- Cuentanos Tú inquietud -->
            <div id="divContactenosInquietud" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Cuéntanos tú inquietud</h3>
                        <br />
                        <textarea id="txtDuda" class="form-control TextoContacto" cols="25" rows="7"
                            placeholder="Inquietud"></textarea>
                        <br />
                        <input id="btnDudaGuardar" class="btn btn-primary buttonLogin" type="button" value="Enviar" />
                    </div>
                </div>
            </div>
            <!-- Gracias -->
            <div id="divContactenosGracias" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Gracias, pronto nos comunicaremos contigo.</h3>
                        <br />
                        <span class="icon icon-mail2 iconoTituloDiv iconHoverDisable" />
                        <br />
                    </div>
                </div>
            </div>
            <!-- Login -->
            <div id="divLogin" class="divCentrado">
                <div class="form-group divDiv">
                    <div class="panel-body">
                        <h3>Bienvenido</h3>
                        <br />
                        <input id="txtUsuario" placeholder="Usuario" class="form-control txtLogin" />
                        <input id="txtClave" placeholder="Clave" type="password" class="form-control txtLogin" />
                        <br />
                        <input id="btnLogin" class="btn btn-primary buttonLogin" type="button" value="Iniciar sesión" />
                    </div>
                </div>
            </div>

            <!-- Footer -->
            <div class="shcPie">
                <p>SHC Software Hecho en Colombia</p>
            </div>
        </div>
        <!--Menú-->
        <div class='divMenuCentrado'>
            <div class="divMenu">
                <ul id="divMenuUl">
                    <li class="espacioMenu">
                        <a id="btnHome" class="icon icon-home btnMenu">
                            <span>Condai</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btnMision" class="icon icon-earth btnMenu">
                            <span>Misión</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btnVision" class="icon icon-eye btnMenu">
                            <span>Visión</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btnDispositivosMoviles" class="icon icon-android btnMenu">
                            <span>Dispositivos Moviles</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btnInstagram" class="icon icon-instagram btnMenu">
                            <span>Instagram</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btntwitter" class="icon icon-twitter btnMenu">
                            <span>Twitter</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btnFacebook" class="icon icon-facebook btnMenu">
                            <span>Facebook</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btnContacto" class="icon icon-address-book btnMenu">
                            <span>Contacto</span>
                        </a>
                    </li>
                    <li class="espacioMenu">
                        <a id="btnMenuLogin" class="icon icon-user btnMenu">
                            <span>Iniciar Sesión</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>

        <!-- HiddenField -->
        <asp:HiddenField ID="hdfUsuario" runat="server" />

        <!-- Link -->
        <asp:LinkButton ID="lnkGuardarUsuario" runat="server" OnClick="GuardarUsuario_Click"></asp:LinkButton>

        <!-- Service -->
        <asp:ScriptManager ID="scrPrincipal" runat="server" EnablePageMethods="true" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
            <Services>
                <asp:ServiceReference Path="~/servicios/Aplicacion/Login/Login.svc" />
                <asp:ServiceReference Path="~/servicios/Aplicacion/Seguridad/Seguridad.svc" />
            </Services>
        </asp:ScriptManager>

        <!-- Modal -->
        <div id="divCargando"></div>
    </form>

    <!-- Entity -->
    <script type="text/javascript" src="scripts/Entity/EntidadesLogin.js"></script>

    <!-- BLL -->
    <script type="text/javascript" src="scripts/BLL/Login/BLLLogin.js"></script>
    <script type="text/javascript" src="scripts/BLL/Seguridad/BLLSeguridad.js"></script>

    <!-- script project : General -->
    <script type="text/javascript" src="scripts/Library/jquery/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="scripts/Library/bootstrap/bootstrap.min.js"></script>
    <script type="text/javascript" src="scripts/Library/notifyJs/notify.min.js"></script>
    <script type="text/javascript" src="scripts/Library/toastr/toastr.min.js"></script>
    <script type="text/javascript" src="scripts/Library/jqueryUi/jquery-ui.min.js"></script>
    <script type="text/javascript" src="scripts/Library/icoMoon/icoMoonCore.js"></script>

    <!-- script project : Condai Master -->
    <script type="text/javascript" src="scripts/Aplicacion/Paginas/MasterPage/CondaiMaster.js"></script>

    <!-- script project : Condai Login -->
    <script type="text/javascript" src="scripts/Aplicacion/DocumentReady/GlobalCondai.js"></script>
    <script type="text/javascript" src="scripts/Aplicacion/General/Validaciones/Validaciones.js"></script>
    <script type="text/javascript" src="scripts/Aplicacion/General/Mensajes/Notify.js"></script>
    <script type="text/javascript" src="scripts/Aplicacion/General/Mensajes/Toastr.js"></script>
    <script type="text/javascript" src="scripts/Aplicacion/General/Cargando/Cargando.js"></script>
    <script type="text/javascript" src="scripts/Aplicacion/Paginas/Login/Login.js"></script>
    <script type="text/javascript" src="scripts/Aplicacion/DocumentReady/CargarSitioCondai.js"></script>
</body>
</html>
