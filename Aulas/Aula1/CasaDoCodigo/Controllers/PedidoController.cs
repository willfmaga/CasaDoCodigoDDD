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
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Application.Services;
using CasaDoCodigo.Models.ViewModels;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoApp produtoApp;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IPedidoApp pedidoApp;
        private readonly IItemPedidoApp itemPedidoApp;

        public PedidoController(IProdutoApp produtoApp, IHttpContextAccessor contextAccessor, IPedidoApp pedidoApp, IItemPedidoApp iTemPedidoApp)
        {
            this.produtoApp = produtoApp;
            this.contextAccessor = contextAccessor;
            this.pedidoApp = pedidoApp;
            this.itemPedidoApp = iTemPedidoApp;
        }

        public IActionResult Carrossel()
        {
            return View(produtoApp.GetProdutos());
        }

        public IActionResult Carrinho(string codigo)
        {
            int? pedidoId = GetPedidoId();

            var pedido = pedidoApp.GetPedido(pedidoId);

            if (!pedidoId.HasValue)
                SetPedidoId(pedido.Id);

            //add o produto no pedido
            if (!string.IsNullOrWhiteSpace(codigo))
            {
                pedidoApp.AddItem(codigo, pedido);
            }
            var carrinhoviewModel = new CarrinhoViewModel(pedido.Itens);

            return View(carrinhoviewModel);
        }

        public IActionResult Resumo()
        {
            var pedido = pedidoApp.GetPedido(GetPedidoId());

            return View(pedido);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public UpdateQuantidadeAjaxResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            int pedidoId = (int)GetPedidoId();


            var updateQuantidadeResponse = pedidoApp.UpdateQuantidade(itemPedido, pedidoId);

            return new UpdateQuantidadeAjaxResponse(updateQuantidadeResponse.ItemPedido,
                              new CarrinhoViewModel(updateQuantidadeResponse.Pedido.Itens));

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
