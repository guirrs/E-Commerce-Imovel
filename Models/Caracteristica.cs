using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Table("Caracteristica")]
public partial class Caracteristica
{
    [Key]
    public int CaracteristicaId { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string? Ambiente { get; set; }

    public bool? Mobiliado { get; set; }

    public bool? Varanda { get; set; }

    public bool? Churrasqueira { get; set; }

    public bool? Piscina { get; set; }

    public bool? Jardim { get; set; }

    public int? QuantidadeBanheiros { get; set; }

    public int? QuantidadeQuartos { get; set; }

    [InverseProperty("Caracteristica")]
    public virtual ICollection<Domicilio> Domicilios { get; set; } = new List<Domicilio>();
}
