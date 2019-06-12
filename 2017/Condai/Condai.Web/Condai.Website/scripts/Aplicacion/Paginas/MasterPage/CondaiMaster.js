function CondaiMaster() {
    //Guarda el Contexto
    var that = this;
    var p = null;

    this.Cargar = function fnCargar(paginas) {
        p = paginas;
        this.Eventos();
        this.CargarListadoMenu();
    };

    //General
    this.Eventos = function fnEventos() {
        var evento = 'click';

        //Evento
        $('#btnCloseSesion').bind(evento, that.CerrarSesion);
    }

    //Metodos
    this.CerrarSesion = function fnCerrarSesion() {
        document.getElementById("lnkCerrarSesion").click();
    }

    //Cargar Menú
    this.CargarMenu = function fnCargarMenu(listadoMenu) {

        if (listadoMenu != null) {

            var menuMP = $('#divMenuMP').empty();

            var listaBotones = $('<ul>', { 'id': 'divMenuUl' });

            for (var i = 0; i < listadoMenu.length; i++) {
                var item = listadoMenu[i];

                var boton = $('<li>', { 'class': 'espacioMenu' });

                boton.append($('<a>', {
                    'class': 'icon icon-' + item.menIcono + ' btnMenu',
                    'href': item.menDireccion
                })
                        .append($('<span>')
                                .append(item.menNombre)
                        )
                    );

                listaBotones.append(boton);
            }

            var contenidoMenu = $('<div>', { 'class': 'divMenuCentrado' })
                                    .append($('<div>', { 'class': 'divMenu' })
                                       .append(listaBotones)
                                 );

            menuMP.append(contenidoMenu);
        }
    }

    //Get Data Menú
    this.CargarListadoMenu = function fnCargarListadoMenu() {

        var bllMasterPage = new BllMasterPage();

        bllMasterPage.ObtenerMenu
            (
                function success(data) {
                    //Render Menú
                    that.CargarMenu(JSON.parse(data));
                },
                function error(data) {
                    p.gToastr.Ver('error', 'Error leyendo menú.');
                }
            );
    }
};