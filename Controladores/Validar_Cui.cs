using System;

namespace PlanificacionPOA.Controladores
{
    public class Validar_Cui
    {
        public bool Validar(string codigo)
        {
            //validar el cui con modulo 11
            int suma = 0;                         
            int digViene = Convert.ToInt32(codigo.Substring(8, 1));

            for (int i = 7; i >= 0; i += -1)
            {
                suma += ((8 - (i - 1)) * Convert.ToInt32(codigo.Substring(i, 1)));
            }
            suma *= 10;
            int digCalculado = suma % 11;
            return (digCalculado == digViene);
        }
        public bool ValidarNIT(string NIT)
        {
            int POS;
            string Correlativo;
            string DigitoVerificador;
            int Factor;
            int Suma = 0;
            int Valor;
            int X;
            double xMOD11;
            string S;

            try
            {
                if (NIT == "CF" | NIT == "C/F")
                {
                    return true;
                }

                if (NIT.IndexOf("-") > 0)
                    POS = NIT.IndexOf("-");
                else
                    POS = NIT.Length - 1;

                Correlativo = NIT.Substring(0, POS);

                if (NIT.IndexOf("-") > 0)
                    DigitoVerificador = NIT.Substring(POS + 1);
                else
                    DigitoVerificador = NIT.Substring(POS);

                Factor = Correlativo.Length + 1;

                for (X = 0; X <= (POS - 1); X++)
                {
                    Valor = Convert.ToInt32(NIT.Substring(X, 1));
                    Suma += (Valor * Factor);
                    Factor -= 1;
                }
                xMOD11 = (11 - (Suma % 11)) % 11;
                S = Convert.ToString(xMOD11);

                if ((xMOD11 == 10 & DigitoVerificador == "K") | (S == DigitoVerificador))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string ReparaNIT(string NIT)
        {
            int POS;
            string Correlativo;
            string DigitoVerificador;

            if (NIT == "CF" | NIT == "C/F")
            {
                return NIT;
            }

            if (NIT.IndexOf("-") < 0)
                return NIT;
            else
                POS = NIT.IndexOf("-");

            Correlativo = NIT.Substring(0, POS);

            DigitoVerificador = NIT.Substring(POS + 1);

            return Correlativo.ToString() + DigitoVerificador.ToString();
        }
    }
}