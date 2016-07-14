var product = (function(){

    function createproduct() {


        var data = {
            Name: $('#name').val(),
            Category: $('#category').val(),
            Price: $('#price').val(),
            StockCount: $('#count').val()
        };

        $.ajax({
            type: "POST",
            url: "/Home/Create",
            data: data,
            success: success
        });
    };

    function success() {
        console.log("success");
    }


    return {
        createproduct: createproduct
    };

})();