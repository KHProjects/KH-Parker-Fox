define("MyModule", ["OtherModule"], function (otherMod) {

    var sayHello = function() {
        console.log("hello");
        otherMod.greet();
    };

    return {
        greet : sayHello
    };
});
