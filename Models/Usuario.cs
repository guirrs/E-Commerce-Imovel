using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Table("Usuario")]
[Index("Email", Name = "UQ__Usuario__A9D10534F12A01FC", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Telefone { get; set; } = null!;

    [StringLength(250)]
    public string? Email { get; set; }

    [MaxLength(128)]
    public byte[] Senha { get; set; } = null!;

    [StringLength(500)]
    public string? FotoURL { get; set; }

    [Precision(0)]
    public DateTime CriadoEM { get; set; }
}
