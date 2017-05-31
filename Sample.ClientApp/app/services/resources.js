"use strict";
myApp.service('resourceService', ['myHttpService', function (_httpService) {

    var resService = {
        addResource: _addResource,
        getResources: _getResources
    };

    return resService;

    function _getResources(projectId, cb) {
        var url = '/api/resources/' + projectId;
        _httpService.get(url, cb);
    }

    function _addResource(resource, cb) {
        var url = '/api/resource';
        _httpService.post(url, resource, cb);
    }

}]);