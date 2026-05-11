using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.ConexionBDD
{
    public class ConectarBDD
    {
        #region declarar
        public List<SqlParameter> Parametros;
        #endregion
        public string Enlace = "Poas";

        /*Objetos ASP*/
        public DataSet ExecuteMenu(string pSql, string pNombre = "tabla")
        {
            DataSet iResultado;
            SqlDataAdapter iAdaptador;
            SqlConnection Connection;
            SqlCommand iComando;

            try
            {
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Enlace].ConnectionString);
                Connection.Open();

                iComando = new SqlCommand(pSql, Connection);
                iComando.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter iParametro in Parametros)
                {
                    iComando.Parameters.Add(iParametro);
                }
                iAdaptador = new SqlDataAdapter(iComando);
                iResultado = new DataSet();
                iAdaptador.Fill(iResultado, pNombre);

                Connection.Close();
                return iResultado;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool LLenarComboList(ListBox pcombo, string pquery, string pcampo, string pllave, bool pItemSeleccione = false, bool pItemAgregar = false, String pSelectedValue = "")
        {
            DataSet iDtDatos = obtenerDataSetCodigo(pquery, "Tabla");
            if (iDtDatos != null && iDtDatos.Tables.Count > 0 && iDtDatos.Tables[0].Rows.Count > 0)
            {
                pcombo.DataTextField = pcampo;
                pcombo.DataValueField = pllave;
                pcombo.DataSource = iDtDatos.Tables[0];
                pcombo.DataBind();
            }
            if (pItemAgregar)
            {
                pcombo.Items.Add(new ListItem("<Agregar>", "-1"));
            }
            return false;
        }
        public bool LLenarBusquedaT(Telerik.Web.UI.RadSearchBox pcombo, string pquery, string pcampo, string pllave, bool pItemSeleccione = false, bool pItemAgregar = false, String pSelectedValue = "")
        {
            DataSet iDtDatos = obtenerDataSetCodigo(pquery, "Tabla");
            if (iDtDatos != null && iDtDatos.Tables.Count > 0 && iDtDatos.Tables[0].Rows.Count > 0)
            {
                pcombo.DataTextField = pcampo;
                pcombo.DataValueField = pllave;
                pcombo.DataSource = iDtDatos.Tables[0];
                pcombo.DataBind();
            }
            return false;
        }
        public bool LLenarComboASP(DropDownList pcombo, string pquery, string pcampo, string pllave, bool pItemSeleccione = false, bool pItemAgregar = false, String pSelectedValue = "")
        {
            DataSet iDtDatos = obtenerDataSetCodigo(pquery, "Tabla");
            if (iDtDatos != null && iDtDatos.Tables.Count > 0 && iDtDatos.Tables[0].Rows.Count > 0)
            {
                pcombo.DataTextField = pcampo;
                pcombo.DataValueField = pllave;
                pcombo.DataSource = iDtDatos.Tables[0];
                pcombo.DataBind();
            }
            if (pItemSeleccione)
            {
                pcombo.Items.Insert(0, new ListItem("<Seleccione>", "0"));
            }
            if (pItemAgregar)
            {
                pcombo.Items.Add(new ListItem("<Agregar>", "-1"));
            }
            return false;
        }
        public bool LLenarComboT(RadComboBox pcombo, string pquery, string pcampo, string pllave, bool pItemSeleccione = false, bool pItemAgregar = false, String pSelectedValue = "")
        {
            DataSet iDtDatos = obtenerDataSetCodigo(pquery, "Tabla");

            if (iDtDatos != null && iDtDatos.Tables.Count > 0 && iDtDatos.Tables[0].Rows.Count > 0)
            {
                pcombo.DataTextField = pcampo;
                pcombo.DataValueField = pllave;
                pcombo.DataSource = iDtDatos.Tables[0];
                pcombo.DataBind();
            }
            return false;
        }
        /*objetos Telerik*/
        public bool LlenarTreeGrid(RadTreeList pCombo, string pquery)
        {
            DataSet iDtDatos = obtenerDataSetCodigo(pquery, "Tabla");
            if (iDtDatos != null && iDtDatos.Tables.Count > 0 && iDtDatos.Tables[0].Rows.Count > 0)
            {
                pCombo.DataSource = iDtDatos.Tables[0];
            }
            return false;
        }
        public bool LLenarComboTelerik(RadComboBox pcombo, string pquery, string pcampo, string pllave, bool pItemSeleccione = false, bool pItemAgregar = false, String pSelectedValue = "")
        {
            DataSet iDtDatos = obtenerDataSetCodigo(pquery, "Tabla");

            if (iDtDatos != null && iDtDatos.Tables.Count > 0 && iDtDatos.Tables[0].Rows.Count > 0)
            {
                pcombo.DataTextField = pcampo;
                pcombo.DataValueField = pllave;
                pcombo.DataSource = iDtDatos.Tables[0];
                pcombo.DataBind();
            }
            return false;
        }
        public bool LlenarRadGrid(RadGrid pCombo, string pquery)
         {
            

            DataSet iDtDatos = obtenerDataSetCodigo(pquery, "Tabla");
            if (iDtDatos != null && iDtDatos.Tables.Count > 0 && iDtDatos.Tables[0].Rows.Count > 0)
             {
                 pCombo.DataSource = iDtDatos.Tables[0];
             }

          
            return false;
        }

        /*ejecutar comandos SQL desde codigo*/
        public void EjecutarCodigo(string pSql)
        {
            SqlCommand iComando;
            SqlConnection Connection;
           
            try
            {
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Enlace].ConnectionString);
                Connection.Open();
                iComando = new SqlCommand(pSql, Connection);
                iComando.CommandType = CommandType.Text;
                iComando.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception) { }
        }
        public DataSet obtenerDataSetCodigo(string pSql, string pNombre)
        {
            DataSet iResultado;
            SqlCommand iComando;
            SqlConnection Connection;
            SqlDataAdapter iAdaptador = new SqlDataAdapter();

            try
            {
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Enlace].ConnectionString);
                Connection.Open();
                iComando = new SqlCommand(pSql, Connection);
                iComando.CommandType = CommandType.Text;
                iAdaptador.SelectCommand = iComando;
                iResultado = new DataSet();

                if (pNombre != string.Empty)
                {
                    iAdaptador.Fill(iResultado, pNombre);
                }
                else
                {
                    iAdaptador.Fill(iResultado);
                    Connection.Close();
                    return iResultado;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return null;
            }
            Connection.Close();
            return iResultado;
        }
        public DataSet Execute(string pSql, string pNombre = "tabla")
        {
            DataSet iResultado;
            SqlDataAdapter iAdaptador;
            SqlConnection Connection;
            SqlCommand iComando;
            try
            {
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Enlace].ConnectionString);
                Connection.Open();

                iComando = new SqlCommand(pSql, Connection);
                iComando.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter iParametro in Parametros)
                {
                    iComando.Parameters.Add(iParametro);
                }
                iAdaptador = new SqlDataAdapter(iComando);
                iResultado = new DataSet();
                iAdaptador.Fill(iResultado);//, pNombre);

                Connection.Close();
                return iResultado;
            }
            catch (Exception ex)
            {
                return null;
                
            }
        }

        #region Constructor y/o destructor
        public ConectarBDD()
        {
            Parametros = new List<SqlParameter> { };
        }
        #endregion
        /*genericos guardar data en procesos almacenados*/
        public SqlParameter AgregarParametro(string pNombre, SqlDbType pTipo, Object pValor, ParameterDirection pDireccion = ParameterDirection.Input, int pTamanio = 0)
        {
            SqlParameter iParametro = new SqlParameter(pNombre, pValor);
            iParametro.SqlDbType = pTipo;
            iParametro.Direction = pDireccion;
            iParametro.Size = pTamanio;
            Parametros.Add(iParametro);
            return null;
        }
        public SqlCommand ExecuteNonQuery(string pSp, bool pAgregaManejoError = false)
        {
            SqlConnection Connection;
            SqlCommand iComando;
            
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Enlace].ConnectionString);
            Connection.Open();
            try
            {
                using (iComando = new SqlCommand())
                {
                    iComando.Connection = Connection;
                    iComando.CommandType = CommandType.StoredProcedure;
                    iComando.CommandText = pSp;

                    foreach (SqlParameter iParametro in Parametros)
                    {
                        iComando.Parameters.Add(iParametro);
                    }

                    if (pAgregaManejoError && iComando != null)
                    {
                        //Para el mensaje de error
                        SqlParameter iParametroMsg = new SqlParameter("@MensajeError", "");
                        iParametroMsg.Direction = ParameterDirection.Output;
                        iParametroMsg.Size = 250;
                        iComando.Parameters.Add(iParametroMsg);

                        // Para el numero de error
                        SqlParameter iParametroError = new SqlParameter("@Error", 0);
                        iParametroError.Value = 0;
                        iParametroError.Direction = ParameterDirection.Output;
                        iComando.Parameters.Add(iParametroError);
                    }
                    iComando.ExecuteNonQuery();
                    Connection.Close();
                    return iComando;
                }
            }
            //catch (Exception)
            //{
            //    return null;
            //}

            catch (Exception ex)
            {
                var mensaje = ex.Message;
                var stack = ex.StackTrace;

                return null;
            }
        }
        public int IntNULLCombo(RadComboBox obj)
        {
            int valor;
            if (obj.SelectedIndex == -1)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToInt32(obj.SelectedItem.Value);
            }
            return valor;
        }
        public int IntNULLComboUNO(RadComboBox obj)
        {
            int valor;
            if (obj.SelectedIndex == -1)
            {
                valor = 1;
            }
            else
            {
                valor = Convert.ToInt32(obj.SelectedItem.Value);
            }
            return valor;
        }
        public string StrNULLCombo(RadComboBox obj)
        {
            string valor;
            if (obj.SelectedIndex == -1)
            {
                valor = string.Empty;
            }
            else
            {
                valor = obj.SelectedItem.Text;
            }
            return valor;
        }
        public string StrNULLComboNacional(RadComboBox obj)
        {
            string valor;
            if ((obj.SelectedIndex == -1)||(obj.SelectedIndex == 0))
            {
                valor = string.Empty;
            }
            else
            {
                valor = obj.SelectedItem.Text;
            }
            return valor;
        }
        public int STRRadNumericTextBox(RadNumericTextBox obj)
        {
            int valor;
            if (obj.Text == string.Empty)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToInt32(obj.Text);
            }
            return valor;
        }
        public decimal CapoStringADecimal(string obj)
        {
            decimal valor;
            if (obj == string.Empty)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToDecimal(obj);
            }
            return valor;
        }
        public string Fechas(RadDatePicker obj)
        {
            string valor;
            if (obj.SelectedDate == null)
            {
                valor = string.Empty;
            }
            else
            {
                valor = String.Format("{0:dd/MM/yyyy}", obj.DateInput.SelectedDate);
            }
            return valor;
        }
        public decimal DecimalRadNumericTextBox(RadNumericTextBox obj)
        {
            decimal valor;
            if (obj.Text == string.Empty)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToDecimal(obj.Text);
            }
            return valor;
        }
    }
}