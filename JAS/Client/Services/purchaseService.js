
(function () {
    'use strict';

    myApp.factory('purchaseService', purchaseService);

    purchaseService.$inject = ['$http', 'serviceBasePath', '$q'];

    function purchaseService($http, serviceBasePath, $q) {
        var fac = {};
        


        fac.sendPurchase = function (model) {
            debugger
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
                $http.post(serviceBasePath + '/api/item/getpurchasedetails',data,config).success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    console.log(err);
                    deferred.reject(err);
                }); debugger
                return deferred.promise;
            }
            else {
                var deferred = $q.defer();
                $http.post(serviceBasePath + '/api/item/getpurchasedetails', config).success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    console.log(err);
                    deferred.reject(err);
                }); debugger
                return deferred.promise;

            }
           

        }

        fac.getTopItemPurchase = function () {
               return $http.get(serviceBasePath + '/api/purchase/getChartTopItemPurchase').then(function (response) {
                   
                return response.data;
            })
        }

        fac.sendPurchase1 = function (model) {

            var config = {
                headers: { "Content-Type": "application/json" }
            };

            var data = {
                SearchFrom: model.SearchFrom,
                SearchTo:model.SearchTo
            }

            var deferred = $q.defer();
            $http.get(serviceBasePath + '/api/item/getpurchasedetails', data, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
          
        }


        fac.getItemSalePurchase = function () {

            return $http.get(serviceBasePath + '/api/purchase/getChartItemSalePurchase').then(function (response) {

                return response.data;
            })
        }

        fac.AddPurchase = function (model) {
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
            $http.post(serviceBasePath + '/api/purchase/addpurchase', model, config).success(function (response) {
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
