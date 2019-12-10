(function () {
    'use strict';
    myApp.controller('RolesCtrl', roleController);

    roleController.$inject = ['$scope', 'dataService'];

    function roleController($scope, dataService) {
        getDetails();
        function Edit(id) {


            console.log(id)
            dataService.getUserById(id).then(function (data) {
                $scope.User = data;
            })
        };


        function getDetails() {
            dataService.getUserDetails().then(function (data) {
                $scope.UserDetailsData = data;

            })
        };
        //$scope.update = function (model) {

        //    //   model.DateOfBirth = (model.DateOfBirth);
        //    console.log(model);
        //    dataService.UpdateUser(model).then(function (data) {
        //        alert()
        //        $scope.data = data;
        //    })


        //};

    };




})();