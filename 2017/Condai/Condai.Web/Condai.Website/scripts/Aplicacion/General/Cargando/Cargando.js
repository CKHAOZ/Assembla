function Cargando() {
    //Guarda el Contexto
    var that = this;
    var dialogo = null;

    this.Cargar = function fnCargar(origenDialogo) {
        that.dialogo = origenDialogo;
        this.ConfigurarModal();
        this.Modal();
    };

    this.Modal = function fnModal() {
        $("#" + that.dialogo).dialog({
            autoOpen: false,
            height: 160,
            width: 320,
            modal: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
            }
        });
    }

    this.ConfigurarModal = function fnConfigurarModal() {
        /* Información cargando */
        $("#" + that.dialogo).attr('title', 'Información');
        $("#" + that.dialogo).addClass('divCargando');
        $("#" + that.dialogo).append($('<label>', { 'id': 'lblIddialogoCargando' }).addClass('mensajeModal'));
        /* Animación de cargando */
        $("#" + that.dialogo).append(
            ($('<div>').addClass('pace pace-active animacionModal'))
                .append(($('<div>', { 'data-progress': '50', 'data-progress-text': '50%' })
                            .addClass('pace-progress bounceAnimation'))
                            .append($('<div>').addClass('pace-progress-inner'))
                            )
            .append($('<div>').addClass('pace-activity'))
        )
    }

    this.Ver = function fnVer(mensaje) {
        $("#lblIddialogoCargando").html(mensaje);
        $("#" + that.dialogo).dialog("open");
    }
    
    this.Ocultar = function fnOcultar(){
        $("#" + that.dialogo).dialog("close");
    }    
}