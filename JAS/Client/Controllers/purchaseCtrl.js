(function () {

    'use strict';

    myApp
    .controller('purchaseCtrl', purchaseCtrl);

    purchaseCtrl.$inject = ['$scope', '$location', 'purchaseService', 'itemService'];

    function purchaseCtrl($scope, $location, purchaseService, itemService) {
     
        $scope.currentPage = 1;
        $scope.itemsq = 5;
        $scope.item = {};
        $scope.sanam = 'sanam';
        // $scope.CreateStudent = {};
        getPurchaseDetails();
        function getPurchaseDetails(model) {
            $scope.s = {};
            $scope.filterfromdate = {};
            purchaseService.sendPurchase().then(function (data) {
                $scope.purchaseresult = data;  //data is passed to UI

            })
        };

      
       // filterfromdate();


     $scope.filterfromdate=function(m) {
            debugger
            purchaseService.sendPurchase(m).then(function (data) {
                $scope.purchaseresult = data;
                //$scope.purchaseresult = data;
             
                $scope.s = {};
            })
        };

        function getItemDropDownDetails() {

            itemService.sendItem().then(function (data) {
                $scope.itemresult = data;  //data is passed to UI

            })
        };

       
        getItemDropDownDetails();

        $scope.addpurchaselist = [];

        $scope
        .addpurchasesarray = function (model) {

            var data = {
                item_name: model.items.item_name, item_id: model.items.item_id,
                quantity: model.quantity, price: model.price, purchase_name: model.purchase_name,
                purchase_date: model.purchase_date
            }
            $scope.addpurchaselist = [];


            $scope.addpurchaselist.push(data);
        }


        $scope.deletepurchaseitemfromlist = function (index) {
           
            $scope.addpurchaselist.splice(index, 1);
            
        }

        $scope.add = function (model) {
           // debugger

            purchaseService.AddPurchase(model).then(function (data) {  //addNotices is passed to noticeservices.
                if (data) {
                    $.notify({
                        title: "",
                        message: "Successfully Added!",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    $scope.g = {};
                    $scope.addpurchaselist = {};
                   // getPurchaseDetails();
                   // $("#myModal2").modal('hide');
                }

            })


        };

        $scope.printDiv = function (divName) {
            debugger
            var printContents = document.getElementById(divName).innerHTML;
            var popupWin = window.open('', '_blank', 'width=100%,height=500,scrollbars=no,toolbar=no,location=no,status=no,titlebar=no');
            popupWin.document.open();
            
            popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="printstyle.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
            popupWin.document.close();
        }



        //$scope.getGroupById = function (id) {


        //    groupService.getGroupById(id).then(function (data) {

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