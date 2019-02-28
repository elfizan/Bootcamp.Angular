var applicationCountry = angular.module("CrudCountry", ["CrudCountryApp.controllers", "ngRoute"]);

applicationCountry.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when("/", {
        templateUrl: "/Partials/CountryList.html",
        controller: "CountryController"
    }).
    when("/AddCountry", {
        templateUrl: "/Partials/AddCountry.html",
        controller: "AddCountryController"
    }).
    when("/UpdateCountry/:Id", {
        templateUrl: "/Partials/UpdateCountry.html",
        controller: "UpdateCountryController"
    }).
    otherwise({
        redirectTo: "/"
    });
}])