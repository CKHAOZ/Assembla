(function Cargar_Sitio_Master_Page_Condai() {

    window.CargarSitioMasterPage = new (function fnCargarSitioMasterPage() {

        var p = {
            gNotify: new NotiFy(),
            gToastr: new Toastr(),
            gValidaciones: new Validaciones(),
            gSeguridad: new Seguridad(),
            gTools: new Tools(),
            gCargando: new Cargando(),
            pCondaiMaster: new CondaiMaster(),
            pUsuarioPage: new UsuarioPage(),
            pCondai: new Condai()
        };

        this.InicioCargarSitioMasterPage = function fnCargarSitioMasterPage() {

            //General
            p.gToastr.Cargar();
            p.gNotify.Cargar();
            p.gValidaciones.Cargar(p);
            p.gSeguridad.Cargar();
            p.gCargando.Cargar('divCargando');

            //Paginas
            p.pCondaiMaster.Cargar(p);
            p.pUsuarioPage.Cargar(p);
            p.pCondai.Cargar(p);
        }

    })();

})();