using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Imovel.Models
{
    public class DashBoardViewModel
    {
        public int Preco {get; set;}
        public int QuantidadeQuartos {get;set;}
        public int Estado{get;set;}
        public int Cidade{get;set;}
        public bool? Mobiliado{get;set;}

        public List<TabelaRelacionamento> BuscaRelacionamentos {get; set;}
    }
}