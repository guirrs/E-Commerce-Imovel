using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Imovel.Data;
using E_Commerce_Imovel.Models;

namespace E_Commerce_Imovel.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? tipoImovel = null, string? tipoCompra)
        {

            var selectBuscaDomicilio = _context.Domicilios
            .Include(busca => busca.CaracteristicaId)
            .AsQueryable();

            var BuscaRelacionamentos = _context.DomicilioTipoCompras
            .Join(
                _context.DomicilioTipoImovels,
                tipoCompra => tipoCompra.DomicilioId,
                tipoImovel => tipoImovel.DomicilioId,
                (tipoCompra, tipoImovel) => new TabelaRelacionamento
                {
                    IdDomicilio = tipoCompra.DomicilioId,
                    Imovel = tipoImovel.TipoImovel.TipoImovel1,
                    Compra = tipoCompra.TipoCompra.TipoCompra1

                }).ToList();
            
                DashBoardViewModel viewModel = new DashBoardViewModel
                {
                    Preco = S
                }

            return View("Index");
        }
    }
}
