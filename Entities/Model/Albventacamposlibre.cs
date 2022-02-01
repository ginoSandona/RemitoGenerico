using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Model
{
    public partial class Albventacamposlibre
    {
        public string Numserie { get; set; }
        public int Numalbaran { get; set; }
        public string N { get; set; }
        public string Pedido { get; set; }
        public string Enviadocvm { get; set; }
        public string Verificado { get; set; }
        public int? Numeronacio { get; set; }
        public string Adenda { get; set; }
        public string Cae { get; set; }
        public string Caefchvenc { get; set; }
        public string Codigoqr { get; set; }
        public string DescripcionCfe { get; set; }
        public string Fechafirma { get; set; }
        public string Hashcfe { get; set; }
        public string Inforeferencia { get; set; }
        public string Linkdgi { get; set; }
        public int? Nrocaeini { get; set; }
        public int? Nrocaefin { get; set; }
        public string Compraid { get; set; }
        public string Clauventa { get; set; }
        public int? Modventa { get; set; }
        public int? Viatransp { get; set; }
        public int? Tipotraslado { get; set; }
        public string Replicado { get; set; }

        public virtual Albventacab NNavigation { get; set; }
    }
}
