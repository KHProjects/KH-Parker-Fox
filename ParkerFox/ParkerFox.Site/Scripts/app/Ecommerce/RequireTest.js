define("MyModule", [], function() {

    var sayHello = function() {
        console.log("hello");
    };

    return {
        greet : sayHello
    };
});