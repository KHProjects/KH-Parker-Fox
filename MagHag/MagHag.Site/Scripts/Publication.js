var MagHag = MagHag || {};

MagHag.PublicationManager = function (displayPanelSelector, resourceUri, subscriptionResourceUri) {
    this.resourceUri = resourceUri;
    this.subscriptionResourceUri = subscriptionResourceUri;
    this.displayPanel = $(displayPanelSelector);

    this.setupSignalRProxy();
    this.setupCreateSubscriptionCommand();
    //var self = this;
    //this.publicationNotifier.client.publicationCreated = function (message) { self.publicationCreatedEventHandler.apply(self, message); };
    //this.publicationNotifier.client.publicationCreated = this.publicationCreatedEventHandler.bind(this);
    this.refreshPublications();   
};

MagHag.PublicationManager.prototype = (function () {

    setupSignalRProxy = function() {
        var connection = $.hubConnection();
        this.publicationNotifier = connection.createHubProxy('publicationEventNotifier');

        this.publicationNotifier.on('publicationCreated', publicationCreatedEventHandler.bind(this));
        connection.start();
    },
    
    setupCreateSubscriptionCommand = function () {
        var self = this;
        $(this.displayPanel).on('click', 'input.subscribeCommand', function () {
            var id = $(this).attr('data-PublicationId');
            $.ajax({
                url: self.subscriptionResourceUri,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: JSON.stringify({ PublicationId: id})
            }).done(function () {
                console.log('done');
            });
        });
    },

    refreshPublications = function () {
        $.ajax({
            context : this,
            url: this.resourceUri
        }).done(showPublications).fail(showErrorFetchingPublications);
    },

    showPublications = function (data) {
        var displayPanel = $(this.displayPanel);
        displayPanel.empty().html(data);
        
    },

    showErrorFetchingPublications = function (jsHhr, textStatus) {
        console.log('error:');
    },

    publicationCreatedEventHandler = function (publicationCreatedEvent) {
        console.log(publicationCreatedEvent);
        this.refreshPublications();
    };
    
    return {
        setupSignalRProxy : setupSignalRProxy,
        refreshPublications : refreshPublications,
        publicationCreatedEventHandler: publicationCreatedEventHandler,
        setupCreateSubscriptionCommand: setupCreateSubscriptionCommand
    };
})();

Function.prototype.bind = function(obj) {
    var fn = this;
    return function() {
        fn.apply(obj, arguments);
    };
};