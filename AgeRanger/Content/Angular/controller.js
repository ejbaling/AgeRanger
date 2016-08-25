app.controller("myCntrl", function ($scope, myService) {
    $scope.divEmployee = false;
    //$scope.items = [{ FirstName: "Will", LastName: "Smith", Age: 33 }];

    function getAllItems() {
        var getData = myService.getItems();

        getData.then(function (result) {
            console.log(JSON.stringify(result));
            $scope.items = result.data;
        }, function () {
            alert('Error in getting items.');
        });
    }

    getAllItems();

});