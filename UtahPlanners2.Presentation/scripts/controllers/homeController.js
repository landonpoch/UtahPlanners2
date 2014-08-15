var homeController = angular.module('homeController', []);

homeController.controller('homeController', ['$scope',
    function ($scope) {
        $scope.lookups = [
            { Description: 'Lookup1' },
            { Description: 'Lookup2' }
        ];
    }]);