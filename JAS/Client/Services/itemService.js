
(function () {
    'use strict';

    myApp.factory('itemService', itemService);

    itemService.$inject = ['$http', 'serviceBasePath', '$q'];

    function itemService($http, serviceBasePath, $q) {
        //var indexedDB = $window.indexedDB;
        //var db = null;
        //var lastIndex = 0;
        var fac = {};

        fac.sendItem = function () {
            return $http.get(serviceBasePath + '/api/item/getitemdetails').then(function (response) {
                return response.data;

               
            })

        }

        fac.AddItem = function (file,model) {


            var config = {
                withCredentials: true,
                headers: { "Content-Type": undefined},
                transformRequest: angular.identity
            };


        
            var fileInput = document.getElementById('file');
                // Use a regular expression to pull the file name only
              var fileName = fileInput.value.split(/(\\|\/)/g).pop();
                // Alert the file name (example)
               // alert(fileName);

               
                debugger
                var formData = new FormData();
         

          
            formData.append("file", file);
            formData.append("item_name", model.item_name);
            formData.append("item_code", model.item_code);
            formData.append("photo", fileName);
            formData.append("item_description", model.item_description);
            formData.append("group_id", model.groupes.group_id);
            formData.append("item_cp", model.item_cp);
            formData.append("item_sp", model.item_sp);
            formData.append("item_unit", model.item_unit);
            formData.append("item_quantity", model.item_quantity);


           
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/item/additem', formData, config).success(function (response) {

                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }

    


        fac.getItemById = function (id) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };

            var deferred = $q.defer();
            $http.get(serviceBasePath + '/api/item/GetItemById', { params: { id: id } }, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }

        fac.updateItem = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };


            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/item/updateitem', model, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }


        fac.DeleteItem = function (id) {

            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            //debugger
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/item/DeleteItem/', id, config).success(function (response) {
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
