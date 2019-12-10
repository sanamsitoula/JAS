(function () {
    'use strict';
    myApp.factory('dataService', dataService);

    dataService.$inject = ['$http', 'serviceBasePath', '$q'];

    function dataService($http, serviceBasePath, $q) {
        var fac = {};
        fac.GetAnonymousData = function () {
            return $http.get(serviceBasePath + '/api/data/forall').then(function (response) {
                return response.data;
            })
        }

        fac.GetAuthenticateData = function () {
            return $http.get(serviceBasePath + '/api/data/authenticate').then(function (response) {
                return response.data;
            })
        }

        fac.GetAuthorizeData = function () {
            return $http.get(serviceBasePath + '/api/data/authorize').then(function (response) {
                return response.data;
            })
        }

        fac.GetCustomerData = function () {
            return $http.get(serviceBasePath + '/api/data/customerdata').then(function (response) {
                return response.data;
            })
        }


        //for the customer role we are doing this 
        fac.CreateUser = function (model) {
            //console.log(model)

            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/user/create', model, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }

        fac.getUserDetails = function () {

            return $http.get(serviceBasePath + '/api/role/getUserRoles').then(function (response) {
                return response.data;
            })


        }

        fac.getActivationCodeUser = function (activationcode) {

            return $http.get(serviceBasePath + '/api/user/confirmemail/', { params: { activationcode: activationcode } }).then(function (response) {
                return response.data;
            })

        }


        //fac.getItemById = function (id) {
        //    var config = {
        //        headers: { 'Content-Type': 'application/json' }
        //    };

        //    var deferred = $q.defer();
        //    $http.get(serviceBasePath + '/api/item/GetItemById', { params: { id: id } }, config).success(function (response) {
        //        deferred.resolve(response);
        //    }).error(function (err) {
        //        console.log(err);
        //        deferred.reject(err);
        //    });
        //    return deferred.promise;

        //}




        //fac.UpdateUser = function (model) {
        //    console.log(model)

        //    var config = {
        //        headers: { 'Content-Type': 'application/json' }
        //    };
        //    var deferred = $q.defer();
        //    $http.post(serviceBasePath + '/api/user/Update', model, config).success(function (response) {
        //        deferred.resolve(response);
        //    }).error(function (err) {
        //        console.log(err);
        //        deferred.reject(err);
        //    });
        //    return deferred.promise;
        //}
        return fac;

    }
})();


