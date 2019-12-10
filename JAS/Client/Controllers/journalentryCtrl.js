(function () {

    'use strict';

    myApp
    .controller('journalentryCtrl', journalentryCtrl);

    journalentryCtrl.$inject = ['$scope', '$location', 'journalentryService', 'glService'];

    function journalentryCtrl($scope, $location, journalentryService, glService) {
     
        $scope.currentPage = 1;
        $scope.itemsq = 5;
        $scope.item = {};
        $scope.sanam = 'sanam';
        // $scope.CreateStudent = {};
        getJournalDetails();
        function getJournalDetails(model) {
            $scope.s = {};
            $scope.filterfromdate = {};
            journalentryService.sendJournalEntry().then(function (data) {
                $scope.journalresult = data;  //data is passed to UI

            })
        };

      
       // filterfromdate();


     $scope.filterfromdate=function(m) {
           
            journalentryService.sendJournalEntry(m).then(function (data) {
                $scope.journalresult = data;
                //$scope.journalresult = data;
             
                $scope.s = {};
            })
        };

        function getGLDropDownDetails() {

            glService.sendGL().then(function (data) {
                $scope.glresult = data;  //data is passed to UI

            })
        };

       
        getGLDropDownDetails();

        $scope.addjournallist = [];

        $scope
        .addjournalarray = function (model) {

            var data = {
                gl_name: model.gls.gl_name, gl_id: model.gls.gl_id,
                journal_name: model.journal_name, Debit_Amount: model.Debit_Amount,
                Credit_Amount: model.Credit_Amount,
                journal_date: model.journal_date,
                transaction_descriptions: model.transaction_descriptions,
                transactions_type: model.transactions_type
            }
         

            $scope.addjournallist.push(data);
            $scope.checkeitherDebitandCreditAmountMatches($scope.addjournallist);
           

        }

        $scope.checkeitherDebitandCreditAmountMatches = function (model) {
            $scope.HideSaveBtn = false;
            $scope.TotaldebitAmount = 0;
            $scope.TotalcreditAmount = 0;
            $.each(model, function (i, e) {
                debugger
                $scope.TotaldebitAmount += e.Debit_Amount;
                $scope.TotalcreditAmount += e.Credit_Amount;

            })
            if ($scope.TotaldebitAmount != $scope.TotalcreditAmount) {
                $scope.HideSaveBtn = true;
                alert("Debit and Credit Amount are not equal")
            }
        }

        $scope.deletejournalentryfromlist = function (index) {
           
            $scope.addjournallist.splice(index, 1);
            
        }

        $scope.add = function (model) {
           // debugger

            journalentryService.AddJournalEntry(model).then(function (data) {  //addNotices is passed to noticeservices.
                if (data) {
                    $.notify({
                        title: "",
                        message: "Successfully Added!",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    $scope.g = {};
                    $scope.addjournallist = {};
                   // getPurchaseDetails();
                   // $("#myModal2").modal('hide');
                }

            })


        };

        $scope.printDiv = function (divName) {
         
            var printContents = document.getElementById(divName).innerHTML;
            var popupWin = window.open('', '_blank', 'width=100%,height=500,scrollbars=no,toolbar=no,location=no,status=no,titlebar=no');
            popupWin.document.open();
            
            popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="printstyle.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
            popupWin.document.close();
        }



     












    }

})();