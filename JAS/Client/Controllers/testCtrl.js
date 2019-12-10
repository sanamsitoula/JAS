﻿app
  .controller('testCtrl', function ($scope) {
      $scope.data = {
          labels: ['16 Jan', '16 Feb', '16 Mar',
          '16 Apr', '16 May', '16 Jun', '16 Jul'],
          datasets: [
            {
                label: "A",
                backgroundColor: 'rgba(255, 99, 132, 1)',
                borderColor: 'rgba(255,99,132,1)',
                data: [60, 90, 120, 60, 90, 120, 60]
            },
            {
                label: "B",
                backgroundColor: 'rgba(75, 192, 192, 1)',
                borderColor: 'rgba(75, 192, 192, 1)',
                data: [40, 60, 80, 40, 60, 80, 40]
            },
             {
                 label: "C",
                 backgroundColor: 'rgba(255, 206, 86, 1)',
                 borderColor: 'rgba(255, 206, 86, 1)',
                 data: [20, 30, 40, 20, 30, 40, 20]
             }

          ]
      };

      $scope.options = {
          scales: {
              xAxes: [{
                  stacked: true
              }],
              yAxes: [{
                  stacked: true
              }]
          },
          legend: {
              display: true,
              labels: {
                  fontColor: 'rgb(255, 99, 132)'
              }
          },
          title: {
              display: true,
              text: 'Custom Chart Title'
          }

          // Chart.js options can go here.
      };
  });