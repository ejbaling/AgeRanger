app.service("myService", function ($http) {

    this.getItems = function () {
        return $http.get("Home/GetItems");
    };

    this.getItem = function (id) {
        var response = $http({
            method: "post",
            url: "Home/GetItem",
            params: {
                id: JSON.stringify(id)
            }
        });
        return response;
    }

    this.addItem = function (item) {

        var response = $http({
            method: "post",
            url: "Home/AddItem",
            data: JSON.stringify(item),
            dataType: "json"
        });

        return response;
    }

    this.updateItem = function (item) {
        var response = $http({
            method: "post",
            url: "Home/UpdateItem",
            data: JSON.stringify(item),
            dataType: "json"
        });
        return response;
    }
});