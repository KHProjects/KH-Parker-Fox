var Basket = function(visitorId, apiUrl) {
    var _visitorId = visitorId;
    var _apiUrl = apiUrl;
    $('#catalog a.addToBasketCommand').on("click", addToBasketCommandEventHandler);
    
    function addToBasketCommandEventHandler(e) {
        var cartItem = {
            Product: {
                ProductId: $(this).attr('data-id')
            },
            Quantity: 1,
            Identifier: _visitorId
        };

        $.ajax({
            type: "POST",
            url: _apiUrl,
            data: cartItem,
            statusCode: {
                200: onAddedToBasket,
                404: onErrorAddToBasket
            }
        });
    };
    
    function onAddedToBasket(product) {
        alert('bla ' + product.Name);
    };

    function onErrorAddToBasket() {
        alert("product not found");
    };
    
    return {
        
    };
};