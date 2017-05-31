(function () {
    "use strict";

    function personController(_peopleService, $location) {
        var ctrl = this;
        ctrl.errorMsg = '';
        ctrl.infoMsg = '';

        ctrl.person = _getPerson();

        ctrl.submit = function () {
            if (!ctrl.personForm.$valid) { return; }

            if (ctrl.personForm.$dirty) {
                _savePerson();
            }
        }


        function _savePerson() {
            _peopleService.addPerson(ctrl.person, function (err, data) {
                if (err) { ctrl.errorMsg = err; return; }

                if (!data.success) ctrl.errorMsg = data.message;
                else { $location.url('/people'); }
            });
        };

        function _getPerson() {
            return {
                id: "",
                firstName: "",
                lastName: "",
                email: "",
                address: "",
                mobile: ""
            };
        };
    }

    myApp.component("person", {
        templateUrl: "/app/people/person.component.html",
        controllerAs: "personCtrl",
        controller: ["peopleService", "$location", personController]
    });

}());