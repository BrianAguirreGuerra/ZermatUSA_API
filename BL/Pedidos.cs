using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pedidos
    {
        public static ML.Result RegistrarPedido(int IdCliente, decimal total)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ZermatUsaContext context = new DL.ZermatUsaContext())
                {
                    var nuevoPedido = new DL.Pedido
                    {
                        IdCliente = IdCliente,
                        Total = total,
                        Fecha = DateTime.Now,
                        Estado = "Pagado"
                    };

                    context.Pedidos.Add(nuevoPedido);

                    context.SaveChanges();

                    result.Correct = true;
                    result.Object = nuevoPedido.IdPedido;
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
