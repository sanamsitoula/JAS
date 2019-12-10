(function () {
    'use strict';
    myApp.controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', 'dataService', '$location'];

    function registerCtrl($scope, dataService, $location) {
       
      
        var vm = this;
        vm.CreateUser = {};

      
        $scope.Create = function (model) {

            //   model.DateOfBirth = (model.DateOfBirth);
        //    console.log($scope.CreateUser);
            dataService.CreateUser(model).then(function (data) {
                alert(data)
                
                $scope.data = data;
            })


        }




        $scope.loginpage = function () {
            $location.path('/login');
        };

    }
})();
