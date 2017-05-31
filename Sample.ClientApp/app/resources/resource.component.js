(function () {
    "use strict";

    function resourceController(_resourceService, _projectsService, _peopleService,) {
        var ctrl = this;
        ctrl.errorMsg = '';
        ctrl.infoMsg = '';

        ctrl.selectedProject = '';
        ctrl.projects = [];
        ctrl.resources = [];
        ctrl.availableResources = [];
        ctrl.projectResources = [];

        ctrl.submit = function () {
            ctrl.newResource.projectId = ctrl.selectedProject.id;
            _saveResource();
        }

        ctrl.getResources = function () {
            _reset();
            _getProjectResources();
        }

        ctrl.resourceChange = function () {
            ctrl.errorMsg = '';
            ctrl.infoMsg = '';
        }

        function _reset() {
            ctrl.availableResources = [];
            ctrl.projectResources = [];
            ctrl.newResource = _getResourceObj();
            ctrl.errorMsg = '';
            ctrl.infoMsg = '';
        };

        function _saveResource() {
            _resourceService.addResource(ctrl.newResource, function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }

                if (!data.success) ctrl.errorMsg = data.message;
                else { ctrl.infoMsg = "Resource alloted successfully.."; ctrl.newResource = _getResourceObj(); _getProjectResources(); }
            });
        };

        function _getProjects() {
            _projectsService.getProjects(function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }
                ctrl.projects = data.content;
            });
        };

        function _getPeople() {
            _peopleService.getPeople(function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }
                ctrl.resources = data.content;
            });
        };

        function _getProjectResources() {
            _resourceService.getResources(ctrl.selectedProject.id, function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }
                ctrl.projectResources = data.content;
                _loadAvailableResources();
            });
        };

        function _loadAvailableResources() {
            if (ctrl.resources && ctrl.resources.length > 0) {
                var tempResource = angular.copy(ctrl.resources);
                _.each(ctrl.projectResources, function (pr) {
                    var prIndex = tempResource.findIndex(x => x.id == pr.peopleId);
                    if (prIndex > -1) tempResource.splice(prIndex, 1);
                });
                ctrl.availableResources = tempResource;
            }
        };

        function _getResourceObj() {
            return {
                projectId: "",
                peopleId: "",
                description: ""
            };
        };
        
        ctrl.$onInit = function () {
            _getProjects();
            _getPeople();
        }
    }

    myApp.component("resource", {
        templateUrl: "/app/resources/resource.component.html",
        controllerAs: "resourceCtrl",
        controller: ["resourceService", "projectsService", "peopleService", resourceController]
    });

}());