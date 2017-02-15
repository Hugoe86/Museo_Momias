using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Sesiones;
using Erp_Apl_Roles.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp_Cat_Apl_Bitacora.Negocio;
using Microsoft.VisualBasic;

namespace Erp.Metodos_Generales
{
    public class Cls_Metodos_Generales
    {
        public enum Enum_Tipo_Caracteres : int
        {
            Alfa_Numerico = 1,
            Digito,
            Letra,
            Numerico_Nextel,
            Numerico,
            Puntuacion,
            Signo,
            Alfa_Numerico_Extendido
        }

        #region Consecutivo

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static String Obtener_ID_Consecutivo(String Tabla, String Campo, String Filtro, Int64 Longitud_ID)
        {
            String Id = Convertir_A_Formato_ID_64Bits(1, Longitud_ID);
            try
            {
                String Mi_SQL = "SELECT MAX(" + Campo + ") FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Object Obj_Temp = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL);
                Obj_Temp.ToString();
                if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                {
                    Id = Convertir_A_Formato_ID_64Bits((Convert.ToInt64(Obj_Temp) + 1), Longitud_ID);
                }
            }
            catch (Exception Ex)
            {
                new Exception(Ex.Message);
            }
            return Id;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static String Obtener_ID_Consecutivo_Venta(String Tabla, String Campo, String Filtro, Int32 Longitud_ID)
        {
            String Id = Convertir_A_Formato_ID(1, Longitud_ID); ;
            try
            {
                String Mi_SQL = "SELECT ifnull(MAX(" + Campo + "), 0) as No_Venta FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Object Obj_Temp = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL);
                Obj_Temp.ToString();
                if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                {
                    if (Obj_Temp.ToString() != "0")
                    {
                        Id = Convertir_A_Formato_ID((Convert.ToInt32(Obj_Temp) + 1), Longitud_ID);
                    }
                    else
                    {
                        Id = Obj_Temp.ToString();
                    }
                }
            }
            catch (Exception Ex)
            {
                new Exception(Ex.Message);
            }
            return Id;
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static Int64 Obtener_ID_Consecutivo_Numerico_Deudorcad(String Tabla, String Campo, String Filtro)
        {
            Int64 Id = 1;
            try
            {
                String Mi_SQL = "SELECT MAX(" + Campo + ") FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Object Obj_Temp = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL);
                Obj_Temp.ToString();
                if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                {
                    Id = (Convert.ToInt64(Obj_Temp.ToString()) + 1);
                }
            }
            catch (Exception Ex)
            {
                new Exception(Ex.Message);
            }
            return Id;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static Int64 Obtener_ID_Consecutivo_Numerico(String Tabla, String Campo, String Filtro)
        {
            Int64 Id = 1;
            try
            {
                String Mi_SQL = "SELECT MAX(" + Campo + ") FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Object Obj_Temp = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL);
                Obj_Temp.ToString();
                if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                {
                    Id = (Convert.ToInt64(Obj_Temp.ToString().Substring(1,9)) + 1);
                }
            }
            catch (Exception Ex)
            {
                new Exception(Ex.Message);
            }
            return Id;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static Int64 Obtener_ID_Consecutivo_Numerico_Accesos(String Tabla, String Campo, String Filtro)
        {
            Int64 Id = 1;
            try
            {
                String Mi_SQL = "SELECT MAX(" + Campo + ") FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Object Obj_Temp = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL);
                Obj_Temp.ToString();
                if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                {
                    Id = (Convert.ToInt64(Obj_Temp.ToString().Substring(1,9)) + 1);
                }
            }
            catch (Exception Ex)
            {
                new Exception(Ex.Message);
            }
            return Id;
        }
        #endregion Consecutivo

        #region Conversiones

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Convertir_Caracter_Mayuscula
        ///DESCRIPCIÓN  : Convertir a mayusculas.
        ///PARAMENTROS  :
        ///CREO         : Sergio Manuel Gallardo Andrade
        ///FECHA_CREO   : 25/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static char Convertir_Caracter_Mayuscula(System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            return e.KeyChar;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Convertir_A_Formato_ID
        ///DESCRIPCIÓN: Pasa un numero entero a Formato de ID.
        ///PARAMETROS:
        ///             1. Dato_ID. Dato que se desea pasar al Formato de ID.
        ///             2. Longitud_ID. Longitud que tendra el ID.
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        private static String Convertir_A_Formato_ID(Int32 Dato_ID, Int32 Longitud_ID)
        {
            String Retornar = "";
            String Dato = "" + Dato_ID;
            for (int Cont_Temp = Dato.Length; Cont_Temp < Longitud_ID; Cont_Temp++)
            {
                Retornar = Retornar + "0";
            }
            Retornar = Retornar + Dato;
            return Retornar;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Convertir_A_Formato_ID
        ///DESCRIPCIÓN: Pasa un numero entero a Formato de ID.
        ///PARAMETROS:
        ///             1. Dato_ID. Dato que se desea pasar al Formato de ID.
        ///             2. Longitud_ID. Longitud que tendra el ID.
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        private static String Convertir_A_Formato_ID_64Bits(Int64 Dato_ID, Int64 Longitud_ID)
        {
            String Retornar = "";
            String Dato = "" + Dato_ID;
            for (int Cont_Temp = Dato.Length; Cont_Temp < Longitud_ID; Cont_Temp++)
            {
                Retornar = Retornar + "0";
            }
            Retornar = Retornar + Dato;
            return Retornar;
        }
        #endregion Conversiones

        #region Limpiar

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Limpia_Controles_Panel
        ///DESCRIPCIÓN: Limpia los controles de un panel.
        ///PARAMETROS:
        ///             1. Ctrl_Padre. Control que se va a limpiar.
        ///CREO: Luis Alberto Salas Garcia.
        ///FECHA_CREO: 21/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Limpia_Controles(Control Ctrl_Padre)
        {
            foreach (Control Ctrl_Interno in Ctrl_Padre.Controls)
            {
                // Si es una caja de texto limpia el contenido.
                if (Ctrl_Interno is TextBox)
                {
                    TextBox Txt_Caja = Ctrl_Interno as TextBox;
                    Txt_Caja.Clear();
                }

                // Si es un combobox selecciona el primer elemento del combo.
                if (Ctrl_Interno is ComboBox)
                {
                    ComboBox Cmb_Combo = Ctrl_Interno as ComboBox;
                    if (Cmb_Combo.Items.Count > 0)
                    { 
                        Cmb_Combo.SelectedIndex = 0; 
                    }
                }                

                // Si hay mas controles dentro, vuelve a llamarse asi misma la funcion.
                if (Ctrl_Interno.Controls.Count > 0)
                {
                    Limpia_Controles(Ctrl_Interno);
                }
            }
        }

        #endregion Limpiar

        #region ComboBox

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Rellena_Combo_Box
        ///DESCRIPCIÓN: Rellena el combobox con los datos que se le manden.
        ///PARAMETROS:
        ///             1. Cmb_Combo. Control ComboBox que se va a rellenar
        ///             2. Dt_Datos. DataTable con los informacion con la que se va
        ///                          a rellenar el ComboBox.
        ///             3. Dtf_Campo_Motrar. Cadena que almacena el campo de la tabla
        ///                          que se va a mostrar en el ComboBox.
        ///             4. Dvf_Campo_Valor. Cadena que almacena el valor que tendra el
        ///                          elemento de la lista del combo, cuando se seleccione.
        ///CREO: Luis Alberto Salas Garcia.
        ///FECHA_CREO: 21/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Rellena_Combo_Box(ComboBox Cmb_Combo, DataTable Dt_Datos, string Dtf_Campo_Motrar, string Dvf_Campo_Valor)
        {
            if (Dt_Datos != null && Dt_Datos.Rows.Count > 0)
            {
                DataRow Row = Dt_Datos.NewRow();
                Row[0] = "0";
                Row[1] = "<-SELECCIONE->";
                Dt_Datos.Rows.InsertAt(Row, 0);
                Cmb_Combo.DataSource = Dt_Datos;
                Cmb_Combo.DisplayMember = Dtf_Campo_Motrar;
                Cmb_Combo.ValueMember = Dvf_Campo_Valor;
            }
        }

        #endregion ComboBox

        #region Habilitar

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Habilita_Deshabilita_Controles_Panel
        ///DESCRIPCIÓN: Habilita o deshablita controles de un panel.
        ///PARAMETROS:
        ///             1. Ctrl_Padre. Coleccion de controles.
        ///             2. Valor. Si es verdadero, habilita los controles, si es
        ///                       falso, los deshabilita.
        ///CREO: Luis Alberto Salas Garcia.
        ///FECHA_CREO: 21/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Habilita_Deshabilita_Controles(Control Ctrl_Padre, bool Valor)
        {
            foreach (Control Ctrl_Interno in Ctrl_Padre.Controls)
            {
                if (Ctrl_Interno is TextBox)
                {
                    Ctrl_Interno.Enabled = Valor;
                }
                else if (Ctrl_Interno is ComboBox)
                {
                    Ctrl_Interno.Enabled = Valor;
                }
                else if (Ctrl_Interno is Button)
                {
                    Ctrl_Interno.Enabled = Valor;
                }
                else if (Ctrl_Interno is DateTimePicker)
                {
                    Ctrl_Interno.Enabled = Valor;
                }
                else if (Ctrl_Interno.Controls.Count > 0)
                {
                    Habilita_Deshabilita_Controles(Ctrl_Interno, Valor);
                }
            }
        }

        #endregion Habilitar

        #region Grid

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Rellena_GridView
        ///DESCRIPCIÓN  : Rellena un DataGridView a partir de un DataTable.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static void Rellena_GridView(DataTable Dt_Fuente, DataGridView Grid_Destino, String[] Filtros)
        {
            Grid_Destino.DataSource = Dt_Fuente;
            for (int Indice = 0; Indice < Grid_Destino.Columns.Count; Indice++)
            {
                Grid_Destino.Columns[Indice].Visible = false;
            }

            foreach (String Cadena in Filtros)
            {
                Grid_Destino.Columns[Cadena].Visible = true;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Grid_Propiedad_Fuente_Celdas
        ///DESCRIPCIÓN  : Carga el aspecto visual del grid de accesos
        ///PARAMENTROS  : Grid_Acceso: el grid al que se le agregara el formato
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 25/Feb/2013 12:38 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static void Grid_Propiedad_Fuente_Celdas(DataGridView Grid_Acceso)
        {
            System.Drawing.Font Fuente_Letra = new System.Drawing.Font("Arial", 9);

            for (int Cnt_For_Renglon = 0; Cnt_For_Renglon < Grid_Acceso.RowCount; Cnt_For_Renglon++)
            {
                for (int Cnt_For_Columna = 0; Cnt_For_Columna < Grid_Acceso.ColumnCount; Cnt_For_Columna++)
                {
                    Grid_Acceso.Rows[Cnt_For_Renglon].Cells[Cnt_For_Columna].Style.Font = Fuente_Letra;
                }
            }
        }

        #endregion Grid

        #region Validaciones

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Validar_Caracter
        ///DESCRIPCIÓN  : Valida que no introduscan caracteres raros.
        ///PARAMENTROS  :
        ///CREO         : Sergio Manuel Gallardo Andrade
        ///FECHA_CREO   : 25/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Char Validar_Caracter(KeyPressEventArgs e, Enum_Tipo_Caracteres Tipo_Caracteres)
        {
            String Cadena = "";
            Char Regreso = ' ';
            Boolean Contenido = false;
            if (!char.IsControl(e.KeyChar))
            {
                switch (Tipo_Caracteres)
                {
                    case Enum_Tipo_Caracteres.Alfa_Numerico:
                        if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;

                    case Enum_Tipo_Caracteres.Digito:
                        if (char.IsDigit(e.KeyChar))
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;

                    case Enum_Tipo_Caracteres.Letra:
                        if (char.IsLetter(e.KeyChar))
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;

                    case Enum_Tipo_Caracteres.Numerico:
                        if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;

                    case Enum_Tipo_Caracteres.Numerico_Nextel:
                        if (char.IsNumber(e.KeyChar) || e.KeyChar == '*')
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;

                    case Enum_Tipo_Caracteres.Puntuacion:
                        if (char.IsPunctuation(e.KeyChar))
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;

                    case Enum_Tipo_Caracteres.Signo:
                        if (char.IsSymbol(e.KeyChar))
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                    case Enum_Tipo_Caracteres.Alfa_Numerico_Extendido:
                        Cadena = "¡!@#$%&*()-_=+[]{}:,<.>/¿?";
                        if (Cadena.IndexOf(e.KeyChar) != -1)
                        {
                            Contenido = true;
                        }
                        if (char.IsLetterOrDigit(e.KeyChar) || Contenido || char.IsWhiteSpace(e.KeyChar))
                        {
                            Regreso = e.KeyChar;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                }
            }
            return Regreso;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Validar_Password
        ///DESCRIPCIÓN  : Valida que no introduscan caracteres raros.
        ///PARAMENTROS  :
        ///CREO         : Sergio Manuel Gallardo Andrade
        ///FECHA_CREO   : 25/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Validar_Password(String Cadena)
        {
            String Caracteres_Validos = "¡!@#$%&*-_=+[](){}:,<.>/¿?";
            Boolean Letras = false;
            Boolean Numeros = false;
            Boolean Caracter_Especial = false;
            Boolean Validado=false;
            bool Valido;
            foreach (char letra in Cadena)
            {
                //valida que sea letra
                 Valido = char.IsLetter(letra);
                if (Valido)
                {
                    Letras = true;
                }
                else
                {
                    //Valida que sea numero
                     Valido = char.IsNumber(letra);
                     if (Valido)
                     {
                         Numeros = true;
                     }
                     else
                     {
                         //Valida que sea un caracter permitido
                         if (Caracteres_Validos.IndexOf(letra) > -1)
                         {
                             Caracter_Especial = true;
                         }
                     }
                }
            }
            if (Letras && Numeros && Caracter_Especial)
            {
                Validado= true;
            }
            return Validado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Solo_Letras
        ///DESCRIPCIÓN  : Cargar solo letras
        ///PARAMENTROS  :
        ///CREO         : Sergio Manuel Gallardo
        ///FECHA_CREO   : 25/Feb/2013 12:38 p.m.
        ///MODIFICO     : Luis Alberto Salas
        ///FECHA_MODIFICO: 06/Mar/2013 10:15 a.m.
        ///CAUSA_MODIFICACIÓN: Se agrego condicion para que siguiera buscando controles,
        ///                    dentro de un contenedor de controles. Se ocultaron los
        ///                    controles sobre los que el usuario no tiene permiso.
        ///*******************************************************************************
        public static void Validar_Acceso_Sistema(String Nombre_Menu_SubMenu, Control Ctrl_Padre)
        {
            Cls_Apl_Roles_Negocio Rs_Accesos_Rol = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Accesos = new DataTable();
            Button Btn_Auxiliar = new Button();

            Rs_Accesos_Rol.P_Rol_Id = MDI_Frm_Apl_Principal.Rol_ID;
            Rs_Accesos_Rol.P_Nombre_Menu = Nombre_Menu_SubMenu;
            Dt_Accesos = Rs_Accesos_Rol.Consultar_Acceso_Roles();

            if (Dt_Accesos != null && Dt_Accesos.Rows.Count > 0)
            {
                foreach (Control Control_Formulario in Ctrl_Padre.Controls)
                {
                    if (Control_Formulario is Button)
                    {
                        if (Control_Formulario.Name.Contains("Nuevo"))
                        {
                            if (Dt_Accesos.Rows[0][Apl_Acceso.Campo_Alta].ToString() == "S")
                            {
                                Control_Formulario.Visible = true;
                            }
                            else
                            {
                                Control_Formulario.Visible = false;
                            }
                        }
                        if (Control_Formulario.Name.Contains("Modificar"))
                        {
                            if (Dt_Accesos.Rows[0][Apl_Acceso.Campo_Cambio].ToString() == "S")
                            {
                                Control_Formulario.Visible = true;
                            }
                            else
                            {
                                Control_Formulario.Visible = false;
                            }
                        }
                        if (Control_Formulario.Name.Contains("Eliminar"))
                        {
                            if (Dt_Accesos.Rows[0][Apl_Acceso.Campo_Eliminar].ToString() == "S")
                            {
                                Control_Formulario.Visible = true;
                            }
                            else
                            {
                                Control_Formulario.Visible = false;
                            }
                        }
                        if (Control_Formulario.Name.Contains("Buscar"))
                        {
                            if (Dt_Accesos.Rows[0][Apl_Acceso.Campo_Consultar].ToString() == "S")
                            {
                                Control_Formulario.Visible = true;
                            }
                            else
                            {
                                Control_Formulario.Visible = false;
                            }
                        }
                    }

                    // Si hay mas controles dentro, vuelve a llamarse asi misma la funcion.
                    if (Control_Formulario.Controls.Count > 0)
                    {
                        Validar_Acceso_Sistema(Nombre_Menu_SubMenu, Control_Formulario);
                    }
                }
            }
        }

        #endregion Validaciones

        #region Meses

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static String Convertir_Mes_Numerico_A_Equivalente_Texto(int Mes_Numerico)
        {
            String Mes_Texto = "";
            try
            {
                switch (Mes_Numerico)
                {
                    case 1:
                        Mes_Texto = "Enero";
                        break;

                    case 2:
                        Mes_Texto = "Febrero";
                        break;

                    case 3:
                        Mes_Texto = "Marzo";
                        break;

                    case 4:
                        Mes_Texto = "Abril";
                        break;

                    case 5:
                        Mes_Texto = "Mayo";
                        break;

                    case 6:
                        Mes_Texto = "Junio";
                        break;

                    case 7:
                        Mes_Texto = "Julio";
                        break;

                    case 8:
                        Mes_Texto = "Agosto";
                        break;

                    case 9:
                        Mes_Texto = "Septiembre";
                        break;

                    case 10:
                        Mes_Texto = "Octubre";
                        break;

                    case 11:
                        Mes_Texto = "Noviembre";
                        break;

                    case 12:
                        Mes_Texto = "Diciembre";
                        break;
                }

            }
            catch (Exception Ex)
            {
                new Exception(Ex.Message);
            }
            return Mes_Texto;
        }
        #endregion
    }
}