<%@ Page Title="Museo Momias" Language="C#" MasterPageFile="~/Paginas/MasterPage_ERP.master" AutoEventWireup="true" 
CodeFile="Frm_Apl_Principal.aspx.cs" Inherits="Paginas_Frm_Apl_Principal" EnableEventValidation="false" ValidateRequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--Estilos Pagina--%>
    <link href="../Estilos/Estilo_Punto_Venta.css" rel="stylesheet" type="text/css" />
   
    <%--Estilos Slider Acordeon--%>
    <link href="../Scripts/Slider_Acordion/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/Slider_Acordion/css/demo.css" rel="stylesheet" type="text/css" />

     <%--Estilos EasyUI--%>
    <link href="../Scripts/jquery-easyui-1.3.1/themes/metro/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery-easyui-1.3.1/themes/icon.css" rel="stylesheet" type="text/css" />
    
    <%--Scripts Jquery--%>
    <script src="../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-easyui-1.3.1/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-easyui-1.3.1/easyui-lang-es.js" type="text/javascript"></script>

    <%--Script para dar formato a las cantidades--%>
    <script src="../Scripts/jquery.formatCurrency-1.4.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.formatCurrency.all.js" type="text/javascript"></script>

    <%--Stript funcionalidad Pagina--%>
    <script src="../Scripts/Paginas/Js_Apl_Principal.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        <!--
            //El nombre del controlador que mantiene la sesión
            var CONTROLADOR = "../Mantenedor_Session.ashx";

            //Ejecuta el script en segundo plano evitando así que caduque la sesión de esta página
            function MantenSesion() {
                var head = document.getElementsByTagName('head').item(0);
                script = document.createElement('script');
                script.src = CONTROLADOR;
                script.setAttribute('type', 'text/javascript');
                script.defer = true;
                head.appendChild(script);
            }

            //Temporizador para matener la sesión activa
            setInterval("MantenSesion()", <%=(int)(0.9*(Session.Timeout * 60000))%>);
        //-->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Area_Trabajo2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Area_Trabajo1" Runat="Server">
    <div id="Imagen_Momias"></div>

    <div style="text-align: right; z-index: 1000; margin-top: 10px;">
        <asp:Button ID="Btn_Consulta" runat="server" Text="Consulta Folio" 
            Width="150px" onclick="Btn_Consulta_Click" CssClass="button" />
    </div>

    <div id="Div_Contenido_Principal" style="background-color: #ffffff; width: 98%; height: 100%;">
        <center>
            <div class="container">
                <div id="va-accordion" class="va-container">
                    <div class="va-nav">
				        <span class="va-nav-prev">Previous</span>
				        <span class="va-nav-next">Next</span>
			        </div>
                    
                    <div class="va-wrapper">
                        <%--***** Div para el primer tab con los datos *****--%>
                        <div id="Div1" class="va-slice va-slice-1">
                            <table width="99%" class="estilo_fuente">
                                <tr>
                                    <td>
                                        <center>
                                            <h3 class="h3-title"> Paso 1 de 3 - Selecci&oacute;n de Productos y Servicios</h3>
                                        </center>
                                    </td>
                                </tr>
                                <tr><td style="height:3px;"></td></tr>
                                <tr>
                                    <td>
                                        <center>
                                            Fecha de la Visita:&nbsp; 
                                            <input type="text" id="Txt_Fecha" class="easyui-datebox" 
                                                style="width: 160px; height: 1.1em; display:block; text-align:center;"/>
                                            <asp:HiddenField runat="server" ID="Hf_Total" />
                                            <asp:HiddenField runat="server" ID="Hf_Total_Producto" />
                                            <asp:HiddenField runat="server" ID="Hf_Total_Servicio" />
                                            <asp:HiddenField runat="server" ID="Hf_Subtotal" />
                                            <asp:HiddenField runat="server" ID="Hf_No_Cantidad" />
                                            <asp:HiddenField runat="server" ID="Hf_Fecha" />
                                        </center>
                                    </td>
                                </tr>
                                <tr><td style="height:3px; border-bottom:solid 1px #dbdbdb; margin:3px; padding:3px;"></td></tr>
                                <tr>
                                    <td>
                                        <%--tabla con la descripcion de los productos y servicios--%>
                                        <table id="Tabla_Descripcion_1" width="100%" style="margin:10px 0 10px 100px;">
                                            <tr>
                                                <td id="Td_Descripcion_Momias">
                                                    <table id="Grid_Productos_Servicios" ></table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--***** Div para el segunto tab con los datos *****--%>
                        <div id="Div2" class="va-slice va-slice-2">
                            <table width="100%" class="estilo_fuente">
                                <tr>
                                    <td style="width:99%;">
                                        <center>
                                            <h3 class="h3-title"> Paso 2 de 3 - Detalles de la venta </h3>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--tabla con la descripcion de los productos y servicios para la compra--%>
                                        <table id="Tabla_Descripcion_2" width="100%" style="margin:10px 0 10px 50px;">
                                            <tr>
                                                <td id="Td_Descripcion_Mominas_2" style="width:99%;" >
                                                    <table id="Grid_Productos_Detalle"></table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--***** Div para el tercer tab con los datos *****--%>
                        <div id="Div3" class="va-slice va-slice-3">
                            <table width="100%" class="estilo_fuente" >
                                <tr>
                                    <td style="width:99%;">
                                        <center>
                                            <h3 class="h3-title"> Paso 3 de 3 - Información para la venta </h3>
                                        </center>
                                    </td>
                                </tr>
                                <tr><td style="height:8px;"></td></tr>
                                <tr>
                                    <td>
                                        <table id="Tabla_Descripcion_3" width="100%" >
                                            <tr> <td colspan="4"> &nbsp;&nbsp; * Datos Requeridos </td> </tr>
                                            <tr> <td colspan="4" style="height:8px;"> </td> </tr>
                                            <tr>
                                                <td colspan = "2">
                                                    <div class="Encabezados" style="text-align:center; font-weight:bold;">Informaci&oacute;n Personal</div>
                                                </td>
                                                <td colspan = "2">
                                                    <div class="Encabezados" style="text-align:center; font-weight:bold;">Condiciones Venta</div>
                                                </td>
                                            </tr>
                                            <tr> <td colspan="4" style="height:10px;"></td> </tr>
                                            <tr>
                                                <td style="width:15%; padding:0 0 0 30px;">  * Nombre: </td>
                                                <td style="width:35%;">
                                                    <asp:TextBox ID="Txt_Nombre" runat = "server" MaxLength = "120" Width="85%" TabIndex="1"
                                                     onblur="this.value = (this.value.match(/^[A-Za-z áéíóúÁÉÍÓÚüÜ]*$/))? this.value : '';" ></asp:TextBox>
                                                </td>
                                                <td style="width:22%; padding:0 0 0 85px;"> Aceptamos: </td>
                                                <td style="width:28%;">
                                                    <img src="../Imagenes/paginas/visa.jpg" alt="Visa" align="absmiddle" style="border:0px; width:30px;" />
                                                    <img src="../Imagenes/paginas/mastercard.jpg" alt="MasterCard" align="absmiddle" style="border:0px; width:30px;" />
                                                </td>
                                            </tr>
                                            <tr> <td colspan="4" style="height:5px;"></td> </tr>
                                            <tr>
                                                <td style="padding:0 0 0 30px;"> * Domicilio: </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Domicilio" runat = "server" MaxLength = "255" Width="85%" TabIndex="2"
                                                    onblur="this.value = (this.value.match(/^[A-Za-z0-9 áéíóúÁÉÍÓÚüÜ.#;]*$/))? this.value : ''; this.value = this.value.replace(/#/gi, 'No.'); "></asp:TextBox>
                                                </td>
                                                <td style="padding:0 0 0 85px;"> * Número Tarjeta: </td>
                                                <td>
                                                    <input id="Txt_Numero_Tarjeta" type="text" name="Number" maxlength="16" tabindex="9" 
                                                        style="width: 65%;" onblur="this.value = (this.value.match(/^\d{16}$/))? this.value : '';"/>
                                                </td>
                                            </tr>
                                            <tr> <td colspan="4" style="height:5px;"></td> </tr>
                                            <tr>
                                                <td style="padding:0 0 0 30px;"> Estado: </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Estado" runat = "server" MaxLength = "100" Width="85%" TabIndex="3"
                                                    onblur="this.value = (this.value.match(/^[A-Za-z áéíóúÁÉÍÓÚüÜ.]*$/))? this.value : '';"></asp:TextBox>
                                                </td>
                                                <td style="padding:0 0 0 85px;"> * C&oacute;digo Seguridad: </td>
                                                <td>
                                                    <input id="Txt_Codigo_Seguridad" name="Cvv2Val" type="text" maxlength="4" tabindex="10" style="width:65%;" />
                                                </td>
                                            </tr>
                                            <tr> <td colspan="4" style="height:5px;"></td> </tr>
                                            <tr>
                                                <td style="padding:0 0 0 30px;"> Ciudad: </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Ciudad" runat = "server" MaxLength = "100" Width="85%" TabIndex="4"
                                                    onblur="this.value = (this.value.match(/^[A-Za-z áéíóúÁÉÍÓÚüÜ.]*$/))? this.value : '';"></asp:TextBox>
                                                </td>
                                                <td style="padding:0 0 0 85px;"> * Fecha Expiraci&oacute;n</td>
                                                <td>
                                                    <input id="Txt_Fecha_Expiracion" type="hidden" name="Expires" />
                                                    <select id="Cmb_Mes" class="easyui-combobox" style="width:60px;" tabindex="11"></select>
                                                        /
                                                        <select id="Cmb_Anio" class="easyui-combobox" style="width:60px;" tabindex="12"></select>
                                                </td>
                                            </tr>
                                            <tr> <td colspan="4" style="height:5px;"></td> </tr>
                                            <tr>
                                                <td style="padding:0 0 0 30px;"> * C&oacute;digo Postal: </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_CP" runat = "server" MaxLength = "5" Width="85%" TabIndex="5"
                                                    onblur="this.value = (this.value.match(/^\d{5}$/))? this.value : '';"></asp:TextBox>
                                                </td>
                                                <td colspan="2"> </td>
                                            </tr>
                                            <tr> <td colspan="4" style="height:5px;"></td> </tr>
                                            <tr>
                                                <td style="padding:0 0 0 30px;"> * Telefono: </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Telefono" runat = "server" MaxLength = "11" Width="85%" TabIndex="6"
                                                    onblur="this.value = (this.value.match(/^[0-9]{2,3}-? ?[0-9]{6,7}$/))? this.value : '';"></asp:TextBox>
                                                </td>
                                                <td colspan="2" rowspan ="2" style="padding:0 30px 0 55px; font-size:8pt;">  
                                                    Los boletos comprados en l&iacute;nea se deben imprimir en casa y deben ser canjeados el d&iacute;a de la visita.
                                                </td>
                                            </tr>
                                            <tr> <td colspan="4" style="height:5px;"></td> </tr>
                                            <tr>
                                                <td style="padding:0 0 0 30px;"> 
                                                    <asp:Label id="Lbl_Email" runat="server" Text="* Email:"></asp:Label>
                                                 </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Email" runat = "server" MaxLength = "250" Width="85%" TabIndex="7"
                                                    onblur="this.value = (this.value.match(/^([a-zA-Z0-9])+([a-zA-Z0-9\._-])*@([a-zA-Z0-9_-])+([a-zA-Z0-9\._-]+)+$/))? this.value : '';"></asp:TextBox>
                                                </td>
                                                <td colspan="2"> </td>
                                            </tr>
                                            <tr>
                                                <td style="padding:0 0 0 30px;"> Enviar Email: </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="Chk_Enviar_Email" runat = "server" Checked ="true" TabIndex="8"></asp:CheckBox>
                                                </td>
                                                <td colspan="2"> 
                                                    <div class="Encabezados" style="text-align:right;">
                                                        Total: &nbsp;
                                                        <input id="Lbl_Total" name="Total" type="text" class="Total" readonly="readonly" style="width: 15%;" />
                                                        <input type="hidden" name="Name" value="user_test" />
                                                        <input type="hidden" name="Password" value="user01" />
                                                        <input type="hidden" name="ClientId" value="19" />
                                                        <input type="hidden" name="Mode" value="Y" />
                                                        <input type="hidden" name="TransType" value="Auth" />
                                                        <input type="hidden" name="Cvv2Indicator" value="1" />
                                                        <input id="ResponsePath" type="hidden" name="ResponsePath" value="" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td style="border-bottom:solid 1px #dbdbdb; height:5px;"></td></tr>
                                <tr>
                                    <td style="padding: 3px 50px 3px 50px ; font-size:7pt; border-bottom:solid 1px #dbdbdb;">
                                        <span style="font-weight:bold;font-size:7pt;">Terminos y condiciones:</span>
                                            Las entradas anticipadas para el Museo de las Momias de Guanajuato, permite al visitante evitar la espera en las líneas de entrada al museo.
                                            No se aceptan devoluciones o intercambios.
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 3px 50px 3px 50px ; font-size:7pt;">
                                        <span style="font-weight:bold;font-size:7pt;">Horario Normal: </span>
                                            Lunes a Jueves de 9:00 a 18:00 horas  y  Viernes a Domingo de 9:00 a 18:30 horas.
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 0px 50px 3px 50px ; font-size:7pt;">
                                        <span style="font-weight:bold;font-size:7pt;">Ubicación: </span>
                                            Explanada del Panteón Municipal s/n, Centro, C.P. 36000,  Guanajuato Capital, México.
                                            Teléfono: (473) 732 06 39
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </div>
                    <div style="height:6px;"></div>
                    <div class="Div_Compra">
                        <span id="Span_Compra" style="display:none;">
                            <asp:ImageButton ID="Btn_Compra" runat="server" CssClass="Boton_Compra" ToolTip="Confirmar Compra" 
                                ImageUrl="~/Scripts/Slider_Acordion/images/Comprar.png" Width="115px" Height="30px" />
                        </span>
			        </div>
                </div>
            </div>
            <script src="../Scripts/Slider_Acordion/js/jquery.easing.1.3.js" type="text/javascript"></script>
            <script src="../Scripts/Slider_Acordion/js/jquery.vaccordion.js" type="text/javascript"></script>
            <script type="text/javascript">
                $(function () {
                    $('#va-accordion').vaccordion({
                        accordionW: 1000, /// / Anchura del acordeón 
                        accordionH: 480, //Altura del acordeón 
                        expandedHeight: 480, // La altura de una rebanada abierto, No debe ser más que accordionH 
                        animSpeed: 500, // Velocidad al abrir / cerrar una rebanada 
                        animEasing: 'easeInOutBack', //Aliviando al abrir / cerrar una rebanada 
                        animOpacity: 0.1, // Valor de opacidad para las rodajas colapsadas
                        visibleSlices: 1, // Número de cortes visibles 
                        contentAnimSpeed: 200, //Tiempo para desvanecerse en el contenido de la rebanada 
                        savePositions: true // Si se establece en false, Nosotros colapsamos cualquier segmento abierto  Antes de deslizar 
                    });
                });
            </script>
        </center>
    </div>
    
    <div id="progressBackgroundFilter" class="progressBackgroundFilter">
        <div  class="processMessage" id="div_progress"><img alt="" src="../Imagenes/paginas/Updating.gif" /></div>
    </div>
</asp:Content>

