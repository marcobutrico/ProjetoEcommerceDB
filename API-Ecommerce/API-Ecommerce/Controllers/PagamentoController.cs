﻿using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Repoositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IPagamentoRepository _pagamentoRepository;
        public PagamentoController(EcommerceContext context)
        {
            _context = context;
            _pagamentoRepository = new PagamentoRepository(_context);
        }

        // 1 - Definir o verbo: GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }

    }
}
