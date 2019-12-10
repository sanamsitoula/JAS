
(function () {
    'use strict';

    myApp.factory('reportService', reportService);

    reportService.$inject = ['$http', 'serviceBasePath', '$q'];

    function reportService($http, serviceBasePath, $q) {
        var fac = {};
        


        fac.sendLedgerReprt = function (model) {
            
            var config = {
                headers: { "Content-Type": "application/json" }
            };
           
            if (model!= null) {
              
               //  var dateAsString = $filter('date')(model.SearchFrom, "yyyy-MM-dd");

                var data = {
                    SearchFrom: model.SearchFrom,
                SearchTo :model.SearchTo
                }
                
                
                var deferred = $q.defer();
                $http.post(serviceBasePath + '/api/report/getGLdetails', data, config).success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    console.log(err);
                    deferred.reject(err);
                }); 
                return deferred.promise;
            }
            else {
                var deferred = $q.defer();
                $http.post(serviceBasePath + '/api/report/getGLdetails', config).success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    console.log(err);
                    deferred.reject(err);
                }); 
                return deferred.promise;

            }
           

        }

       

        return fac;

    }
})();
