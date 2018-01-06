$(document).ready(function () {
    $("#secc_form").hide();
    $('#tbllistado').DataTable();
    listar();
});

//Listar las Empresas
function listar() {
    $('#tbllistado').DataTable({
        destroy: true,
        searching: true,
        "ajax": {
            "url": "/Departamento/GetDepartamentos/",
            "type": "GET"
        },
        "columns": [
            { "defaultContent": "" },
            { "data": "desc_departamento" }
        ],
        "columnDefs": [{
            "targets": 0, "data": "id_departamento", "render": function (data, type, full, meta) {
                return "<button type='button' title='Editar' id='btn_mas" + data + "' class='btn btn-warning' onclick='verDetalle(" + data + ")'  ><i class='fa fa-edit'></i></button>"
            }
        }]
    });
}

//Mostrar Formulario de Agregar Empresa
function Agregar() {
    $("#listadoregistros").hide();
    $("#secc_form").show();
    $("#btnAgregar").hide();
    limpiar();
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
    $("#IdDepartamento").val("");
    $("#departamento").val("");
}

//Funcion para Guardar y Editar Empresa
function guardarEditar() {
    parametros = {
        "id_departamento": $("#IdDepartamento").val(),
        "desc_departamento": $("#departamento").val(),
    }
    $.ajax({
        url: "/Departamento/Guardar/",
        async: true,
        dataType: "json",
        beforeSend: function () { },
        data: JSON.stringify(parametros),
        cache: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            cancelarForm();
            swal({ title: "Departamento", text: "Registrado Correctamente", type: "success" }, function () { listar(); });
        },
        error: function (request, status, error) {+
            cancelarForm();
            swal({ title: "Error", text: "al guardar el Departamento", type: "error" }, function () { listar(); });
        }
    });
}

//Funcion Editar la Empresa
function verDetalle(id_departamento) {
    Agregar();
    $.ajax({
        url: "/Departamento/GetDepartamento/" + id_departamento,
        async: true,
        beforeSend: function () { },
        dataType: "json",
        data: '{ }',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            $("#IdDepartamento").val(data.data.id_departamento),
            $("#departamento").val(data.data.desc_departamento)
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