(function () {

    "use strict";

    function projectListController(_projectsService) {
        var ctrl = this;
        ctrl.projects = [];

        ctrl.$onInit = function () {
            ctrl.projects = ctrl.data;
        }

        ctrl.$onChanges = function () {
            ctrl.projects = ctrl.data;
        }
    }

    myApp.component("projectList", {
        templateUrl: "/app/projects/list.component.html",
        bindings:{
            data: "<"
        },
        controllerAs: "projListCtrl",
        controller: ["projectsService", projectListController]
    });

}());