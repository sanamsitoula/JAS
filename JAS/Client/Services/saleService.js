
(function () {
    'use strict';

    myApp.factory('saleService', saleService);

    saleService.$inject = ['$http', 'serviceBasePath', '$q'];

    function saleService($http, serviceBasePath, $q) {
        var fac = {};
        fac.sendSale = function () {
            return $http.get(serviceBasePath + '/api/sale/getsaledetails').then(function (response) {
                return response.data;
            })

        }

        fac.getTopItemSale = function () {
               return $http.get(serviceBasePath + '/api/sale/getChartTopItemSale').then(function (response) {
                   
                return response.data;
            })
        }



        fac.AddSale = function (model) {
            debugger

            var config = {
                headers: { "Content-Type": "application/json" }
            };

            //var data = {

            //    item_name: model.item_name,
            //    item_id: model.items.item_id,
            //    purchase_date: model.purchase_date,
            //    purchase_name: model.purchase_name,
            //    quantity: model.quantity,
            //    price:model.price

            //}
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/sale/addsale', model, config).success(function (response) {
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
