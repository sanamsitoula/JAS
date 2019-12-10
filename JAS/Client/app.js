/// <reference path="Views/layouts/Dashboard.html" />
/// <reference path="Views/layouts/Dashboard.html" />
var myApp = angular.module("myApp", ["ui.router", "ui.bootstrap", "chart.js"]);
        myApp.config(function ($urlRouterProvider, $stateProvider) {


            $urlRouterProvider.otherwise('/home');


          
            $stateProvider


            .state('home', {
                url: '/home',
                templateUrl: '/Client/Views/Home.html',
                controller: 'itemCtrl'

            })
                     .state('auth', {
                         abstract: true,
                         views: {
                             '@': {
                                 templateUrl: '/Client/Views/layouts/Dashboard.html',
                                 controller : 'authorizeCtrl'
                             },
                         }
                     })

                 //.state('public', {
                 //    abstract: true,
                 //    views: {
                 //        '@': {
                 //            templateUrl: '/Client/Views/layouts/index.html'
                 //        },
                 //    }
                 //})


                    .state('contactus', {
                        url: '/contactus',
                        templateUrl: '/Client/Views/Contact.html',
                        controller: 'contactusCtrl'

                    })


                     .state('profile', {
                         url: '/profile',
                         templateUrl: '/Client/Views/UserProfileManagement.html',
                         controller: 'registerCtrl'

                     })


                     .state('confirmEmail', {
                         url: '/confirmEmail',
                         templateUrl: '/Client/Views/UserRegisterActivateAccount.html',
                         controller: 'registerCtrl'

                     })


                     .state('register', {
                         url: '/register',
                         templateUrl: '/Client/Views/Home.html',
                         controller: 'registerCtrl'

                     })


              


                .state('auth.groupes', {
                    url: '/groupes',
                    templateUrl: '/Client/Views/GroupManagement.html',
                    controller: 'groupCtrl',
                    controllerAs: 'groupCtrl'

                })

                 .state('auth.items', {
                     url: '/items',
                     templateUrl: '/Client/Views/ItemManagement.html',
                     controller: 'itemCtrl',
                     controllerAs: 'i'

                 })

                 .state('auth.purchases', {
                     url: '/purchases',
                     templateUrl: '/Client/Views/PurchaseManagement.html',
                     controller: 'purchaseCtrl',
                     controllerAs: 'purchaseCtrl'

                 })

                  .state('auth.addpurchases', {
                      url: '/addpurchases',
                      templateUrl: '/Client/Views/addPurchaseManagement.html',
                     controller: 'purchaseCtrl',
                      controllerAs: 'purchaseCtrl'

                  })

                  .state('auth.sales', {
                      url: '/sales',
                      templateUrl: '/Client/Views/SaleManagement.html',
                      controller: 'saleCtrl',
                      controllerAs: 'saleCtrl'

                  })

                  .state('auth.addsales', {
                      url: '/addsales',
                      templateUrl: '/Client/Views/addSaleManagement.html',
                      controller: 'saleCtrl',
                      controllerAs: 'saleCtrl'

                  })

             .state('auth.reports', {
                 url: '/reports',
                 templateUrl: '/Client/Views/ReportManagement.html',
                 controller: 'reportCtrl',
                 controllerAs: 'reportCtrl'

             })

            


                   .state('auth.gl', {
                       url: '/gl',
                       templateUrl: '/Client/Views/GLManagement.html',
                       controller: 'glCtrl',
                       controllerAs: 'glCtrl'

                   })

            
                    .state("auth.authorize", {
                        url: '/authorize',
                        templateUrl: '/Client/Views/authorize.html',
                        controller: 'authorizeCtrl'

                  
                    })

             .state("auth.journals", {
                 url: '/journals',
                 templateUrl: '/Client/Views/JournalEntryManagement.html',
                 controller: 'journalentryCtrl'


             })

             .state("auth.addjournals", {
                 url: '/addjournals',
                 templateUrl: '/Client/Views/addJournalEntryManagement.html',
                 controller: 'journalentryCtrl'


             })


                   

});

        myApp.factory('Excel', function ($window) {
            var uri = 'data:application/vnd.ms-excel;base64,',
                template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>',
                base64 = function (s) { return $window.btoa(unescape(encodeURIComponent(s))); },
                format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) };
            return {
                tableToExcel: function (tableId, worksheetName) {
                    var table = $(tableId),
                        ctx = { worksheet: worksheetName, table: table.html() },
                        href = uri + base64(format(template, ctx));
                    return href;
                }
            };
        });




        //myApp.directive('exportTable', function () {
        //    var link = function ($scope, elm, attr) {
        //        $scope.$on('export-pdf', function (e, d) {
        //            elm.tableExport({ type: 'pdf', escape: false });
        //        });
        //        $scope.$on('export-excel', function (e, d) {
        //            elm.tableExport({ type: 'excel', escape: false });
        //        });
        //        $scope.$on('export-doc', function (e, d) {
        //            elm.tableExport({ type: 'doc', escape: false });
        //        });
        //        $scope.$on('export-csv', function (e, d) {
        //            elm.tableExport({ type: 'csv', escape: false });
        //        });
        //    }
        //    return {
        //        restrict: 'C',
        //        link: link
        //    }
        //});





        myApp.constant('serviceBasePath', 'http://localhost:3523');


        //http interceptor
        myApp.config(['$httpProvider', function ($httpProvider) {
            //debugger
            var interceptor = function (userService, $q, $location) {
                return {
                    request: function (config) {
                        var currentUser = userService.GetCurrentUser();
                        if (currentUser != null) {
                            config.headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                        }
                        return config;
                    },
                    responseError: function (rejection) {
                        if (rejection.status === 401) {
                            $location.path('/login');
                            return $q.reject(rejection);
                        }
                        if (rejection.status === 403) {
                            $location.path('/unauthorized');
                            return $q.reject(rejection);
                        }
                        return $q.reject(rejection);
                    }

                }
            }
            var params = ['userService', '$q', '$location'];
            interceptor.$inject = params;
            $httpProvider.interceptors.push(interceptor);
        }]);