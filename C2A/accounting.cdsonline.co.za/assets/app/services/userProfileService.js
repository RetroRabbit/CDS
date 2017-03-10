'use strict';
app.factory('userProfileService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiResourceBaseUri;

    var userProfileServiceFactory = {};

    var _getUserProfile = function () {
        return $http.get(serviceBase + 'api/user').then(function (results) {
            return results;
        });
    };

    userProfileServiceFactory.getUserProfile = _getUserProfile;

    return userProfileServiceFactory;

}]);