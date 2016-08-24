var app = angular.module('app', ['ui.grid']);

var app;
app = angular.module('app');
app.directive('dbsAgeRangerGrid', function () {
    var controller = function() {
        function init() {
            
        }

        init();
    };
    
    return {
        restrict: 'E',
        replace: true,
        scope: {
            canEdit: "@canEdit"
        },
        templateUrl: './age-ranger/age-ranger-grid.tpl.html',
        controllerAs: 'vm',
        controller: app.cC({
            inject: ['$scope', '$timeout', '$window', '$element', '$http'],
            data: {
                rowHeight: 38,
                columnWidth: 100
            },
            init: function () {
                return this.$scope.gridOptions = {
                    enableSorting: false,
                    enableColumnMenus: false,
                    enableHorizontalScrollbar: this.uiGridConstants.scrollbars.NEVER,
                    enableVerticalScrollbar: this.uiGridConstants.scrollbars.NEVER,
                    rowHeight: this.rowHeight,
                    showFooter: false,
                    minRowsToShow: 0,
                    enableCellEditOnFocus: true,
                    rowTemplate: '<div><div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader }" ui-grid-cell></div></div>',
                    columnDefs: [
                      {
                          name: 'FirstName',
                          displayName: 'Firstname',
                          enableCellEdit: true,
                          cellTemplate: '<div class="ui-grid-cell-contents ng-binding ng-scope"><span>{{row.entity.firstName}}</span></div>'
                      }
                    ]
                };
            }
        })
    };
});