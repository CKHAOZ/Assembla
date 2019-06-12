function BllLogin()
{
    
}

BllLogin.prototype.GuardarInquietud = function (contacto, success, error) {
  
    ServerCondai.Web.Login.GuardarInquietud
    (
        JSON.stringify(contacto),
        function onSuccess(data) {
            success(data);
        },
        function onFailed(error) {
            error(data);
        }
    );
};
