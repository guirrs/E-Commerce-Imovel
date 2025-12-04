using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Imovel.Models
{
    public class TabelaRelacionamento
    {
        public int? IdDomicilio{get;set;}
        public string? Imovel{get;set;} = null!;
        public string? Compra{get;set;} = null!;
    }
}