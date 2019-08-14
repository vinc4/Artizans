app.controller('indexController', function ($scope, accountService) {

    $scope.login = function ()
    {


        var toSend = {
            username: $scope.modelLogin.username,
            password: $scope.modelLogin.password,
        }

        accountService.login(toSend).then(function (results) {
            if (results.data.loginSuccess) {
                $rootScope.loggedInUser = results.data.user;
            }
            else {

            }
        }, function (err) {
                console.log('error: ', err);
                
           // Bootstrap.alert("Login Failed!")
        });
    }

    $scope.Register = function ()
    {
        var toSend = {
            email: $scope.modelObjReg.email,
            password: $scope.modelObjReg.password,
            mobileNo: $scope.modelObjReg.mobilenumber,
            isCvUploaded:0
        }

        accountService.register(toSend).then(function (results) {
            if (results.data != "") {
                $rootScope.loggedInUser = results.data.user;
            }

        }, function (err) {
            console.log('error: ', err);

            // Bootstrap.alert("Login Failed!")
        });
    }
})