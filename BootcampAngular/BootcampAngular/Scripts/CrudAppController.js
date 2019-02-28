angular.module("CrudAngularApp",[]).
controller("MainController", function ($scope, PlayerService) {
    $scope.message = "Nyoba Angular";
    PlayerService.GetPlayersFromDb().then(function (d) {
        $scope.listPlayers = d.data.list;
    })

    $scope.DeletePlayer = function (Id, index) {
        $scope.listPlayers.splice(index, 1);
        PlayerService.DeletePlayer(Id);
    }
}).
    controller("AddPlayerController", function ($scope, PlayerService) {
        $scope.message = "Add Player Details";
        $scope.AddPlayer = function () {
            //alert("Hello Mr");
            PlayerService.AddPlayer($scope.player);
        }
        // memanggil factory PlayerService pada country
        PlayerService.GetCountryFromDb().then(function (x) {
            $scope.listCountry = x.data.list;
        })
    }).
    controller("EditPlayerController", function ($scope, PlayerService, $routeParams) {
        $scope.message = "Update Player Details";

        var Id = $routeParams.Id;
        PlayerService.GetPlayerById(Id).then(function (d) {
            $scope.player = d.data.player;
        })

        $scope.EditPlayer = function () {
            PlayerService.EditPlayer($scope.player);
        }

        // memanggil factory PlayerService pada country
        PlayerService.GetCountryFromDb().then(function (x) {
            $scope.listCountry = x.data.list;
        })
    }).

factory("PlayerService", ["$http", function ($http) {
    var fac = {};

    fac.GetPlayersFromDb = function () {
        return $http.get("/Players/GetPlayers");
    }

    //get data from database country
    fac.GetCountryFromDb = function () {
        return $http.get("/Countries/GetCountries");
    }

    fac.GetPlayerById = function (Id){
        return $http.get("/Players/GetPlayerById", {params :{Id:Id}});
    }

    fac.AddPlayer = function (player) {
        $http.post("/Players/AddPlayer", player).success(function (response) {
            alert(response.status);
        })
    }

    fac.EditPlayer = function (player) {
        $http.post("/Players/EditPlayer", player).success(function (response) {
            alert(response.status);
        })
    }

    fac.DeletePlayer = function (Id) {
        $http.post("/Players/DeletePlayer", { Id: Id }).success(function (response) {
            alert(response.status);
        })
    }
    return fac;
}])