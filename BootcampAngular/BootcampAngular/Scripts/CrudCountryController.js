angular.module("CrudCountryApp.controllers", []).
controller("CountryController", function ($scope, CountryService) {
    $scope.message="CRUD Country";
    CountryService.GetCountryFromDb().then(function (d) {
        $scope.listCountry = d.data.list;
    })

    $scope.DeleteCountry = function (Id, index) {
        $scope.listCountry.splice(index, 1);
        CountryService.DeleteCountry(Id);
    }
}).

    controller("AddCountryController", function ($scope, CountryService) {
        $scope.message="Add Country Details";
        $scope.AddCountry = function () {
            CountryService.AddCountry($scope.country);
        }
    }).
    controller("UpdateCountryController", function ($scope, CountryService, $routeParams) {
        $scope.message = "Update Country Details";

        var Id = $routeParams.Id;
        CountryService.GetCountryById(Id).then (function(d){
            $scope.country = d.data.country;
        })

        $scope.UpdateCountry = function () {
            CountryService.UpdateCountry($scope.country);
        }
    }).

factory("CountryService", ["$http", function ($http) {
    var fac = {};

    fac.GetCountryFromDb = function () {
        return $http.get("/Countries/GetCountries");
    }

    fac.GetCountryById = function (Id) {
        return $http.get("/Countries/GetCountryById", { params: { Id: Id } });
    }

    fac.AddCountry = function (country) {
        $http.post("/Countries/AddCountry", country).success(function (response) {
            alert(response.status);
        })
    }

    fac.UpdateCountry = function (country) {
        $http.post("/Countries/UpdateCountry", country).success(function (response) {
            alert(response.status);
        })
    }

    fac.DeleteCountry = function (Id) {
        $http.post("/Countries/DeleteCountry", { Id: Id }).success(function (response) {
            alert(response.status);
        })
    }

    return fac;
}])