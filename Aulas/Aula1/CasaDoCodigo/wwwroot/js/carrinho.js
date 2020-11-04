class Carrinho {
    clickIncremento(button) {

        let data = this.GetData(button);
        data.Quantidade++;
        this.PostQuantidade(data);

    }

    clickDecremento(button) {
        let data = this.GetData(button);
        data.Quantidade--;
        this.PostQuantidade(data);

    }

    UpdateQuantidade(input) {
        let data = this.GetData(input);
        this.PostQuantidade(data);
    }

    PostQuantidade(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};

        headers['RequestVerificationToken'] = token;


        $.ajax({
            url: "/pedido/updatequantidade",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            headers: headers
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
        var novaQuantidade = $(linhaDoItem).find("input").val();

        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}

