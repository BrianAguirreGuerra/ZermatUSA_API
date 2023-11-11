using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAllProductos()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZermatUsaContext context = new DL.ZermatUsaContext())
                {
                    var productos = context.Productos.ToList();

                    if (productos != null && productos.Count > 0)
                    {
                        result.Correct = true;
                        result.Objects = productos.Cast<object>().ToList();
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron productos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrió un problema: " + ex.Message;
            }
            return result;
        }
    }
}
