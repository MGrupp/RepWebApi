using System;
using System.Collections.Generic;

namespace WebApiPrueba
{
    public class BusinessResult
    {
        public BusinessResult()
        {
            Success = false;
            ErrorsList = new List<string>();
            Other = null;
        }

        public bool Success { get; set; }

        public object Other { get; set; }

        public List<string> ErrorsList { get; set; }

        public string Errors
        {
            get
            {
                string errores = "";
                foreach (string error in this.ErrorsList)
                {
                    errores = errores + error + "\n";
                }
                return errores;
            }
        }
    }
}
