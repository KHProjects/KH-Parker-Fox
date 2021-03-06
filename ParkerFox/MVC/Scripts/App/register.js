﻿function Registration(viewModel) {
    var _viewModel = viewModel;
    ko.applyBindings(_viewModel);
    
    $('#lookup-address-command')
        .on('click', lookupAddress);

    function lookupAddress() {
        var postCode = $('#post-code-lookup').val();
        var url = '/api/address/' + postCode;

        $.ajax({
            url: url,
            type: 'GET',
            headers: { 'Accept' : 'application/json; charset=utf-8'}
        }).done(showAddressPickDialog);
    };

    function showAddressPickDialog(data) {
        var dialog = $('#address-pick-dialog');

        ko.applyBindings({ Addresses: data }, dialog[0]);
        dialog.show();
        $('#address-pick-dialog div.address-row a')
            .on('click', selectAddress);
    };

    function selectAddress(e) {
        e.preventDefault();
        
        var address = ko.mapping.fromJSON($(this).attr('data-value'));
        _viewModel.Addresses.push(address);
        $('#address-pick-dialog').hide();
    };
};
