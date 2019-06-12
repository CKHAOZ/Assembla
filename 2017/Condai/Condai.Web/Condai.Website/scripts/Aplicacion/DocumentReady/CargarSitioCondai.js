(function Cargar_Sitio_Condai() {

    window.CargarSitioCondai = new (function fnCargarSitioCondai() {

        var p = {
            gNotify: new NotiFy(),
            gToastr: new Toastr(),
            gValidaciones: new Validaciones(),
            gCargando: new Cargando(),
            pLogin: new Login()
        };

        this.InicioCargarSitioCondai = function fnInicioCargarSitioCondai() {

            //General
            p.gToastr.Cargar();
            p.gNotify.Cargar();
            p.gValidaciones.Cargar(p);
           
            //Paginas
            p.pLogin.Cargar(p);
        }

    })();

})();