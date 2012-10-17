
function ClassOne() {
    this.LookMaAProperty = "mama llama";
};

//--prototype is like refering to base in C#, but you can define methods using it
ClassOne.prototype.MethodAdded = function () {
    console.log(this.LookMaAProperty);
};

function ClassTwo(ctorArg) {
    this.PropertyOne = ctorArg;

    this.SomeMethod = function() {
        console.log(this.PropertyOne);
    };
};