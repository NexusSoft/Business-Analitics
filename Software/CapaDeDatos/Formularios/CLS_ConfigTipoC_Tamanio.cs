using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_ConfigTipoC_Tamanio : ConexionBase
    {
        public string Id_Usuario { get; set; }
        public string c_codigo_tipocorte { get; set; }
        public string c_codigo_tam { get; set; }
        public string v_nombre_tipocorte { get; set; }
        public string v_nombre_tam { get; set; }

        public void MtdSeleccionarTipoCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_TiposCorte_Select";

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

        public void MtdSeleccionarTamanios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Calibres_Select";
                _dato.CadenaTexto = c_codigo_tipocorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tipocorte");
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

        public void MtdSeleccionarTipoCorte_Tamanio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_TipoCorte_Tamaño_Select";
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
        public void MtdEliminarTipoCorte_Tamanio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_TipoCorte_Tamaño_Delete";
                _dato.CadenaTexto = c_codigo_tipocorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tipocorte");
                _dato.CadenaTexto = c_codigo_tam;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tam");
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
        public void MtdInsertarTipoCorte_Tamanio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_TipoCorte_Tamaño_Insert";
                _dato.CadenaTexto = c_codigo_tipocorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tipocorte");
                _dato.CadenaTexto = v_nombre_tipocorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_tipocorte");
                _dato.CadenaTexto = c_codigo_tam;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tam");
                _dato.CadenaTexto = v_nombre_tam;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_tam");
                _dato.CadenaTexto = Id_Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Usuario");
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
