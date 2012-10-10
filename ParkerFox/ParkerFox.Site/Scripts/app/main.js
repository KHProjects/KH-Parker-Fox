(function() {
    var root = this;

    define3rdPartyModules();

    function define3rdPartyModules() {
        define('jquery', [], function() { return root.jQuery; });
    };
})();