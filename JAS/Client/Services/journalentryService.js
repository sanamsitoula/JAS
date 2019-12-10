
(function () {
    'use strict';

    myApp.factory('journalentryService', journalentryService);

    journalentryService.$inject = ['$http', 'serviceBasePath', '$q'];

    function journalentryService($http, serviceBasePath, $q) {
        var fac = {};
        


        fac.sendJournalEntry = function (model) {
         
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
                $http.post(serviceBasePath + '/api/journal/getjournaldetails',data,config).success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    console.log(err);
                    deferred.reject(err);
                }); 
                return deferred.promise;
            }
            else {
                var deferred = $q.defer();
                $http.post(serviceBasePath + '/api/journal/getjournaldetails', config).success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    console.log(err);
                    deferred.reject(err);
                }); 
                return deferred.promise;

            }
           

        }

   
      
      

        fac.AddJournalEntry = function (model) {
          

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
            $http.post(serviceBasePath + '/api/journal/addjournal', model, config).success(function (response) {
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
