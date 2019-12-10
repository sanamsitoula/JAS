
(function () {
    'use strict';
    myApp.controller('userProfileCtrl', userProfileCtrl);

    userProfileCtrl.$inject = ['$scope', 'dataService', 'purchaseService', 'saleService'];

    function userProfileCtrl($scope, dataService, purchaseService, saleService) {
        $scope.data = "";
        $scope.sanam = "test";

   

        dataService.GetCustomerData().then(function (data) {

            $scope.data = data.details;
            $scope.name = data.name;


        })
       
      
        



        }
     
     


      


  


})();

