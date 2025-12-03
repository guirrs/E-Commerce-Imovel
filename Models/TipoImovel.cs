using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Table("TipoImovel")]
public partial class TipoImovel
{
    [Key]
    public int TipoImovelId { get; set; }

    [Column("TipoImovel")]
    [StringLength(250)]
    [Unicode(false)]
    public string TipoImovel1 { get; set; } = null!;
}
