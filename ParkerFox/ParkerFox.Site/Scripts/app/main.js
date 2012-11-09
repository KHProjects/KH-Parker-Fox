(function () {

    


    var root = this;

    define3rdPartyModules();


    function define3rdPartyModules() {
        define('jquery', [], function() { return root.jquery; });
    };
})();

/*
i had to download require-jquery.js from the requirejs sample for jquery

*/