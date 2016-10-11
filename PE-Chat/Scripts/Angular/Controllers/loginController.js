﻿'use strict';
app.controller('loginController', ['$scope', '$location', 'authService',  function ($scope, $location, authService, ngAuthSettings) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {
            $location.path('/chat');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
}]);
