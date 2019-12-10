(function () {

    'use strict';

    myApp
    .controller('reportCtrl', reportCtrl);

    reportCtrl.$inject = ['$scope', '$location', 'reportService'];

    function reportCtrl($scope, $location, reportService) {
     
        $scope.currentPage = 1;
        $scope.itemsq = 5;
        $scope.item = {};
        $scope.sanam = 'sanam';
        // $scope.CreateStudent = {};
        getGLDetails();
        function getGLDetails(model) {
            $scope.s = {};
            $scope.filterfromdate = {};

            $scope.TotaldebitAmount = 0;
            $scope.TotalcreditAmount = 0;

            debugger;
            reportService.sendLedgerReprt().then(function (data) {
                $scope.purchaseresult = data;  //data is passed to UI
                $.each($scope.purchaseresult, function (i, e) {
                    $scope.TotaldebitAmount += e.Debit_Amount;
                    $scope.TotalcreditAmount += e.Credit_Amount;

                })
            })
        };

      
       // filterfromdate();


     $scope.filterfromdate=function(m) {
            reportService.sendLedgerReprt(m).then(function (data) {
                $scope.purchaseresult = data;

              
                //$scope.purchaseresult = data;

             
                $scope.s = {};
            })
        };

        //function getItemDropDownDetails() {

        //    reportService.sendItem().then(function (data) {
        //        $scope.itemresult = data;  //data is passed to UI

        //    })
        //};

       
       // getItemDropDownDetails();

      

     


        $scope.printDiv = function (divName) {
            debugger
            var printContents = document.getElementById(divName).innerHTML;
            var popupWin = window.open('', '_blank', 'width=100%,height=500,scrollbars=no,toolbar=no,location=no,status=no,titlebar=no');
            popupWin.document.open();
            
            popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="printstyle.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
            popupWin.document.close();
        }



       




       





    }

})();