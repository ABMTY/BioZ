$(document).ready(function () {
    $("#secc_form").hide();
    $('#tbllistado').DataTable();
    listar();
});

//Listar Empleado
function listar() {
    $('#tbllistado').DataTable({
        destroy: true,
        searching: true,
        "ajax": {
            "url": "/Empleado/GetEmpleados/",
            "type": "GET"
        },
        "columns": [
            { "defaultContent": "" },
            { "data": "nombre" },
            { "data": "nombre_completo" },
            { "data": "desc_departamento" },
            { "data": "desc_sucursal" },
            { "data": "enrollnumber" },
            { "defaultContent": "" },

        ],
        "columnDefs": [{
            "targets": 0, "data": "id_empleado", "render": function (data, type, full, meta) {
                return "<button type='button' title='Editar' id='btn_mas" + data + "' class='btn btn-warning' onclick='verDetalle(" + data + ")'  ><i class='fa fa-edit'></i></button>"
            }
        },
        {
            "targets": 6, "data": "imagen", "render": function (data, type, full, meta) {
                if (data != null) {
                    var url = "data:image/png;base64," + data;
                    return "<img src=" + url + " width='60px;' height='50px;' />"
                } else {
                    return "<p></p>"
                }

            }
        }]
    });
}

//Listar Departamentos
function listarDepartamentos() {
    $.ajax({
        url: "/Departamento/GetDepartamentos/",
        async: true,
        beforeSend: function () { },
        dataType: "json",
        data: '{ }',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            $.each(data.data, function (i, Item) {
                $("#departamento").append("<option value='" + Item.id_departamento + "'>" + Item.desc_departamento + "</option>")
            });
            $('#departamento').selectpicker('refresh');
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

//Listar Sucursales
function listarSucursales() {
    $.ajax({
        url: "/Sucursal/GetSucursales/",
        async: true,
        beforeSend: function () { },
        dataType: "json",
        data: '{ }',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            $.each(data.data, function (i, Item) {
                $("#sucursal").append("<option value='" + Item.id_sucursal + "'>" + Item.desc_sucursal + "</option>")
            });
            $('#sucursal').selectpicker('refresh');
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

//Mostrar Formulario de Agregar
function Agregar() {
    $("#listadoregistros").hide();
    $("#secc_form").show();
    $("#btnAgregar").hide();
    limpiar();
    listarDepartamentos();
    listarSucursales();
}

//No envia los datos del formulario y carga la tabla
function cancelarForm() {
    $("#listadoregistros").show();
    $("#secc_form").hide();
    $("#btnAgregar").show();
    limpiar();
}

//Limpia los campos del formulario
function limpiar() {
    $("#id_empleado").val("");
    $("#nombre").val("");
    $("#ap_paterno").val("");
    $("#ap_materno").val("");
    $("#id_departamento").val("");
    $("#id_sucursal").val("");
    $("#enrollnumber").val("");
    $("#sucursal").html("");
    $("#departamento").html("");
    $("#imgBase64").text("");
    $("#subirImagen").val("");
    document.getElementById("imagen").src = "";
    document.getElementById("imagenOriginal").src = "";
}

//Funcion para Guardar y Editar Empresa
function guardarEditar() {
    var e = document.getElementById("departamento");
    var departamento = e.options[e.selectedIndex].value;
    $("#id_departamento").val(departamento);

    var s = document.getElementById("sucursal");
    var sucursal = s.options[s.selectedIndex].value;
    $("#id_sucursal").val(sucursal);

    parametros = {
        "id_empleado": $("#id_empleado").val(),
        "nombre": $("#nombre").val(),
        "ap_paterno": $("#ap_paterno").val(),
        "ap_materno": $("#ap_materno").val(),
        "id_departamento": $("#id_departamento").val(),
        "id_sucursal": $("#id_sucursal").val(),
        "enrollnumber": $("#enrollnumber").val(),
        "imagen": $("#imgBase64").text()
    }
    $.ajax({
        url: "/Empleado/Guardar/",
        async: true,
        dataType: "json",
        beforeSend: function () { },
        data: JSON.stringify(parametros),
        cache: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            cancelarForm();
            swal({ title: "Empleado", text: "Registrado Correctamente", type: "success" }, function () { listar(); limpiar();});
        },
        error: function (request, status, error) {
            +
                cancelarForm();
            swal({ title: "Error", text: "al guardar el Empleado", type: "error" }, function () { listar(); limpiar(); });
        }
    });
}

//Funcion Editar Sucursal
function verDetalle(id_empleado) {
    $("#listadoregistros").hide();
    $("#secc_form").show();
    $("#btnAgregar").hide();
    $.ajax({
        url: "/Empleado/GetEmpleado/" + id_empleado,
        async: true,
        beforeSend: function () { },
        dataType: "json",
        data: '{ }',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            var imagen = data.data.imagen;
            $("#departamento").html("");
            $("#sucursal").html("");
            $("#id_empleado").val(data.data.id_empleado);
            $("#id_departamento").val(data.data.id_departamento);
            $("#id_sucursal").val(data.data.id_sucursal);
            $("#nombre").val(data.data.nombre);
            $("#ap_paterno").val(data.data.ap_paterno);
            $("#ap_materno").val(data.data.ap_materno);
            $("#enrollnumber").val(data.data.enrollnumber);
            listarDepartamentos();
            $("#departamento").append("<option value=" + data.data.id_departamento + ">" + data.data.desc_departamento + "</option>");
            $("#departamento").selectpicker('refresh');
            listarSucursales();
            $("#sucursal").append("<option value=" + data.data.id_sucursal + ">" + data.data.desc_sucursal + "</option>");
            $("#sucursal").selectpicker('refresh');
            $("#imgBase64").text(imagen)
            document.getElementById("imagenOriginal").src = "data:image/png;base64," + imagen;
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
            //alert(Logo)
            document.getElementById("imagen").src = srcData;
            document.getElementById("imgBase64").textContent = Logo;

        }
        archivoLeer.readAsDataURL(archivoCargar);
    }
}