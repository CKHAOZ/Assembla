function Condai() {
    //Guarda el Contexto
    var that = this;
    var p = null;

    //Carga inicial
    this.Cargar = function fnCargar(paginas) {
        p = paginas;
        this.MostrarMensaje();
        setTimeout(function () {
            if ($('#hdfCondai') != undefined &&
                $('#hdfCondai').val() == "1") {                
                $('#lblBienvenida').html('¡Bienvenido!');
                p.gCargando.Ocultar();
                that.IniciarPagina();
            }
        }, 1000);
    };

    //Metodos
    this.MostrarMensaje = function fnMostrarMensaje() {        
        $('#lblBienvenida').addClass('CondaiBienvenida');
    }

    //Iniciar página
    this.IniciarPagina = function fnIniciarPagina() {
        setTimeout(function () {
            $('#lblBienvenida').html('');
            $('#lblBienvenida').animate({ "margin-top": "10%" });
            $('#lblBienvenida').html('Por favor, seleccione una opción.');
            $('#lblBienvenida').animate({ "margin-top": "15%" });
        }, 3000);
    }
};