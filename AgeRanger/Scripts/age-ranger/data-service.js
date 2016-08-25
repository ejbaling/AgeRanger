module.exports = angular.module('ageRanger.data', []).factory('ageRangerDataService', [
  '$window', function ($window) {
      var chargeLines = [];

      return {
          chargeLines: chargeLines
      };
  }
]);