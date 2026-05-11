using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanificacionPOA.Controladores
{
    public class Validar_Productos_Codigo
    {
        public bool ShowHideProductoFisca(int Producto, int Op) 
        {
            bool ShowHide = false;
            if(Op == 1) 
            {
                if (Producto == 52) 
                {
                    ShowHide = true;
                }
                else 
                {
                    ShowHide = false;
                }
            }
            if (Op == 2)
            {
                if (Producto == 62) 
                {
                    ShowHide = true;
                }
                else 
                {
                    ShowHide = false;
                }
            }
           
            return ShowHide;
        }
        public bool ShowHideProductoForta(int Producto, int Op) 
        {
            bool ShowHide = false;
            if (Op == 1) 
            {
                if ((Producto == 00))
                {
                    ShowHide = true;
                }
                else 
                {
                    ShowHide = false;
                }
            }            
            return ShowHide;
        }
        public bool ShowHideProductoIncentivoForestalM(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 00))
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoIncentivoForestal(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 92) || (Producto == 93) || (Producto == 95) || (Producto == 102) || (Producto == 103))
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoIndustria(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 92) ||(Producto == 99) ||  (Producto == 95) ||  (Producto == 286) || (Producto == 101)|| (Producto == 102) || (Producto == 103))
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoProteccionForestal(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 208) || (Producto == 215))
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoPinabete(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if (Producto == 160)
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoMangle(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 120) || (Producto == 121))
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoCulturaForestal(int Producto, int Op)
        {
            bool ShowHide = false;
            //if (Op == 1)
            //{
            //    if ((Producto == 45))
            //    {
            //        ShowHide = true;
            //    }
            //    else
            //    {
            //        ShowHide = false;
            //    }
            //}
            if(Op == 2) 
            {
                if (Producto == 37)
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            if (Op == 3)
            {
                if (Producto == 38)
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            if (Op == 4)
            {
                if (Producto == 42)
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            if (Op == 5)
            {
                if (Producto == 43)
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }           
            return ShowHide;
        }
        public bool ShowHideProductoMonitoreo(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 126) || (Producto == 127) || (Producto == 128) || (Producto == 129) || (Producto == 130) || (Producto == 131) ||
                    (Producto == 132) || (Producto == 133) || (Producto == 124)) 
                { 
                    ShowHide = false;
                }
                else
                {
                    ShowHide = true;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoExentosForestales(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if(Producto == 256) 
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        //Habilitar Ojo para visualizar doucumentos
        public bool ShowHideProductoProbosque(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 184) || (Producto == 185) || (Producto == 189) || (Producto == 192) || (Producto == 193) || (Producto == 194) ||
                    (Producto == 195) || (Producto == 199) || (Producto == 204) || (Producto == 198) || (Producto == 201)|| (Producto == 288)|| (Producto == 289)|| (Producto == 290)
                    || (Producto == 291)|| (Producto == 292)|| (Producto == 293)|| (Producto == 294)|| (Producto == 295)|| (Producto == 296)|| (Producto == 297)
                    )
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoRNF(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if(Producto == 255)
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }       
        public bool ShowHideProductoPINPEP(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 164) || (Producto == 165)|| (Producto == 174) || (Producto == 173) || (Producto == 177) || (Producto == 179) || (Producto == 169) || (Producto == 171) ||
                    (Producto == 172) || (Producto == 175) || (Producto == 178) || (Producto == 180)|| (Producto == 297)|| (Producto == 298)|| (Producto == 299)|| (Producto == 300)|| (Producto == 301)|| (Producto == 301)
                    || (Producto == 302)|| (Producto == 303)|| (Producto == 304)|| (Producto == 167)|| (Producto == 166)|| (Producto == 168)|| (Producto == 170)
                    )
                {
                    ShowHide = true;
                }
                else
                {
                    ShowHide = false;
                }
            }
            return ShowHide;
        }
        public bool ShowHideProductoLicencia(int Producto, int Op)
        {
            bool ShowHide = false;
            if (Op == 1)
            {
                if ((Producto == 104) || (Producto == 108) || (Producto == 111) || 
                    (Producto == 110) || (Producto == 107) || (Producto == 109) || 
                    (Producto == 112) || (Producto == 105))
                {
                    ShowHide = false;
                }
                else
                {
                    ShowHide = true;
                }
            }
            return ShowHide;
        }
    }
}