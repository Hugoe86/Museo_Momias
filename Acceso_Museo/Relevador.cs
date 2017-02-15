using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acceso_Museo
{
    public class Relevador
    {
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Entrar_Click
        ///DESCRIPCIÓN: Manejador del evento click sobre el botón Entrar: se valida que el texto en txt_acceso
        ///             esté registrado en Ope_Accesos
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 14-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Activar_Relevador(MccDaq.DigitalLogicState Estado, Int32 Puerto)
        {
            int FirstBit;
            int PortType;
            int NumPorts;
            int ProgAbility;
            int NumBits;

            MccDaq.DigitalPortType PortNum;
            MccDaq.DigitalPortType BitPort;
            MccDaq.DigitalLogicState BitValue;
            MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);
            DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();

            try
            {
                PortType = DigitalIO.clsDigitalIO.PORTOUT;
                NumPorts = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility,
                    out PortNum, out NumBits, out FirstBit);

                BitValue = Estado;
                BitPort = MccDaq.DigitalPortType.AuxPort;

                if (PortNum > MccDaq.DigitalPortType.AuxPort)
                    BitPort = MccDaq.DigitalPortType.FirstPortA;

                MccDaq.ErrorInfo ULStat = DaqBoard.DBitOut(BitPort, FirstBit + Puerto, BitValue);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Activar_Relevador()
        {
            int FirstBit;
            int PortType;
            int NumPorts;
            int ProgAbility;
            int NumBits;

            MccDaq.DigitalPortType PortNum;
            MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);
            DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();

            try
            {
                PortType = DigitalIO.clsDigitalIO.PORTOUT;
                NumPorts = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility,
                    out PortNum, out NumBits, out FirstBit);

                string Aux = string.Empty;
            }
            catch (Exception)
            {
            }
        }
    }
}
