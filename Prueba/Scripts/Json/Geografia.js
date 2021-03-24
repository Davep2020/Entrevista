$(function () {

    estableceEventosChange();

    cargaDropdownListProvincias();
});


function estableceEventosChange() {
    $("#provincia").change(function () {
        var provincia = $("#provincia").val();
        cargaDropdownListCantones(provincia);
    });
    $("#canton").change(function () {
        var canton = $("#canton").val();
        cargarDropdownListDistritos(canton);
    });
}



function cargaDropdownListProvincias() {

    var url = '/Personas/RetornaProvincias';

    var parametros = {
    };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoProvincias(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}


function procesarResultadoProvincias(data) {
    var ddlProvincia = $("#provincia");
    ddlProvincia.empty();
    var nuevaOpcion = "<option value=''>Seleccione una provincia</option>";
    ddlProvincia.append(nuevaOpcion);

    $(data).each(function () {
        var provinciaActual = this;
        nuevaOpcion = "<option value='" + provinciaActual.id_Provincia + "'>" + provinciaActual.nombre + "</option>";
        ddlProvincia.append(nuevaOpcion);
    });
}


function cargaDropdownListCantones(pIdProvincia) {


    var url = '/Personas/RetornaCantones';

    var parametros = {
        id_Provincia: pIdProvincia
    };
  
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoCantones(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}


function procesarResultadoCantones(data) {
    var ddlCantones = $("#canton");
    ddlCantones.empty();
    nuevaOpcion = "<option value=''>Seleccione un Cantón</option>";
    ddlCantones.append(nuevaOpcion);
    $(data).each(function () {
        var cantonActual = this;
        nuevaOpcion = "<option value='" + cantonActual.id_Canton + "'>" + cantonActual.nombre + "</option>";
        ddlCantones.append(nuevaOpcion);
    });
}

function cargarDropdownListDistritos(pId_Canton) {

    var url = '/Personas/RetornaDistritos';

    var parametros = {
        id_Canton: pId_Canton
    };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoDistritos(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}
function procesarResultadoDistritos(data) {
    var ddlDistritos = $("#distrito");
    ddlDistritos.empty();
    nuevaOpcion = "<option value=''>Seleccione un Distrito</option>";
    ddlDistritos.append(nuevaOpcion);
    $(data).each(function () {
        var DistritoActual = this;
        nuevaOpcion = "<option value='" + DistritoActual.id_Distrito + "'>" + DistritoActual.nombre + "</option>";
        ddlDistritos.append(nuevaOpcion);
    });
}