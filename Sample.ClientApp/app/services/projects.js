"use strict";
myApp.service('projectsService', ['myHttpService', function (_httpService) {

    var prjService = {
        addProject: _addProject,
        getProjects: _getProjects
    };

    return prjService;

    function _getProjects(cb) {
        var url = '/api/project';
        _httpService.get(url, cb);
    }

    function _addProject(project, cb) {
        var url = '/api/project';
        _httpService.post(url, project, cb);
    }

}]);