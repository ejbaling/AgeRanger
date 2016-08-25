app.service("myService", function ($http) {

    //get All Eployee
    this.getItems = function () {
        return $http.get("Home/GetItems");
    };
});