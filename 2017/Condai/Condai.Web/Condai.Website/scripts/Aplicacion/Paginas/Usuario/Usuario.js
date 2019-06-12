function UsuarioPage() {
    //Guarda el Contexto
    var that = this;
    var p = null;
    var usuarioHdf = null;
    var CambioContrasenaVisible = null;

    //Carga inicial
    this.Cargar = function fnCargar(paginas) {
        p = paginas;
        that.OcultarBotones();
        p.gCargando.Ver('Cargando información');
        setTimeout(function () {
            if ($('#hdfUsuario') != undefined &&
                $('#hdfUsuario').val() == "1") {                
                that.IniciarPagina();
                p.gCargando.Ocultar();
            }
        }, 1200);
    };

    //Eventos
    this.Eventos = function fnEventos() {
        var evento = 'click';
        var cambio = 'change';
       
        //Iniciar Pagina
        $('#lnkUsuariosIniciarP').bind(evento, that.IniciarPagina);

        //Eventos
        $('#btnModificarUsuario').bind(evento, that.VerModificarUsuario);
        $('#btnCancelar').bind(evento, that.CancelarModificarUsuario);
        $('#btnActualizarUsuario').bind(evento, that.ActualizarUsuario);

        //Eventos Contraseña
        $('#btnCambiarContrasena').bind(evento, that.VerCambioPass);
        $('#btnGuardarContrasena').bind(evento, that.CambiarContrasena);
        $('#btnCancelarGuardarCon').bind(evento, that.OcultarCambioPass);

        //Cambiar Imagen de Usuario
        $('#btnVerSubirImagen').bind(evento, that.VerCargarImagen);
        $('#btnSubirImagen').bind(evento, that.VerCargando);
        $('#btnSubirImagenCancelar').bind(evento, that.CancelarCargarImagen);
       
        //Muestro Botones
        $('#btnModificarUsuario').show();
        $('#btnCambiarContrasena').show();
        $('#btnVerSubirImagen').show();

        $('input[type=file]').change(function () {
            fileCount = this.files.length;
            $(this).prev().text(fileCount + 'Selected');
        })
    }

    this.OcultarBotones = function fnOcultarBotones()
    {
        $('#btnModificarUsuario').hide();
        $('#btnCambiarContrasena').hide();
        $('#divUploadImage').hide();
        $('#btnVerSubirImagen').hide();
    }

    //Iniciar Pagina
    this.IniciarPagina = function fnIniciarPagina()
    {
        var usuarioActual = p.gSeguridad.ObtenerUsuarioActual();

        //Iniciar Info Usuario
        $('#lblUsuario').html(usuarioActual.usuUsuario);
        $('#lblDescripcion').html(usuarioActual.usuDescripcion);
        $('#lblNombre').html(usuarioActual.usuNombre);
        $('#lblApellido').html(usuarioActual.usuApellido);
        $('#lblCorreo').html(usuarioActual.usuCorreo);
        $('#lblTelefono').html(usuarioActual.usuTelefono);
        $('#lblFechaUltimoIngreso').html(p.gTools.LeerFecha(usuarioActual.usuFechaUltimoIngreso));

        //Foto
        $('#lblNombreParaFoto').html(usuarioActual.usuNombre);
        
        //Eventos
        that.Eventos();
    }

    //Upload Image
    this.VerCargarImagen = function fnVerCargarImagen() {
        if (that.CambioContrasenaVisible == null || that.CambioContrasenaVisible == false) {
            that.CambioContrasenaVisible = true;
            $('#divUploadImage').show();
            $('#divNombrePass').hide();
        }
        else {
            that.CambioContrasenaVisible = false;
            $('#divUploadImage').hide();
            $('#divNombrePass').show();
        }
    }

    this.VerCargando = function fnVerCargando() {
        alert(1);
        p.gCargando.Ver('Cargando imagen');
    }

    this.CancelarCargarImagen = function fnCancelarCargarImagen() {
        that.CambioContrasenaVisible = false;
        $('#divUploadImage').hide();
        $('#divNombrePass').show();
    }
    
    //Contraseña   
    this.VerCambioPass = function fnVerCambioPass()
    {
        $('#divVerCambioPass').hide();
        $('#divCambioPass').show();
    }

    this.OcultarCambioPass = function fnOcultarCambioPass() {
        $('#divVerCambioPass').show();
        $('#divCambioPass').hide();
    }

    this.LimpiarContrasena = function fnLimpiarContrasena() {
        $('#txtContrasenaActual').val('');
        $('#txtNuevaContrasena').val('');
        $('#txtNuevaConfirma').val('');
    }
    
    this.CambiarContrasena = function fnCambiarContrasena() {

        //Get info Actual User
        var usuarioActual = p.gSeguridad.ObtenerUsuarioActual();

        var oBLLSeguridad = new BLLSeguridad();

        if (that.ValidarCambioClave()) {
            if ($('#txtContrasenaActual').val() != $('#txtNuevaContrasena').val()) {
                if ($('#txtNuevaContrasena').val() == $('#txtNuevaConfirma').val()) {

                    p.gCargando.Ver('Cargando información');
                    oBLLSeguridad.ActualizarContrasena
                        (
                            usuarioActual.usuId,
                            usuarioActual.usuUsuario,
                            $('#txtContrasenaActual').val(),
                            $('#txtNuevaConfirma').val(),
                            function success(data) {
                                var res = JSON.parse(data);
                                p.gCargando.Ocultar();
                                if (res.Data != null && res.Data > 0) {
                                    that.LimpiarContrasena();
                                    that.OcultarCambioPass();
                                    p.gToastr.Ver('success', res.Mensaje);
                                }
                                else {
                                    that.LimpiarContrasena();
                                    p.gToastr.Ver('error', res.Mensaje);
                                }
                            },
                            function error(data) {
                                var res = JSON.parse(data);
                                p.gCargando.Ocultar();
                                that.LimpiarContrasena();
                                p.gToastr.Ver('error', res.Mensaje);
                            }
                        );
                }
                else {
                    that.LimpiarContrasena();
                    p.gToastr.Ver('error', 'La contraseña nueva no coincide.');
                }
            }
            else {
                that.LimpiarContrasena();
                p.gToastr.Ver('error', 'La contraseña nueva es igual a la actual.');
            }
        }
    }

    //Editar Usuario
    this.OcultarCambioUsuario = function fnOcultarCambioUsuario() {
        //Navegación
        $('#divVerUsuario').show();
        $('#divEditarUsuario').hide();

        that.LimpiarEdicion();
    }

    this.VerModificarUsuario = function fnVerModificarUsuario() {

        //Navegación
        $('#divVerUsuario').hide();
        $('#divEditarUsuario').show();

        //Get info Actual User
        var usuarioActual = p.gSeguridad.ObtenerUsuarioActual();

        //Iniciar Info Usuario
        $('#lblinfoUsuario').html(usuarioActual.usuUsuario);
        $('#txtDescripcion').val(usuarioActual.usuDescripcion);
        $('#txtNombre').val(usuarioActual.usuNombre);
        $('#txtApellido').val(usuarioActual.usuApellido);
        $('#txtCorreo').val(usuarioActual.usuCorreo);
        $('#txtTelefono').val(usuarioActual.usuTelefono);
        $('#txtFechaUltimoIngreso').val(p.gTools.LeerFecha(usuarioActual.usuFechaUltimoIngreso));
    }

    this.CancelarModificarUsuario = function fnCancelarModificarUsuario() {
        that.OcultarCambioUsuario();
    }

    this.LimpiarEdicion = function fnLimpiarEdicion() {

        // un unico set de memoria vacio.
        var empty = '';

        //Limpiando Campos.
        $('#txtUsuario').val(empty);
        $('#txtDescripcion').val(empty);
        $('#txtNombre').val(empty);
        $('#txtApellido').val(empty);
        $('#txtCorreo').val(empty);
        $('#txtTelefono').val(empty);
        $('#txtFechaUltimoIngreso').val(empty);
    }

    this.LeerUsuarioEditado = function fnLeerUsuarioEditado(){
        //Get info Actual User
        var usuarioActual = p.gSeguridad.ObtenerUsuarioActual();

        //Actualiza Información del Usuario.
        usuarioActual.usuDescripcion = $('#txtDescripcion').val();
        usuarioActual.usuNombre = $('#txtNombre').val();
        usuarioActual.usuApellido = $('#txtApellido').val();
        usuarioActual.usuCorreo = $('#txtCorreo').val();
        usuarioActual.usuTelefono = $('#txtTelefono').val();
        
        return usuarioActual;
    }

    this.ActualizarUsuario = function fnActualizarUsuario() {

        that.usuarioHdf = $('#hdfUsuarioUP');

        if (that.ValidarCambioInfoPersonal()) {

            var usuarioEditar = that.LeerUsuarioEditado();

            var oBLLSeguridad = new BLLSeguridad();

            p.gCargando.Ver('Cargando información');
            oBLLSeguridad.ActualizarUsuario
                (
                    usuarioEditar,
                    function success(data) {
                        var res = JSON.parse(data);
                        if (res.Data != null) {
                            p.gToastr.Ver('success', 'Información actualizada.');
                            that.OcultarCambioUsuario();
                            that.usuarioHdf.val(JSON.stringify(res.Data));
                            setTimeout(function () {
                                document.getElementById("lnkGuardarUsuarioUP").click();
                            }, 1000);
                        }
                        else {
                            p.gToastr.Ver('error', 'Error actualizando usuario.');
                        }
                    },
                    function error(data) {
                        p.gCargando.Ocultar();
                        p.gToastr.Ver('error', 'Error actualizando usuario.');
                    }
                );
        }
        else {
            p.gToastr.Ver('error', 'Hubo un error.');
        }
    }

    //Validaciones
    this.ValidarCambioInfoPersonal = function fnValidarCambioInfoPersonal()
    {
        //Validar Correo
        //Telefono Númerico
         
        var resultado = true;

        //Campos de Contraseña
        var descripcion = $('#txtDescripcion');
        var nombre = $('#txtNombre');
        var apellido = $('#txtApellido');
        var correo = $('#txtCorreo');
        var telefono = $('#txtTelefono');

        //Tipo de mensajes
        var info = 'info';
        var error = 'error';

        //Posición mensaje
        var position = 'right top';

        //Validar Campos obligatorios
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, descripcion, '¿Descripción requerida?', position);
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, nombre, '¿Cual es tu nombre?', position);
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, apellido, '¿Cual es tu apellido?', position);
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, correo, '¿Cual es tu correo?', position);
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, telefono, '¿Cual es tu telefono?', position);

        if (telefono.val().length > 0) {

            //Longitud maxima de campos
            resultado = p.gValidaciones.ValidarMaximo(info, resultado, telefono, 10, 'El telefono debe ser de 10 digitos maximo', position);

            //Longitud minimo de campos
            resultado = p.gValidaciones.ValidarMinimo(info, resultado, telefono, 7, 'El telefono debe ser de 7 digitos minimo', position);

            //Validaciones especiales
            resultado = p.gValidaciones.ValidarCampoNumerico(info, resultado, telefono, 'solo numeros', position);

        }

        if (correo.val().length > 0) {

            //Validaciones especiales
            resultado = p.gValidaciones.ValidarCorreo(info, resultado, correo, 'Correo incorrecto', position);
        }

        return resultado;
    }

    this.ValidarCambioClave = function fnValidarCambioClave()
    {
        var resultado = true;

        //Campos de Contraseña
        var conActual =   $('#txtContrasenaActual');
        var conNueva = $('#txtNuevaContrasena');
        var conConfirma = $('#txtNuevaConfirma');

        //Tipo de mensajes
        var info = 'info';
        var error = 'error';

        //Posición mensaje
        var position = 'left top';

        //Validar Campos obligatorios
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, conActual, '¿Cual es tu Contraseña?', position);
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, conNueva, '¿Cual es tu Contraseña nueva?', position);
        resultado = p.gValidaciones.CampoObligatorio(error, resultado, conConfirma, '¿Cual es tu Contraseña nueva?', position);

        if (conActual.val() != '') {

            //Longitud maxima de campos
            resultado = p.gValidaciones.ValidarMaximo(info, resultado, conActual, 20, 'Tu Contraseña es muy larga', position);
            resultado = p.gValidaciones.ValidarMaximo(info, resultado, conNueva, 20, 'Tu Contraseña es muy larga', position);
            resultado = p.gValidaciones.ValidarMaximo(info, resultado, conConfirma, 20, 'Tu Contraseña es muy larga', position);

            //Longitud minima Permitida
            resultado = p.gValidaciones.ValidarMinimo(info, resultado, conActual, 3, 'Debe ser de 6 digitos minimo', position);
            resultado = p.gValidaciones.ValidarMinimo(info, resultado, conNueva, 6, 'Debe ser de 6 digitos minimo', position);
            resultado = p.gValidaciones.ValidarMinimo(info, resultado, conConfirma, 6, 'Debe ser de 6 digitos minimo', position);
        }

        return resultado;
    }
};