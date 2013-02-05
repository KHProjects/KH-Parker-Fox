var MyClass = function() {

};

MyClass.prototype = function () {
    return {
        init : function() {
            console.log('you called the init function, you sexy beast');
        }
    };
}();