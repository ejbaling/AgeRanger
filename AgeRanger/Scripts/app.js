var app = angular.module('app', ['ui.grid', 'classy']);

app.directive('dbsAgeRangerGrid', function () {

    var lines = [{firstName: "test"}];
    
    return {
        restrict: 'E',
        replace: true,
        scope: {
            canEdit: "@canEdit"
        },
        templateUrl: './Scripts/age-ranger/age-ranger-grid.tpl.html',
        controllerAs: 'vm',
        controller: app.cC({
            inject: ['$scope', '$timeout', '$window', '$element', '$http'],
            data: {
                rowHeight: 38
            },
            init: function () {
                return this.$scope.gridOptions = {
                    data: lines,
                    enableSorting: false,
                    enableColumnMenus: false,
                    //enableHorizontalScrollbar: this.uiGridConstants.scrollbars.NEVER,
                    //enableVerticalScrollbar: this.uiGridConstants.scrollbars.NEVER,
                    rowHeight: this.rowHeight,
                    showFooter: false,
                    minRowsToShow: 0,
                    enableCellEditOnFocus: true,
                    rowTemplate: '<div><div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader }" ui-grid-cell></div></div>',
                    columnDefs: [
                      {
                          name: 'firstName',
                          displayName: 'Firstname',
                          enableCellEdit: true,
                          cellTemplate: '<div class="ui-grid-cell-contents ng-binding ng-scope"><span>{{row.entity.firstName}}</span></div>'
                      }
                    ]
                };
            },
            watch: {
                lines: this._updateLines()
            },
            methods: {
                _updateLines: function () {
                    this.height = this.$scope.gridOptions.rowHeight - 4 + (this.lines * this.$scope.gridOptions.rowHeight);
                    
                }
            }
        })
    };
});
