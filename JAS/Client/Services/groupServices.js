
(function () {
    'use strict';

    myApp.factory('groupService', groupService);

    groupService.$inject = ['$http', 'serviceBasePath', '$q'];

    function groupService($http, serviceBasePath, $q) {
        var fac = {};
        fac.sendGroup = function () {
            return $http.get(serviceBasePath + '/api/group/getgroupdetails').then(function (response) {
                return response.data;
            })

        }

        fac.AddGroup = function (model) {


            var config = {
                headers: { 'Content-Type': 'application/json' }
            };

            var data = {
                group_name: model.group_name,
                group_code: model.group_code
               /// user_id: model.user_id,
               // created_on:model.created_on


            }

            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/group/addgroup', data, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }


        fac.getGroupById = function (id) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };

            var deferred = $q.defer();
            $http.get(serviceBasePath + '/api/group/GetGroupById', { params: { id: id } }, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }

        fac.updateGroup = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
           

            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/group/updategroup', model, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }


        fac.DeleteGroup = function (id) {

            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/group/DeleteGroup/', id, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }


        return fac;

    }
})();
