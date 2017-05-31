"use strict";
myApp.service('myHttpService', function ($http) {

    var _serviceBaseUrl = "http://localhost:64955",
        _timeOut = 60000,
        service = {
        "delete": _genericDelete,
        "get": _genericGet,
        "patch": _genericPatch,
        "post": _genericPost,
        "put": _genericPut
    };

    return service;

    // Public Methods

    function _genericDelete(url, cb) {
        var options = {
            method: "DELETE",
            url: _serviceBaseUrl + url,
            timeout: _timeOut
        };

        _genericHttp(options, cb);
    }

    function _genericGet(url, cb) {
        var options = {
            method: "GET",
            url: _serviceBaseUrl + url,
            timeout: _timeOut
        };

        _genericHttp(options, cb);
    }

    function _genericPatch(url, data, cb) {
        var options = {
            method: "PATCH",
            url: _serviceBaseUrl + url,
            data: data,
            timeout: _timeOut
        };

        _genericHttp(options, cb);
    }

    function _genericPost(url, data, cb) {
        var options = {
            method: "POST",
            url: _serviceBaseUrl + url,
            data: data,
            timeout: _timeOut
        };

        _genericHttp(options, cb);
    }

    function _genericPut(url, data, cb) {
        var options = {
            method: "PUT",
            url: _serviceBaseUrl + url,
            data: data,
            timeout: _timeOut
        };

        _genericHttp(options, cb);
    }

    function _genericHttp(options, cb) {
        $http(options).then(function cbSuccess(response) {
            if (response.status != 200) { cb("Error"); return; }
            cb(null, response.data);
        }, function cbError(response) {
            console.log("Error: " + response.data);
            cb(_getErrorDescription(response));
        });
    };

    function _getErrorDescription(response) {
        switch (response.status) {
            case 404:
                return "Requested API is not found... Please try again...";
            case 400:
                return "Bad request...";
            case 500:
                return "Internal server error...";
            default:
                return "Something is wrong... Please try later...";
        }
    }
});