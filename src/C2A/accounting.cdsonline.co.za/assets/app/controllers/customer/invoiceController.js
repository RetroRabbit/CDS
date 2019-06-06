'use strict';
app.controller('invoiceController', ['$http', '$rootScope', '$scope', 'userProfileService', 'localStorageService', 'ngAuthSettings', '$filter', '$location', '$state', '$stateParams',
    function ($http, $rootScope, $scope, userProfileService, localStorageService, ngAuthSettings, $filter, $location, $state, $stateParams) {

        var serviceBase = ngAuthSettings.apiResourceBaseUri;
        $scope.newDocument = $stateParams.newDocument;

        $scope.SearchCompanyOnEnter = function (e) {

            if (e.keyCode == 13) {
                $scope.searchCompany();
            }
        }

        $scope.companyResults = [];

        $scope.searchCompany = function () {

            //if ($scope.document.company.name.length == 0)
            //    return;

            //var searchURL = serviceBase + 'api/company?type=1&searchValue=' + $scope.document.company.name;
            var searchURL = serviceBase + 'api/company?type=1&searchValue=';

            $http.get(searchURL).then(function (results) {
                $scope.companyResults = results.data;
            });

        };

        $scope.loadItems = function () {

            var searchURL = serviceBase + 'api/item?type=5';

            $http.get(searchURL).then(function (results) {
                $scope.itemResults = results.data;
            });

        };

        $scope.document = {};
        $scope.document.documentheader = {};
        $scope.document.documentheader.documentLines = [];
        $scope.document.datePosted = $filter('date')(new Date(), 'MM/dd/yyyy');

        //Delete line
        $scope.deleteLine = function (item) {
            var index = $scope.document.documentheader.documentLines.indexOf(item);
            $scope.document.documentheader.documentLines.splice(index, 1);
        };

        $scope.LineVat = function (item) {
            item.totalVat = parseFloat(((item.quantity * item.amount) * 0.14).toFixed(2));
            return $filter('currency')(item.totalVat, "R ");
        };

        $scope.LineTotal = function (item) {
            item.total = parseFloat(((item.quantity * item.amount) * 1.14).toFixed(2));
            return $filter('currency')(item.total, "R ");
        };

        $scope.documentTotalVat = function () {
            var total = 0;
            var line;
            for (line in $scope.document.documentheader.documentLines) {
                total += parseFloat((($scope.document.documentheader.documentLines[line].quantity * $scope.document.documentheader.documentLines[line].amount) * 0.14).toFixed(2));
            }

            return $filter('currency')(total, "R ");
        };

        $scope.documentTotal = function () {
            var total = 0;
            var line;
            for (line in $scope.document.documentheader.documentLines) {
                total += parseFloat((($scope.document.documentheader.documentLines[line].quantity * $scope.document.documentheader.documentLines[line].amount) * 1.14).toFixed(2));
            }
            
            return $filter('currency')(total, "R ");
        };
        
        // add line
        $scope.addLine = function () {
            $scope.document.documentheader.documentLines.push({
                lineOrder: $scope.document.documentheader.documentLines.length + 1,
                itemId: 0,
                description: '',
                quantity: 1,
                amount: null,
                totalVat: null,
                total: null,
                isNew: true
            });
        };

        $scope.saveDocument = function () {
            var req = {
                method: 'POST',
                url: serviceBase + 'api/invoice',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                data: "=" + JSON.stringify($scope.document),
            }

            $http(req).then(function (response) {
                $location.path('/customer/invoice/list');
            });
        };

        $scope.selectCompany = function () {
            var id = $scope.document.companyId;
            var searchURL = serviceBase + 'api/company?id=' + id;

            $http.get(searchURL).then(function (results) {
                $scope.document.billingAddressLine1 = results.data.billingAddressLine1;
                $scope.document.billingAddressLine2 = results.data.billingAddressLine2;
                $scope.document.billingAddressLine3 = results.data.billingAddressLine3;
                $scope.document.referenceShort1 = results.data.referenceShort1;
                $scope.document.referenceShort2 = results.data.referenceShort2;
                //$scope.companyResults = results.data;
            });
        };

        $scope.openDocument = function () {
            if ($rootScope.document != undefined) {
                $scope.document = $rootScope.document;
                $scope.document.datePosted = $filter('date')($scope.document.datePosted, 'MM/dd/yyyy');
                $scope.readOnly = true;
            }
            if ($scope.newDocument == "true") {
                $scope.document = {};
                $scope.document.documentheader = {};
                $scope.document.documentheader.documentLines = [];
                $scope.document.datePosted = $filter('date')(new Date(), 'MM/dd/yyyy');
                $scope.readOnly = false;
                $rootScope.document = null;
            }
        };

        $scope.printDocument = function () {
            $state.go('root.report', { documentId: $scope.document.id, reportId: '17' });
        }

        $scope.$on('$stateChangeSuccess', function () {
            $scope.searchCompany();
            $scope.loadItems();
            $scope.openDocument();
            
            if ($scope.newDocument == "true") {
                //$state.go($state.current, {newDocument: "false"}, { reload: true });
            }
        });
    }]);