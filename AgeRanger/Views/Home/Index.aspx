<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html ng-app="myApp">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Age Ranger</title>
    <link href="../../Content/ui-grid.min.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.3.16/angular.min.js"></script>
    <script src="../../Scripts/ui-grid.min.js"></script>
    <script src="../../Scripts/angular-classy.min.js"></script>
    <script src="../../Scripts/require.js"></script>
    <script src="../../Content/Angular/Module.js"></script>
    <script src="../../Content/Angular/Service.js"></script>
    <script src="../../Content/Angular/Controller.js"></script>
</head>
<body style="margin: 50px;">
    <div ng-controller="myCntrl">
        <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
     <%-- <div id="grid1" ui-grid="{ data: myData }" class="grid"></div>
    </div>--%>
    <%--<div>
        <dbs-age-ranger-grid>
        </dbs-age-ranger-grid>
    </div>--%>
    <h1>Age Ranger</h1>
    <br/>
               
    <div class="divList">
        <p class="divHead">Age Range List</p>
        <table cellpadding="12" class="table table-bordered table-hover" style="width: 50%;">
            <tr>
                <td><b>Firsname</b></td>
                <td><b>LastName</b></td>
                <td><b>Age</b></td>
                <td><b>Actions</b></td>
            <tr ng-repeat="item in items">
                <td>
                    {{item.FirstName}}
                </td>
                <td>
                    {{item.LastName}}
                </td>
                <td>
                    {{item.Age}}
                </td>
                <td>
                    <span ng-click="editEmployee(employee)" class="btnAdd">Edit</span>
                    <span ng-click="deleteEmployee(employee)" class="btnRed">Delete</span>
                </td>
            </tr>
        </table>
    </div>
        
    <input type="button" class="btnAdd" value="Add Person" ng-click="AddPersonDiv()" />
        
    <br/>
    <br/>
        
    <div ng-show="divPerson">
        <p class="divHead">{{Action}} Person Details</p>
        <table>
            <tr>
                <td><b>Id</b></td>
                <td style="padding-left: 20px;">
                    <input type="text" disabled="disabled" ng-model="personId" />
                </td>
            </tr>
            <tr>
                <td><b>First Name</b></td>
                <td style="padding-left: 20px;">
                    <input type="text" ng-model="personFirstName" />
                </td>
            </tr>
            <tr>
                <td><b>Last Name</b></td>
                <td style="padding-left: 20px;">
                    <input type="text" ng-model="personLastName" />
                </td>
            </tr>
            <tr>
                <td><b>Age</b></td>
                <td style="padding-left: 20px;">
                    <input type="text" ng-model="personAge" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="button" class="btnAdd" value="Save" ng-click="AddUpdateItem()" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
