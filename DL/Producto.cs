using System;
using System.Collections.Generic;

namespace DL;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? CódigoBarras { get; set; }

    public string? Descripción { get; set; }

    public decimal Precio { get; set; }

    public int? IdCategoría { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Categoria? IdCategoríaNavigation { get; set; }
}
