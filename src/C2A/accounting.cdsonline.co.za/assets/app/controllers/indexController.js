'use strict';
app.controller('indexController', ['$rootScope', '$scope', '$location', 'authService', 'localStorageService', function ($rootScope, $scope, $location, authService, localStorageService) {

    if (localStorageService.get('user') && localStorageService.get('user') !== '') {
        $rootScope.user = localStorageService.get('user');
        $rootScope.user.avatar = "data:image/png;base64," + $rootScope.user.avatar;
        $rootScope.user.isAuth = authService.authentication.isAuth;
        $rootScope.companyName = localStorageService.get('authorizationData').companyName;
    }
    else {
        $location.path('/login');
    }

    $scope.showlinks = function () {
        $scope.userLinks = !$scope.userLinks;
    }


}]);