$(document).ready(function () {
    $("#secc_form").hide();
    $('#tbllistado').DataTable();
    listar();
});

//Listar Sucursales
function listar() {
    $('#tbllistado').DataTable({
        destroy: true,
        searching: true,
        "ajax": {
            "url": "/Sucursal/GetSucursales/",
            "type": "GET"
        },
        "columns": [
            { "defaultContent": "" },
            { "data": "desc_sucursal" },
            { "data": "razon_social" }
        ],
        "columnDefs": [{
            "targets": 0, "data": "id_sucursal", "render": function (data, type, full, meta) {
                return "<button type='button' title='Editar' id='btn_mas" + data + "' class='btn btn-warning' onclick='verDetalle(" + data + ")'  ><i class='fa fa-edit'></i></button>"
            }
        }]
    });
}

function listarEmpresas() {
    $.ajax({
        url: "/Empresa/GetEmpresas/",
        async: true,
        beforeSend: function () { },
        dataType: "json",
        data: '{ }',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            //$("#empresa").html("");
            $.each(data.data, function (i, Item) {
                $("#empresa").append("<option value='" + Item.id_empresa + "'>" + Item.razon_social + "</option>")
            });
            $('#empresa').selectpicker('refresh');
        },
        xhr: function () {
            var xhr = $.ajaxSettings.xhr();
            xhr.onprogress = function (evt) {
                var porcentaje = Math.floor((evt.loaded / evt.total * 100));
            };
            return xhr;
        },
        error: function (request, status, error) {
            console.log("Error => " + error);
        }
    })
}

//Mostrar Formulario de Agregar Empresa
function Agregar() {
    $("#listadoregistros").hide();
    $("#secc_form").show();
    $("#btnAgregar").hide();
    limpiar();
    listarEmpresas();
}

//No envia los datos del formulario y carga la tabla de empresas
function cancelarForm() {
    $("#listadoregistros").show();
    $("#secc_form").hide();
    $("#btnAgregar").show();
    limpiar();
}

//Limpia los campos del formulario
function limpiar() {
    $("#id_sucursal").val("");
    $("#id_empresa").val("");
    $("#sucursal").val("");
    $("#descripcion").val("");
    $("#empresa").html("");
}

//Funcion para Guardar y Editar Empresa
function guardarEditar() {
    var e = document.getElementById("empresa");
    var empresa = e.options[e.selectedIndex].value;
    $("#id_empresa").val(empresa);

    parametros = {
        "id_sucursal": $("#id_sucursal").val(),
        "desc_sucursal": $("#sucursal").val(),
        "id_empresa": $("#id_empresa").val()
    }
    $.ajax({
        url: "/Sucursal/Guardar/",
        async: true,
        dataType: "json",
        beforeSend: function () { },
        data: JSON.stringify(parametros),
        cache: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            cancelarForm();
            swal({ title: "Sucursal", text: "Registrada Correctamente", type: "success" }, function () { listar(); });
        },
        error: function (request, status, error) {
            +
                cancelarForm();
            swal({ title: "Error", text: "al guardar la Sucursal", type: "error" }, function () { listar(); });
        }
    });
}

//Funcion Editar Sucursal
function verDetalle(id_sucursal) {
    $("#listadoregistros").hide();
    $("#secc_form").show();
    $("#btnAgregar").hide();
    $.ajax({
        url: "/Sucursal/GetSucursal/" + id_sucursal,
        async: true,
        beforeSend: function () { },
        dataType: "json",
        data: '{ }',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            $("#empresa").html("");
            $("#id_sucursal").val(data.data.id_sucursal);
            $("#id_empresa").val(data.data.id_empresa);
            $("#sucursal").val(data.data.desc_sucursal);
            listarEmpresas();
            $("#empresa").append("<option value=" + data.data.id_empresa + ">" + data.data.razon_social + "</option>");
            $("#empresa").selectpicker('refresh');
        },
        xhr: function () {
            var xhr = $.ajaxSettings.xhr();
            xhr.onprogress = function (evt) {
                var porcentaje = Math.floor((evt.loaded / evt.total * 100));
            };
            return xhr;
        },
        error: function (request, status, error) {
            console.log("Error => " + error);
        }
    })
}