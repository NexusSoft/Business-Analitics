using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Choferes : ConexionBase
    {

        public string Id_Chofer { get; set; }
        public string Nombre_Chofer { get; set; }
        public string Id_EmpresaAcarreo { get; set; }
        public string Usuario { get; set; }

        public void MtdSeleccionarChoferes()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Chofer_Select";
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
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

        public void MtdInsertarChoferes()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Chofer_Insert";
                _dato.Texto = Id_Chofer;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Chofer");
                _dato.Texto = Nombre_Chofer;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Chofer");
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
                _dato.Texto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
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

        public void MtdEliminarChoferes()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Chofer_Delete";
                _dato.Texto = Id_Chofer;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Chofer");
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
