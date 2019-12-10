
(function () {
    'use strict';
    myApp.factory('accountService', accountService);

    accountService.$inject = ['$http', '$q', 'serviceBasePath', 'userService']; //to use services we have to inject

    function accountService($http, $q, serviceBasePath, userService) {
        var fac = {};
        fac.login = function (user) {
         //   debugger
            var obj = { 'username': user.user_name, 'password': user.password, 'grant_type': 'password' };
            Object.toparams = function ObjectsToParams(obj) {
                var p = [];
                for (var key in obj) {
                    p.push(key + '=' + encodeURIComponent(obj[key]));
                }
                return p.join('&');
            }
              // debugger
            var defer = $q.defer();
            $http({
                method: 'post',
                url: serviceBasePath + "/token",
                data: Object.toparams(obj),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                userService.SetCurrentUser(response.data);
                defer.resolve(response.data);



            }, function (error) {
                defer.reject(error.data);
            })
            return defer.promise;
        }

       
        fac.logout = function () {
          
            userService.CurrentUser = null;
            userService.SetCurrentUser(userService.CurrentUser);
        }

        fac.registerCustomer = function (credentials) {
            // debugger

            var data = {
                email: credentials.email,
                password: credentials.password,
                user_name: credentials.username

            };
            var defer = $q.defer();
            $http({
                method: 'post',
                url: serviceBasePath + "/api/customer/create",
                data: data,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
              
                defer.resolve(response.data);



            }, function (error) {
                defer.reject(error.data);
            })
            return defer.promise;

        }

        return fac;
    }
})();