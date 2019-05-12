using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVCNomina.Helpers
{
    public static class SalaryAmountHelper
    {
        public static string Convert(string number)
        {
            return decimal.Parse(number).ToString("C3");
        }
    }
}