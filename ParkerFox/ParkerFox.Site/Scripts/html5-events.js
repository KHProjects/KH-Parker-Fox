

function bindHtml5Events() {
    $(window).on("hashchange", function(e) {
        var event = e.originalEvent;
    });

    $(window).on("popstate", function (e) {
        var event = e.originalEvent;
    });

    $(window).on("drop", function(e) {
        var event = e.originalEvent;
    });
};