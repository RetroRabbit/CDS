
var app = angular.module('c2aApp', ['ngRoute'])
	.config(function ($routeProvider, $locationProvider) {
		$routeProvider.when('/test', {templateUrl: '/templates/home.html', controller: 'indexViewModel' });
        //$routeProvider.otherwise({ redirectTo: '/' });
        
	});

app.controller("indexViewModel", function($scope, $http, $location) {
	$scope.headingCaption = "C2A - Complete Cloud Acounting";
});