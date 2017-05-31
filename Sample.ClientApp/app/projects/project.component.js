(function () {

    "use strict";

    //var myApp = angular.module('myApp', []);

    function projectController(_projectsService) {
        var ctrl = this;

        ctrl.errorMsg = '';
        ctrl.infoMsg = '';
        ctrl.project = '';
        ctrl.projects = [];

        ctrl.$onInit = function () {
            ctrl.project = _getProjectObj();
            ctrl.projects = _getProjects();
        }

        ctrl.submit = function () {
            ctrl.errorMsg = '';
            ctrl.infoMsg = '';
            if (!ctrl.projectForm.$valid) { return; }

            if (ctrl.projectForm.$dirty) {
                _saveProject();
            }
        }

        function _saveProject() {
            _projectsService.addProject(ctrl.project, function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }

                if (!data.success) ctrl.errorMsg = data.message;
                else { ctrl.infoMsg = "Project saved successfully.."; ctrl.project = _getProjectObj(); _getProjects(); }
            });
        };

        function _getProjectObj() {
            return {
                id: "",
                name: "",
                description: ""
            };
        };

        function _getProjects() {
            _projectsService.getProjects(function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }
                ctrl.projects = data.content;
            });
        };

        ctrl.message = "Hi Suneel!!!";
    }

    myApp.component("project", {
        templateUrl: "/app/projects/project.component.html",
        controllerAs: "projectCtrl",
        controller: ["projectsService", projectController]
    });

}());