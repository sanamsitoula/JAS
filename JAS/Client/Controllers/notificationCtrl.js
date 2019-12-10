(function () {
    'use strict';
    myApp.controller('notificationController', notificationController);

    notificationController.$inject = ['$scope', 'accountService', '$location'];

    function notificationController($scope, accountService, $location) {
        $scope.logoutuser = function () {
            accountService.logout();
            $location.path('/login');
        }
    }
})();
