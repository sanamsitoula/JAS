(function () {
    'use strict';
    myApp.controller('loginCtrl', loginController);

    loginController.$inject = ['$scope', 'accountService', '$location'];

    function loginController($scope, accountService, $location) {
       // debugger
        $scope.account = {
            user_name: '',
            password: ''
        }

        $scope.UserloginFunction = function () {
            $location.path('/login');
        }

       

        $scope.message = "";
        $scope.login = function () {
           // debugger
            accountService.login($scope.account).then(function (data) {
                //$.notify({
                //    title: "",
                //    message: " Login Success!",
                //    icon: 'fa fa-check'
                //}, {
                //    type: "info"
                //});
         
           $location.path('/authorize');
          // $location.path('/profile');

            }, function (error) { 
                $.notify({
                    title: "",
                    message: " Login Failed!loginCTRL",
                    icon: 'fa fa-check'
                }, {
                    type: "danger"
                });
            })
        }

    

        //$scope.registerpage = function () {
        //    $location.path('/register');
        //};
    }
})();

