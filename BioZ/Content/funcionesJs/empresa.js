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
            "url": "/Empresa/GetEmpresas/",
            "type": "GET"
        },
        "columns": [
            { "defaultContent": "" },
            { "data": "razon_social" },
            { "data": "direccion" },
            { "data": "estado" },
            { "data": "municipio" },
            { "defaultContent": "" }
        ],
        "columnDefs": [{
            "targets": 0, "data": "id_empresa", "render": function (data, type, full, meta) {
                return "<button type='button' title='Editar' id='btn_mas" + data + "' class='btn btn-warning' onclick='verDetalle(" + data + ")'  ><i class='fa fa-edit'></i></button>"
            }
        },
        {
            "targets": 5, "data": "imgBase64", "render": function (data, type, full, meta) {
                return "<img src=" + data + " width='30%;' height='30%;' />"
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
    $("#idEmpresa").val("");
    $("#razon_soc").val("");
    $("#direccion").val("");
    $("#estado").val("");
    $("#municipio").val("");
    $("#subirImagen").val("");
    $("#imgBase64").text("");
    document.getElementById("imagen").src = "";
}

//Funcion para Guardar y Editar Empresa
function guardarEditar() {
    parametros = {
        "id_empresa": $("#idEmpresa").val(),
        "razon_social": $("#razon_soc").val(),
        "direccion": $("#direccion").val(),
        "estado": $("#estado").val(),
        "municipio": $("#municipio").val(),
        "imgBase64": $("#imgBase64").text()
    }
    $.ajax({
        url: "/Empresa/Guardar/",
        async: true,
        dataType: "json",
        beforeSend: function () { },
        data: JSON.stringify(parametros),
        cache: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            cancelarForm();
            swal({ title: "Empresa", text: "Registrada Correctamente", type: "success" }, function () { listar(); });
        },
        error: function (request, status, error) {
            cancelarForm();
            swal({ title: "Error", text: "al guardar la Empresa", type: "error" }, function () { listar(); });
        }
    });
}

//Funcion Editar la Empresa
function verDetalle(id_empresa) {
    Agregar();
    $.ajax({
        url: "/Empresa/GetEmpresa/" + id_empresa,
        async: true,
        beforeSend: function () { },
        dataType: "json",
        data: '{ }',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            $("#idEmpresa").val(data.data.id_empresa),
            $("#razon_soc").val(data.data.razon_social),
            $("#direccion").val(data.data.direccion),
            $("#estado").val(data.data.estado),
            $("#municipio").val(data.data.municipio)
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

//Convertir imagen a base64
function convertirImagen() {
    var archivoImagen = document.getElementById("subirImagen").files;
    if (archivoImagen.length > 0) {
        var archivoCargar = archivoImagen[0];
        var archivoLeer = new FileReader();

        archivoLeer.onload = function (eventoCargarArchivo) {
            var srcData = eventoCargarArchivo.target.result; //Imagen base64
            //alert(srcData);
            var Logo = srcData.split(',')[1];
            alert(Logo)
            document.getElementById("imagen").src = srcData;
            document.getElementById("imgBase64").textContent = Logo;
            
        }
        archivoLeer.readAsDataURL(archivoCargar);
    }
}