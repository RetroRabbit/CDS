'use strict';
app.controller('documentListController', ['$http', '$rootScope', '$scope', 'userProfileService', 'localStorageService', 'ngAuthSettings', '$filter', '$location', '$state',
    function ($http, $rootScope, $scope, userProfileService, localStorageService, ngAuthSettings, $filter, $location, $state) {

        var serviceBase = ngAuthSettings.apiResourceBaseUri;

        var _getInvoices = function () {

            return $http.get(serviceBase + 'api/invoice').then(function (results) {
                return results;
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.

            });
        };

        $scope.invoices = [];

        _getInvoices().then(function (results) {

            $scope.invoices = results.data;

        }, function (error) {
            //alert(error.data.message);
        });

        $scope.SelectDocument = function (document) {
            var id = document.id;
            var searchURL = serviceBase + 'api/invoice?id=' + id;

            $http.get(searchURL).then(function (results) {
                $rootScope.document = results.data;
                //$location.path('/customer/invoice/new');
                $state.go('root.customer.invoice.new', { newDocument: 'false' });
            });
        };

    }]);