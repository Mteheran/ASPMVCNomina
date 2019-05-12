using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVCNomina.Helpers
{
    public static class EstadoCargoHelper
    {
        public static string getEstado(string estado)
        {
            if(estado == "0"){
                return ("Inactivo");
            }
            else if(estado == "1"){
                return ("Activo");
            }
            return ("");
                                   
        }

        public static string getStyleEstado(string estado)
        {
            if (estado == "0")
            {
                return ("alert-danger");
            }
            else if (estado == "1")
            {
                return ("alert-success");
            }
            return ("");

        }
    }
}