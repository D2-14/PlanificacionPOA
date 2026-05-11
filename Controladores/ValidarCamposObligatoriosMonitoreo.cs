using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using Telerik.Web.UI;

namespace PlanificacionPOA.Controladores
{
    public class ValidarCamposObligatoriosMonitoreo
    {
        public decimal HectariaPF(int Id,decimal H1,decimal H2)
        {
            decimal Valor = 0;
            if ((Id == 213) || (Id == 236))//txthectaria1
            {
                Valor = H1;
            }
            if ((Id == 207) || (Id == 210))//txthectaria2
            {
                Valor = H2;
            }

            return Valor;
        }
        public string Agente_Causal(int Id,string Causal1,string Causal2) 
        {
            string Valor = string.Empty;
            if((Id == 213) ||(Id == 236))//txtAgenteCausal1
            {
                Valor = Causal1;
            }
            if ((Id == 207) || (Id == 210))//txtAgenteCausal2
            {
                Valor = Causal2;
            }

            return Valor;
        }
        public CondicionalUM ValidarCamposUMNacional(int IdUM, int Op)
        {
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            CondicionalUM Retorno = new CondicionalUM();
            if (Op == 1)
            {
                if (IdUM == 0)
                {
                    Retorno.ExpresionBool = false;
                }
                else
                {
                    Retorno.ExpresionBool = true;
                }
            }
            if (Op == 2)
            {
                if (xdata.Tipo_conteoNacional(IdUM) == 1)
                {
                    Retorno.ExpresionBool = true;
                    Retorno.ExpresionNumber = "1";
                }
                else
                {
                    Retorno.ExpresionBool = false;
                    Retorno.ExpresionNumber = string.Empty;
                }
            }

            return Retorno;
        }
        public CondicionalUM ValidarCamposUM(int IdUM,int Op) 
        {
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            CondicionalUM Retorno = new CondicionalUM();
            if(Op == 1)
            {
                if(IdUM == 0) 
                {
                    Retorno.ExpresionBool = false;
                }
                else 
                {
                    Retorno.ExpresionBool = true;
                }
            }
            if(Op == 2)
            {
                if (xdata.Tipo_conteo(IdUM) == 1) 
                {
                    Retorno.ExpresionBool = true;
                    Retorno.ExpresionNumber = "1"; 
                }
                else 
                {
                    Retorno.ExpresionBool = false;
                    Retorno.ExpresionNumber = string.Empty;
                }
            }

            return Retorno; 
        }
        public CondicionalUM ValidarCamposUMValor(decimal ValorUM) 
        {
            CondicionalUM Retorno = new CondicionalUM();
            if (ValorUM == 0) 
            {
                Retorno.ExpresionBool = false;
            }
            else 
            {
                Retorno.ExpresionBool = true;
            }
            return Retorno;
        }
        /*Validar Campos*/
        public Validar_Data Campos_Obligatorio_Asuntos_Juridicos(EncabezadoMonitoreoIngreso G, RadAsyncUpload Subir, string Mantenimiento = "False") 
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;

