var utahPlannerServices = angular.module('utahPlannersServices', []);

utahPlannerServices.service('utahPlannersServices', ['$http',
    function ($http) {
        this.getLookups = function () {
            var promise = $http.get('api/Lookup')
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                return data;
            });
            return promise;
        };
    }]);