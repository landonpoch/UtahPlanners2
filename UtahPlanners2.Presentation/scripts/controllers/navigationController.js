var navigationController = angular.module('navigationController', []);

navigationController.controller('navigationController', ['$scope', function ($scope) {
    $scope.menuItems = [
        { Name: "Index", Url: "#", Active: false, Visible: true },
        { Name: "About", Url: "#", Active: false, Visible: true },
        { Name: "Admin", Url: "#", Active: false, Visible: false },
        { Name: "Login", Url: "#", Active: false, Visible: true }
    ];
}]);