            bool hay = Mim.VerificarPDF(Subir);
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(G.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(G.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(G.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_Capacitacion(EncabezadoMonitoreoIngreso G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();                    
            Validar_Data v = new Validar_Data();                       
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            if (G.Id_Evento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el Evento.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1;}
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if(Total == 1) 
            {
                if(umv1 > 0) 
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }          
            if ((DMI.Id_ProductoVerificable == 227) || (DMI.Id_ProductoVerificable == 21))
            {
                if(G.Observaciones == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado las Observaciones a esta actividad en especifico.<br/>"; }
            }
            if (DMI.Id_SubComponente!=2)
            {
                if(G.Survey == "-1") { v.Verificar = true; v.Mensaje += "No se ha ingresado el valor para el listado Survey.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_ProgarmaRE(EncabezadoProgramaReduccionEmision G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            if (G.NoResolucion == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de resolución.<br/>"; }
            //if (G.FechaResolucion == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha de la resolución.<br/>"; }
            if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de expediente.<br/>"; }            

            if ((DMI.Id_ProductoVerificable == 239) || (DMI.Id_ProductoVerificable == 240) || (DMI.Id_ProductoVerificable == 241) ||
                (DMI.Id_ProductoVerificable == 244) || (DMI.Id_ProductoVerificable == 245) || (DMI.Id_ProductoVerificable == 246) ||
                (DMI.Id_ProductoVerificable == 247) || (DMI.Id_ProductoVerificable == 248))
            {
                if (G.Id_TipoProyecto == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de proyecto.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_CulturaForestal(EncabezadoCulturaForestal G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            if (DMI.Id_ProductoVerificable == 45)
            {
                //if (G.Id_TipoEvento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de evento.<br/>"; }
                //if (G.NombreEvento == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del evento.<br/>"; }
                //if (G.TemaONombreEntidad == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre del tema.<br/>"; }
                //if (G.Id_Campania == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de campaña.<br/>"; }
                //if (G.MediosParticipantes == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado los medios participantes.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 35)
            {
                if (G.Id_TemaAtendido == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tema atendido.<br/>"; }
            }           
            if (DMI.Id_ProductoVerificable == 38)
            {
                if (G.NombredelMaterial == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del material.<br/>"; }
            }
            if ((DMI.Id_ProductoVerificable == 39) || (DMI.Id_ProductoVerificable == 40))
            {
                if (G.Id_TipoEvento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de evento.<br/>"; }
                if (G.NombreEvento == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del evento.<br/>"; }
                if (G.TemaONombreEntidad == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre del tema.<br/>"; }
                if (G.Id_Campania == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de campaña.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 41)
            {
                if (G.NombreMediosComunicacion == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del medio de comunicacion.<br/>"; }
                if (G.TemaAbordado == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tema abordado.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 42)
            {
                if (G.PeriodoPublicidadInicio == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el periodo inicial de la publicidad.<br/>"; }
                if (G.PeriodoPublicidadFinal == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el periodo final de la publicidad.<br/>"; }
               
                if((G.PeriodoPublicidadInicio != string.Empty) && (G.PeriodoPublicidadFinal != string.Empty)) 
                {
                    bool FechaValidas = Mim.Validad_Fechas_ValidasCF(G.PeriodoPublicidadInicio, G.PeriodoPublicidadFinal);
                    if (FechaValidas == false) { v.Verificar = true; v.Mensaje += "La fecha final de publicidad no puede ser menor a la fecha de inicio de la publicidad.<br/>"; }
                }
                if (G.Id_TipoApoyo == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de apoyo.<br/>"; }
                if (G.NombreEntidad == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre de la entidad.<br/>"; }
                if (G.TemaONombreEntidad == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre del tema.<br/>"; }
                if (G.Id_Campania == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de campaña.<br/>"; }
            }           
            if (DMI.Id_ProductoVerificable == 44)
            {
                if (G.TemaONombreEntidad  == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre de la entidad del acuerdo.<br/>"; }
                if (G.Id_Campania == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Campaña de Comunicación.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_PPMF(EncabezadoPPMF G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            if((DMI.Id_ProductoVerificable == 181) || (DMI.Id_ProductoVerificable == 182) || (DMI.Id_ProductoVerificable == 183)|| (DMI.Id_ProductoVerificable == 234))
            {
                if (G.FechaPlantacion == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha de medición.<br/>"; }
                //if (G.FechaPPM == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha de medición de PPM.<br/>"; }
                if (G.Id_TipoBosque == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de bosque.<br/>"; }
                if (G.CoordenadaX == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada en X.<br/>"; }
                if (G.CoordenadaY == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada en Y.<br/>"; }
                //if (G.NombreSitio == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del sitio.<br/>"; }
                //if (G.NoExperimento == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el número de experimento.<br/>"; }
                //if (G.NoParcela == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el número de parcela.<br/>"; }
                //if (G.NoMedicion == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Medición.<br/>"; }
                //if (G.Replanteo  == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el Replanteo.<br/>"; }
                //if(G.CodigoProyecto == string.Empty) { v.Verificar = true; v.Mensaje += " No a ingresado el código del expediente"; }
                if (G.CoordenadaX != 0)
                {
                    if (G.CoordenadaX.ToString().Length < 6) { v.Verificar = true; v.Mensaje += "el Numero tiene menos de 6 digitos.<br/>"; }
                }
                if (G.CoordenadaY != 0)
                {
                    if (G.CoordenadaY.ToString().Length < 7) { v.Verificar = true; v.Mensaje += "el Numero tiene menos de 7 digitos.<br/>"; }
                }
            }
            //if(DMI.Id_ProductoVerificable == 234)
            //{
            //    if (G.NombreSitio == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del sitio.<br/>"; }
            //    if (G.NoExperimento == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el número de experimento.<br/>"; }
            //    if (G.NoParcela == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el número de parcela.<br/>"; }
            //    if (G.NoMedicion == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Medición.<br/>"; }
            //}
            if(DMI.Id_ProductoVerificable == 235)
            {
                if (G.UnidadMuestreo == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la unidad de muestreo.<br/>"; }
                if (G.CoordenadaX == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada en X.<br/>"; }
                if (G.CoordenadaY == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada en Y.<br/>"; }

                if (G.CoordenadaX != 0)
                {
                    if (G.CoordenadaX.ToString().Length < 6) { v.Verificar = true; v.Mensaje += "el Numero tiene menos de 6 digitos.<br/>"; }
                }               
                if (G.CoordenadaY != 0)
                {
                    if (G.CoordenadaY.ToString().Length < 7) { v.Verificar = true; v.Mensaje += "el Numero tiene menos de 7 digitos.<br/>"; }
                }
            }


            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }
            return v;
        }
        public Validar_Data Campos_Obligatorio_Pinabete(EncabezadoPinabete G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI,string Mantenimiento="False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            if ((DMI.Id_ProductoVerificable == 163) || (DMI.Id_ProductoVerificable == 162)) 
            {
                if (G.Id_TipoArea == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el Tipo de Área.<br/>"; }
                //if (G.NoRegistro == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de Registro.<br/>"; }
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de Expediente.<br/>"; }
            }

            if (DMI.Id_ProductoVerificable == 160)
            {
                if (G.Survey == "-1") { v.Verificar = true; v.Mensaje += "No se ha ingresado el valor para el listado Survey.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }
            return v;
        }
        public Validar_Data Campos_Obligatorio_Mangle(EncabezadoMangle G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }           
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }


            if (DMI.Id_ProductoVerificable == 120)
            {
                if (G.Survey == "-1") { v.Verificar = true; v.Mensaje += "No se ha ingresado el valor para el listado Survey.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_IncentivosF(EncabezadoIncentivosForestales G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            if ((DMI.Id_ProductoVerificable == 85) || (DMI.Id_ProductoVerificable == 86)) 
            {
                if (G.NumeroExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de Expediente.<br/>"; }
                //if (G.Area == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el Área.<br/>"; }
                if (G.Id_TipoIncentivo == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Incentivo.<br/>"; }
                if (G.Id_Incentivo == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la modalidad.<br/>"; }
                if (G.Id_fase == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la fase de proyecto.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }
            return v;
        }
        public Validar_Data Campos_Obligatorio_IndustriaComercio(EncabezadoIndustriaComercio G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            //if ((DMI.Id_ProductoVerificable == 95)
            //     )
            //{               
            //    if (G.Id_Tema == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tema.<br/>"; }
            //    if(G.Id_Tema != 0) 
            //    {
            //        if (G.Id_Tema == 7)
            //        {
            //            if (G.Tema_Especifico == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tema.<br/>"; }
            //        }
            //    }               
            //}
            //if ((DMI.Id_ProductoVerificable == 91) || (DMI.Id_ProductoVerificable == 94) ) 
            //{
            //    if (G.Id_TipoRegistro == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Registro.<br/>"; }
            //    if (G.NumeroRegistro == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Registro.<br/>"; }

            //    if (G.Id_TipoOrganizacion == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Registro.<br/>"; }
            //    if (G.Id_TipoOrganizacion != 0)
            //    {
            //        if (G.Id_TipoOrganizacion == 4)
            //        {
            //            if (G.Tema_Organizacion  == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tema de organizacion.<br/>"; }
            //        }
            //    }
            //    if (G.Id_TipoEmpresa == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Registro.<br/>"; }
            //    if (G.Id_TipoEmpresa != 0)
            //    {
            //        if (G.Id_TipoEmpresa == 4)
            //        {
            //            if (G.Tema_Empresa  == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tema de empresa.<br/>"; }
            //        }
            //    }

            //    if (G.Producto_Recomendado == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el producto recomendado.<br/>"; }
            //}

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_ProteccionForestal(EncabezadoProteccionForestal G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }                          
            if (DMI.Id_ProductoVerificable == 210) 
            {
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Número de Expediente.<br/>"; }
                if (G.AgenteCausal == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Agente Causal.<br/>"; }
                if (G.NombreTitular == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Nombre del titular.<br/>"; }
                if (G.Hectarias == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado las Héctarias.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 207) 
            {
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Número de Expediente.<br/>"; }
                if (G.AgenteCausal == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Agente Causal.<br/>"; }
                if (G.NombreTitular == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Nombre del titular.<br/>"; }
                if (G.Hectarias == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado las Héctarias.<br/>"; }

            }
            if ((DMI.Id_ProductoVerificable == 215)) 
            {
                //if (G.CoordenadaX  == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado el Número de Coordena en X.<br/>"; }
                //if(G.CoordenadaX != 0) 
                //{
                //    if (G.CoordenadaX.ToString().Length < 6) { v.Verificar = true; v.Mensaje += "el Numero tiene menos de 6 digitos.<br/>"; }
                //}
                //if (G.CoordenadaY  == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado el Número de Coordena en Y.<br/>"; }
                //if (G.CoordenadaY != 0)
                //{
                //    if (G.CoordenadaY.ToString().Length < 7) { v.Verificar = true; v.Mensaje += "el Numero tiene menos de 7 digitos.<br/>"; }
                //}
                if (G.NombreContacto == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Nombre de Contacto.<br/>"; }
                if (G.NumeroTelefono == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado el Numero de Teléfono.<br/>"; }
                if(G.NumeroTelefono != 0) 
                {
                    if(G.NumeroTelefono.ToString().Length < 8) { v.Verificar = true; v.Mensaje += "el Numero tiene menos de 8 digitos.<br/>"; }
                }                
                if (G.Id_EquipoProteccion == 0) { v.Verificar = true; v.Mensaje += "No a Seleccionado el equipo de Protección.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 209) 
            {
                if (G.Id_tipoAreaBM == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado tipo de Área de Manejo.<br/>"; }
                if (G.Id_AreaBM == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el Área de Manejo.<br/>"; }
                if (G.Id_fase == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Fase del Proyecto.<br/>"; }
            }
            if ((DMI.Id_ProductoVerificable == 236))
            {
                if (G.AgenteCausal == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Agente Causal.<br/>"; }
                if (G.NumeroMuestra == string.Empty) { v.Verificar = true; v.Mensaje += "No a Ingresado el Número de Muestra.<br/>"; }
                if (G.Id_TipoEscenario == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado tipo de Escenario.<br/>"; }
                if(G.Id_TipoEscenario != 0) 
                {
                    if ((G.Id_TipoEscenario == 1) || (G.Id_TipoEscenario == 2) || (G.Id_TipoEscenario == 3)) 
                    {
                        if (G.Hectarias == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado las Héctarias.<br/>"; }
                    }
                }
                
            }
            if (DMI.Id_ProductoVerificable == 216)
            {
                if (G.Id_Tipo_Bosque == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado tipo de Bosque.<br/>"; }
                if (G.Id_Tipo_Incendio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado tipo de Incendio.<br/>"; }
                if (G.Id_Tipo_Administracion == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado tipo de Adeministración.<br/>"; }               
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_FiscalizacionyControl(EncabezadoFiscalizacionIngreso G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento = "False")
        {            
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();          
            Validar_Data v = new Validar_Data();
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;

            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            if ((DMI.Id_ProductoVerificable == 51) || (DMI.Id_ProductoVerificable == 53) || (DMI.Id_ProductoVerificable == 60) || (DMI.Id_ProductoVerificable == 52))
            {
                //if (G.Id_TipoDeRegistro == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Registro.<br/>"; }
                //if (G.NumeroDeRegistro == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Registro.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 54)
            {
                if (G.Id_TipoDeRegistro == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Resgistro.<br/>"; }
                if (G.NumeroDeRegistro == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Registro.<br/>"; }
                if (G.Id_TipoDeActa == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Acta.<br/>"; }
                if (G.Id_TipoDeActa == 1)
                {
                    if (G.ErroresAnomalias == string.Empty) { v.Verificar = true; v.Mensaje += "No a descrito la anomalia que se encontro.<br/>"; }
                }
            }
            if (DMI.Id_ProductoVerificable == 55)
            {
                if (G.Id_Especie == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Especie.<br/>"; }
                if (G.Tipo_Producto == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tipo de Producto.<br/>"; }
                if (G.NombreEmpresa  == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre de la empresa exportadora.<br/>"; }
                if (G.RegistroExim  == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de registro exim.<br/>"; }
                if (G.Id_Pais == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el pais de destino.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 56)
            {
                if (G.Id_TipoDeRegistro == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Resgistro.<br/>"; }
                if (G.NumeroDeRegistro == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Registro.<br/>"; }
               // if (G.ErroresAnomalias == string.Empty) { v.Verificar = true; v.Mensaje += "No a descrito la anomalia que se encontro.<br/>"; }
            }
            //if (DMI.Id_ProductoVerificable == 57)
            //{
            //    if (G.Id_Estado == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el estado.<br/>"; }
            //}
            if (DMI.Id_ProductoVerificable == 58)
            {
                if (G.Id_TipoDeRegistro == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Resgistro.<br/>"; }
                if (G.NumeroDeRegistro == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Registro.<br/>"; }
                if (G.Id_ReactivaSeinef == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado si fue reactivada.<br/>"; }
            }
            //if (DMI.Id_ProductoVerificable == 59)
            //{
            //    if (G.Id_TipoAccion == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de acción.<br/>"; }
            //    if (G.Id_TipoIncumplimiento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de incumplimiento.<br/>"; }
            //}
            if (DMI.Id_ProductoVerificable == 61)
            {
                if (G.NombreEmpresa == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre de la empresa exportadora.<br/>"; }
                if (G.RegistroExim == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de registro exim.<br/>"; }
                if (G.Id_Especie == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Especie.<br/>"; }
                if (G.Tipo_Producto == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tipo de Producto.<br/>"; }
            }          
            if (DMI.Id_ProductoVerificable == 64)
            {
                if (G.Id_ExistenciaCobertura == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la existencia de cobertura.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 65)
            {
                if (G.Id_TipoCobertura == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado  el tipo de cobertura.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 66)
            {
                if (G.Id_Especie == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Especie.<br/>"; }
                if (G.Tipo_Producto == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tipo de Producto.<br/>"; }
            }
            if (DMI.Id_ProductoVerificable == 67)
            {
                if (G.Id_Especie == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Especie.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }


            return v;
        }
        public Validar_Data Campos_Obligatorio_Fortalecimiento(EncabezadoFortalecimiento G, RadAsyncUpload Subir, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;
            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;

            if (Producto == 0)
            {
                v.Verificar = true; v.Mensaje += "Este producto ha sido desactivado por el administrador del sistema.";

            }
            else
            {

            
                

            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteo(G.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteo(G.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteo(G.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }

            if ((G.ValorUM1==0) && (G.ValorUM2==0)&& (G.ValorUM3==0))
                { v.Verificar = true; v.Mensaje += "Debe ingresar almenos un valor para continuar.<br/>"; }

                if (G.Id_Puesto_Actvidad == 0 & G.Id_ProductoVerificable!=70 & G.Id_ProductoVerificable!=279 
                & G.Id_ProductoVerificable !=80 & G.Id_ProductoVerificable !=73 & G.Id_ProductoVerificable !=77& G.Id_ProductoVerificable !=69)
            { v.Verificar = true; v.Mensaje += "No a seleccionado el puesto quien ejecuta la actividad.<br/>"; }


            if ((Producto == 74) || (Producto == 75) || (Producto == 81)|| (Producto == 82))

            {
                if (G.Id_Puesto_Actvidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el puesto que ejecuta.<br/>"; }               
            }
            if ((Producto == 71) || (Producto == 76) || (Producto == 230))
            {
                if (G.Id_Puesto_Actvidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el puesto que ejecuta.<br/>"; }
                if (G.ComunidadOrganizacion == string.Empty ) { v.Verificar = true; v.Mensaje += "No a ingresado la Ubicación.<br/>"; }
                if (G.UbicacionOrganizacion == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado comunidad u organización.<br/>"; }                                              
            }
            if (Producto == 72)
            {
                if (G.Id_Puesto_Actvidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el puesto que ejecuta.<br/>"; }
                if (G.NombreDocumento == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del documento.<br/>"; }
                if (G.AnioVigenciaPolitica == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el año de vigencia de la politica.<br/>"; }                              
            }
            if (Producto == 79)
            {
                if (G.Id_Puesto_Actvidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el puesto que ejecuta.<br/>"; }               
            }
            if ((Producto == 78))
            {
                if (G.Id_Puesto_Actvidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el puesto que ejecuta.<br/>"; }
                if (G.TipoActor == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado  el Actor.<br/>"; }
                if (G.Actores == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Actor.<br/>"; }
                if (G.NombreActor == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre del actor.<br/>"; }
                if (G.TemaAtendido == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el tema atendido.<br/>"; }
            }

            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_MonitoreoForestal(EncabezadoMonitoreoIngreso G, RadAsyncUpload Subir, string Mantenimiento = "False") 
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;
            bool hay = Mim.VerificarPDF(Subir);

            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }           
            if ((Producto == 136) || (Producto == 137) || (Producto == 138) || (Producto == 141) || (Producto == 142) || (Producto == 143) ||
                        (Producto == 144) || (Producto == 145) || (Producto == 146) || (Producto == 123) || (Producto == 134) || (Producto == 139) ||
                        (Producto == 140) || (Producto == 154) || (Producto == 155) || (Producto == 156) || (Producto == 157) || (Producto == 158) ||
                        (Producto == 159) || (Producto == 147) || (Producto == 148) || (Producto == 149) || (Producto == 150) || (Producto == 151) ||
                        (Producto == 152) || (Producto == 153))
            {
                if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            }
            if (G.Id_UM1 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM1) != 1)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
            }
            if (G.Id_UM2 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM2) != 1)
                {
                    if ((Producto == 136) || (Producto == 137) || (Producto == 138) || (Producto == 141) || (Producto == 142) || (Producto == 143) ||
                        (Producto == 144) || (Producto == 145) || (Producto == 146) || (Producto == 123) || (Producto == 134) || (Producto == 139) || 
                        (Producto == 140) || (Producto == 154) || (Producto == 155) || (Producto == 156) || (Producto == 157) || (Producto == 158) || 
                        (Producto == 159) || (Producto == 147) || (Producto == 148) || (Producto == 149) || (Producto == 150) || (Producto == 151) || 
                        (Producto == 152) || (Producto == 153))
                    {
                        if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                    }
                }
            }
            if (G.Id_UM3 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM3) != 1)
                {
                    if ((Producto == 136) || (Producto == 137) || (Producto == 138) || (Producto == 141) || (Producto == 142) || (Producto == 143) ||
                        (Producto == 144) || (Producto == 145) || (Producto == 146) || (Producto == 123) || (Producto == 134) || (Producto == 139) || 
                        (Producto == 140) || (Producto == 154) || (Producto == 155) || (Producto == 156) || (Producto == 157) || (Producto == 158) || 
                        (Producto == 159) || (Producto == 147) || (Producto == 148) || (Producto == 149) || (Producto == 150) || (Producto == 151) || 
                        (Producto == 152) || (Producto == 153))
                    {
                        if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                    }
                }
            }
           
            //if (G.Fecha != string.Empty)
            //{
            //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
            //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
            //}

            if ((Producto == 126) || (Producto == 127) || (Producto == 128) || (Producto == 129) || (Producto == 130) || (Producto == 131) ||
                     (Producto == 132) || (Producto == 133) || (Producto == 124))
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }
            if ((Producto == 123) || (Producto == 134))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
                if (G.Noexpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                if (G.Estado == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el estado.<br/>"; }
                if (G.Fase == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fase.<br/>"; }
                if (G.Estatus == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el estatus.<br/>"; }
                if (G.Edad == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la edad.<br/>"; }
                if (G.Id_Garantia == 0) { v.Verificar = true; v.Mensaje += "No seleccionado la garantia.<br/>"; }
                if (G.NoInforme == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número del informe.<br/>"; }
            }
            if ( (Producto == 142) || 
                (Producto == 144) || (Producto == 145) || (Producto == 146))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Noexpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                if (G.Edad == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la edad.<br/>"; }
                if (G.NoInforme == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número del informe.<br/>"; }
                if (G.Volumen == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el volumen.<br/>"; }
            }

            if ((Producto == 136) || (Producto == 137) || (Producto == 138) || (Producto == 141) || (Producto == 139) || (Producto == 143) || (Producto == 140) || (Producto == 272))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Noexpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }

            }
            //    if ((Producto == 140))
            //{
            //    if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            //    if (G.Id_Especie == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la especie.<br/>"; }
            //    if (G.Volumen == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el volumen.<br/>"; }
            //    if (G.Noexpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número del Expediente.<br/>"; }
            //    if (G.NoInforme == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número del informe.<br/>"; }
            //    if (G.CoordenadaX == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada X.<br/>"; }
            //    if (G.CoordenadaY == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada Y.<br/>"; }
                
            //    if(G.CoordenadaX != 0) 
            //    {
            //        if (G.CoordenadaX.ToString().Length < 6) { v.Verificar = true; v.Mensaje += "la Coordenada x debe de ser de 6 digitos.<br/>"; }
            //    }
            //    if (G.CoordenadaY != 0)
            //    {
            //        if (G.CoordenadaY.ToString().Length < 7) { v.Verificar = true; v.Mensaje += "la Coordenada Y debe de ser de 7 digitos.<br/>"; }
            //    }
            //    if (G.Volumen > 15) { v.Verificar = true; v.Mensaje += "No se puede ingresar mas de 15 metros Cubicos en el volumen.<br/>"; }

            //}
            if ((Producto == 154) || (Producto == 155) || (Producto == 156) || (Producto == 157) || (Producto == 158) || (Producto == 159) ||
               (Producto == 147) || (Producto == 148) || (Producto == 149) || (Producto == 150) || (Producto == 151) || (Producto == 152) ||
               (Producto == 153))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
                //if (G.Noexpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                //if (G.Fase == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fase.<br/>"; }
                if (G.NoInforme == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de boleta.<br/>"; }
            }



            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_ConsumoFamiliar(EncabezadoConsumoFamiliarIngreso G, string Mantenimiento = "False")
        {           
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;          

            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            
            if (G.Id_UM1 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM1) != 1)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
            }
           /* if (G.Id_UM2 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM2) != 1)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
            }*/
            if (G.Id_UM3 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM3) != 1)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
            if ((Producto == 49) || (Producto == 50) || (Producto == 250) || (Producto == 251))
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }


            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_RNF(EncabezadoRNF G, RadAsyncUpload Subir, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;
            bool hay = Mim.VerificarPDF(Subir);

            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }

            if(Producto == 255)
            {
                if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            }
            if (G.Id_UM1 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM1) != 1)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
            }
            if (G.Id_UM2 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM2) != 1)
                {
                    if(Producto == 255)
                    {
                        if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                    }
                }
            }
            if (G.Id_UM3 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM3) != 1)
                {
                    if(Producto == 255)
                    {
                        if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                    }
                }
            }
            if(Producto == 255)
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de expediente.<br/>"; }
                if (G.CategoriaRNF == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la categoria.<br/>"; }
                if (G.SubcategoriaRNF == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la subcatgegoria.<br/>"; }
                if (G.Especificaciones == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado las especificaciones.<br/>"; }
                if (G.IdTipoDenegacion == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de denegación.<br/>"; }
            }

            if ((Producto == 218) || (Producto == 219))
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_PINPEP(EncabezadoPINPEPIngreso G, RadAsyncUpload Subir, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;
            bool hay = Mim.VerificarPDF(Subir);

            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }

            if ((Producto == 164) || (Producto == 165) || (Producto == 169) || (Producto == 171) ||
                (Producto == 172) || (Producto == 175) || (Producto == 178) || (Producto == 180) ||
                    (Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
            {
                if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            }
            if (G.Id_UM1 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM1) != 1)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
            }
            if (G.Id_UM2 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM2) != 1)
                {
                    if ((Producto == 164) || (Producto == 165) || (Producto == 169) || (Producto == 171) ||
                        (Producto == 172) || (Producto == 175) || (Producto == 178) || (Producto == 180))
                    {
                        if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                    }
                }
            }
            if (G.Id_UM3 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM3) != 1)
                {
                    if ((Producto == 164) || (Producto == 165) || (Producto == 169) || (Producto == 171) ||
                        (Producto == 172) || (Producto == 175) || (Producto == 178) || (Producto == 180))
                    {
                        if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                    }
                }
            }
            if ((Producto == 169) ||  (Producto == 178))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}
                if (G.Id_Modalidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la modalidad.<br/>"; }
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Expediente.<br/>"; }
                if (G.ResolucionInforme == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Resolucion/informe.<br/>"; }
            }if ((Producto == 169) || (Producto == 178))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}
                if (G.Id_Modalidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la modalidad.<br/>"; }
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Expediente.<br/>"; }
                if (G.ResolucionInforme == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Resolucion/informe.<br/>"; }
            }

            if ((Producto == 171) || (Producto == 172) || (Producto == 175) || (Producto == 180))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}
           
            }
            if ((Producto == 164) || (Producto == 165))
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}
               

            }

                if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170) 
               //||  (Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
              )
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }


            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
        public Validar_Data Campos_Obligatorio_ExentosForestales(EncabezadoExentosIngreso G, RadAsyncUpload Subir, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;
            bool hay = Mim.VerificarPDF(Subir);

            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if (Producto == 256)
            {
                if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            }
            if (G.Id_UM1 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM1) != 1)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
            }
            if (G.Id_UM2 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM2) != 1)
                {
                    if (Producto == 256)
                    {
                        if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                    }
                }
            }
            if (G.Id_UM3 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM3) != 1)
                {
                    if(Producto == 256)
                    {
                        if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                    }
                }
            }
            if (Producto == 256)
            {
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha,G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}

                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Expediente.<br/>"; }
                if (G.NoResolucion == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Resolucion.<br/>"; }
            }
            if ((Producto == 46) || (Producto == 47) || (Producto == 48) || (Producto == 256))
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }
            return v;
        }
        public Validar_Data Campos_Obligatorio_Probosque(EncabezadoProbosqueIngreso G,RadAsyncUpload Subir, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;
            bool hay = Mim.VerificarPDF(Subir);

            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            
            
            if ((Producto == 184) || (Producto == 185) || (Producto == 189) || (Producto == 192) || (Producto == 193) || (Producto == 194) ||
                  (Producto == 195) || (Producto == 199) || (Producto == 204) || (Producto == 198) || (Producto == 201))            
            {
                if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
            }
            if (G.Id_UM1 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM1) != 1)
                {
                    //if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
            }
            if (G.Id_UM2 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM2) != 1)
                {
                    if ((Producto == 184) || (Producto == 185) || (Producto == 189) || (Producto == 192) || (Producto == 193) || (Producto == 194) ||
                  (Producto == 195) || (Producto == 199) || (Producto == 204) || (Producto == 198) || (Producto == 201))
                    {
                        //if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                     
                    }
                }
            }
            if (G.Id_UM3 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM3) != 1)
                {
                    if ((Producto == 184) || (Producto == 185) || (Producto == 189) || (Producto == 192) || (Producto == 193) || (Producto == 194) ||
                  (Producto == 195) || (Producto == 199) || (Producto == 204) || (Producto == 198) || (Producto == 201))
                    {
                        //if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                        //if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                    }
                }
            }
            if ((Producto == 185) || (Producto == 189) || (Producto == 193) || (Producto == 194) ||
                  (Producto == 195) || (Producto == 199) || (Producto == 204) || (Producto == 198) || (Producto == 201))
            {
                //if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                //if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}
                ////if (G.Id_Modalidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la modalidad.<br/>"; }
                //if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Expediente.<br/>"; }
                //if (G.ResolucionInforme == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el número de Resolucion/informe.<br/>"; }
            }
            if ((Producto == 192) || (Producto == 184) || (Producto == 189) || (Producto == 201) || (Producto == 198) || (Producto == 193) || (Producto == 195) || (Producto == 204))
            {
                //if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargardo el medio de verificación.<br/>"; }
                //if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}

            }

            if ((Producto == 186) || (Producto == 187) || (Producto == 188) || (Producto == 190) || (Producto == 191) ||
                    (Producto == 196) || (Producto == 197) || (Producto == 200) || (Producto == 202) || (Producto == 203))
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }

            if ((Producto == 288) || (Producto == 187) || (Producto == 188) || (Producto == 190) || (Producto == 191) ||
                    (Producto == 196) || (Producto == 197) || (Producto == 200) || (Producto == 202) || (Producto == 203))
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }
            return v;
        }
        /*Detalle de ingresos*/
        /*participantes*/
        public Validar_Data Verificar_VaciosD1(CapacitacionDatos1 G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_Evento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el Tipo de Evento.<br/>"; }
            if (G.Id_Participante == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el Participante.<br/>"; }
            if (G.Id_Tipoparticipante == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo participantes.<br/>"; }
            if (G.Id_Comunidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Seleccione Comunidad lenguistica.<br/>"; }
            if (G.NumeroPersonaComunidad == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el numero de personas de la comunidad lenguistica.<br/>"; }
            return v;
        }
        /*grupo Etario*/
        public Validar_Data Verificar_VaciosD2(CapacitacionDatos2 G)
        {            
            Validar_Data v = new Validar_Data();

            if (G.Id_Genero == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el Genero.<br/>"; }
            if (G.Id_pertenencia == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la pertenencia.<br/>"; }
            if (G.Id_GrupoEtario == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el Grupo Etario.<br/>"; }
            if (G.NumeroPersonaEtario == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el numero de personas del grupo etario.<br/>"; }
            return v;
        }
        /*Rendimiento*/
        public Validar_Data Verificar_VaciosRendimiento(FiscalizacionDatos1 G)
        {
            Validar_Data v = new Validar_Data();
            decimal Total;
            if (G.Maquinaria == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el nombre de la maquinaria.<br/>"; }
            if (G.Id_Especie == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Especie.<br/>"; }

            Total = G.PorcentajeMaderaAserrada + G.PorcentajeLepa + G.PorcentajeAserrio + G.PorcentajeOtro;

            if (Convert.ToInt32(Total) < 100) { v.Verificar = true; v.Mensaje += "La suma de los porcentajes es Menor de 100.<br/>"; }
            if (Convert.ToInt32(Total) > 100) { v.Verificar = true; v.Mensaje += "La suma de los porcentajes es Mayor de 100.<br/>"; }
            return v;
        }
        /*Comunidad Linguistica*/
        public Validar_Data Verificar_VaciosComunidadL(FiscalizacionDatos2 G)
        {            
            Validar_Data v = new Validar_Data();

            if (G.Id_Comunidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Comunidad Lengüistica.<br/>"; }
            if (G.NumeroPersonas == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el numero de personas de la Comunidad.<br/>"; }
            return v;
        }
        /*Actores*/
        public Validar_Data Verificar_VaciosActores(Fortalecimiento1 G)
        {
            Validar_Data v = new Validar_Data();
           
            if (G.Id_Comunidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Comunidad Linguistica.<br/>"; }
            if (G.NumeroPersonas == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el numero de personas de comunidad Linguistica.<br/>"; }
            return v;
        }
        public Validar_Data Verificar_VaciosModalidadArea(DetallePRE G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_Modalidad  == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Modalidad.<br/>"; }
            if (G.Area == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el Área.<br/>"; }
            return v;
        }
        public Validar_Data Verificar_NotasCF(Detalle3CulturaForestal G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_Notas == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de nota.<br/>"; }
            if (G.NumeroNotas == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la cantidad de notas.<br/>"; }
            return v;
        }
        public Validar_Data Verificar_PublicidadCF(Detalle4CulturaForestal G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_TipoPublicidad == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de publicidad.<br/>"; }
            if (G.Cantidad  == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la cantidad.<br/>"; }
            return v;
        }
        public Validar_Data Verificar_PublicidadCF5(Detalle5CulturaForestal G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_Publico == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de publico.<br/>"; }
            if (G.Cantidad == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la cantidad.<br/>"; }
            return v;
        }
        public Validar_Data Verificar_PublicidadCF6(Detalle6CulturaForestal G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_TipoMaterial  == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de material.<br/>"; }
            if (G.Id_Material == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el material.<br/>"; }
            if (G.Cantidad == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la cantidad.<br/>"; }
            return v;
        }
        public Validar_Data Verificar_PublicidadCF7(Detalle7CulturaForestal G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_Campania == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado la Campaña de comunicación.<br/>"; }            
            if (G.Cantidad == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la cantidad.<br/>"; }
            return v;
        }
        public Validar_Data Verificar_PublicidadCF8(Detalle8CulturaForestal G)
        {
            Validar_Data v = new Validar_Data();

            if (G.Id_TipoNota == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de Nota.<br/>"; }
            if (G.Id_Nota == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de medio.<br/>"; }
            if (G.Cantidad == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la cantidad.<br/>"; }
            return v;
        }
        /*validar ingreso de informacion de nacionales*/
        public Validar_Data Campos_Obligatorio_Nacionales(EncabezadoNacionalGeneral G, RadAsyncUpload Subir, DatosMonitoreoIngresoMetas DMI, string Mantenimiento="False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();

          

            bool hay = Mim.VerificarPDF(Subir);
            int umv1 = 0;
            int umv2 = 0;
            int umv3 = 0;
            int Total = 0;
           
            if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
            if (G.Fecha == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la fecha.<br/>"; }
            if (G.Fecha != string.Empty)
            {
                bool FechaValida = Mim.Validad_Fechas_ValidasNacionales(G.Id_Mes, G.Fecha,DMI.Id_PoAnual);
                if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha menor o mayor al Mes de Ingreso.<br/>"; }
            }
            if ((G.Id_UM1 != 0) && (Mim.Tipo_conteoNacional(DMI.Id_UM1) != 1)) { Total += 1; umv1 = 1; }
            if ((G.Id_UM2 != 0) && (Mim.Tipo_conteoNacional(DMI.Id_UM2) != 1)) { Total += 1; umv2 = 1; }
            if ((G.Id_UM3 != 0) && (Mim.Tipo_conteoNacional(DMI.Id_UM3) != 1)) { Total += 1; umv3 = 1; }
            if (Total == 1)
            {
                if (umv1 > 0)
                {
                    if (G.ValorUM1 == 0 && G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                }
                if (umv2 > 0)
                {
                    if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                }
                if (umv3 > 0)
                {
                    if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                }
            }
        
           if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length<60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }
           
            return v;
        }
        public Validar_Data Campos_Obligatorio_Licencia(EncabezadoLicenciaForestal G, RadAsyncUpload Subir, string Mantenimiento = "False")
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            Validar_Data v = new Validar_Data();
            int Producto = G.Id_ProductoVerificable;
            bool hay = Mim.VerificarPDF(Subir);

            if (G.Id_Departamento == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el departamento.<br/>"; }
            if ((Producto == 113) || (Producto == 253) || (Producto == 254) || (Producto == 259) || (Producto == 106) || (Producto == 114) ||
                (Producto == 115) || (Producto == 116) || (Producto == 117) || (Producto == 118) || (Producto == 119) || (Producto == 249))
            {
                if (G.Id_Municipio == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el municipio.<br/>"; }
                if (hay == false) { v.Verificar = true; v.Mensaje += "No a Cargado el medio de verificación.<br/>"; }
                //if (G.Fecha != string.Empty)
                //{
                //    bool FechaValida = Mim.Validad_Fechas_Validas(G.Id_Mes, G.Fecha, G.Id_PoAnual);
                //    if (FechaValida == false) { v.Verificar = true; v.Mensaje += "Esta ingresando una Fecha quen no corresponde al Mes de Ingreso.<br/>"; }
                //}
            }
            if (G.Id_UM1 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM1) != 1)
                {
                    if ((Producto == 113) || (Producto == 253) || (Producto == 254) || (Producto == 259) || (Producto == 106) || (Producto == 114) ||
                       (Producto == 115) || (Producto == 116) || (Producto == 117) || (Producto == 118) || (Producto == 119) || (Producto == 249))
                    {
                        if (G.ValorUM1 == 0 && G.ValorUM2 == 0 ) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM1.<br/>"; }
                    }                    
                }
            }
            if (G.Id_UM2 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM2) != 1)
                {
                    if ((Producto == 113) || (Producto == 253) || (Producto == 254) || (Producto == 259) || (Producto == 106) || (Producto == 114) ||
                        (Producto == 115) || (Producto == 116) || (Producto == 117) || (Producto == 118) || (Producto == 119) || (Producto == 249))
                    {
                        if (G.ValorUM2 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM2.<br/>"; }
                    }
                }
            }
            if (G.Id_UM3 != 0)
            {
                if (xdata.Tipo_conteo(G.Id_UM3) != 1)
                {
                    if ((Producto == 113) || (Producto == 253) || (Producto == 254) || (Producto == 259) || (Producto == 106) || (Producto == 114) ||
                        (Producto == 115) || (Producto == 116) || (Producto == 117) || (Producto == 118) || (Producto == 119) || (Producto == 249))
                    {
                        if (G.ValorUM3 == 0) { v.Verificar = true; v.Mensaje += "No a Ingresado valor al UM3.<br/>"; }
                    }
                }
            }
            if(Producto == 113) 
            {
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                if (G.NoResolucionInformePOATrimestral == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de Resolución.<br/>"; }
                if (G.Id_TipoDeModificacion == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de modificacion.<br/>"; }
            }
            if ((Producto == 104) || (Producto == 108) || (Producto == 111) ||
                (Producto == 110) || (Producto == 107) || (Producto == 109) ||
                (Producto == 112) || (Producto == 105))
            {
                if (G.Id_Mes == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el mes de Ingreso.<br/>"; }
            }
            if ((Producto == 253) || (Producto == 254))
            {
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                if (G.NoResolucionInformePOATrimestral == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de informe Trimestral.<br/>"; }
                if (G.Hectarias == 0) { v.Verificar = true; v.Mensaje += "No a ingresado las hectarias.<br/>"; }
                if (G.NoLicencia == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado la licencia.<br/>"; }
                if (G.Id_TipoDeBosque == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de bosque.<br/>"; }
            }
            if (Producto == 259)/*otro pendiente*/
            {
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                if (G.NoResolucionInformePOATrimestral == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de Resolución.<br/>"; }
                if (G.Titular == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre del titular.<br/>"; }
                if (G.NoTelefono == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el numero de telefono del titular.<br/>"; }
                if (G.Elaborador == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre del Elaborador.<br/>"; }
                if (G.NoTelefonoElabora == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el numero de telefono del Elaborador.<br/>"; }
                //if (G.Especie == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre de la especie.<br/>"; }
                if (G.CoordenadaX == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada X.<br/>"; }
                if (G.CoordenadaY == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la coordenada Y.<br/>"; }
                if (G.CoordenadaX != 0)
                {
                    if (G.CoordenadaX.ToString().Length < 6) { v.Verificar = true; v.Mensaje += "la Coordenada x debe de ser de 6 digitos.<br/>"; }
                }
                if (G.CoordenadaY != 0)
                {
                    if (G.CoordenadaY.ToString().Length < 7) { v.Verificar = true; v.Mensaje += "la Coordenada Y debe de ser de 7 digitos.<br/>"; }
                }
            }
            if ((Producto == 106) || (Producto == 114) || (Producto == 115) || (Producto == 116)) 
            {
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                if (G.NoResolucionInformePOATrimestral == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de Resolución.<br/>"; }
                if (G.Id_TipoLicencia == 0) { v.Verificar = true; v.Mensaje += "No a selecionado el tipo de licencia.<br/>"; }
                if (G.Id_TipoDeBosque == 0) { v.Verificar = true; v.Mensaje += "No a seleccionado el tipo de bosque.<br/>"; }
            }
            if ((Producto == 106) || (Producto == 114) || (Producto == 115) || (Producto == 116)) 
            {
                if (G.NoExpediente == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de expediente.<br/>"; }
                if (G.NoResolucionInformePOATrimestral == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Número de Resolución / de dictamen.<br/>"; }
            }

            if (Mantenimiento == "True")
            {
                if (G.Observaciones.Length < 60)
                {
                    { v.Verificar = true; v.Mensaje += "Debe ingresar la justificación correspondiente.<br/>"; }
                }
            }

            return v;
        }
    }
}