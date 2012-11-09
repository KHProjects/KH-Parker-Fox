define(['ModuleOne'], function (moduleOne) {
    var _moduleOne = moduleOne;

    function moduleTwoMethodOne() {
        console.log("module two method one bla");
        _moduleOne.methodOne();
    };

    return {
        methodOne : moduleTwoMethodOne
    };
});