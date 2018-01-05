//Variable Global
//var tabla;
//Función que se ejecutara al inicio
function init() {
    mostrarForm(false);
    //listar();
    $("#formulario").on("submit", function (e) {
        //guardaryeditar(e);
    })
}
//Función para limpiar los campos del formulario
function limpiar() {
    $("#departamento").val("");
}
//Función Mostrar Formulario
function mostrarForm(flag) {
    limpiar();
    if (flag) {
        $("#listadoregistros").hide();
        $("#formularioregistros").show();
        $("#btnGuardar").prop("disabled", false);
        $("#btnAgregar").hide();
    } else {
        $("#listadoregistros").show();
        $("#formularioregistros").hide();
        $("#btnAgregar").show();
    }
}
//Función Cancelar Formulario
function cancelarForm() {
    limpiar();
    mostrarForm(false);
}
//Función Listar
//function listar() {
//    tabla = $("#tbllistado").dataTable({
//        "aProcessing": true, //Activa Procesamiento de DataTables
//        "aServerSide": true, //Paginación y filtrado realizado por el servidor
//        dom: "Bfrtip",
//        buttons: [
//            "copyHtml5",
//            "excelHtml5",
//            "csvHtml5",
//            "pdf"
//        ],
//        "ajax": {
//            url: "../ajax/categoria.php?op=listar",
//            type: "get",
//            dataType: "json",
//            error: function (e) {
//                console.log(e.responseText);
//            }
//        },
//        "bDestroy": true,
//        "iDisplayLength": 5,
//        "order": [[0, "desc"]]
//    }).DataTable();
//}
////Función Guardar o Editar
//function guardaryeditar(e) {
//    e.preventDefault(); //No se activará la acción predeterminada del botón
//    $("#btnGuardar").prop("disabled", true);
//    var formData = new FormData($("#formulario")[0]);
//    $.ajax({
//        url: "../ajax/categoria.php?op=guardaryeditar",
//        type: "POST",
//        data: formData,
//        contentType: false,
//        processData: false,
//        success: function (datos) {
//            swal(datos, "", "success");
//            //alert(datos);
//            mostrarForm(false);
//            tabla.ajax.reload();
//        }
//    });
//    limpiar();
//}
////Función para Mostrar en el formulario los datos que se enviaran a Editar
//function mostrar(idcategoria) {
//    $.post("../ajax/categoria.php?op=mostrar", { idcategoria: idcategoria }, function (data, status) {
//        data = JSON.parse(data);
//        mostrarForm(true);
//        $("#idcategoria").val(data.idcategoria);
//        $("#nombre").val(data.nombre);
//        $("#descripcion").val(data.descripcion);
//    });
//}
////Funcion para Activar Categoría
//function activar(idcategoria) {
//    swal({
//        title: '¿Está seguro que desea activar la categoría?',
//        text: "",
//        type: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Confirmar'
//    }).then((result) => {
//        if (result.value) {
//            $.post("../ajax/categoria.php?op=activar", { idcategoria: idcategoria }, function (e) {
//                tabla.ajax.reload();
//                swal(
//                    e,
//                    '',
//                    'success'
//                )
//            })
//        }
//    })
//}
init();