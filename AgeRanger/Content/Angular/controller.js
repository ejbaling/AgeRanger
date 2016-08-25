app.controller("myCntrl", function ($scope, myService) {
    $scope.divPerson = false;
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

    $scope.AddUpdateItem = function () {

        var item = {
            FirstName: $scope.personFirstName,
            LastName: $scope.personLastName,
            Age: $scope.personAge
        };

        var getData = myService.addItem(item);
        getData.then(function(msg) {
            getAllItems();
            alert(msg.data);
            $scope.divPerson = false;
        }, function() {
            alert('Error in adding record');
        });
    }

    function clearFields() {
        $scope.personFirstName = "";
        $scope.personLastName = "";
        $scope.personAge = "";
    }

    $scope.AddPersonDiv = function () {
        clearFields();
        $scope.Action = "Add";
        $scope.divPerson = true;
    }

});