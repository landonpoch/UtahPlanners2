var utahPlannersApp = angular.module('utahPlannersApp', [
    'ngRoute',

    'utahPlannersServices',
    'utahPlannersControllers'
]);

utahPlannersApp.config(['$routeProvider',
function ($routeProvider) {
    $routeProvider.
    when('/', {
        templateUrl: 'Index.html',
        controller: 'LookupListCtrl'
    });
}]);