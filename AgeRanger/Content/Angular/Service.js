app.service("myService", function ($http) {

    this.getItems = function () {
        return $http.get("Home/GetItems");
    };

    this.addItem = function (item) {

        var response = $http({
            method: "post",
            url: "Home/AddItem",
            data: JSON.stringify(item),
            dataType: "json"
        });

        return response;
    }
});