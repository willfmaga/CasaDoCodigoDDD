class Carrinho {
    clickIncremento(btn) {

        let data = this.GetData(btn);
        data.Quantidade++;
        this.PostQuantidade(data);

    }

    clickDecremento(btn) {
        let data = this.GetData(btn);
        data.Quantidade--;
        this.PostQuantidade(data);

    }

    UpdateQuantidade(input) {
        let data = this.GetData(input);
        this.PostQuantidade(data);
    }

    PostQuantidade(data) {
        $.ajax({
            url: "/pedido/updatequantidade",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data)
        }).done(function (response) {

            let itemPedido = response.itemPedido;
            let carrinho = response.carrinhoViewModel;

            let linhadoitem = $('[item-id=' + itemPedido.id + ']');
            linhadoitem.find('input').val(itemPedido.quantidade);
            linhadoitem.find('[subtotal]').html((itemPedido.subTotal).duasCasas());

            $('[numero-itens]').html('Total: ' + carrinho.itens.length + ' itens');

            if (itemPedido.quantidade == 0) {
                linhadoitem.remove();
            }

            $('[total]').html((carrinho.total).duasCasas());
        });
    }

    GetData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemId = $(linhaDoItem).attr("item-id");
        var novaQtde = $(linhaDoItem).find("input").val();

        return {
            Id: itemId,
            Quantidade: novaQtde
        };
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}

