app.factory('accountService', function ($http) {
    var accountServiceInstance = {};
    var serviceBase = app.constant.serviceBase;


    var _login = function (obj) {
        return $http.post('http://localhost:57666/api/Users/LoginUser/' + obj.username + '/' + obj.password);
    };

    var _register = function (obj) {
        return $http.post('http://localhost:57666/api/Users/', angular.toJson(obj));
    };

    accountServiceInstance.login = _login;
    accountServiceInstance.register = _register;
    return accountServiceInstance;
});