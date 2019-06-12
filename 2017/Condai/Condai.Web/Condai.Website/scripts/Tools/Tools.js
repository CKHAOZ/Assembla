function Tools() {
    //Guarda el Contexto
    var that = this;

    //Date - Fechas - Formato
    this.LeerFecha = function fnLeerFecha(origen)
    {
        var resultado = '';

        var date = new Date(origen)
        
        if (date != null)
            resultado = date.format('dd/MM/yyyy hh:mm:ss');

        return resultado;
    }
};