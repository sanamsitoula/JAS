(function () {

    'use strict';

    myApp
    .controller('groupCtrl', groupCtrl);

    groupCtrl.$inject = ['$scope', '$location', 'groupService'];

    function groupCtrl($scope, $location, groupService) {
        /* jshint validthis:true */
        $scope.group = {};
       // $scope.CreateStudent = {};
        getGroupDetails();
        function getGroupDetails() {

            groupService.sendGroup().then(function (data) {
                $scope.result = data;  //data is passed to UI

            })
        };





        $scope.add = function (model) {


            groupService.AddGroup(model).then(function (data) {  //addNotices is passed to noticeservices.
                if (data) {
                    $.notify({
                        title: "",
                        message: "Group Successfully Added!",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    $scope.g = {};
                    getGroupDetails();
                    $("#myModal2").modal('hide');
                }

            })


        };



        $scope.getGroupById = function (id) {


            groupService.getGroupById(id).then(function (data) {

                if (data != null) {
                    $scope.g = data;  //data is passed to UI
                    debugger;
                }

            })
        }




        $scope.editGroup = function (model) {

            groupService.updateGroup(model).then(function (data) {
                if (data) {
                    $.notify({
                        title: "",
                        message: "Updated Successfully !",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getGroupDetails();
                    $("#myModal").modal('hide');
                }

            })
        };



        $scope.DeleteGroup = function (id) {
            var result = confirm("Are you sure want to delete?");
            if (result) {
               groupService.DeleteGroup(id).then(function (data) {
                    if (data) {
                        $.notify({
                            title: "",
                            message: "Group Successfully Deleted!",
                            icon: 'fa fa-check'
                        }, {
                            type: "info"
                        });
                        getGroupDetails();
                        $("#myModal2").modal('hide');
                    }
                })
            }
        };






    }

})();