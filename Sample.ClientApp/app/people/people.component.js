(function () {
    "use strict";

    function peopleListController(_peopleService) {
        var ctrl = this;
        ctrl.people = [];
        ctrl.errorMsg = '';
        ctrl.infoMsg = '';

        ctrl.$onInit = function () {
            ctrl.projects = _getPeople();
        }

        function _getPeople() {
            _peopleService.getPeople(function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }
                ctrl.people = data.content;
            });
        };
    }

    myApp.component("peopleList", {
        templateUrl: "/app/people/people.component.html",
        controllerAs: "peopleCtrl",
        controller: ["peopleService", peopleListController]
    });

}());