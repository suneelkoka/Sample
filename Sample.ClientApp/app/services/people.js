"use strict";
myApp.service('peopleService', ['myHttpService', function (_httpService) {

    var pplService = {
        addPerson: _addPerson,
        getPeople: _getPeople
    };

    return pplService;

    function _getPeople(cb) {
        var url = '/api/people';
        _httpService.get(url, cb);
    }

    function _addPerson(person, cb) {
        var url = '/api/people';
        _httpService.post(url, person, cb);
    }

}]);