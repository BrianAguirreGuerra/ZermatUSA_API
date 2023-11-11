namespace BL
{
    public class Clientes
    {
        public static ML.Result GetByEmail(string email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZermatUsaContext context = new DL.ZermatUsaContext())
                {

                    var cliente = context.Clientes
                        .SingleOrDefault(p => p.Email == email);

                    if (cliente != null)
                    {
                        result.Correct = true;
                        result.Object = cliente;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró ningún cliente";
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

        public static ML.Result AddCliente(DL.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZermatUsaContext context = new DL.ZermatUsaContext())
                {
                    var existingCliente = context.Clientes.SingleOrDefault(c => c.Email == cliente.Email);

                    if (existingCliente == null)
                    {
                        context.Clientes.Add(cliente);
                        context.SaveChanges(); 

                        result.Correct = true;
                        result.Object = cliente; 
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ya existe un cliente con este email";
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