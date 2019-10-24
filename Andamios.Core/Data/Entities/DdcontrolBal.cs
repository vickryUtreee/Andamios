using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdcontrolBal
    {
        public int BalId { get; set; }
        public int? BalClienteId { get; set; }
        public int? BalProyectoId { get; set; }
        public int? BalCotiId { get; set; }
        public string BalProdId { get; set; }
        public int? BalCantOrdenada { get; set; }
        public int? BalCantRecibida { get; set; }
        public int? BalCantDevuelta { get; set; }
    }
}
