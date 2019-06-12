function Toastr() {
    //Guarda el Contexto
    var that = this;

    this.Cargar = function fnCargar() {
        this.Eventos();
    };
    
    this.Eventos = function fnEventos() {
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
    }

    /*
        1 - Success 
        2 - Info
        3 - Warning
        4 - Error        
    */

    this.Ver = function fnVer(tipo, mensaje) {

        switch (tipo) {
            case 'success':
                toastr.success(mensaje);
                break;

            case 'info':
                toastr.info(mensaje);
                break;

            case 'warn':
                toastr.warning(mensaje);
                break;

            case 'error':
                toastr.error(mensaje);
                break;

            default:
                toastr.success(mensaje);
                break;
        };
    };
};