function PublicationManager(displayPanelSelector, resourceUri) {
    
    this.resourceUri = resourceUri;    
    this.displayPanel = $(displayPanelSelector);

    this.publicationNotifier = $.connection.publicationEventNotifier;
    var _this = this;
    this.publicationNotifier.client.publicationCreated = function () { _this.publicationCreatedEventHandler.apply(_this); };
    this.publicationNotifier.client.publicationActivated = this.publicationActivated;
    this.refreshPublications();   
};

PublicationManager.prototype = (function () {
    refreshPublications = function () {
        $.ajax({
            context : this,
            url: this.resourceUri
        }).done(showPublications).fail(showErrorFetchingPublications);
    },
    showPublications = function (data) {        
        $(this.displayPanel).empty().html(data);
    },
    showErrorFetchingPublications = function(jsHhr, textStatus) {
        console.log('error');
    }, publicationCreatedEventHandler = function (publicationCreatedEvent) {
        console.log(this);
        this.refreshPublications();
    };
    
    return {
        refreshPublications : refreshPublications,
        publicationCreatedEventHandler: publicationCreatedEventHandler,        
        publicationActivatedEventHandler: function (publicationActivated) { console.log("publication activated"); }
    };
})();