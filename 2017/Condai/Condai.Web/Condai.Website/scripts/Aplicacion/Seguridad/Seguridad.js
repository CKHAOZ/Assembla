function Seguridad() {
    //Guarda el Contexto
    var that = this;
    var Usuario;

    this.Cargar = function fnCargar() {
        this.CargarUsuarioActual();
    };

    this.GuardarUsuario = function fnGuardarUsuario(usuarioActual)
    {
        that.Usuario = usuarioActual;
    }

    this.ObtenerUsuarioActual = function fnObtenerUsuarioActual()
    {
        return that.Usuario;
    }

    this.CargarUsuarioActual = function fnCargarUsuarioActual()
    {
        if ($('#hdfSeguridadUsuario').val() != '') {
            that.Usuario = JSON.parse($('#hdfSeguridadUsuario').val())
        }
    }
};