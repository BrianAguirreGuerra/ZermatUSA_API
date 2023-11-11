using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DetallePedido
    {
        public static ML.Result InsertarDetallePedido(int IdPedido, List<Dictionary<string, object>> carrito)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ZermatUsaContext context = new DL.ZermatUsaContext())
                {
                    foreach (var item in carrito)
                    {
                        var detallePedido = new DL.DetallePedido
                        {
                            IdPedido = IdPedido,
                            IdProducto = Convert.ToInt32(item["IdProducto"]),
                            Cantidad = Convert.ToInt32(item["Cantidad"])
                        };

                        context.DetallePedidos.Add(detallePedido);

                    }

                    context.SaveChanges();

                    result.Correct = true;
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
