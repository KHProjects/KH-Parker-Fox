$(function () {
    
    ko.applyBindings(viewModel);
    $('#lookup-address-command')
        .on('click', lookupAddress);

});

function lookupAddress() {
    var postCode = $('#post-code-lookup').val();
    var url = '/api/address/' + postCode;

    $.ajax({ url: url })
        .done(showAddressPickDialog);
};

function showAddressPickDialog(data) {
    var dialog = $('#address-pick-dialog');
    var viewModel = { Addresses: data };

    ko.applyBindings(viewModel, dialog[0]);
    dialog.show();
    $('#address-pick-dialog div.address-row a')
        .on('click', selectAddress);
};

function selectAddress(e) {
    e.preventDefault();
    var address = ko.mapping.fromJSON($(this).attr('data-value'));
    viewModel.Addresses.push(address);
    $('#address-pick-dialog').hide();
};