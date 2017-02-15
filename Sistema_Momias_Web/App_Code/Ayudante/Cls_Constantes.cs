using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace Erp.Constantes
{
    public class Cls_Constantes
    {
        public static String Gestor_Base_Datos = ConfigurationManager.ConnectionStrings["Gestor"].ProviderName.ToString();
        public static String Cadena_Conexion = ConfigurationManager.ConnectionStrings["Gestor"].ConnectionString;
        public static string Nombre_Base_Datos = "museo_momias_punto_venta";
    }

    ///**********************************************************************************************************************************
    ///                                                           NOMINA
    ///**********************************************************************************************************************************

    #region Nomina

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Nom_Empleados
    /// DESCRIPCIÓN: Clase que contiene los datos de los empleados
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Nom_Empleados
    {
        public const String Tabla_Cat_Nom_Empleados = "CAT_NOM_EMPLEADOS";
        public const String Campo_Empleado_Id = "EMPLEADO_ID";
        public const String Campo_Area_Id = "AREA_ID";
        public const String Campo_Nombre_Area = "NOMBRE_AREA";
        public const String Campo_Puesto_Id = "PUESTO_ID";
        public const String Campo_Nombre_Puesto = "NOMBRE_PUESTO";
        public const String Campo_Jefe_Id = "JEFE_ID";
        public const String Campo_Nombre_Jefe = "NOMBRE_JEFE";
        public const String Campo_Nombre_Completo = "NOMBRE_COMPLETO";
        public const String Campo_Nombres = "NOMBRES";
        public const String Campo_Apellido_Paterno = "APELLIDO_PATERNO";
        public const String Campo_Apellido_Materno = "APELLIDO_MATERNO";
        public const String Campo_Fecha_Nacimiento = "FECHA_NACIMIENTO";
        public const String Campo_Pais = "PAIS";
        public const String Campo_Localidad = "LOCALIDAD";
        public const String Campo_Estado = "ESTADO";
        public const String Campo_Colonia = "COLONIA";
        public const String Campo_Ciudad = "CIUDAD";
        public const String Campo_Calle = "CALLE";
        public const String Campo_Numero_Interior = "NUMERO_INTERIOR";
        public const String Campo_Numero_Exterior = "NUMERO_EXTERIOR";
        public const String Campo_CP = "CP";
        public const String Campo_RFC = "RFC";
        public const String Campo_CURP = "CURP";
        public const String Campo_No_IMSS = "NO_IMSS";
        public const String Campo_Telefono = "TELEFONO";
        public const String Campo_Celular = "CELULAR";
        public const String Campo_Nextel = "NEXTEL";
        public const String Campo_Email = "EMAIL";
        public const String Campo_Licencia_Manejo = "LICENCIA_MANEJO";
        public const String Campo_Vigencia_Licencia = "VIGENCIA_LICENCIA";
        public const String Campo_Tipo_Sangre = "TIPO_SANGRE";
        public const String Campo_Alergias = "ALERGIAS";
        public const String Campo_Sueldo = "SUELDO";
        public const String Campo_Sueldo_Diario = "SUELDO_DIARIO";
        public const String Campo_Fecha_Contrato = "FECHA_CONTRATADO";
        public const String Campo_Fecha_Baja = "FECHA_BAJA";
        public const String Campo_Motivo_Baja = "MOTIVO_BAJA";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Nom_Areas
    /// DESCRIPCIÓN: Clase que contiene las area de la empresa
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Nom_Areas
    {
        public const String Tabla_Cat_Nom_Areas = "CAT_NOM_AREAS";
        public const String Campo_Area_Id = "AREA_ID";
        public const String Campo_Centro_Costo_Id = "CENTRO_COSTO_ID";
        public const String Campo_Nombre = "NOMBRE";
        public const String Campo_Descripcion = "DESCRIPCION";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Nom_Centro_Costo
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Nom_Centro_Costo
    {
        public const String Tabla_Cat_Nom_Centro_Costo = "CAT_NOM_CENTRO_COSTO";
        public const String Campo_Centro_Costo_Id = "CENTRO_COSTO_ID";
        public const String Campo_Nombre = "NOMBRE";
        public const String Campo_Descripcion = "DESCRIPCION";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Nom_Puestos
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Nom_Puestos
    {
        public const String Tabla_Cat_Nom_Puestos = "CAT_NOM_PUESTOS";
        public const String Campo_Puesto_Id = "PUESTO_ID";
        public const String Campo_Nombre = "NOMBRE";
        public const String Campo_Descripcion = "DESCRIPCION";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    #endregion Nomina

    ///**********************************************************************************************************************************
    ///                                                           ADMINISTRACION
    ///**********************************************************************************************************************************

    #region Administracion

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Adm_Proveedores
    /// DESCRIPCIÓN: Clase que contiene los datos de los Proveedores
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Adm_Proveedores
    {
        public const String Tabla_Cat_Adm_Proveedores = "CAT_ADM_PROVEEDORES";
        public const String Campo_Proveedor_Id = "PROVEEDOR_ID";
        public const String Campo_Giro_Id = "GIRO_ID";
        public const String Campo_Nombre_Corto = "NOMBRE_CORTO";
        public const String Campo_Razon_Social = "RAZON_SOCIAL";
        public const String Campo_RFC = "RFC";
        public const String Campo_Pais = "PAIS";
        public const String Campo_Estado = "ESTADO";
        public const String Campo_Localidad = "LOCALIDAD";
        public const String Campo_Colonia = "COLONIA";
        public const String Campo_Ciudad = "CIUDAD";
        public const String Campo_Calle = "CALLE";
        public const String Campo_Numero_Interior = "NUMERO_INTERIOR";
        public const String Campo_Numero_Exterior = "NUMERO_EXTERIOR";
        public const String Campo_CP = "CP";
        public const String Campo_Fax = "FAX";
        public const String Campo_Telefono = "TELEFONO";
        public const String Campo_Extension = "EXTENSION";
        public const String Campo_Nextel = "NEXTEL";
        public const String Campo_Email = "EMAIL";
        public const String Campo_Sitio_Web = "SITIO_WEB";
        public const String Campo_Dias_Credito = "DIAS_CREDITO";
        public const String Campo_Limite_Credito = "LIMITE_CREDITO";
        public const String Campo_Descuento = "DESCUENTO";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Adm_Contactos
    /// DESCRIPCIÓN: Clase que contiene los contactos
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Adm_Contactos
    {
        public const String Tabla_Cat_Adm_Contactos = "CAT_ADM_CONTACTOS";
        public const String Campo_Contacto_Id = "CONTACTO_ID";
        public const String Campo_Cliente_Id = "CLIENTE_ID";
        public const String Campo_Proveedor_Id = "PROVEEDOR_ID";
        public const String Campo_Tipo_Contacto = "TIPO_CONTACTO";
        public const String Campo_Nombre_Completo = "NOMBRE_COMPLETO";
        public const String Campo_Nombres = "NOMBRES";
        public const String Campo_Apellido_Paterno = "APELLIDO_PATERNO";
        public const String Campo_Apellido_Materno = "APELLIDO_MATERNO";
        public const String Campo_Telefono_1 = "TELEFONO_1";
        public const String Campo_Telefono_2 = "TELEFONO_2";
        public const String Campo_Nextel = "NEXTEL";
        public const String Campo_Puesto = "PUESTO";
        public const String Campo_Area = "AREA";
        public const String Campo_Tipo = "TIPO";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Adm_Clientes
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Adm_Clientes
    {
        public const String Tabla_Cat_Adm_Clientes = "CAT_ADM_CLIENTES";
        public const String Campo_Cliente_Id = "CLIENTE_ID";
        public const String Campo_Giro_Id = "GIRO_ID";
        public const String Campo_Nombre_Corto = "NOMBRE_CORTO";
        public const String Campo_Razon_Social = "RAZON_SOCIAL";
        public const String Campo_RFC = "RFC";
        public const String Campo_CURP = "CURP";
        public const String Campo_Pais = "PAIS";
        public const String Campo_Estado = "ESTADO";
        public const String Campo_Localidad = "LOCALIDAD";
        public const String Campo_Colonia = "COLONIA";
        public const String Campo_Ciudad = "CIUDAD";
        public const String Campo_Calle = "CALLE";
        public const String Campo_Numero_Exterior = "NUMERO_EXTERIOR";
        public const String Campo_Numero_Interior = "NUMERO_INTERIOR";
        public const String Campo_CP = "CP";
        public const String Campo_Fax = "FAX";
        public const String Campo_Telefono_1 = "TELEFONO_1";
        public const String Campo_Telefono_2 = "TELEFONO_2";
        public const String Campo_Extension = "EXTENSION";
        public const String Campo_Nextel = "NEXTEL";
        public const String Campo_Email = "EMAIL";
        public const String Campo_Sitio_Web = "SITIO_WEB";
        public const String Campo_Dias_Credito = "DIAS_CREDITO";
        public const String Campo_Limite_Credito = "LIMITE_CREDITO";
        public const String Campo_Descuento = "DESCUENTO";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Adm_Giros_Empresariales
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Adm_Giros_Empresariales
    {
        public const String Tabla_Cat_Adm_Giros_Empresariales = "CAT_ADM_GIROS_EMPRESARIALES";
        public const String Campo_Giro_Id = "GIRO_ID";
        public const String Campo_Nombre = "NOMBRE";
        public const String Campo_Descripcion = "DESCRIPCION";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    #endregion Administracion

    ///**********************************************************************************************************************************
    ///                                                           APLICACION
    ///**********************************************************************************************************************************

    #region Alicacion

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Apl_Contratos
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 14 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Apl_Contratos
    {
        public const String Tabla_Apl_Contratos = "APL_CONTRATOS";
        public const String Campo_Contrato_Id = "CONTRATO_ID";
        public const String Campo_Empresa_Id = "EMPRESA_ID";
        public const String Campo_Tipo_Sistema = "TIPO_SISTEMA";
        public const String Campo_Costo = "COSTO";
        public const String Campo_Comentarios = "COMENTARIOS";
        public const String Campo_Nombre_Base_Datos = "NOMBRE_BASE_DATOS";
        public const String Campo_Usuario_Base_Datos = "USUARIO_BASE_DATOS";
        public const String Campo_Contrasena_Base_Datos = "CONTRASENA_BASE_DATOS";
        public const String Campo_Ip_Base_Datos = "IP_BASE_DATOS";
        public const String Campo_Fecha_Contrato = "FECHA_CONTRATO";
        public const String Campo_Fecha_Renovacion = "FECHA_RENOVACION";
        public const String Campo_Fecha_Expira = "FECHA_EXPIRA";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Empresas
    /// DESCRIPCIÓN: Clase que contiene los datos de las empresas
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 14 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Empresas
    {
        public const String Tabla_Cat_Empresas = "CAT_EMPRESAS";
        public const String Campo_Empresa_Id = "EMPRESA_ID";
        public const String Campo_Nombre_Corto = "NOMBRE_CORTO";
        public const String Campo_Razon_Social = "RAZON_SOCIAL";
        public const String Campo_RFC = "RFC";
        public const String Campo_Giro = "GIRO";
        public const String Campo_Calle = "CALLE";
        public const String Campo_Numero_Exterior = "NUMERO_EXTERIOR";
        public const String Campo_Numero_Interior = "NUMERO_INTERIOR";
        public const String Campo_Colonia = "COLONIA";
        public const String Campo_Ciudad = "CIUDAD";
        public const String Campo_Localidad = "LOCALIDAD";
        public const String Campo_Estado = "ESTADO";
        public const String Campo_Pais = "PAIS";
        public const String Campo_CP = "CP";
        public const String Campo_Fax = "FAX";
        public const String Campo_Telefono = "TELEFONO";
        public const String Campo_Telefono_2 = "TELEFONO_2";
        public const String Campo_Extension = "EXTENSION";
        public const String Campo_Nextel = "NEXTEL";
        public const String Campo_Contacto = "CONTACTO";
        public const String Campo_Email = "EMAIL";
        public const String Campo_Sitio_Web = "SITIO_WEB";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Apl_Menus
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Apl_Menus
    {
        public const String Tabla_Apl_Menus = "APL_MENUS";
        public const String Campo_Menu_Id = "MENU_ID";
        public const String Campo_Parent_Id = "PARENT_ID";
        public const String Campo_Menu_Descripcion = "MENU_DESCRIPCION";
        public const String Campo_Url_Link = "URL_LINK";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    #endregion Alicacion

    ///**********************************************************************************************************************************
    ///                                                           SEGURIDAD
    ///**********************************************************************************************************************************

    #region Seguridad

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Apl_Registro_Accesos
    /// DESCRIPCIÓN: Clase que contiene los datos de registro de usuarios
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 14 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Apl_Registro_Accesos
    {
        public const String Tabla_Apl_Registro_Accesos = "APL_REGISTRO_ACCESOS";
        public const String Campo_Registro_Id = "REGISTRO_ID";
        public const String Campo_Usuario_Id = "USUARIO_ID";
        public const String Campo_Tipo = "TIPO";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Apl_Bitacora
    /// DESCRIPCIÓN: Clase que contiene las actividades de los registro
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 14 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Apl_Bitacora
    {
        public const String Tabla_Apl_Bitacora = "APL_BITACORA";
        public const String Campo_Bitacora_Id = "BITACORA_ID";
        public const String Campo_Usuario_Id = "USUARIO_ID";
        public const String Campo_Recurso_Id = "RECURSO_ID";
        public const String Campo_Accion = "ACCION";
        public const String Campo_Recurso = "RECURSO";
        public const String Campo_Descripcion = "DESCRIPCION";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Apl_Usuarios
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 13 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Apl_Usuarios
    {
        public const String Tabla_Apl_Usuarios = "APL_USUARIOS";
        public const String Campo_Usuario_Id = "USUARIO_ID";
        public const String Campo_Usuario = "USUARIO";
        public const String Campo_Rol_Id = "ROL_ID";
        public const String Campo_Nombre_Usuario = "NOMBRE_USUARIO";
        public const String Campo_Contrasenia = "CONTRASENIA";
        public const String Campo_Fecha_Expira_Contrasenia = "FECHA_EXPIRA_CONTRASENIA";
        public const String Campo_Email = "EMAIL";
        public const String Campo_No_Intentos_Acceso = "NO_INTENTOS_ACCESO";
        public const String Campo_No_Intentos_Recuperar = "NO_INTENTOS_RECUPERAR";
        public const String Campo_Comentario = "COMENTARIO";
        public const String Campo_Pregunta_Secreta = "PREGUNTA_SECRETA";
        public const String Campo_Respuesta_Secreta = "RESPUESTA_SECRETA";
        public const String Campo_Fecha_Intento_Acceso = "FECHA_INTENTO_ACCESO";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Caja_ID = "CAJA_ID";
        public const String Campo_Fecha_Ultimo_Acceso = "FECHA_ULTIMO_ACCESO";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Apl_Roles
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 14 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Apl_Roles
    {
        public const String Tabla_Apl_Roles = "APL_ROLES";
        public const String Campo_Rol_Id = "Rol_ID";
        public const String Campo_Nombre = "Nombre";
        public const String Campo_Descripcion = "Descripcion";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Tipo = "Tipo";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Apl_Acceso
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 14 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Apl_Acceso
    {
        public const String Tabla_Apl_Acceso = "APL_ACCESO";
        public const String Campo_Rol_Id = "ROL_ID";
        public const String Campo_Menu_Id = "MENU_ID";
        public const String Campo_Nombre_Menu = "NOMBRE_MENU";
        public const String Campo_Tipo_Menu = "TIPO_MENU";
        public const String Campo_Habilitado = "HABILITADO";
        public const String Campo_Alta = "ALTA";
        public const String Campo_Cambio = "CAMBIO";
        public const String Campo_Eliminar = "ELIMINAR";
        public const String Campo_Consultar = "CONSULTAR";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Menus
    /// DESCRIPCIÓN:
    /// PARÁMETROS :
    /// CREO       : Alejandro Leyva Alvarado
    /// FECHA_CREO : 14 Febrero 2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Menus
    {
        public const String Tabla_Cat_Menus = "CAT_MENUS";
        public const String Campo_Menu_Id = "MENU_ID";
        public const String Campo_Parent_Id = "PARENT_ID";
        public const String Campo_Menu_Descripcion = "MENU_DESCRIPCION";
        public const String Campo_Url_Link = "URL_LINK";
        public const String Campo_Nombre_Menu = "NOMBRE_MOSTRAR";
        public const String Campo_Orden = "ORDEN";
        public const String Campo_Estatus = "ESTATUS";
        public const String Campo_Usuario_Creo = "USUARIO_CREO";
        public const String Campo_Ip_Creo = "IP_CREO";
        public const String Campo_Equipo_Creo = "EQUIPO_CREO";
        public const String Campo_Fecha_Creo = "FECHA_CREO";
        public const String Campo_Usuario_Modifico = "USUARIO_MODIFICO";
        public const String Campo_Ip_Modifico = "IP_MODIFICO";
        public const String Campo_Equipo_Modifico = "EQUIPO_MODIFICO";
        public const String Campo_Fecha_Modifico = "FECHA_MODIFICO";
    }

    #endregion Seguridad

    ///**********************************************************************************************************************************
    ///                                                           OPERACIÓN
    ///**********************************************************************************************************************************

    #region Operación
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Estacionamiento
    /// DESCRIPCIÓN: Clase para la tabla Ope_Turnos y sus campos
    /// PARÁMETROS :
    /// CREO       : Juan Alberto Hernández Negrete.
    /// FECHA_CREO : 13 Noviembre 2013 18:43 Hrs.
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Estacionamiento
    {
        public const String Tabla_Ope_Estacionamiento = "Ope_Estacionamiento";
        public const String Campo_No_Estacionamiento = "No_Estacionamiento";
        public const String Campo_Fecha_Hora_Ingreso = "Fecha_Hora_Ingreso";
        public const String Campo_Fecha_Hora_Salida = "Fecha_Hora_Salida";
        public const String Campo_Horas = "Horas";
        public const String Campo_Codigo = "Codigo";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Importe = "Importe";
        public const String Campo_Producto_ID = "Producto_Id";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Turnos
    /// DESCRIPCIÓN: Clase para la tabla Ope_Turnos y sus campos
    /// PARÁMETROS :
    /// CREO       : Roberto González Oseguera
    /// FECHA_CREO : 03-oct-2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Turnos
    {
        public const String Tabla_Ope_Turnos = "Ope_Turnos";
        public const String Campo_No_Turno = "No_Turno";
        public const String Campo_Turno_ID = "Turno_ID";
        public const String Campo_Fecha_Hora_Inicio = "Fecha_Hora_Inicio";
        public const String Campo_Fecha_Hora_Cierre = "Fecha_Hora_Cierre";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Accesos
    /// DESCRIPCIÓN       : Clase que continene la tabla Ope_Accesos y sus campos
    /// PARÁMETROS:
    /// CREO              : Antonio Salvador Benavides Guardado
    /// FECHA_CREO        : 03-Octubre-2013
    /// MODIFICO:
    /// FECHA_MODIFICO:
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Accesos
    {
        public const String Tabla_Ope_Accesos = "Ope_Accesos";
        public const String Campo_No_Acceso = "No_Acceso";
        public const String Campo_No_Venta = "No_Venta";
        public const String Campo_Producto_ID = "Producto_ID";
        public const String Campo_Terminal_ID = "Terminal_ID";
        public const String Campo_Numero_Serie = "Numero_Serie";
        public const String Campo_Vigencia_Inicio = "Vigencia_Inicio";
        public const String Campo_Vigencia_Fin = "Vigencia_Fin";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Fecha_Hora_Acceso = "Fecha_Hora_Acceso";
        public const String Campo_Fecha_Hora_Salida = "Fecha_Hora_Salida";
        public const String Campo_Tipo = "Tipo";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
        public const String Campo_Fecha_Expedicion = "Fecha_Expedicion";
    }
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Pagos
    /// DESCRIPCIÓN       : Clase que continene la tabla Ope_Pagos y sus campos
    /// PARÁMETROS:
    /// CREO              : Antonio Salvador Benavides Guardado
    /// FECHA_CREO        : 03-Octubre-2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Pagos
    {
        public const String Tabla_Ope_Pagos = "Ope_Pagos";
        public const String Campo_No_Pago = "No_Pago";
        public const String Campo_No_Venta = "No_Venta";
        public const String Campo_No_Caja = "No_Caja";
        public const String Campo_Forma_ID = "Forma_ID";
        public const String Campo_Motivo_ID = "Motivo_ID";
        public const String Campo_Banco_ID = "Banco_ID";
        public const String Campo_No_Estacionamiento = "No_Estacionamiento";
        public const String Campo_Monto_Pago = "Monto_Pago";
        public const String Campo_Monto_Comision = "Monto_Comision";
        public const String Campo_Numero_Transaccion = "Numero_Transaccion";
        public const String Campo_Numero_Cheque = "Numero_Cheque";
        public const String Campo_Referencia_Transferencia = "Referencia_Transferencia";
        public const String Campo_Numero_Tarjeta_Banco = "Numero_Tarjeta_Banco";
        public const String Campo_Tipo_Tarjeta_Banco = "Tipo_Tarjeta";
        public const String Campo_Fecha_Cancelacion = "Fecha_Cancelacion";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
        public const String Campo_Domicilio = "Domicilio";
        public const String Campo_Estado = "Estado";
        public const String Campo_Ciudad = "Ciudad";
        public const String Campo_Codigo_Postal = "Codigo_Postal";
        public const String Campo_Titular_Tarjeta = "Titular_Tarjeta";
    }
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Retiros
    /// DESCRIPCIÓN: Clase que contiene los datos de registro de los retiros que se harán de las cajas
    /// PARÁMETROS :
    /// CREO       : Juan Alberto Hernández Negrete
    /// FECHA_CREO : 03 Octubre 2013 11:21 a.m.
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Retiros
    {
        public const string Tabla_Ope_Retiros = "Ope_Retiros";
        public const string Campo_No_Retiro = "No_Retiro";
        public const string Campo_No_Caja = "No_Caja";
        public const string Campo_Usuario_ID_Autoriza = "Usuario_ID_Autoriza";
        public const string Campo_Cantidad = "Cantidad";
        public const string Campo_Motivo = "Motivo";
        public const string Campo_Fecha = "Fecha";
        public const string Campo_Usuario_Creo = "Usuario_Creo";
        public const string Campo_Fecha_Creo = "Fecha_Creo";
        public const string Campo_Usuario_Modifico = "Usuario_Modifico";
        public const string Campo_Fecha_Modifico = "Fecha_Modifico";
    }
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Recolecciones
    /// DESCRIPCIÓN: Clase que contiene los datos de registro de las recolecciones que se harán de las cajas
    /// PARÁMETROS :
    /// CREO       : Juan Alberto Hernández Negrete
    /// FECHA_CREO : 03 Octubre 2013 11:24 a.m.
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Recolecciones
    {
        public const string Tabla_Ope_Recolecciones = "Ope_Recolecciones";
        public const string Campo_No_Recoleccion = "No_Recoleccion";
        public const string Campo_No_Caja = "No_Caja";
        public const string Campo_Usuario_ID_Colecta = "Usuario_ID_Colecta";
        public const string Campo_Numero_Recoleccion = "Numero_Recoleccion";
        public const string Campo_Numero_Arqueo = "Numero_Arqueo";
        public const string Campo_Fecha_Hora = "Fecha_Hora";
        public const string Campo_Monto_Recolectado = "Monto_Recolectado";
        public const string Campo_Estatus = "Estatus";
        public const string Campo_Motivo_Cancelacion = "Motivo_Cancelacion";
        public const string Campo_Tipo = "Tipo";
        public const string Campo_Usuario_Creo = "Usuario_Creo";
        public const string Campo_Fecha_Creo = "Fecha_Creo";
        public const string Campo_Usuario_Modifico = "Usuario_Modifico";
        public const string Campo_Fecha_Modifico = "Fecha_Modifico";
        public const string Campo_Total_Cancelaciones = "Total_Cancelaciones";
        public const string Campo_Total_Tarjeta = "Total_Tarjeta";
        public const string Campo_Resultado_Corte = "Resultado_Corte";
        public const string Campo_Total_Retiros = "Total_Retiros";
        public const string Campo_Total_Cortes = "Total_Cortes";
        public const string Campo_Monto_Depositar = "Monto_Depositar";
    }
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Recolecciones_Detalles
    /// DESCRIPCIÓN: Clase que contiene los datos de registro de los detalles de las recolecciones que se harán de las cajas
    /// PARÁMETROS :
    /// CREO       : Juan Alberto Hernández Negrete
    /// FECHA_CREO : 03 Octubre 2013 11:28 a.m.
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Recolecciones_Detalles
    {
        public const string Tabla_Ope_Recolecciones_Detalles = "Ope_Recolecciones_Detalles";
        public const string Campo_No_Recoleccion = "No_Recoleccion";
        public const string Campo_Billetes_1000 = "Billetes_1000";
        public const string Campo_Billetes_500 = "Billetes_500";
        public const string Campo_Billetes_200 = "Billetes_200";
        public const string Campo_Billetes_100 = "Billetes_100";
        public const string Campo_Billetes_50 = "Billetes_50";
        public const string Campo_Billetes_20 = "Billetes_20";
        public const string Campo_Monedas_20 = "Monedas_20";
        public const string Campo_Monedas_10 = "Monedas_10";
        public const string Campo_Monedas_5 = "Monedas_5";
        public const string Campo_Monedas_2 = "Monedas_2";
        public const string Campo_Monedas_1 = "Monedas_1";
        public const string Campo_Monedas_050 = "Monedas_050";
        public const string Campo_Monedas_020 = "Monedas_020";
        public const string Campo_Monedas_010 = "Monedas_010";
        public const string Campo_Usuario_Creo = "Usuario_Creo";
        public const string Campo_Fecha_Creo = "Fecha_Creo";
        public const string Campo_Usuario_Modifico = "Usuario_Modifico";
        public const string Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Descuentos
    /// DESCRIPCIÓN       : Clase que continene la tabla Ope_Descuentos y sus campos
    /// PARÁMETROS:
    /// CREO              : Antonio Salvador Benavides Guardado
    /// FECHA_CREO        : 07-Octubre-2013
    /// MODIFICO:
    /// FECHA_MODIFICO:
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Descuentos
    {
        public const String Tabla_Ope_Descuentos = "Ope_Descuentos";
        public const String Campo_No_Descuento = "No_Descuento";
        public const String Campo_No_Pago = "No_Pago";
        public const String Campo_Cantidad = "Cantidad";
        public const String Campo_Monto_Pago = "Monto_Pago";
        public const String Campo_Descuento_Pago = "Descuento_Pago";
        public const String Campo_Total_Pagar = "Total_Pagar";
        public const String Campo_Fecha_Descuento = "Fecha_Descuento";
        public const String Campo_Fecha_Vencimiento = "Fecha_Vencimiento";
        public const String Campo_Fundamento_Legal = "Fundamento_Legal";
        public const String Campo_Observaciones = "Observaciones";
        public const String Campo_Realizo = "Realizo";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }
	
	///*******************************************************************************
    /// NOMBRE DE LA CLASE : Ope_Cajas
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a las operaciones de caja
    /// PARÁMETROS         :
    /// CREO               : Héctor Gabriel Galicia Luna
    /// FECHA_CREO         : 11 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Ope_Cajas
    {
        public const String Tabla_Ope_Cajas = "Ope_Cajas";
        public const String Campo_No_Caja = "No_Caja";
        public const String Campo_No_Turno = "No_Turno";
        public const String Campo_Usuario_ID = "Usuario_ID";
        public const String Campo_Caja_ID = "Caja_ID";
        public const String Campo_Monto_Inicial = "Monto_Inicial";
        public const String Campo_Fecha_Hora_Inicio = "Fecha_Hora_Inicio";
        public const String Campo_Fecha_Hora_Cierre = "Fecha_Hora_Cierre";
        public const String Campo_Estatus = "Estatus";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Ventas
    /// DESCRIPCIÓN       : Clase que continene la tabla Ope_Ventas y sus campos
    /// PARÁMETROS:
    /// CREO              : Miguel Angel Bedolla Moreno
    /// FECHA_CREO        : 14-Octubre-2013
    /// MODIFICO:
    /// FECHA_MODIFICO:
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Ventas
    {
        public const String Tabla_Ope_Ventas = "Ope_Ventas";
        public const String Campo_No_Venta = "No_Venta";
        public const String Campo_Subtotal = "Subtotal";
        public const String Campo_Impuestos = "Impuestos";
        public const String Campo_Descuentos = "Descuentos";
        public const String Campo_Total = "Total";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Motivo_Descuento_Id = "Motivo_Descuento_ID";
        public const String Campo_Usuario_Autoriza_ID = "Usuario_Autoriza_ID";
        public const String Campo_Fecha_Tramite = "Fecha_Tramite";
        public const String Campo_Persona_Tramita = "Persona_Tramita";
        public const String Campo_Empresa = "Empresa";
        public const String Campo_Fecha_Inicio_Vigencia = "Fecha_Inicio_Vigencia";
        public const String Campo_Fecha_Fin_Vigencia = "Fecha_Fin_Vigencia";
        public const String Campo_Aplican_Dias_Festivos = "Aplican_Dias_Festivos";
        public const String Campo_Motivo_Cancelacion = "Motivo_Cancelacion";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
        public const String Campo_Lugar_Venta = "Lugar_Venta";
        public const String Campo_Fecha_Cancelacion = "Fecha_Cancelacion";
        public const String Campo_Usuario_Cancelo = "Usuario_Cancelo";
        public const String Campo_Correo_Electronico = "Correo_Electronico";
        public const String Campo_Telefono = "Telefono";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Ope_Ventas
    /// DESCRIPCIÓN       : Clase que continene la tabla Ope_Ventas y sus campos
    /// PARÁMETROS:
    /// CREO              : Miguel Angel Bedolla Moreno
    /// FECHA_CREO        : 14-Octubre-2013
    /// MODIFICO:
    /// FECHA_MODIFICO:
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Ope_Ventas_Detalles
    {
        public const String Tabla_Ope_Ventas_Detalles = "Ope_Ventas_Detalles";
        public const String Campo_No_Venta = "No_Venta";
        public const String Campo_Producto_Id = "Producto_ID";
        public const String Campo_Cantidad = "Cantidad";
        public const String Campo_Subtotal = "Subtotal";
        public const String Campo_Total = "Total";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }
    #endregion Operación

    ///**********************************************************************************************************************************
    ///                                                           CATÁLOGOS
    ///**********************************************************************************************************************************

    #region Catálogos

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE: Cat_Turnos
    /// DESCRIPCIÓN: Clase para la tabla Cat_Turnos y sus campos
    /// PARÁMETROS :
    /// CREO       : Roberto González Oseguera
    /// FECHA_CREO : 03-oct-2013
    /// MODIFICO          :
    /// FECHA_MODIFICO    :
    /// CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    public class Cat_Turnos
    {
        public const String Tabla_Cat_Turnos = "Cat_Turnos";
        public const String Campo_Turno_ID = "Turno_ID";
        public const String Campo_Nombre = "Nombre";
        public const String Campo_Comentarios = "Comentarios";
        public const String Campo_Hora_Inicio = "Hora_Inicio";
        public const String Campo_Hora_Cierre = "Hora_Cierre";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Fijo = "Fijo";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Productos
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a los productos
    /// PARÁMETROS         :
    /// CREO               : Héctor Gabriel Galicia Luna
    /// FECHA_CREO         : 03 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Productos
    {
        public const String Tabla_Cat_Productos = "Cat_Productos";
        public const String Campo_Producto_Id = "Producto_Id";
        public const String Campo_Nombre = "Nombre";
        public const String Campo_Descripcion = "Descripcion";
        public const String Campo_Tipo = "Tipo";
        public const String Campo_Tipo_Servicio = "Tipo_Servicio";
        public const String Campo_Tipo_Valor = "Tipo_Valor";
        public const String Campo_Costo = "Costo";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Ruta_Imagen = "Ruta_Imagen";
        public const String Campo_Codigo = "Codigo";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
        public const String Campo_Web = "Web";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Cajas
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a las cajas
    /// PARÁMETROS         :
    /// CREO               : Héctor Gabriel Galicia Luna
    /// FECHA_CREO         : 04 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Cajas
    {
        public const String Tabla_Cat_Cajas = "Cat_Cajas";
        public const String Campo_Caja_ID = "Caja_ID";
        public const String Campo_Numero_Caja = "Numero_Caja";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Comentarios = "Comentarios";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Formas_Pago
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a las formas de pago
    /// PARÁMETROS         :
    /// CREO               : Héctor Gabriel Galicia Luna
    /// FECHA_CREO         : 09 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Formas_Pago 
    {
        public const String Tabla_Cat_Formas_Pago = "Cat_Formas_Pago";
        public const String Campo_Forma_ID = "Forma_ID";
        public const String Campo_Nombre = "Nombre";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";           
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Bancos
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a los bancos
    /// PARÁMETROS         :
    /// CREO               : Héctor Gabriel Galicia Luna
    /// FECHA_CREO         : 10 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Bancos
    {
        public const String Tabla_Cat_Bancos = "Cat_Bancos";
        public const String Campo_Banco_ID = "Banco_ID";
        public const String Campo_Moneda = "Moneda";
        public const String Campo_Nombre = "Nombre";
        public const String Campo_Cuenta = "Cuenta";
        public const String Campo_Ruta_Logo = "Ruta_Logo";
        public const String Campo_Comision = "Comision";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Bancos
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a los Motivos de Descuento
    /// PARÁMETROS         :
    /// CREO               : Héctor Gabriel Galicia Luna
    /// FECHA_CREO         : 10 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Motivos_Descuento
    {
        public const String Tabla_Cat_Motivos_Descuento = "Cat_Motivos_Descuento";
        public const String Campo_Motivo_Descuento_ID = "Motivo_Descuento_ID";
        public const String Campo_Descripcion = "Descripcion";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Dias_Feriados
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a los Días Feriados
    /// PARÁMETROS         :
    /// CREO               : Héctor Gabriel Galicia Luna
    /// FECHA_CREO         : 14 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Dias_Feriados 
    {
        public const String Tabla_Cat_Dias_Feriados = "Cat_Dias_Feriados";
        public const String Campo_Dia_ID = "Dia_ID";
        public const String Campo_Descripcion = "Descripcion";
        public const String Campo_Fecha = "Fecha";
        public const String Campo_Fecha_Fin = "Fecha_Fin";
        public const String Campo_Anios = "Anios";
        public const String Campo_Estatus = "Estatus";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Motivos_Cancelacion
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a los Motivos de Cancelación
    /// PARÁMETROS         :
    /// CREO               : Luis Eugenio Razo Mendiola
    /// FECHA_CREO         : 14 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Motivos_Cancelacion
    {
        public const string Tabla_Cat_Motivos_Cancelacion = "Cat_Motivos_Cancelacion";
        public const string Campo_Motivo_ID = "Motivo_ID";
        public const string Campo_Motivo = "Motivo";
        public const string Campo_Descripcion = "Descripción";
        public const string Campo_Leyenda = "Leyenda";
        public const string Campo_Estatus = "Estatus";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Impresoras
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada a las impresoras
    /// PARÁMETROS         :
    /// CREO               : Luis Eugenio Razo Mendiola
    /// FECHA_CREO         : 15 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************

    public class Cat_Impresoras
    {
        public const string Tabla_Cat_Impresoras = "Cat_Impresoras";
        public const string Campo_Impresora_Id = "Impresora_Id";
        public const string Campo_Nombre_Impresora = "Nombre_Impresora";
        public const string Campo_Ip = "Ip";
        public const string Campo_Ubicacion = "Ubicacion";
        public const string Campo_Comentarios = "Comentarios";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Terminales
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada con las terminales
    /// PARÁMETROS         :
    /// CREO               : Luis Eugenio Razo Mendiola
    /// FECHA_CREO         : 16 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************

    public class Cat_Terminales
    {
        public const String Tabla_Cat_Terminales = "Cat_Terminales";
        public const String Campo_Terminal_ID = "Terminal_ID";
        public const String Campo_Nombre = "Nombre";
        public const String Campo_Puerto = "Puerto";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Parametros
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada con los Parametros
    /// PARÁMETROS         :
    /// CREO               : Luis Eugenio Razo Mendiola
    /// FECHA_CREO         : 16 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Parametros
    {
        public const String Tabla_Cat_Parametros = "Cat_Parametros";
        public const String Campo_Parametro_ID = "Parametro_Id";
        public const String Campo_Dias_Vigencia = "Dias_Vigencia";
        public const String Campo_Directorio_Compartido = "Directorio_Compartido";
        public const String Campo_Encabezado_Recibo = "Encabezado_Recibo";
        public const String Campo_Mensaje_Dia_Recibo = "Mensaje_Dia_Recibo";
        public const String Campo_Email = "Email";
        public const String Campo_Contrasenia = "Contrasenia";
        public const String Campo_Host_Email = "Host_Email";
        public const String Campo_Puerto = "Puerto";
        public const String Campo_Mensaje_Sistema = "Mensaje_Sistema";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
        public const String Campo_Asunto_Correo = "Asunto_Correo";
        public const String Campo_Texto_Correo = "Texto_Correo";
        public const String Campo_Leyenda = "Leyenda";
        public const String Campo_Producto_Id_Web = "Producto_Id_Web";
        public const String Campo_Vigencia_Web = "Vigencia_WEB";
    }

    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Descuentos
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada con los Descuento
    /// PARÁMETROS         :
    /// CREO               : Luis Eugenio Razo Mendiola
    /// FECHA_CREO         : 17 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Descuentos
    {
        public const String Tabla_Cat_Descuentos = "Cat_Descuentos";
        public const String Campo_Descuento_ID = "Descuento_ID";
        public const String Campo_Descripcion = "Descripcion";
        public const String Campo_Vigencia_Desde = "Vigencia_Desde";
        public const String Campo_Vigencia_Hasta = "Vigencia_Hasta";
        public const String Campo_Porcentaje_Descuento = "Porcentaje_Descuento";
        public const String Campo_Monto_Descuento = "Monto_Descuento";
        public const String Campo_Motivo = "Motivo";
        public const String Campo_Leyenda = "Leyenda";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }
    ///*******************************************************************************
    /// NOMBRE DE LA CLASE : Cat_Impresoras_Cajas
    /// DESCRIPCIÓN        : Clase que contiene la información relacionada con las impresoras de las cajas
    /// PARÁMETROS         :
    /// CREO               : Luis Eugenio Razo Mendiola
    /// FECHA_CREO         : 25 Octubre 2013
    /// MODIFICO           :
    /// FECHA_MODIFICO     :
    /// CAUSA_MODIFICACIÓN :
    ///*******************************************************************************
    public class Cat_Impresoras_Cajas
    {
        public const String Tabla_Cat_Impresoras_Cajas = "Cat_Impresoras_Cajas";
        public const String Campo_Caja_ID = "Caja_ID";
        public const String Campo_Impresora_Pago = "Impresora_Pago";
        public const String Campo_Impresora_Accesos = "Impresora_Accesos";
        public const String Campo_Impresora_Servicios = "Impresora_Servicios";
        public const String Campo_Usuario_Creo = "Usuario_Creo";
        public const String Campo_Fecha_Creo = "Fecha_Creo";
        public const String Campo_Usuario_Modifico = "Usuario_Modifico";
        public const String Campo_Fecha_Modifico = "Fecha_Modifico";
    }
    #endregion Catálogos

}