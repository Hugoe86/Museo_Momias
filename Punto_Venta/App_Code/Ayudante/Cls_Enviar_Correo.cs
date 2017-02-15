using System;
using System.Data;
using System.Net.Mail;
using Erp_Apl_Parametros.Negocio;
using Erp.Constantes;
using Erp.Seguridad;

namespace Erp.Envio_Email
{
    public class Cls_Enviar_Correo
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Envia_Correo
        ///DESCRIPCIÓN  : Envia un correo a un usuario
        ///PARAMENTROS  :
        ///CREO         : Sergio Manuel Gallardo Andrade
        ///FECHA_CREO   : 25/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        
        public static bool Envia_Correo(String Mensaje,String Correo_Destinatario)
        {
            try
            {
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                Consulta_Parametros.P_Parametro_Id = "00001";
                DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                if (Dt_Consulta != null)
                {
                    if (Dt_Consulta.Rows.Count >= 1)
                    {
                        DataTable Dt_Usuarios = new DataTable();
                        System.Net.Mail.MailMessage Mensaje_Correo = new System.Net.Mail.MailMessage();
                        Mensaje_Correo.To.Add(Correo_Destinatario);
                        Mensaje_Correo.From = new MailAddress(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Email].ToString(), "Notificación Sistema CONTEL", System.Text.Encoding.UTF8);
                        Mensaje_Correo.Subject = "Notificación Recuperación de Contraseña";
                        Mensaje_Correo.SubjectEncoding = System.Text.Encoding.UTF8;
                        Mensaje_Correo.Body = Mensaje;
                        Mensaje_Correo.BodyEncoding = System.Text.Encoding.UTF8;
                        Mensaje_Correo.IsBodyHtml = false;

                        SmtpClient Servidor = new SmtpClient();
                        Servidor.Credentials = new System.Net.NetworkCredential(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Email].ToString(), Cls_Seguridad.Desencriptar(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Contrasenia].ToString()));
                        Servidor.Port = Int16.Parse(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Puerto].ToString());
                        Servidor.Host = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Host_Email].ToString();
                        Servidor.EnableSsl = true;
                        Servidor.Send(Mensaje_Correo);
                    }
                }
            }
            catch (Exception E)
            {
                throw new Exception("Enviar_Correo: " + E.Message);
            }
            return false;
        }
    }
}
