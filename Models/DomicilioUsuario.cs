using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Keyless]
[Table("DomicilioUsuario")]
public partial class DomicilioUsuario
{
    public int? DomicilioId { get; set; }

    public int? UsuarioId { get; set; }

    [ForeignKey("DomicilioId")]
    public virtual Domicilio? Domicilio { get; set; }

    [ForeignKey("UsuarioId")]
    public virtual Usuario? Usuario { get; set; }
}
