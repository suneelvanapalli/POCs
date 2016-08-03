(function () {
    var arr = ["suneel", "kumar", "vanapalli"];

    //foreach
    arr.forEach(logger);

    function logger(item) {
        console.log(item);
    }

    //filter
    var match = arr.filter(itemmatchespattern);
    console.log(match.concat());

    function itemmatchespattern(item, index) {
        var firstpattern = [1, 2];
        return firstpattern.includes(index);
    };

    //passing filter


    var firstpattern = [1, 2];
    var match = arr.filter(itemmatchespattern(firstpattern));
    

    function itemmatchespattern(matcharray) {
        return function (item, index) {
            return matcharray.includes(index);
        }
    };


    //map
   
    var mapped = arr.map(function (item) {
        return item.toUpperCase();
    });

    
    console.log(mapped.concat(" "));

})();