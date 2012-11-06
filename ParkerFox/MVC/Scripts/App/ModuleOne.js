define('ModuleOne', [], function() {
    function moduleOneMethodOne() {
        console.log("module one method one");
    };
    
    return {
        methodOne : moduleOneMethodOne
    };
});