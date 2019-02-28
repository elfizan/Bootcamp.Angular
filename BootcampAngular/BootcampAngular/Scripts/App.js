var app = angular.module("BootcampAngular", ["CrudAngularApp", "ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when("/", {
        templateUrl: "/Partials/PlayerList.html",
        controller: "MainController"
    }).
    when("/AddPlayer", {
        templateUrl: "/Partials/AddPlayer.html",
        controller: "AddPlayerController"
    }).
    when("/EditPlayer/:Id", {
        templateUrl: "/Partials/EditPlayer.html",
        controller: "EditPlayerController"
    }).
    otherwise({
        redirectTo: "/"
    });
}])