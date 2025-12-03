using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Table("TipoCompra")]
public partial class TipoCompra
{
    [Key]
    public int TipoCompraId { get; set; }

    [Column("TipoCompra")]
    [StringLength(250)]
    [Unicode(false)]
    public string TipoCompra1 { get; set; } = null!;
}
