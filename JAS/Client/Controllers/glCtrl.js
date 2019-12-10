(function () {

    'use strict';

    myApp
    .controller('glCtrl', glCtrl);

    glCtrl.$inject = ['$scope', '$location', 'glService','Excel', '$timeout'];

    function glCtrl($scope, $location, glService, Excel, $timeout) {
        /* jshint validthis:true */
        $scope.gl = {};
        // $scope.CreateStudent = {};
        getGLDetails();
        function getGLDetails() {

            glService.sendGL().then(function (data) {
                $scope.glresult = data;  //data is passed to UI

            })
        };

        //function getGroupDropDownDetails() {

        //    glService.sendGroup().then(function (data) {
        //        $scope.groupresult = data;  //data is passed to UI

        //    })
        //};

       
       // getGroupDropDownDetails();

        $scope.exportToExcel = function (tableId) { // ex: '#my-table'
            var exportHref = Excel.tableToExcel(tableId, 'GLExcel');
            $timeout(function () { location.href = exportHref; }, 100); // trigger download
        };

        //$scope.exportAction = function (option) {
        //    switch (option) {
        //        case 'pdf': $scope.$broadcast('export-pdf', {});
        //            break;
        //        //case 'excel': $scope.$broadcast('export-excel', {});
        //        //    break;
        //        //case 'doc': $scope.$broadcast('export-doc', {});
        //        //    break;
        //        //case 'csv': $scope.$broadcast('export-csv', {});
        //        //    break;
        //        default: console.log('no event caught');
        //    }
        //}





        $scope.add = function (model) {


            glService.AddGL(model).then(function (data) {  //addNotices is passed to noticeservices.
                if (data) {
                    $.notify({
                        title: "",
                        message: "Add Successfully Added!",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    $scope.gl = {};
                    getGLDetails();
                    $("#myModal2").modal('hide');
                }

            })


        };



        //$scope.getGLById = function (id) {


        //    glService.getGroupById(id).then(function (data) {

        //        if (data != null) {
        //            $scope.g = data;  //data is passed to UI
        //            debugger;
        //        }

        //    })
        //}




        //$scope.editGroup = function (model) {

        //    groupService.updateGroup(model).then(function (data) {
        //        if (data) {
        //            $.notify({
        //                title: "",
        //                message: "Updated Successfully !",
        //                icon: 'fa fa-check'
        //            }, {
        //                type: "info"
        //            });
        //            getGroupDetails();
        //            $("#myModal").modal('hide');
        //        }

        //    })
        //};



        //$scope.DeleteGroup = function (id) {
        //    var result = confirm("Are you sure want to delete?");
        //    if (result) {
        //        groupService.DeleteGroup(id).then(function (data) {
        //            if (data) {
        //                $.notify({
        //                    title: "",
        //                    message: "Group Successfully Deleted!",
        //                    icon: 'fa fa-check'
        //                }, {
        //                    type: "info"
        //                });
        //                getGroupDetails();
        //                $("#myModal2").modal('hide');
        //            }
        //        })
        //    }
        //};






    }

})();