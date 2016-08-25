app.controller("myCntrl", function ($scope, myService) {
    $scope.divPerson = false;

    $scope.getItems = function () {
        var getData = myService.getItems($scope.searchTerm);

        getData.then(function (result) {
            $scope.items = result.data;
        }, function () {
            alert('Error in getting people.');
        });
    }

    $scope.getItems();

    $scope.AddUpdateItem = function () {

        var item = {
            FirstName: $scope.personFirstName,
            LastName: $scope.personLastName,
            Age: $scope.personAge
        };

        var getAction = $scope.Action;
        if (getAction === "Update") {
            item.Id = $scope.personId;
            var result = myService.updateItem(item);
            result.then(function (msg) {
                $scope.getItems();
                $scope.divPerson = false;
            }, function () {
                alert('Error in updating person.');
            });
        } else {
            var getData = myService.addItem(item);
            getData.then(function(msg) {
                $scope.getItems();
                $scope.divPerson = false;
            }, function() {
                alert('Error in adding person.');
            });
        }
    }

    $scope.editItem = function (item) {
        var getData = myService.getItem(item.Id);
        getData.then(function (result) {
            $scope.person = result.data;
            $scope.personId = item.Id;
            $scope.personFirstName = item.FirstName;
            $scope.personLastName = item.LastName;
            $scope.personAge = item.Age;
            $scope.Action = "Update";
            $scope.divPerson = true;
        },
        function () {
            alert('Error in getting person.');
        });
    }

    function clearFields() {
        $scope.personId = "";
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