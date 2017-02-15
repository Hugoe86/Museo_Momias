using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;

namespace Erp.Validador
{
    public class Validador_Generico
    {
        ErrorProvider errorProvider;
        // Declaración de expresiones regulares.
        public static Regex Moneda = new Regex(@"^-?\d+(\.\d{2})?$");
        public static Regex Url = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        public static Regex Email = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        public static Regex Nextel = new Regex(@"^(\d{2}\*)(\d{5}\*)(\d{1,2})$");
        public static Regex Numeros = new Regex(@"^[0-9]+$");
        public static Regex Contrasenia = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[A-Z])(?=.*[a-z]).*");
        public static Regex Letras_Tildes_Espacio = new Regex(@"^[a-zA-Z áéíóúAÉÍÓÚÑñ]+$");
        public static Regex Alfanumerico = new Regex(@"[a-zA-ZñÑ0-9]");
        public static Regex Alfanumerico_Extendido = new Regex(@"[a-zA-ZáéíóúAÉÍÓÚÑñ0-9\s\w\.@-]");
        public static Regex Hora = new Regex(@"^(0[1-9]|1\d|2[0-3]):([0-5]\d):([0-5]\d)$");

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion
        ///DESCRIPCIÓN          : Inicializa la clase validación.
        ///PARAMETROS           :     1.errorProvider_Copia, variable que hace referencia
        ///                                 al componente ErroProvider del formulario donde se 
        ///                                 instancie la clase.
        ///CREO                 : Luis Alberto Salas Garica
        ///FECHA_CREO           : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Validador_Generico(ErrorProvider errorProvider_Copia)
        {
            errorProvider = errorProvider_Copia;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Vacio
        ///DESCRIPCIÓN          : Comprueba que el campo no este vacio solamente.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 18/Enero/2013 12:24 P.M.
        ///MODIFICO             : Luis Alberto Salas García
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///CAUSA_MODIFICACIÓN   : Se cambio el nombre de la función y se agregaron más parámetros
        ///                       para hacerla función aplicable a cualquier formulario.
        ///*******************************************************************************
        public void Validacion_Campo_Vacio(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar)
        {
            if (String.IsNullOrWhiteSpace(Txt_Caja_Texto_Evaluar.Text))
            {
                errorProvider.SetError(Txt_Caja_Texto_Evaluar, "El Campo es requerido para continuar.");
                e.Cancel = true;
                return;
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Fecha
        ///DESCRIPCIÓN          : Valida que la fecha este escrita con el formato que se le envia.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Formato_Fecha, Cadena con el formato de fecha.
        ///                           4. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 18/Enero/2013 12:24 P.M.
        ///MODIFICO             : Luis Alberto Salas García
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///CAUSA_MODIFICACIÓN   : Se cambio el nombre de la función y se agregaron más parámetros
        ///                       para hacerla función aplicable a cualquier formulario.
        ///*******************************************************************************
        public void Validacion_Campo_Fecha(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, String Nombre_Campo, String Formato_Fecha, bool Requerido)
        {
            DateTime Dt_Fecha;
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!DateTime.TryParseExact(Txt_Caja_Texto_Evaluar.Text, Formato_Fecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out Dt_Fecha))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "Introduzca la " + Nombre_Campo + " con el formato " + Formato_Fecha + ".");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Numerico
        ///DESCRIPCIÓN          : Valida que solo esten ingresados caracteres numéricos en el campo
        ///                       de texto.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Numerico(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Numeros.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "Ingrese solo números.");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Alfanumerico
        ///DESCRIPCIÓN          : Valida que solo esten ingresados caracteres alafanuméricos,
        ///                       sin espacios ni tildes.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Alfanumerico(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Alfanumerico.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "Ingrese caracteres alfanumericos, sin espacios ni tildes.");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Alfanumerico_Extendido
        ///DESCRIPCIÓN          : Valida que solo esten ingresados caracteres alafanuméricos, tildes
        ///                       espacios y ciertos caracteres especiales '@' '-' o '.'.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Alfanumerico_Extendido(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Alfanumerico_Extendido.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "Ingrese caracteres alfanuméricos.");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Alfanumericos_Tildes_Espacio
        ///DESCRIPCIÓN          : Valida que solo esten ingresados caracteres alafanuméricos,
        ///                       tildes y espacios.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Letras_Tildes_Espacio(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Letras_Tildes_Espacio.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "Ingrese solo Letras, tildes y espacios");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Numerico
        ///DESCRIPCIÓN          : Valida que solo esten ingresados caracteres numéricos en el campo
        ///                       de texto.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Nextel(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Nextel.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "El # Nextel es incorrecto. Ejem: 12*34567*89");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Url
        ///DESCRIPCIÓN          : Valida que este ingresada correctamente una dirección url.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Url(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Url.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "La url es incorrecta. Ejem: http://www.ejemplo.com");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Moneda
        ///DESCRIPCIÓN          : Valida que este ingresada correctamente un campo moneda.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Moneda(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Moneda.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "El formato es incorrecto. Ejem: 1234.56");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Email
        ///DESCRIPCIÓN          : Valida que este ingresado correctamente un correo electrónico.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio, si es falso, 
        ///                                 es opcional, pero si contiene algún texto lo evalúa y muestra
        ///                                 el mensaje para que el usuario lo rellene correctamente.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Email(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Email.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "El formato de correo electrónico es incorrecto. Ejem: correo@ejemplo.com");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Contrasenia
        ///DESCRIPCIÓN          : Valida que este ingresada una contraseña cumpliendo las siguientes
        ///                       reglas:
        ///                           1. Tener al menos una letra mayúscula.
        ///                           2. Tener al menos una letra minúscula.
        ///                           3. Tener al menos un número o carácter especial.
        ///                           4. La longitud mínima es de 8 caracteres.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio y no permite
        ///                                 realizar las acciones, si es falso, es opcional, pero aún 
        ///                                 asi se muestra el mensaje.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Contrasenia(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, String Nombre_Campo, bool Requerido)
        {
            String Mensaje = "";
            Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            Mensaje += "La contraseña debe de seguir el siguiente formato:";
            Mensaje += "\nTener al menos una letra mayúscula.";
            Mensaje += "\nTener al menos una letra minúscula.";
            Mensaje += "\nTener al menos un número o carácter especial.";
            Mensaje += "\nLa longitud minima es de 8 caracteres.";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!Contrasenia.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje);
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Campo_Especial
        ///DESCRIPCIÓN          : Valida que este ingresado correctamente el campo, con una expresión
        ///                       regular en especifico.
        ///PARAMETROS           :     1. Txt_Caja_Texto_Evaluar, Campo de texto que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del campo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio y no permite
        ///                                 realizar las acciones, si es falso, es opcional, pero aún 
        ///                                 asi se muestra el mensaje.
        ///                           4. Expresion_Regular, Cadena con la expresión regular a evaluar.
        ///                           5. Formato, Cadena que contiene el formato que debe seguir el
        ///                                  campo, y es la que se le muestra al usuario.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Validacion_Campo_Especial(CancelEventArgs e, TextBox Txt_Caja_Texto_Evaluar, String Nombre_Campo, bool Requerido, String Expresion_Regular, String Formato)
        {
            Regex re = new Regex(@Expresion_Regular);
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido || Txt_Caja_Texto_Evaluar.Text.Trim().Length > 0)
            {
                if (!re.IsMatch(Txt_Caja_Texto_Evaluar.Text))
                {
                    errorProvider.SetError(Txt_Caja_Texto_Evaluar, Mensaje + "Ingrese el " + Nombre_Campo + " con formato " + Formato);
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Txt_Caja_Texto_Evaluar, "");
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validacion_Combo_Requerido
        ///DESCRIPCIÓN          : Valida que se seleccione un elemento en el combo.
        ///PARAMETROS           :     1. Cmb_Copia, Combo box que se va a evaluar.
        ///                           2. Nombre_Campo, Cadena con el nombre del combo a evaluar,
        ///                                 sirve para personalizar el mensaje que se muestra.
        ///                           3. Requerido, Si es verdadero el campo es obligatorio y no permite
        ///                                 realizar las acciones, si es falso, es opcional, pero aún 
        ///                                 asi se muestra el mensaje.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 18/Enero/2013 12:24 P.M.
        ///MODIFICO             : Luis Alberto Salas García
        ///FECHA_MODIFICO       : 27/Febrero/2013
        ///CAUSA_MODIFICACIÓN   : Se cambio el nombre de la función y se agregaron más parámetros
        ///                       para hacerla función aplicable a cualquier formulario.
        ///*******************************************************************************
        public void Validacion_Combo_Requerido(CancelEventArgs e, ComboBox Cmb_Combo_Box_Evaluar, bool Requerido)
        {
            String Mensaje = Requerido ? "Obligatorio. " : "Opcional. ";
            if (Requerido)
            {
                if (Cmb_Combo_Box_Evaluar.SelectedIndex < 1)
                {
                    errorProvider.SetError(Cmb_Combo_Box_Evaluar, Mensaje + "Seleccione una opción del combo ");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider.SetError(Cmb_Combo_Box_Evaluar, "");
        }
    }
}
