function NotiFy() {
    //Guarda el Contexto
    var that = this;

    this.Cargar = function fnCargar() {
        this.Eventos();
    };

    this.Eventos = function fnEventos() {
        $.notify.defaults(
            {
                // whether to hide the notification on click
                clickToHide: true,
                // whether to auto-hide the notification
                autoHide: true,
                // if autoHide, hide after milliseconds
                autoHideDelay: 4000,
                // show the arrow pointing at the element
                arrowShow: true,
                // arrow size in pixels
                arrowSize: 5,
                // default style
                style: 'bootstrap',
                // default class (string or [string])
                className: 'error',
                // show animation
                showAnimation: 'slideDown',
                // show animation duration
                showDuration: 400,
                // hide animation
                hideAnimation: 'slideUp',
                // hide animation duration
                hideDuration: 200,
                // padding between element and notification
                gap: 2
            }
            );
    }

    /*
        1 - Success 
        2 - Info
        3 - warn
        4 - Error        
    */

    /*
        Position

        right top
        left top    
    */

    // El campo es el objeto en jquery.
    this.Ver = function fnVer(tipo, campo, mensaje, position) {

        switch (tipo) {
            case 'success':
                campo.notify(mensaje, { position: position, elementPosition: position, className: tipo });
                break;
            case 'info':
                campo.notify(mensaje, { position: position, elementPosition: position, className: tipo });
                break;
            case 'warn':
                campo.notify(mensaje, { position: position, elementPosition: position, className: tipo });
                break;
            case 'error':
                campo.notify(mensaje, { position: position, elementPosition: position, className: tipo });
                break;
            default:
                campo.notify(mensaje, { position: position, elementPosition: position, className: "success" });
                break;
        };
    };
};