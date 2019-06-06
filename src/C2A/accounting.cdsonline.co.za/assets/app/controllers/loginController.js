'use strict';
app.controller('loginController', ['$rootScope', '$scope', '$location', 'authService', 'userProfileService', 'localStorageService', function ($rootScope, $scope, $location, authService, userProfileService, localStorageService) {

    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.message = "";

    $rootScope.companyName = "C2Accounting";

    $scope.login = function () {
        authService.login($scope.loginData)
        .then(function () {
            userProfileService.getUserProfile()
                .then(function (results) {
                    localStorageService.set('user', results.data);
                    if (localStorageService.get('user') && localStorageService.get('user') !== '') {
                        $rootScope.user = localStorageService.get('user');
                        $rootScope.user.avatar = "data:image/png;base64," + $rootScope.user.avatar;
                        $rootScope.user.isAuth = authService.authentication.isAuth;
                        $rootScope.companyName = localStorageService.get('authorizationData').companyName;
                    }
                    $location.path('/dashboard');
            })
        });
        //authService.login($scope.loginData).then(function (response) { $location.path('/dashboard'); }, function (err) { $scope.message = err.error_description; });
    };

}]);