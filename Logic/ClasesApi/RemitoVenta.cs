#nullable enable
using System.Collections.Generic;

namespace Logic.ClasesApi
{
    public class RemitoVenta
    {
        public RemitoVenta()
        {
            this.lineas = new List<LineaVenta>();
        }
        public int? tipoDoc { get; set; }
        public string serie { get; set; }
        public string referencia { get; set; }
        public int? cliente { get; set; }
        public bool controlStock { get; set; }
        public bool recibido { get; set; }
        public ICollection<LineaVenta> lineas { get; set; }
        
    }

    public class LineaVenta
    {
        public string? codigo { get; set; }
        public int? unidades { get; set; }
        public string? deposito { get; set; }
        public int? precio { get; set; }
        public int? iva { get; set; }
        public int? dto { get; set; }
        public string descripcion { get; set; }
    }
}