'use strict';
app.controller('previewController',
    function ($rootScope, $scope, $location, $http, $sce, $sceDelegate, $timeout, ngAuthSettings, $stateParams) {


        var serviceBase = ngAuthSettings.apiResourceBaseUri;
        $scope.documentId = $stateParams.documentId;
        $scope.reportId = $stateParams.reportId;

        $scope.pdfName = '';
        var url = serviceBase + 'api/report?documentId=' + $scope.documentId + '&reportId=' + $scope.reportId;


        var req = {
            method: 'POST',
            url: url,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            responseType: 'arraybuffer',
        }

        $http(req).then(function (response) {
            var file = new Blob([response.data], { type: 'application/pdf' });
            var fileURL = URL.createObjectURL(file);
            $scope.content = $sce.trustAsResourceUrl(fileURL);
        });

    });