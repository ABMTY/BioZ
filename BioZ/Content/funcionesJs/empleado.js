$(document).ready(function () {
    $("#secc_form").hide();
    $("#secc_webCam").hide();
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
            },
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
        },
        {
            "targets": 7, "data": "id_empleado", "render": function (data, type, full, meta) {
                return "<button type='button' class='btn btn-primary' id='btn_mas" + data + "' name='button' onclick='AgregarHuellaIdEmpleado(" + data + ")'><i class='fa fa-hand-pointer-o'></i></button>"
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
    document.getElementById("botones").style.display = "inline";
    limpiar();
    listarDepartamentos();
    listarSucursales();
}

//No envia los datos del formulario y carga la tabla
function cancelarForm() {
    $("#listadoregistros").show();
    $("#secc_form").hide();
    $("#secc_webCam").hide();
    $("#btnAgregar").show();
    document.getElementById("botones").style.display = "none";
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
    $("#base64").text("");
    document.getElementById("photo").src = "";
    document.getElementById("imagenOriginal").src = "";
    var canvas = document.getElementById("canvas");
    var ctx = canvas.getContext("2d");
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    document.getElementById("b").src = "";
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
        "imagen": $("#base64").text().split(',')[1]
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
    document.getElementById("botones").style.display = "inline"
    $("#btnAgregar").hide();
    document.getElementById("imgEditar").style.display = "inline";
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
            $("#base64").text(imagen)
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

//Capturar Foto con WebCam
function webCam() {
    $("#secc_webCam").show();
    document.getElementById("imgEditar").style.display = "none";
    var streaming = false,
       video = document.querySelector('#video'),
       canvas = document.querySelector('#canvas'),
       photo = document.querySelector('#photo'),
       startbutton = document.querySelector('#startbutton'),
       guardar = document.querySelector('#guardar'),
       width = 320,
       height = 0;

    navigator.getMedia = (navigator.getUserMedia ||
                           navigator.webkitGetUserMedia ||
                           navigator.mozGetUserMedia ||
                           navigator.msGetUserMedia);

    navigator.getMedia(
      {
          video: true,
          audio: false
      },
      function (stream) {
          if (navigator.mozGetUserMedia) {
              video.mozSrcObject = stream;
          } else {
              var vendorURL = window.URL || window.webkitURL;
              video.src = vendorURL.createObjectURL(stream);
          }
          video.play();
      },
      function (err) {
          console.log("An error occured! " + err);
      }
    );

    video.addEventListener('canplay', function (ev) {
        if (!streaming) {
            height = video.videoHeight / (video.videoWidth / width);
            video.setAttribute('width', width);
            video.setAttribute('height', height);
            canvas.setAttribute('width', width);
            canvas.setAttribute('height', height);
            streaming = true;
        }
    }, false);

    function takepicture() {
        canvas.width = width;
        canvas.height = height;
        canvas.getContext('2d').drawImage(video, 0, 0, width, height);
        var data = canvas.toDataURL('image/png');
        photo.setAttribute('src', data);
        //alert(data);
    }

    startbutton.addEventListener('click', function (ev) {
        document.getElementById("divPreview").style.display = "inline";
        document.getElementById("imgPreview").style.display = "none";
        document.getElementById("guardar").style.display = "inline";
        takepicture();
        ev.preventDefault();
    }, false);

    $('#photo').Jcrop({
        setSelect: [50, 50, 400, 150],
        aspectRatio: 1,
        bgColor: 'rgba(73,155,234,0.75)',
        onChange: updatePreview,
        onSelect: updatePreview,
    });

    function updatePreview(c) {
        if (parseInt(c.w) > 0) {
            var canvas = document.getElementById("preview");
            canvas.setAttribute("width", "100");
            canvas.setAttribute("height", "100");
            // Muestra preview de Imagen
            var imageObj = $("#photo")[0];
            var canvas = $("#preview")[0];
            var context = canvas.getContext("2d");
            context.drawImage(imageObj, c.x, c.y, c.w, c.h, 0, 0, canvas.width, canvas.height);
            var d = canvas.toDataURL('image/png');
            $("#base64").text(d);
        }
    }

    guardar.addEventListener('click', function (ev) {
        document.getElementById("divPreview").style.display = "none";
        document.getElementById("imgPreview").style.display = "inline";
        document.getElementById("guardar").style.display = "none";
        document.getElementById("b").src = $("#base64").text();
        ev.preventDefault();
    }, false);
}