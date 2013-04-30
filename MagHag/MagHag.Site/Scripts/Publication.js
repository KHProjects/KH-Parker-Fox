var MagHag = MagHag || {};

MagHag.PublicationManager = function (displayPanelSelector, resourceUri) {
    
    this.resourceUri = resourceUri;    
    this.displayPanel = $(displayPanelSelector);

    this.publicationNotifier = $.connection.publicationEventNotifier;
    //var hubConnection = $.hubConnection();
    //this.publicationNotifier = hubConnection.createHubProxy('publicationEventNotifier');
    //hubConnection.start();
    //this.publicationNotifier.on('publicationCreated', function(publicationCreatedEvent) {
    //    console.log('pub was like totally created');
    //});


    //var self = this;
    //this.publicationNotifier.client.publicationCreated = function (message) { self.publicationCreatedEventHandler.apply(self, message); };
    this.publicationNotifier.client.publicationCreated = this.publicationCreatedEventHandler.bind(this);
    this.refreshPublications();   
};

MagHag.PublicationManager.prototype = (function () {

    refreshPublications = function () {
        $.ajax({
            context : this,
            url: this.resourceUri
        }).done(showPublications).fail(showErrorFetchingPublications);
    },

    showPublications = function (data) {
        $(this.displayPanel).empty().html(data);
    },

    showErrorFetchingPublications = function (jsHhr, textStatus) {
        console.log('error:');
    },

    publicationCreatedEventHandler = function (publicationCreatedEvent) {
        console.log(publicationCreatedEvent);
        this.refreshPublications();
    };
    
    return {
        refreshPublications : refreshPublications,
        publicationCreatedEventHandler: publicationCreatedEventHandler
    };
})();

Function.prototype.bind = function(obj) {
    var fn = this;
    return function() {
        fn.apply(obj, arguments);
    };
};