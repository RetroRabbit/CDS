
var app = angular.module('c2aApp', ['ui.router', 'LocalStorageModule', 'angular-loading-bar', 'ui.bootstrap', 'ui.router.stateHelper', 'xeditable']);

app.config(function ($urlRouterProvider, stateHelperProvider) {

    stateHelperProvider
        .state({
            name: 'root',
            abstract: true,
            views: {
                "mainView": {
                    templateUrl: "/assets/app/views/home.html",
                    controller: "indexController"
                }
            },
            children: [
                {
                    name: 'dashboard',
                    url: '/dashboard',
                    views: {
                        "contentView": {
                            templateUrl: "/assets/app/views/dashboard.html",
                            controller: "dashboardController"
                        },
                        "topbarRightView": {
                            templateUrl: "/assets/app/views/dashboard.topbar.html",
                            controller: "dashboardController"
                        }
                    }
                },
                {
                    name: 'customer',
                    url: '/customer',
                    views: {
                        "contentView": {
                            template: "<ui-view />"
                        },
                        "topbarRightView": {
                            templateUrl: "/assets/app/views/customer/invoice.list.topbar.html"
                        }
                    },
                    children: [
                        {
                            name: 'invoice',
                            url: '/invoice',
                            template: "<ui-view />",
                            children: [
                                {
                                    name: 'list',
                                    url: '/list',
                                    views: {
                                        "": {
                                            templateUrl: "/assets/app/views/customer/invoice.list.html",
                                            controller: "documentListController"
                                        }
                                    }
                                },
                                {
                                    name: 'new',
                                    url: '/new:newDocument',
                                    templateUrl: "/assets/app/views/customer/invoice.new.html",
                                    controller: "invoiceController",
                                    params: {
                                        // here we define default value for foo
                                        // we also set squash to false, to force injecting
                                        // even the default value into url
                                        newDocument: {
                                            value: 'true',
                                            squash: false,
                                        },
                                        // this param is not part of url
                                        // it could be passed with $state.go or ui-sref 
                                        hiddenParam: 'YES',
                                    }
                                }
                            ]
                            
                        }
                    ]
                },
                {
                    name: 'report',
                    url: '/report:documentId?reportId',
                    views: {
                        "contentView": {
                            templateUrl: "/assets/app/views/report/preview.html",
                            controller: "previewController",
                            params: {
                                // here we define default value for foo
                                // we also set squash to false, to force injecting
                                // even the default value into url
                                documentId: {
                                    value: '0',
                                    squash: false,
                                },
                                reportId: {
                                    value: '1',
                                    squash: false,
                                }
                            }
                        }
                    }
                }
            ]
        })
    .state({
        name: 'login',
        url: "/login",
        views: {
            "mainView": {
                templateUrl: "/assets/app/views/login.html",
                controller: "loginController"
            }
        }
    })
    .state({
        name: 'signup',
        url: "/signup",
        views: {
            "mainView": {
                templateUrl: "/assets/app/views/signup.html",
                controller: "signupController"
            }
        }
    });



    $urlRouterProvider.otherwise("/dashboard");

});

var serviceBase = 'http://localhost:51641/';
var resourceBase = 'http://localhost:64515/';
//var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    apiResourceBaseUri: resourceBase,
    clientId: 'ngC2AAuthApp'
});

app.run(['authService', '$rootScope', '$state', 'localStorageService', '$location', 
function (authService, $rootScope, $state, localStorageService, $location) {
        authService.fillAuthData();

        $rootScope.logOut = function () {
            $rootScope.user = null;
            authService.logOut();
            $location.path('/login');
        }

        $rootScope.$on('$stateChangeStart', function (e, toState, toParams, fromState, fromParams) {

            var isLogin = toState.name === "login" || toState.name === "signup";

            if (isLogin) {

                return; // no need to redirect anymore 
            }

            if (localStorageService.get('authorizationData') && localStorageService.get('authorizationData') !== '') {
                var expired = new Date(localStorageService.get('authorizationData').expires);
                var dateNow = new Date();

                if (expired.getTime() < dateNow.getTime()) {
                    $rootScope.logOut();
                    e.preventDefault(); // stop current execution
                    $state.go('login'); // go to login
                }
            }
            else {
                $rootScope.logOut();
                e.preventDefault(); // stop current execution
                $state.go('login'); // go to login
            }

        });
    }]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});


