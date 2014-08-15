var utahPlannersControllers = angular.module('utahPlannersControllers', []);

utahPlannersControllers.controller('LookupListCtrl', ['$scope',
    'utahPlannersServices',
    function ($scope, utahPlannersServices) {
        var promise = utahPlannersServices.getLookups();
            
        promise.then(function (response) {
                $scope.lookups = response.data;
            });
}]);