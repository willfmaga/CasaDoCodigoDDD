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

        debugger;
            let linhaPedido = $('[item-id=' + itemPedido.Id + ']');

            debugger;
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

