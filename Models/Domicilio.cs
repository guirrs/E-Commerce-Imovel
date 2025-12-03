using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Table("Domicilio")]
public partial class Domicilio
{
    [Key]
    public int DomicilioId { get; set; }

    public int CaracteristicaId { get; set; }

    [Column(TypeName = "money")]
    public decimal Preco { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? Sobre { get; set; }

    public DateTime Publicacao { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Cidade { get; set; }

    [ForeignKey("CaracteristicaId")]
    [InverseProperty("Domicilios")]
    public virtual Caracteristica Caracteristica { get; set; } = null!;
}
