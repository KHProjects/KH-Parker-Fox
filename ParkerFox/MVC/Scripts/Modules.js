//revealing module works because of closures
function revealingModule(arbitraryArument) {
    var property = arbitraryArument;

    var methodToBeCalled = function() {
        console.log(property);
    };

    //--return an 'Object Literal' which chooses the methods to 'reveal'
    return {
        CallMeMaybe: methodToBeCalled
    };
};

//--singleton is pattern which ensures there is only ever one instance of your class, like statics object... which are bad mmmkay
var revealingModuleSingleton = (function () {
    ///this looks different cos the properties and methods are just comma seperated
    var property = "bob",
        method = function () {
            console.log(property);
        };

    return {
        Method : method
    };
}());