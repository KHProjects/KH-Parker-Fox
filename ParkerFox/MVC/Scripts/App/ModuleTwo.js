define('ModuleTwo', ['ModuleOne'], function (moduleOne) {
    var _moduleOne = moduleOne;

    function moduleTwoMethodOne() {
        console.log("module two method one");
        _moduleOne.methodOne();
    };

    return {
        methodOne : moduleTwoMethodOne
    };
});