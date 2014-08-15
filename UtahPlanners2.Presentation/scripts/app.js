var app = angular.module('utahPlannersApp', [
    'ngRoute',
    'navigationController',
    'homeController'
]);

app.config(['$routeProvider',
    '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true); // Gets rid of the hash in the url?  weird

        $routeProvider
            .when('/', { templateUrl: '/views/home.html', controller: 'homeController' });
    }]);