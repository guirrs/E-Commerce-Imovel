using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Models;

[Keyless]
[Table("DomicilioTipoImovel")]
public partial class DomicilioTipoImovel
{
    public int? DomicilioId { get; set; }

    public int? TipoImovelId { get; set; }

    [ForeignKey("DomicilioId")]
    public virtual Domicilio? Domicilio { get; set; }

    [ForeignKey("TipoImovelId")]
    public virtual TipoImovel? TipoImovel { get; set; }
}
