ranger = angular.module 'dbsAgeRanger'

ranger.directive 'dbsAgeRangerGrid', ->
    restrict: 'E'
    replace: true
    scope: 
    templateUrl: './age-ranger-grid.tpl.html'
    controllerAs: 'vm'
    controller: ranger.cC
        inject: ['$scope', '$timeout', '$window', '$element', '$http']

        data: 
            rowHeight: 38
            columnWidth: 100

        init: ->

        @$scope.gridOptions = {
            #data: 'chargeLines'
            enableSorting: false
            enableColumnMenus: false
            enableHorizontalScrollbar: @uiGridConstants.scrollbars.NEVER
            enableVerticalScrollbar: @uiGridConstants.scrollbars.NEVER
            rowHeight: @rowHeight
            showFooter: false
            minRowsToShow: 0
            enableCellEditOnFocus: true
            rowTemplate:'<div><div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader }" ui-grid-cell></div></div>'
            columnDefs: [
                {
                    name: 'FirstName'
                    displayName: 'Firstname'
                    enableCellEdit: true
                    cellTemplate: '<div class="ui-grid-cell-contents ng-binding ng-scope"><span>{{row.entity.firstName}}</span></div>'
                }
            ]
        }

        methods:


      
