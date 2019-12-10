(function () {

    'use strict';

    myApp
    .controller('itemCtrl', itemCtrl);

    itemCtrl.$inject = ['$scope', '$location', 'itemService', 'groupService'];

    function itemCtrl($scope, $location, itemService, groupServicet) {
       
        $scope.cartitemcount = 0;

        $scope.item = {};
        // Variables
        $scope.Message = "";
        $scope.FileInvalidMessage = "";
        $scope.SelectedFileForUpload = null;

    

        $scope.IsFormSubmitted = false;
        $scope.IsFileValid = false;
        $scope.IsFormValid = false;

        //Form Validation
        $scope.$watch("g.$valid", function (isValid) {
            $scope.IsFormValid = isValid;
        });

        // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
        // ------------------------------------------------------------------------------------
        //File Validation
        $scope.ChechFileValid = function (file) {
            var isValid = false;
            if ($scope.SelectedFileForUpload != null) {
                if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                    $scope.FileInvalidMessage = "";
                    isValid = true;
                }
                else {
                    $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
                }
            }
            else {
                $scope.FileInvalidMessage = "Image required!";
            }
            $scope.IsFileValid = isValid;
        };


        //File Select event 
        $scope.selectFileforUpload = function (file) {
            $scope.SelectedFileForUpload = file[0];
        }
      

      


        //Clear form 
        function ClearForm() {
            $scope.g = {};
            //as 2 way binding not support for File input Type so we have to clear in this way
            //you can select based on your requirement
            angular.forEach(angular.element("input[type='file']"), function (inputElem) {
                angular.element(inputElem).val(null);
            });
 
        
            $scope.IsFormSubmitted = false;
        }


       





      
     // $scope.addchartlist = [];
        $scope
        .addcartarray = function (model) {

            var data = {

                item_name: model.item_name, item_id: model.item_id,
                item_quantity: model.item_quantity, price: model.item_sp, item_description: model.item_description,
                photo: model.photo
            }

            if ($scope.addchartlist == null) {
                $scope.addchartlist = [];
                $scope.addchartlist.push(data);
                //cartitemcount = addchartlist.length;
            } else {
                $scope.addchartlist.push(data);

              
            }





        }



        $scope.deletecartitemfromlist = function (index) {

            $scope.addchartlist.splice(index, 1);

        }




        getItemDetails();
        function getItemDetails() {

            itemService.sendItem().then(function (data) {
                $scope.itemresult = data;  //data is passed to UI

            })
        };

        function getGroupDropDownDetails() {

            groupService.sendGroup().then(function (data) {
                $scope.groupresult = data;  //data is passed to UI

            })
        };

       
        getGroupDropDownDetails();


    
    
        $scope.addItemCTRL = function (model) {
            $scope.quant_i = 1;
            $scope.IsFormSubmitted = true;
            $scope.Message = "";
            $scope.ChechFileValid($scope.SelectedFileForUpload);
            if ($scope.IsFormValid && $scope.IsFileValid) {

                itemService.AddItem($scope.SelectedFileForUpload,model).then(function (d) {
                 //   alert(d.Message);
                   +
                 // debugger
                    getItemDetails();
                    ClearForm();
                    $("#myModal2").modal('hide');
                }, function (e) {
                  //  alert(e);
                });
            }
            else {
                $scope.Message = "All the fields are required.";
            }
        };


        $scope.addItemcheckoutCTRL = function (model) {

            checkoutService.ChooseCheckOutService(model).then(function (d) {
                $location.path('/CheckoutPage');
            })
        };
          



        $scope.getItemById = function (id) {
            debugger

            itemService.getItemById(id).then(function (data) {
                debugger
                if (data != null) {
                    $scope.g = data;
                    $scope.groupname = data.group_name;

                    //data is passed to UI
                    //debugger;
                }

            })
        }




        $scope.editItem = function (model) {

            itemService.updateItem(model).then(function (data) {
                if (data) {
                    $.notify({
                        title: "",
                        message: "Updated Successfully !",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getItemDetails();
                    $("#myModal").modal('hide');
                }

            })
        };



        $scope.DeleteItem = function (id) {
            var result = confirm("Are you sure want to delete?");
            if (result) {
                debugger
                itemService.DeleteItem(id).then(function (data) {
                    if (data) {
                        $.notify({
                            title: "",
                            message: "Item Successfully Deleted!",
                            icon: 'fa fa-check'
                        }, {
                            type: "info"
                        });
                        getItemDetails();
                        $("#myModal2").modal('hide');
                    }
                })
            }
        };




        //function init() {
        //    indexedDBDataSvc.open().then(function () {
        //        vm.refreshList();
        //    });
        //}

        //init();



    }

})();