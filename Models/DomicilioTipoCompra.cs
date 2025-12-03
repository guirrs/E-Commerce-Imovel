using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Keyless]
[Table("DomicilioTipoCompra")]
public partial class DomicilioTipoCompra
{
    public int? DomicilioId { get; set; }

    public int? TipoCompraId { get; set; }

    [ForeignKey("DomicilioId")]
    public virtual Domicilio? Domicilio { get; set; }

    [ForeignKey("TipoCompraId")]
    public virtual TipoCompra? TipoCompra { get; set; }
}
