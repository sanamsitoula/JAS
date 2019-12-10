
(function () {
    'use strict';
    myApp.controller('authorizeCtrl', authorizeCtrl);

    authorizeCtrl.$inject = ['$scope', 'dataService', 'purchaseService','saleService'];

    function authorizeCtrl($scope, dataService, purchaseService, saleService) {
        $scope.data = "";
        $scope.sanam = "test";

        $scope.colors = [
          {
              backgroundColor: "rgba(159,204,0, 0.2)",
              pointBackgroundColor: "rgba(159,204,0, 1)",
              pointHoverBackgroundColor: "rgba(159,204,0, 0.8)",
              borderColor: "rgba(159,204,0, 1)",
              pointBorderColor: '#fff',
              pointHoverBorderColor: "rgba(159,204,0, 1)"
          }, "rgba(250,109,33,0.5)", "#9a9a9a", "rgb(233,177,69)"
        ];


        dataService.GetAuthorizeData().then(function (data) {

          //  debugger
            $scope.data = data.details;
            $scope.name = data.name;
           var admin_name = data.role_name;

           if (data.role_name == 'admin') {
               $scope.admin_name = true;
           }
           else {
               $scope.customer_name = data.role_name;
              // $location.path('/profile');
           }


        })

        //dataService.GetCustomerData().then(function (data) {

        
        //    $scope.data = data.details;
        //    $scope.name = data.name;
        //    $scope.customer_name = data.role_name;


        //})

        $scope.logout = function () {
            // accountService.logout();

            alert("hello");

        }

        getPieChartData();
        getBarChartSalesData();
        getLinechartDataFromSalesAndPurchases();

        function getBarChartSalesData() {

            var arrData = new Array();
            var arrLabels = new Array();
            saleService.getTopItemSale().then(function (data) {


                $.map(data, function (item) {
                    arrData.push(item.quantity);
                    arrLabels.push(item.item_name);
                    //   debugger
                });


                $scope.dataQS = [];
                $scope.labelsNS = [];

                $scope.dataQS.push(arrData.slice(0));

                for (var i = 0; i < arrLabels.length; i++) {
                    $scope.labelsNS.push(arrLabels[i]);
                }

                // $scope.PieChartResult = data;
            })


        }

        function getPieChartData() {

            var arrData = new Array();
            var arrLabels = new Array();
            purchaseService.getTopItemPurchase().then(function (data) {
               

                $.map(data, function (item) {
                    arrData.push(item.quantity);
                    arrLabels.push(item.item_name);
                 //   debugger
                });
              

                $scope.dataQ = [];
                $scope.labelsN = [];

                $scope.dataQ.push(arrData.slice(0));

                for (var i = 0; i < arrLabels.length; i++) {
                    $scope.labelsN.push(arrLabels[i]);
                }

                // $scope.PieChartResult = data;
            })

           

        }

        function getLinechartDataFromSalesAndPurchases() {

            var arrData = [];
            var arrLabels = [];
        
            purchaseService.getItemSalePurchase().then(function (data) {
             

                $.map(data, function (item) {
                    arrData.push(item.purchase_quantity);
                    arrData.push(item.sale_quantity);
                    arrLabels.push(item.item_name);
                    //   debugger


                });
               

                $scope.dataSP = [];
                $scope.labelsSP = [];

                $scope.dataSP.push(arrData.slice(0));

                for (var i = 0; i < arrLabels.length; i++) {
                    $scope.labelsSP.push(arrLabels[i]);
                }

             
                $scope.datasetOverride = [{
                    yAxisID: 'y-axis-1'
                }, {
                    yAxisID: 'y-axis-2'
                }];

                $scope.options = {
                    scales: {
                        yAxes: [{
                            id: 'y-axis-1',
                            type: 'linear',
                            display: true,
                            position: 'left'
                        }, {
                            id: 'y-axis-2',
                            type: 'linear',
                            display: true,
                            position: 'right'
                        }]
                    }
                };

            })
        



        }
     
     


      


    }
   
  


})();

