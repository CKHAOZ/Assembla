function Validaciones() {
    //Guarda el Contexto
    var that = this;
    var p = null;

    this.Cargar = function fnCargar(paginas) {
        p = paginas;
    };

    //Generales

    // El campo obligatorio siempre es tipo error.
    this.CampoObligatorio = function fnCampoObligatorio(tipo, resultadoOrigen, campo, mensaje, position) {
        var resultado = resultadoOrigen;

        if (position == null) {
            position = 'right top';
        }

        if (campo.val().length == 0) {
            resultado = false;
            p.gNotify.Ver(tipo, campo, mensaje, position);
        }

        return resultado;
    }

    //Validar Campo Numerico
    this.ValidarCampoNumerico = function fnValidarCampoNumerico(tipo, resultadoOrigen, campo, mensaje, position) {
        var resultado = resultadoOrigen;

        var campoNumerico = campo.val();

        if (position == null) {
            position = 'right top';
        }

        if (campo.val().length > 0) {
            var letrasOCaracteres = campoNumerico.match(/\D/g);

            if (letrasOCaracteres != null &&
                letrasOCaracteres.length > 0) {

                resultado = false;

                p.gNotify.Ver(tipo, campo, mensaje, position);
            }
        }

        return resultado;
    }

    //Validar maximo con respecto al length de un campo
    this.ValidarMaximo = function fnValidarMaximo(tipo, resultadoOrigen, campo, max, mensaje, position) {
        var resultado = resultadoOrigen;

        if (position == null) {
            position = 'right top';
        }

        if (campo.val().length > max) {

            resultado = false;

            p.gNotify.Ver(tipo, campo, mensaje, position);
        }

        return resultado;
    }

    //Validar minimo con respecto al length de un campo
    this.ValidarMinimo = function fnValidarMinimo(tipo, resultadoOrigen, campo, min, mensaje, position) {
        var resultado = resultadoOrigen;

        if (position == null) {
            position = 'right top';
        }

        if (campo.val().length < min) {

            resultado = false;

            p.gNotify.Ver(tipo, campo, mensaje, position);
        }

        return resultado;
    }

    //Validar que un campo sea igual al length enviado
    this.ValidarIgual = function fnValidarIgual(tipo, resultadoOrigen, campo, equal, mensaje, position) {
        var resultado = resultadoOrigen;

        if (position == null) {
            position = 'right top';
        }

        if (campo.val().length != equal) {

            resultado = false;

            p.gNotify.Ver(tipo, campo, mensaje, position);
        }

        return resultado;
    }

    //Validar RegEx ' ' espacio
    this.ValidarEspacio = function fnValidarEspacio(tipo, resultadoOrigen, campo, mensaje, position) {
        var resultado = resultadoOrigen;

        var correo = campo.val();

        if (position == null) {
            position = 'right top';
        }

        if (campo.length > 0) {

            var valorABuscar = correo.match(/\s/g);

            if (valorABuscar != null &&
                valorABuscar.length > 0) {

                resultado = false;

                p.gNotify.Ver(tipo, campo, mensaje, position);
            }
        }

        return resultado;
    }

    //Validar RegEx @
    this.ValidarArroba = function fnValidarArroba(tipo, resultadoOrigen, campo, mensaje, position) {
        var resultado = resultadoOrigen;

        var correo = campo.val();

        if (position == null) {
            position = 'right top';
        }

        if (campo.length > 0) {

            var valorABuscar = correo.match(/\@/g);

            if (valorABuscar == null ||
                valorABuscar.length == 0) {

                resultado = false;

                p.gNotify.Ver(tipo, campo, mensaje, position);
            }
        }

        return resultado;
    }

    //Validar RegEx . Punto
    this.ValidarPunto = function fnValidarPunto(tipo, resultadoOrigen, campo, mensaje, position) {
        var resultado = resultadoOrigen;

        var correo = campo.val();

        if (position == null) {
            position = 'right top';
        }

        if (campo.length > 0) {

            var valorABuscar = correo.match(/\./g);

            if (valorABuscar == null ||
                valorABuscar.length == 0) {

                resultado = false;

                p.gNotify.Ver(tipo, campo, mensaje, position);
            }
        }

        return resultado;
    }


    //Compuestas

    //Validar Correo electronico
    this.ValidarCorreo = function fnValidarCorreo(tipo, resultadoOrigen, campo, mensaje, position) {
        var resultado = resultadoOrigen;

        //Validar Espacios
        resultado = that.ValidarEspacio(tipo, resultadoOrigen, campo, 'El Email no debe tener espacios', position);

        //Validar arroba
        resultado = that.ValidarArroba(tipo, resultadoOrigen, campo, mensaje, position);

        //Validar punto
        resultado = that.ValidarPunto(tipo, resultadoOrigen, campo, mensaje, position);

        return resultado;
    }

};