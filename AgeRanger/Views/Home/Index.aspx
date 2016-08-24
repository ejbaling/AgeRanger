<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html ng-app="app">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Age Ranger</title>
    <link href="../../Content/ui-grid.min.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.3.16/angular.min.js"></script>
    <script src="../../Scripts/ui-grid.min.js"></script>
    <script src="../../Scripts/app.js"></script>
</head>
<body>
    <%--<div ng-controller="MainCtrl">
      <div id="grid1" ui-grid="{ data: myData }" class="grid"></div>
    </div>--%>
    <div>
        <dbs-age-ranger-grid>
        </dbs-age-ranger-grid>
    </div>
</body>
</html>
