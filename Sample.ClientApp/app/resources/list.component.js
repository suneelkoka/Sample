(function () {

    "use strict";

    function resourceListController() {
        var ctrl = this;
        ctrl.resources = [];

        ctrl.$onInit = function () {
            ctrl.resources = ctrl.data;
        }

        ctrl.$onChanges = function () {
            ctrl.resources = ctrl.data;
        }
    }

    myApp.component("resourceList", {
        templateUrl: "/app/resources/list.component.html",
        bindings: {
            data: "<"
        },
        controllerAs: "resourcesCtrl",
        controller: [resourceListController]
    });

}());