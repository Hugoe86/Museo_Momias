//****************************************************************************************************************************************************
//************************************************************** INICIO ******************************************************************************
//****************************************************************************************************************************************************

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : $(document).ready(function
///DESCRIPCIÓN          : Funcion para iniciar con los datos del formulario
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 21/Mayo/2014
///***********************************************************************************************************************
$(document).ready(function () {
    try {
        Inicializar_Formulario();

        $('.progressBackgroundFilter')
        .ajaxStart(function () { $(this).show(); })
        .ajaxStop(function () { $(this).hide(); });

        $('.progressBackgroundFilter').hide();
    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al ejecutar los eventos de la página. Error: [' + Ex + ']', 'error');
    }
});


//****************************************************************************************************************************************************
//*********************************************************** METODOS GENERALES **********************************************************************
//****************************************************************************************************************************************************

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Inicializar_Formulario
///DESCRIPCIÓN          : Funcion para inicializar el formulario
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 21/Mayo/2014
///***********************************************************************************************************************
function Inicializar_Formulario() {
    var Fecha = new Date();
    var Dia = Fecha.getDate();
    var Mes = Fecha.getMonth() + 1;
    var Anio = Fecha.getFullYear();
    var Fecha_Actual = Mes + '/' + Dia + '/' + Anio;

    try {
        //Evento del boton de salir
        $("input[id$=Btn_Compra]").click(function (e) {
            var Mes = "00" + $('#Cmb_Mes').combobox('getValue');
            var Anio = $('#Cmb_Anio').combobox('getValue');

            var forms = document.forms;
            var Response = document.getElementById("ResponsePath");
            var Ruta;
            var Indice;

            Response.value = forms[0].action;
            forms[0].action = "https://eps.banorte.com/recibo";

            Indice = Response.value.lastIndexOf("/") + 1;
            Ruta = Response.value.substring(0, Indice);
            Ruta += "Frm_Apl_Pago.aspx";
            Response.value = Ruta;

            Mes = Mes.substr(Mes.length - 2);
            Anio = Anio.substr(Anio.length - 2);

            $("#Txt_Fecha_Expiracion").val(Mes + "/" + Anio);

            Generar_Compra();
        });

        //evento del check box de email
        $("input:checkbox[id$=Chk_Enviar_Email]").click(function (e) {
            if ($("input:checkbox[id$=Chk_Enviar_Email]").attr('checked')) {
                $("[id$=Lbl_Email]").text("* Email:");
            }
            else {
                $("[id$=Lbl_Email]").text(" Email:");
            }
        });

        $('#Txt_Fecha').datebox({
            editable: false //indicamos que no se pueda escribir en el txt de la fecha
        });

        $('#Txt_Fecha').datebox('setValue', Fecha_Actual);
        $("input[id$=Hf_Fecha]").val(Fecha_Actual);

        $('#Txt_Fecha').datebox({
            onSelect: function (date) {
                $.messager.confirm('Confirm', 'Se perderá el detalle de la venta, ¿Está seguro de continuar? ', function (r) {
                    if (r) {
                        Limpiar_Controles();
                        $("input[id$=Hf_Fecha]").val($('#Txt_Fecha').datebox('getValue'));
                        Llenar_Grid_Productos();
                    } else {
                        $('#Txt_Fecha').datebox('setValue', $("input[id$=Hf_Fecha]").val());
                    }
                });
            }
        });

        $("input[id$=Hf_Total]").val(0);
        $("input[id$=Hf_No_Cantidad]").val(0);

        Consultar_Cantidad();
        Llenar_Grid_Productos();
        Llenar_Grid_Productos_Detalle();
        Llenar_Combo_Anio();
        Llenar_Combo_Mes();
    } 
    catch (Ex) {
        $.messager.alert('Mensaje', 'Error al iniciar los eventos de la página. Error: [' + Ex + ']', 'error');
    }
}


///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Generar_Cadena_Parametros
///DESCRIPCIÓN          : Funcion para generar la cadena de parametros
///PARAMETROS           1 Accion: funcion que ejecutaremos 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 21/Mayo/2014
///***********************************************************************************************************************
function Generar_Cadena_Parametros(Accion) {
    var Parametros = '';
    var Obj_Productos = new Object();
    var Obj_Prod = new Array();
    

    try {
        Parametros = "?Accion=" + Accion + "&Parametros="; //obtenemos los parametros
        Parametros += "{"; //inicio cadena
        if (Accion == 'Generar_Compra') {
            var Productos = JSON.stringify($('#Grid_Productos_Detalle').propertygrid('getData').rows);
            Parametros += "\"P_Productos\":" + encodeURI(Productos) + ",";
        }
        Parametros += "\"P_Nombre\":\"" + encodeURI($("input[id$=Txt_Nombre]").val()) + "\",";
        Parametros += "\"P_Estado\":\"" + encodeURI($("input[id$=Txt_Estado]").val()) + "\",";
        Parametros += "\"P_Ciudad\":\"" + encodeURI($("input[id$=Txt_Ciudad]").val()) + "\",";
        Parametros += "\"P_Domicilio\":\"" + encodeURI($("input[id$=Txt_Domicilio]").val()) + "\",";
        Parametros += "\"P_Codigo_Postal\":\"" + encodeURI($("input[id$=Txt_CP]").val()) + "\",";
        Parametros += "\"P_Telefono\":\"" + encodeURI($("input[id$=Txt_Telefono]").val()) + "\",";
        Parametros += "\"P_Email\":\"" + encodeURI($("input[id$=Txt_Email]").val()) + "\",";
        Parametros += "\"P_Total\":\"" + encodeURI($("[id$=Lbl_Total]").val().replace(/,/gi, '')) + "\",";
        Parametros += "\"P_Numero_Tarjeta\":\"" + encodeURI($("input[id$=Txt_Numero_Tarjeta]").val()) + "\",";
        Parametros += "\"P_Codigo_Seguridad\":\"" + encodeURI($("input[id$=Txt_Codigo_Seguridad]").val()) + "\",";
        Parametros += "\"P_Fecha_Expira\":\"" + encodeURI($('#Cmb_Mes').combobox('getValue')) + "/" + encodeURI($('#Cmb_Anio').combobox('getValue')) + "\",";

        if ($("input:checkbox[id$=Chk_Enviar_Email]").attr('checked')) {
            Parametros += "\"P_Enviar_Email\":\"SI\",";
        }
        else {
            Parametros += "\"P_Enviar_Email\":\"NO\",";
        }

        Parametros += "\"P_Fecha\":\"" + encodeURI($("input[id$=Hf_Fecha]").val()) +"\"";
        Parametros += "}"; //fin cadena
    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al crear la cadena de los parametros. Error: [' + Ex + ']', 'error');
    }

    return Parametros;
}


///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Limpiar_Controles
///DESCRIPCIÓN          : Funcion para limpiar los controles de la pantalla
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 22/Mayo/2014
///***********************************************************************************************************************
function Limpiar_Controles() {
    var Limpiar_Grid = { total: 0, rows: [] };
    var Fecha = new Date();
    var Anio = Fecha.getFullYear();
    var Mes = Fecha.getMonth() + 1;

    $('#Grid_Productos_Servicios').propertygrid('loadData', Limpiar_Grid);

    //Div 2
    $('#Grid_Productos_Detalle').propertygrid('loadData', Limpiar_Grid);
    $('#Grid_Productos_Detalle').datagrid('reloadFooter', [{ Cantidad: '', Descripcion: 'Total', Costo: '', Producto_Id: ' ', Subtotal: 0}]);

    //Div 3
    $("input[id$=Txt_Nombre]").val('');
    $("input[id$=Txt_Estado]").val('');
    $("input[id$=Txt_Ciudad]").val('');
    $("input[id$=Txt_Domicilio]").val('');
    $("input[id$=Txt_CP]").val('');
    $("input[id$=Txt_Telefono]").val('');
    $("input[id$=Txt_Email]").val('');
    $("[id$=Lbl_Total]").val('0.00');
    $("input[id$=Txt_Numero_Tarjeta]").val('');
    $("input[id$=Txt_Codigo_Seguridad]").val('');
    $("input[id$=Hf_Total]").val('');
    $("input[id$=Hf_Subtotal]").val('');
    $("input:checkbox[id$=Chk_Enviar_Email]").attr('checked', 'true');

     $("input[id$=Hf_Total_Producto]").val('0.00');
     $("input[id$=Hf_Total_Servicio]").val('0.00');

    $('#Cmb_Anio').combobox({
        value: Anio
    });

    $('#Cmb_Mes').combobox({
        value: Mes
    });
}


//****************************************************************************************************************************************************
//*********************************************************** METODOS FORMULARIOS ********************************************************************
//****************************************************************************************************************************************************

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Consultar_Cantidad
///DESCRIPCIÓN          : Funcion para obtener la cantidad de elementos que contendra el combo 
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 26/Mayo/2014
///***********************************************************************************************************************
function Consultar_Cantidad() 
{
    try 
    {
        $.ajax({
            url: "Frm_Apl_Principal_Controlador.aspx?Accion=Obtener_Cantidad",
            type: 'POST',
            async: false,
            cache: false,
            success: function (Datos) {
                if (Datos != null) {
                    $("input[id$=Hf_No_Cantidad]").val(Datos);
                }
                else {
                    $("input[id$=Hf_No_Cantidad]").val(10);
                }
            }
        });
    } 
    catch (Ex) {
        $.messager.alert('Mensaje', 'Error al consultar la cantidad. Error[' + Ex + ']', 'error');
    }
}

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Calcular_Total
///DESCRIPCIÓN          : Funcion para calcular el total del pedido
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 24/Mayo/2014
///***********************************************************************************************************************
function Calcular_Total() {
    var Total = 0;
    var Renglones;
    var i = 0;
    var Renglon;
    var Total_Productos = 0;
    var Total_Servicios = 0;

    try {

        //obtenemos todos los productos seleccionados para obtener el total
        Renglones = $('#Grid_Productos_Servicios').propertygrid('getData'); //obtenemos los renglones seleccionados
        //validamos si la cantidad es mayor a 0 para dejar el renglon seleccionado o deseleccinarlo
        for (i = 0; i < Renglones.total; i++) {
            Renglon = Renglones.rows[i];
            Total = Total + parseFloat(Renglon.Subtotal.replace(/,/gi, ''));
            
            if (Renglon.Tipo == "Producto") {
                Total_Productos = Total_Productos + parseFloat(Renglon.Subtotal.replace(/,/gi, ''));
            } else {
                Total_Servicios = Total_Servicios + parseFloat(Renglon.Subtotal.replace(/,/gi, ''));
            }
        }

        $("input[id$=Hf_Total]").val(Total);
        $("input[id$=Hf_Total]").formatCurrency({ colorize: true, region: 'es-MX' });
        $("[id$=Lbl_Total]").val(Total);
        $("[id$=Lbl_Total]").formatCurrency({ colorize: true, region: 'es-MX' });

        $("input[id$=Hf_Total_Producto]").val(Total_Productos);
        $("input[id$=Hf_Total_Producto]").formatCurrency({ colorize: true, region: 'es-MX' });
        $("input[id$=Hf_Total_Servicio]").val(Total_Servicios);
        $("input[id$=Hf_Total_Servicio]").formatCurrency({ colorize: true, region: 'es-MX' });
    }
    catch (Ex) {
        $.messager.alert('Mensaje', 'Error al calcular el total. Error[' + Ex + ']', 'error');
    }
}

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Eliminar_Registro_Pedido
///DESCRIPCIÓN          : Funcion para eliminar un registro del grid de detalles
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 24/Mayo/2014
///***********************************************************************************************************************
function Eliminar_Registro_Pedido(Producto_Id, Indice) {
    var Renglones;
    try {
        //eliminamos el registro del grid
//        $('#Grid_Productos_Detalle').propertygrid('deleteRow', Indice);

        //obtenemos todos los productos para quitar la cantidad del total y recalcular el total
        Renglones = $('#Grid_Productos_Servicios').propertygrid('getData'); //obtenemos los renglones seleccionados
        //validamos si la cantidad es mayor a 0 para dejar el renglon seleccionado o deseleccinarlo
        for (i = 0; i < Renglones.total; i++) {
            Renglon = Renglones.rows[i];
            if (Producto_Id == Renglon.Producto_Id) {
                Renglon.Subtotal = '0.00';
                Renglon.Cantidad = 0;
                $('#Grid_Productos_Servicios').propertygrid('refreshRow', i); //actualizamos el registro
            }
        }

        Calcular_Total(); //calculamos el total

        //actualizamos el footer del grid con el total
        //actualizamos el total del grid de detalles
        $('#Grid_Productos_Detalle').datagrid('reloadFooter',
             [{ Cantidad: '', Descripcion: 'Total Productos', Costo: '', Producto_Id: ' ', Subtotal: $("input[id$=Hf_Total_Producto]").val() },
             { Cantidad: '', Descripcion: 'Total Servicios', Costo: '', Producto_Id: ' ', Subtotal: $("input[id$=Hf_Total_Servicio]").val() },
             { Cantidad: '', Descripcion: 'Total', Costo: '', Producto_Id: ' ', Subtotal: $("input[id$=Hf_Total]").val() }
             ]);

        //Obtenemos los datos del grip para actualizar los indices
        //        Renglones = $('#Grid_Productos_Detalle').propertygrid('getData'); //obtenemos los renglones seleccionados
        Renglones = $('#Grid_Productos_Servicios').propertygrid('getChanges');
        Renglones = Acomodar_Datos_Detalle(Renglones);
        $('#Grid_Productos_Detalle').propertygrid('loadData', Renglones); //cargamos los datos en el grid de detalles del pedido

    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al eliminar el registro de la tabla. Error[' + Ex + ']', 'error');
    }
}

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Validar_Cantidad_Productos
///DESCRIPCIÓN          : Funcion para dejar seleccionados solo los productos con cantidad mayor a 0
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 23/Mayo/2014
///***********************************************************************************************************************
function Validar_Cantidad_Productos() {
    var Renglones;
    var i = 0;
    var Renglon;
    var Indice = '';
    var Editor_Cantidad = '';
    var Cantidad = 0;
    var Costo = 0;
    var Subtotal = 0;
    var Total = 0;

    try {

        Renglon = $('#Grid_Productos_Servicios').propertygrid('getSelected'); //obtenemos el renglon que estamos trabajando

        if (Renglon) {
            Indice = $('#Grid_Productos_Servicios').propertygrid('getRowIndex', Renglon); //obtenemos el index del renglon
            Costo = parseFloat(Renglon["Costo"].replace(/,/gi, ''));

            //obtenemos el editor del combobox de la cantidad
            Editor_Cantidad = $('#Grid_Productos_Servicios').propertygrid('getEditor', { index: Indice, field: 'Cantidad' });
            Cantidad = $(Editor_Cantidad.target).numberbox("getValue");

            Subtotal = Cantidad * Costo;

            //le damos formato al subtotal
            $("input[id$=Hf_Subtotal]").val(Subtotal);
            $("input[id$=Hf_Subtotal]").formatCurrency({ colorize: true, region: 'es-MX' });

            Renglon["Subtotal"] = $("input[id$=Hf_Subtotal]").val();

            //cerramos la edicion del grid para que nos tome la cantidad registrada
            $('#Grid_Productos_Servicios').propertygrid('endEdit', Indice);
        }

        Calcular_Total(); //calculamos el total del pedido

        Renglones = $('#Grid_Productos_Servicios').propertygrid('getChanges'); //obtenemos los renglones seleccionados

        Renglones = Acomodar_Datos_Detalle(Renglones);

        $('#Grid_Productos_Detalle').propertygrid('loadData', Renglones); //cargamos los datos en el grid de detalles del pedido
        
        //actualizamos el total del grid de detalles
        $('#Grid_Productos_Detalle').datagrid('reloadFooter',
             [{ Cantidad: '', Nombre: 'Total Productos', Costo: '', Producto_Id: ' ', Subtotal: $("input[id$=Hf_Total_Producto]").val() },
             { Cantidad: '', Nombre: 'Total Servicios', Costo: '', Producto_Id: ' ', Subtotal: $("input[id$=Hf_Total_Servicio]").val() },
             { Cantidad: '', Nombre: 'Total', Costo: '', Producto_Id: ' ', Subtotal: $("input[id$=Hf_Total]").val() }
             ]);
    }
    catch (Ex) {
        $.messager.alert('Mensaje', 'Error al validar los productos seleccionados. Error[' + Ex + ']', 'error');
    }
}

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Acomodar_Datos_Detalle
///DESCRIPCIÓN          : Funcion para aconmodar los datos del detalle del grid
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 06/junio/2014
///***********************************************************************************************************************
function Acomodar_Datos_Detalle(Obj_Registros) {
    var Registros = new Array();
    var Registro;
    var Contador = -1;

    try {
        if (Obj_Registros.length > 0) {
            for (var i = 0; i < Obj_Registros.length; i++) {
                Registro = Obj_Registros[i];
                if (Registro.Cantidad > 0) {
                    Contador++;
                    Registros[Contador] = new Object()
                    Registros[Contador] = Registro;
                }
            }
        }

    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al validar los productos seleccionados. Error[' + Ex + ']', 'error');
    }
    return Registros;
}

//*****************************************************************************************************************************************************
//*********************************************************** COMBOS **********************************************************************************
//*****************************************************************************************************************************************************

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Llenar_Combo_Anio
///DESCRIPCIÓN          : Funcion para llenar el combo de los años
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 26/Mayo/2014
///***********************************************************************************************************************
function Llenar_Combo_Anio() {
    var Anios = new Array();
    var i;
    var Numero = 0;
    var Fecha = new Date();
    var Anio_Actual = Fecha.getFullYear();

    try {
        //obtenemos el numero de elementos que se asignaran
        Numero = parseInt($("input[id$=Hf_No_Cantidad]").val(), 10);

        //construimos dinamicamente la cadena con formato json para llenar los años
        for (i = 0; i <= Numero; i++) {
            Anios[i] = new Object();
            Anios[i].Anio_Id = Anio_Actual + i;
            Anios[i].Anio = Anio_Actual + i;
        }

        //llenamos el combo de años
        $('#Cmb_Anio').combobox({
            valueField: 'Anio_Id',
            textField: 'Anio',
            data: Anios,
            editable: false, //indicamos que no se pueda escribir en el combo
            value: Anio_Actual, //valor por default seleccionado
            formatter: function (row) {
                var opts = $(this).combobox('options');
                return '<span style="font-size:8pt; font-family:Consolas; color:black;">' + row[opts.textField] + '</span>';
            }
        });

    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al llenar el combo de Años. Error[' + Ex + ']', 'error');
    }
}

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Llenar_Combo_Mes
///DESCRIPCIÓN          : Funcion para llenar el combo de los meses
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 26/Mayo/2014
///***********************************************************************************************************************
function Llenar_Combo_Mes() {
    var Meses = new Array();
    var Fecha = new Date();
    var Mes = Fecha.getMonth() + 1;

    try {
        Meses[0] = new Object();
        Meses[0].Mes_Id = 1;
        Meses[0].Mes = "Ene";

        Meses[1] = new Object();
        Meses[1].Mes_Id = 2;
        Meses[1].Mes = "Feb";

        Meses[2] = new Object();
        Meses[2].Mes_Id = 3;
        Meses[2].Mes = "Mar";

        Meses[3] = new Object();
        Meses[3].Mes_Id = 4;
        Meses[3].Mes = "Abr";

        Meses[4] = new Object();
        Meses[4].Mes_Id = 5;
        Meses[4].Mes = "May";

        Meses[5] = new Object();
        Meses[5].Mes_Id = 6;
        Meses[5].Mes = "Jun";

        Meses[6] = new Object();
        Meses[6].Mes_Id = 7;
        Meses[6].Mes = "Jul";

        Meses[7] = new Object();
        Meses[7].Mes_Id = 8;
        Meses[7].Mes = "Ago";

        Meses[8] = new Object();
        Meses[8].Mes_Id = 9;
        Meses[8].Mes = "Sep";

        Meses[9] = new Object();
        Meses[9].Mes_Id = 10;
        Meses[9].Mes = "Oct";

        Meses[10] = new Object();
        Meses[10].Mes_Id = 11;
        Meses[10].Mes = "Nov";

        Meses[11] = new Object();
        Meses[11].Mes_Id = 12;
        Meses[11].Mes = "Dic";


        //llenamos el combo de años
        $('#Cmb_Mes').combobox({
            valueField: 'Mes_Id',
            textField: 'Mes',
            data: Meses,
            editable: false, //indicamos que no se pueda escribir en el combo
            value: Mes, //valor por default seleccionado
            formatter: function (row) {
                var opts = $(this).combobox('options');
                return '<span style="font-size:8pt; font-family:Consolas; color:black;">' + row[opts.textField] + '</span>';
            }
        });

    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al llenar el combo de Meses. Error[' + Ex + ']', 'error');
    }
}

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Llenar_Combo_Cantidad
///DESCRIPCIÓN          : Funcion para llenar el combo de la cantidad
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 22/Mayo/2014
///***********************************************************************************************************************
function Llenar_Combo_Cantidad() {
    var Cantidad = new Array();
    var i;
    var Numero = 0;

    try {
        Numero = parseInt($("input[id$=Hf_No_Cantidad]").val(), 10);

        for (i = 0; i <= Numero; i++) {
            Cantidad[i] = new Object();
            Cantidad[i].Cantidad = i;
            Cantidad[i].Cant = i;
        }

    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al llenar el combo de cantidad. Error[' + Ex + ']', 'error');
    }

    return Cantidad;
}


//*****************************************************************************************************************************************************
//************************************************************* GRID  *********************************************************************************
//*****************************************************************************************************************************************************

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Llenar_Grid_Productos
///DESCRIPCIÓN          : Funcion para llevar el grid de los productos
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 21/Mayo/2014
///***********************************************************************************************************************
function Llenar_Grid_Productos() {
    var Parametros = '';
    var Indice_Anterior = -1;
    var Editor_Cantidad = null;
    var Renglon = null;
    var Indice = -1;
    var Json_Cantidad;

    try {
        Parametros = Generar_Cadena_Parametros("Obtener_Productos_Servicios");
        //Json_Cantidad = Llenar_Combo_Cantidad();

        $('#Grid_Productos_Servicios').propertygrid({
            url: 'Frm_Apl_Principal_Controlador.aspx' + Parametros,
            width: 780,
            height: 350,
            align: 'left',
            nowrap: false,
            striped: true,
            collapsible: false,
            pagination: false,
            rownumbers: false,
            showFooter: false,
            groupField: 'Tipo',
            loadMsg: 'Cargando Datos',
            groupFormatter: function (value, rows) {
                return '<span style="font-size:9pt;text-align:left!important;">' + value + ' </span>';
            },
            showGroup: true,
            columns: [[
                 { title: 'Cantidad', field: 'Cantidad', width: 100, align: 'left',
                     editor: {
                         type: 'numberbox',
                         options: {
                             onChange: function (newValue, oldValue) {
                                 if (newValue > 0) {
                                     Validar_Cantidad_Productos();
                                 }
                             }
                         }
                     },
                     formatter: function (Valor) {
                         return '<span style="font-size:8pt; font-family:Consolas; color:black;">' + Valor + '</span>';
                     }
                 },
                {
                    title: 'Nombre', field: 'Nombre', width: 550, align: 'left',
                    formatter: function (value) {
                        return '<span style="font-size:8pt; font-family:Consolas;">' + value + '</span>';
                    }
                },
                { field: 'Costo', title: 'Costo', width: 100, align: 'right',
                    formatter: function (value) {
                        return '<span style="font-size:8pt; font-family:Consolas;">' + value + '</span>';
                    }
                },
                { field: 'Producto_Id', hidden: true }
            ]],
            onBeforeLoad: function () {
                $(this).propertygrid('rejectChanges');
            },
            onClickRow: function (Indice, row) {
                if (Indice_Anterior != Indice) {
                    $('#Grid_Productos_Servicios').propertygrid('selectRow', Indice);
                    $('#Grid_Productos_Servicios').propertygrid('endEdit', Indice_Anterior);
                    $('#Grid_Productos_Servicios').propertygrid('beginEdit', Indice);
                }
                Indice_Anterior = Indice;
            }
        });
    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al obtener la información de los productos y servicios. Error[' + Ex + ']', 'error');
    }
}

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Llenar_Grid_Productos_Detalle
///DESCRIPCIÓN          : Funcion para llenar el grid con los detalles de la compra
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 23/Mayo/2014
///***********************************************************************************************************************
function Llenar_Grid_Productos_Detalle() {
    var Renglones = '';
    var Indice = '';

    try {
        $('#Grid_Productos_Detalle').propertygrid({
            width: 880,
            height: 385,
            align: 'left',
            nowrap: false,
            striped: true,
            collapsible: false,
            pagination: false,
            rownumbers: false,
            showFooter: true,
            loadMsg: 'Cargando Datos',
            groupField: 'Tipo',
            groupFormatter: function (value, rows) {
                return '<span style="font-size:9pt;text-align:left!important;">' + value + ' </span>';
            },
            showGroup: true,
            columns: [[
                {
                    title: 'Nombre', field: 'Nombre', width: 550, align: 'left',
                    formatter: function (value, row) {
                        if (row.Producto_Id != '') {
                            return '<span style="font-size:8pt; font-family:Consolas;">' + value + '</span>';
                        }
                        else {
                            if (value == "Total") {
                                return '<span style="font-size:9pt; font-family:Consolas;font-weight:bold; color:Navy;">' + value + '</span>';
                            }
                            else {
                                return '<span style="font-size:8pt; font-family:Consolas;font-weight:200; color:Navy;">' + value + '</span>';
                            }
                        }
                    }
                },
                { field: 'Costo', title: 'Costo', width: 100, align: 'right',
                    formatter: function (value) {
                        return '<span style="font-size:8pt; font-family:Consolas;">' + value + '</span>';
                    }
                },
                { title: 'Cantidad', field: 'Cantidad', width: 100, align: 'center',
                    formatter: function (Valor) {
                        return '<span style="font-size:8pt; font-family:Consolas; color:black;">' + Valor + '</span>';
                    }
                },
                { field: 'Subtotal', title: 'Subtotal', width: 100, align: 'right',
                    formatter: function (value, row) {
                        if (row.Producto_Id != '') {
                            return '<span style="font-size:8pt; font-family:Consolas;">' + value + '</span>';
                        }
                        else {
                            if (row.Descripcion == "Total") {
                                return '<span style="font-size:9pt; font-family:Consolas;font-weight:bold; color:Navy;">' + value + '</span>';
                            }
                            else {
                                return '<span style="font-size:8pt; font-family:Consolas;font-weight:200; color:Navy;">' + value + '</span>';
                            }
                        }
                    }
                },
                { title: 'Eliminar', field: 'Producto_Id', width: 60, align: 'center',
                    formatter: function (value, row, index) {
                        if (row != undefined && row != null) {
                            if (row.Producto_Id != ' ' && row.Producto_Id != undefined && row.Producto_Id != null) {
                                return '<center><span style="font-size:10px; font-weight:bold;">' +
                            '<img id="eliminar_img" title="Eliminar Registro" style="cursor:pointer;width:16px; height:16px;" onclick="javascript:Eliminar_Registro_Pedido(\'' + row.Producto_Id + '\',' + index + ');" src="../Imagenes/paginas/grid_garbage.png"/>' +
                            '</span></center>';
                            }
//                            else {
//                                return '<span style="font-size:8pt; font-family:Consolas;">' + row.Producto_Id + '</span>';
//                            } 
                        }
                    }
                }
            ]]
        });
    }
    catch (Ex) {
        $.messager.alert('Mensaje', 'Error al llenar el grid de los detalles del pedido. Error[' + Ex + ']', 'error');
    }
}

//*****************************************************************************************************************************************************
//*********************************************************** METODOS COMPRA **************************************************************************
//*****************************************************************************************************************************************************

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Validar_Datos_Compra
///DESCRIPCIÓN          : Funcion para validar los datos de la compra
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 27/Mayo/2014
///***********************************************************************************************************************
function Validar_Datos_Compra() {
    var Datos_Validos = true;
    var Mensaje = '';

    try {

        if ($("input[id$=Txt_Nombre]").val() == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Nombre <br/>";
        }

        if ($("input[id$=Txt_Domicilio]").val() == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Domicilio <br/>";
        }

        if ($("input[id$=Txt_CP]").val() == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Código Postal <br/>";
        }

        if ($("input[id$=Txt_Telefono]").val() == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Telefono <br/>";
        }

        if ($("input:checkbox[id$=Chk_Enviar_Email]").attr('checked')) {
            if ($("input[id$=Txt_Email]").val() == '') {
                Datos_Validos = false;
                Mensaje += " ** Un Email <br/>";
            }
        }

        if ($("[id$=Lbl_Total]").val() == '') {
            Datos_Validos = false;
            Mensaje += " ** Seleccionar algún producto o servicio <br/>";
        } 
        else 
        {
            if (parseFloat($("[id$=Lbl_Total]").val().replace(/,/gi, '')) <= 0.00) 
            {
                Datos_Validos = false;
                Mensaje += " ** Seleccionar algún producto o servicio <br/>";
             }
        }

        if ($("input[id$=Txt_Numero_Tarjeta]").val() == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Número de Tarjeta <br/>";
        }

        if ($("input[id$=Txt_Codigo_Seguridad]").val() == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Código de Seguridad <br/>";
        }

        if ($('#Cmb_Mes').datebox('getValue') == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Mes de la Fecha Expira Tarjeta <br/>";
        }

        if ($('#Cmb_Anio').datebox('getValue') == '') {
            Datos_Validos = false;
            Mensaje += " ** Un Año de la Fecha Expira Tarjeta <br/>";
        }

        if (!Datos_Validos) {
            $.messager.alert('Mensaje', 'Favor de proporcionar: <br>' + Mensaje, 'warning');
        }

    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al validar los datos de la compra. Error[' + Ex + ']', 'error');
    }
    return Datos_Validos;
 }

///***********************************************************************************************************************
///NOMBRE DE LA FUNCIÓN : Generar_Compra
///DESCRIPCIÓN          : Funcion para generar la compra
///PARAMETROS           : 
///CREO                 : Leslie González Vázquez
///FECHA_CREO           : 27/Mayo/2014
///***********************************************************************************************************************
function Generar_Compra() {
    var Parametros = '';
    var Mensaje = '';
    try {
        //validamos los datos de la compra
        if (Validar_Datos_Compra()) 
        {
            Mensaje = 'Los detalles de tu compra y boletos de acceso al Museo se encuentran en el pdf descargado'
            if ($("input:checkbox[id$=Chk_Enviar_Email]").attr('checked')) {
                Mensaje += ", y fueron enviados a tu Correo Electrónico";
            }

            Parametros = Generar_Cadena_Parametros("Generar_Compra");

            $.ajax({
                url: "Frm_Apl_Principal_Controlador.aspx" + Parametros,
                type: 'POST',
                async: false,
                cache: false,
                success: function (Datos) {
                    if (Datos != null) {
                        //obtenemos la ruta del pdf con los datos de la compra y los tickets
                        /*alert(Datos);
                        descargar_doc(Datos);
                        $.messager.alert('Mensaje', 'Compra generada con Éxito!! <br /> ' + Mensaje + '.', 'info', function () {
                            location.reload();
                        });
                        */
                        //Limpiar_Controles();
                        //setTimeout(function () { location.reload(); }, 4000);
                    }
                    else {
                        $.messager.alert('Mensaje', "No se pudo generar la venta", 'info');
                    }
                }
            });
        }

    } catch (Ex) {
        $.messager.alert('Mensaje', 'Error al generar la compra. Error[' + Ex + ']', 'error');
    }
}

/// <summary>
/// Nombre: descargar_doc
/// Descripción: Método descarga el documento seleccionado del empleado
/// Usuario Creo: Juan Alberto Hernández Negrete
/// Fecha Creo: 19 Septiembre 2013
/// </summary>
function descargar_doc(ctrl) {
    window.location.href = 'Abrir_Archivos.aspx?Documento=' + encodeURI(ctrl);
}

