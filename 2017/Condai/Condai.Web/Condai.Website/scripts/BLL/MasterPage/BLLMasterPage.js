function BllMasterPage() {

}

BllMasterPage.prototype.ObtenerMenu = function (success, error) {

    ServerCondai.Web.MasterPage.ObtenerMenu
    (
        function onSuccess(data) {
            success(data);
        },
        function onFailed(error) {
            error(data);
        }
    );
};