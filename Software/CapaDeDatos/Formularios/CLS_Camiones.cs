using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Camiones : ConexionBase
    {

        public string Id_Camion { get; set; }
        public string Nombre_Camion { get; set; }
        public string Placas { get; set; }
        public string Id_EmpresaAcarreo { get; set; }
        public string Usuario { get; set; }

        public void MtdSeleccionarCamion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Camion_Select";
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }
        public void MtdSeleccionarCamionPlaca()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Camion_Placas_Select";
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
                _dato.CadenaTexto = Id_Camion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Camion");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }

        public void MtdInsertarCamion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Camion_Insert";
                _dato.CadenaTexto = Id_Camion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Camion");
                _dato.CadenaTexto = Nombre_Camion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Camion");
                _dato.CadenaTexto = Placas;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Placas");
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
                _dato.CadenaTexto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Usuario");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

        public void MtdEliminarCamion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Camion_Delete";
                _dato.CadenaTexto = Id_Camion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Camion");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

    }
}
