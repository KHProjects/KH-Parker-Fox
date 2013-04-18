function Customer(firstName) {
    this.shutup(firstName);
    this.one();
};

Customer.prototype = (function () {

    this.MyMethodOne = function () {
        alert('my method one');
    };

    this.ShutUp = function(name) {
        alert('shut up ' + name);
    };
    
    return {
        shutup: ShutUp,
        one: MyMethodOne
    };
})();
