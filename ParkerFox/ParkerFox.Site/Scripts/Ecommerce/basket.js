//this is a self calling function, the vars at the stop are scoped within this function, so no name clashes
(function () {
    var textInputField = $('<input type="text" class="quantity-input" />');
    var saveCommand = $('<a class="saveCommand"><img alt="update" src="/content/images/save.png" /></a>');
    var deleteCommand = $('<a class="deleteCommand"><img alt="delete" src="/content/images/cross.png" /></a>');
    var updateUri = '@Url.Action("UpdateItem", "Basket")';
    var deleteUri = '@Url.Action("DeleteItem", "Basket")';

    //show the text box with the current quantity value and a save button
    function enterEditState() {
        var row = $(this);
        var quantityCell = row.children('td.quantity');

        textInputField.val(quantityCell.text());

        quantityCell.empty().append(textInputField).append(saveCommand).append(deleteCommand);
    };

    //remove the form data and show the text box quantity
    function leaveEditState() {
        var row = $(this);
        var quantityCell = row.children('td.quantity');
        quantityCell.empty().text(quantityCell.attr('data-value'));
    };

    //get value for quantity from text box
    function saveQuantityClickHandler(e) {
        e.stopPropagation();

        var row = $(this).parents('tr');

        var quantityCell = row.children('td.quantity');
        var quantityInput = quantityCell.children('input');
        var quantity = quantityInput.val();

        updateItemQuantity(row.attr('data-id'), quantity);

        quantityCell.empty().append(quantity);
        quantityCell.attr('data-value', quantity);
    };

    //get product id call action to remove item
    function deleteItemClickHandler(e) {
        e.stopPropagation();

        if (confirm("Are you sure you want to delete this item from your shopping cart")) {
            var row = $(this).parents('tr');
            deleteItem(row.attr('data-id')).done(function () {
                //todo: refresh just the basket table not the whole page
                window.location = window.location;
            });
        }
    };

    //use jquery ajaz to call a controller method to update the quantity
    function updateItemQuantity(productId, quantity) {
        $.ajax({
            url: updateUri,
            type: "POST",
            data: { ProductId: productId, Quantity: quantity }
        });
    };

    //use jquery ajax to call a controller method to remove item from cart
    function deleteItem(productId) {
        return $.ajax({
            url: deleteUri,
            type: "POST",
            data: { ProductId: productId }
        });
    };

    //start
    $(function () {
        $('#basket tr').hover(enterEditState, leaveEditState);
        $(document).on("click", "#basket td.quantity a.saveCommand", saveQuantityClickHandler);
        $(document).on("click", "#basket td.quantity a.deleteCommand", deleteItemClickHandler);
        $(document).on("click", "#basket td.quantity input", function () { $(this).select(); });
        $('#basket td.edit').remove(); //if JS enabled then we'll remove the manual update column
    });
}());