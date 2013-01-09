function demoPrototype() {

    var someClass = new myClass();
    var someClass2 = new myClass();
    
    //--this method is only attached to the instance someClass and not the class myClass
    someClass.someAdHocMethod = function() {
        console.log('some ad hoc method called');
    };

    try {
        someClass.someAdHocMethod();
        someClass2.someAdHocMethod();
    } catch(e) {
        console.log(e.toString());
    }

    someClass.somePrototypedMethod();
    someClass2.somePrototypedMethod();

    var instanceOfDerivedClass = new derivedClass();
    instanceOfDerivedClass.test();
};

//in JS everything is an object, even a function like this one.
function myClass() {
    this.PropertyOne = "this is property one";
};

// this method is on the prototype of all myClass instances
myClass.prototype.somePrototypedMethod = function() {
    console.log("some prototype method was called");
};


//-------------------------------

function derivedClass() { };
function baseClass() { };

baseClass.prototype.test = function() {
    console.log('test from base class');
};

derivedClass.prototype = new baseClass();