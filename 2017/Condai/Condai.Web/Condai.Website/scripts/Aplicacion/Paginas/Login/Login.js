function Login() {
    //Guarda el Contexto
    var that = this;
    var p = null;

    this.Cargar = function fnCargar(paginas) {
        p = paginas;
        p.gCargando.Cargar('divCargando');
        this.Eventos();
        this.EsconderObjetos();
        
        //TODO intento para mejorar esta parte
        $("#txtUsuario").keyup(function (event) {
            if (event.keyCode == 13) {
                that.VerItem('divLogin');
            }
        });
    };

    //General
    this.Eventos = function fnEventos() {
        var evento = 'click';

        //Eventos
        $('#btnLogin').bind(evento, that.ValidarUsuario);

        //Navegación
        $('#btnHome').bind(evento, function btnHome_click() { that.VerItem('divHome'); });
        $('#btnMision').bind(evento, function btnMision_click() { that.VerItem('divMision'); });
        $('#btnVision').bind(evento, function btnVision_click() { that.VerItem('divVision'); });
        $('#btnDispositivosMoviles').bind(evento, function btnMobile_click() { that.VerItem('divMobile'); });
        $('#btnInstagram').bind(evento, function btnInstagram_click() { that.VerItem('divInstagram'); });
        $('#btntwitter').bind(evento, function btnTwitter_click() { that.VerItem('divTwitter'); });
        $('#btnFacebook').bind(evento, function btnFacebook_click() { that.VerItem('divFacebook');  });
        $('#btnContacto').bind(evento, function btnContacto_click() { that.VerItem('divContactenosInicio'); });
        $('#btnMenuLogin').bind(evento, function btnLogin_click() { that.VerItem('divLogin'); });

        //Contactenos - Quien es.
        $('#btnConContinuar').bind(evento, function btnConContinuar_Click() { that.VerContactenos(); });

        //Ver la duda - Expresanos tú inquietud.
        $('#btnQuienContinuar').bind(evento, function btnConContinuar_Click() { that.VerDuda(); });

        //Gracias inquietud.
        $('#btnDudaGuardar').bind(evento, function btnLogin_click() { that.GuardarDuda(); });
    }

    //Diseño
    this.EsconderObjetos = function fnEsconderObjetos()
    {
        that.EsconderObjeto('divHome');
        that.EsconderObjeto('divMision');
        that.EsconderObjeto('divVision');
        that.EsconderObjeto('divMobile');
        that.EsconderObjeto('divInstagram');
        that.EsconderObjeto('divTwitter');
        that.EsconderObjeto('divFacebook');

        that.EsconderObjeto('divContactenosInicio');
        that.EsconderObjeto('divContactenosQuienEs');
        that.EsconderObjeto('divContactenosInquietud');
        that.EsconderObjeto('divContactenosGracias');

        that.EsconderObjeto('divLogin');
    }

    this.VerItem = function fnVerItem(itemNombre)
    {
        //Colocamos el estilo del Sitio.
        document.body.style.background = 'url("../../image/Login/WebSite.jpg")';
        document.body.style.backgroundSize = 'cover';
        document.body.style.backgroundColor = 'black';
        document.body.style.backgroundRepeat = 'no-repeat';

        //Ocultamos todos los objetos.
        that.EsconderObjetos();

        //Mostramos la página solicitada.
        $('#' + itemNombre).show();
    }

    this.EsconderObjeto = function fnEsconderObjeto(nombreObjeto)
    {
        $('#' + nombreObjeto).hide();        
    }

    //Metodos.
    this.ValidarUsuario = function fnValidarUsuario() {
        var usuario = $('#txtUsuario').val();
        var clave = $('#txtClave').val();

        if (that.ValidarLogin() &&
            usuario !== 'Clave' && clave !== 'Usuario') {
            var oBLLSeguridad = new BLLSeguridad();
            p.gCargando.Ver('Validando usuario');
            oBLLSeguridad.ValidarUsuario
                (
                    usuario,
                    clave,
                    function success(data) {
                        var res = JSON.parse(data);
                        p.gCargando.Ocultar();
                        if (data != null) {
                            if (res.Resultado > 0) {
                                p.gToastr.Ver('success', 'Usario Valido.');
                                $('#hdfUsuario').val(JSON.stringify(res.Data));
                                document.getElementById("lnkGuardarUsuario").click();
                            }
                            else {                                
                                that.LimpiarPass();
                                p.gToastr.Ver('info', res.Mensaje);
                            }
                        }
                        else {
                            that.LimpiarPass();
                            p.gToastr.Ver('error', 'Error validando usuario.');
                            p.gToastr.Ver('info', 'Por favor intente mas tarde.');
                        }
                    },
                    function error(data) {
                        p.gCargando.Ocultar();
                        that.LimpiarPass();
                        p.gToastr.Ver('error', 'Error validando usuario.');
                    }
                );
        }
        else {
            p.gToastr.Ver('error', 'Por favor ingrese usuario y clave.');
        };
    };
    
    this.LimpiarPass = function fnLimpiarPass() {
        $('#txtUsuario').val('');
        $('#txtClave').val('');
    }

    //Validaciones
        /* Login */
    this.ValidarLogin = function fnValidarLogin()
    {
        var resultado = true;

        //Tipo de mensajes
        var info = 'info';
        var error = 'error';

        resultado = p.gValidaciones.CampoObligatorio(error, resultado, $('#txtUsuario'), '¿Cual es tu usuario?');
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, $('#txtClave'), '¿Cual es tu clave?');

        return resultado;
    }

        /* Contacto */
    this.ValidarContacto = function fnValidarContacto() {
        //Indica si debo continuar a preguntar que duda existe.
        var resultado = true;

        //Inicializo los campos una sola vez.
        var nombre = $('#txtNombre');
        var ocupacion = $('#txtOcupacion');
        var pais = $('#txtPais');
        var telefono = $('#txtTelefono');
        var correo = $('#txtCorreo');

        //Tipo de mensajes
        var info = 'info';
        var error = 'error';

        //Valido Campos Obligatorios
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, nombre, '¿Cual es tu nombre?');
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, ocupacion, '¿Cual es tu ocupación?');
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, pais, '¿Cual es tu país?');
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, telefono, '¿Cual es tu telefono?');
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, correo, '¿Cual es tu Correo?');

        if (telefono.val().length > 0) {

            //Longitud maxima de campos
            resultado = p.gValidaciones.ValidarMaximo(info, resultado, telefono, 10, 'El telefono debe ser de 10 digitos maximo');

            //Longitud minimo de campos
            resultado = p.gValidaciones.ValidarMinimo(info, resultado, telefono, 7, 'El telefono debe ser de 7 digitos minimo');

            //Validaciones especiales
            resultado = p.gValidaciones.ValidarCampoNumerico(info, resultado, telefono, 'solo numeros');

        }

        if (correo.val().length > 0) {

            //Validaciones especiales
            resultado = p.gValidaciones.ValidarCorreo(info, resultado, correo, 'Email incorrecto');
        }

        //Retorno aprobación para ver la duda
        return resultado;
    }

        /* Duda */
    this.ValidarDuda = function fnValidarDuda() {
        //Indica si debo continuar a preguntar que duda existe.
        var resultado = true;

        //Inicializo los campos una sola vez.
        var duda = $('#txtDuda');
       
        //Tipo de mensajes
        var info = 'info';
        var error = 'error';

        //Valido Campos Obligatorios
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, duda, '¿Cual es tu inquietud?');
      
        if (duda.val().length > 0) {

            //Longitud maxima de campos
            resultado = p.gValidaciones.ValidarMaximo(info, resultado, duda, 512, 'Tu inquietud es muy larga');
        }

        //Retorno aprobación para ver la duda
        return resultado;
    }

    //Metodos    
    this.LimpiarCampos = function fnLimparCampos() {
        var clean = '';
        $('#txtNombre').val(clean);
        $('#txtOcupacion').val(clean);
        $('#txtPais').val(clean);
        $('#txtTelefono').val(clean);
        $('#txtCorreo').val(clean);
        $('#txtDuda').val(clean);
    }
    
    //Eventos

    //Ver Datos del usuario
    this.VerContactenos = function fnVerContactenos() {
        that.LimpiarCampos();
        $('#divContactenosInicio').hide();
        $('#divContactenosQuienEs').show(); 
        $('#divContactenosInquietud').hide();
    }
    
    //Ver inquietud
    this.VerDuda = function fnVerDuda() {
        if (that.ValidarContacto()) {
            $('#divContactenosInicio').hide();
            $('#divContactenosQuienEs').hide();
            $('#divContactenosInquietud').show();
        }
    }

    //Guardar respuesta 
    this.GuardarDuda = function fnGuardarDuda() {

        if (that.ValidarDuda()) {

            //Envio entidad contacto a base de datos y email.
            var contacto = that.LeerContacto();
            
            var bllLogin = new BllLogin();

            var res = bllLogin.GuardarInquietud
                (
                    contacto,
                    function success(data) {
                        if (data != null) {
                            $('#divContactenosInquietud').hide();
                            $('#divContactenosGracias').show();
                            p.gToastr.Ver('success', 'Mensaje enviado correctamente.');
                        }
                        else {
                            p.gToastr.Ver('error', 'Error enviando mensaje.');
                            p.gToastr.Ver('info', 'Por favor intente mas tarde.');
                        }
                    },
                    function error(data) {
                        p.gToastr.Ver('error', 'Error enviando mensaje.');
                    }
                );
        }
    }

    //Devuelve información del contacto.
    this.LeerContacto = function fnLeerContacto() {

        var oContacto = new Contacto();

        oContacto.NombreApellido = $('#txtNombre').val();
        oContacto.Ocupacion = $('#txtOcupacion').val();
        oContacto.Pais = $('#txtPais').val();
        oContacto.Telefono = $('#txtTelefono').val();
        oContacto.Correo = $('#txtCorreo').val();
        oContacto.Duda = $('#txtDuda').val();

        return oContacto;
    }
};