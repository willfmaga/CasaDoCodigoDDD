using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CasaDoCodigo.Models;
using CasaDoCodigo.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using CasaDoCodigo.Application.Interfaces;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoApp produtoApp;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IPedidoApp pedidoApp;

        public PedidoController(IProdutoApp produtoApp, IHttpContextAccessor contextAccessor, IPedidoApp pedidoApp)
        {
            this.produtoApp = produtoApp;
            this.contextAccessor = contextAccessor;
            this.pedidoApp = pedidoApp;
        }

        public IActionResult Carrossel()
        {
            return View(produtoApp.GetProdutos());
        }

        public IActionResult Carrinho()
        {
            int? pedidoId = GetPedidoId();

            var pedido = pedidoApp.GetPedido(pedidoId);

            if (!pedidoId.HasValue)
                SetPedidoId(pedido.Id);

            return View(pedido.Itens);
        }

        public IActionResult Resumo()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        private int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

    }
}
