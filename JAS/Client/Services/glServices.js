
(function () {
    'use strict';

    myApp.factory('glService', glService);

    glService.$inject = ['$http', 'serviceBasePath', '$q'];

    function glService($http, serviceBasePath, $q) {
        var fac = {};
        fac.sendGL = function () {
            return $http.get(serviceBasePath + '/api/gl/getgldetails').then(function (response) {
                return response.data;
            })

        }

        fac.AddGL = function (model) {


            var config = {
                headers: { 'Content-Type': 'application/json' }

            };

            var data = {
                gl_name: model.gl_name,
                gl_code: model.gl_code,
                gl_master_type: model.gl_master_type
                
               
            }

            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/gl/addgl', data, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

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

        //fac.updateGroup = function (model) {
        //    var config = {
        //        headers: { 'Content-Type': 'application/json' }
        //    };


        //    var deferred = $q.defer();
        //    $http.post(serviceBasePath + '/api/group/updategroup', model, config).success(function (response) {
        //        deferred.resolve(response);
        //    }).error(function (err) {
        //        console.log(err);
        //        deferred.reject(err);
        //    });
        //    return deferred.promise;

        //}


        //fac.DeleteGroup = function (id) {

        //    var config = {
        //        headers: { 'Content-Type': 'application/json' }
        //    };
        //    var deferred = $q.defer();
        //    $http.post(serviceBasePath + '/api/group/DeleteGroup/', id, config).success(function (response) {
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
