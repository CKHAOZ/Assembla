function BLLSeguridad() {

}

BLLSeguridad.prototype.ValidarUsuario = function (usuario, contrasena, success, error) {

    ServerCondai.Web.Seguridad.ValidarUsuario
    (
        usuario,
        contrasena,
        function onSuccess(data) {
            success(data);
        },
        function onFailed(error) {
            error(data);
        }
    );
};

BLLSeguridad.prototype.ActualizarUsuario = function (usuario, success, error) {

    ServerCondai.Web.Seguridad.ActualizarUsuario
    (
        JSON.stringify(usuario),
        function onSuccess(data) {
            success(data);
        },
        function onFailed(error) {
            error(data);
        }
    );
};

BLLSeguridad.prototype.ActualizarContrasena = function (idUsuario, usuario, ContrasenaActual, ContrasenaNueva, success, error) {

    ServerCondai.Web.Seguridad.ActualizarContrasena
    (
        idUsuario,
        usuario,
        ContrasenaActual,
        ContrasenaNueva,
        function onSuccess(data) {
            success(data);
        },
        function onFailed(error) {
            error(data);
        }
    );
};