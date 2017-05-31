"use strict";

var underscore = angular.module('underscore', []);
underscore.factory('_', ['$window', function ($window) {
    return $window._; // assumes underscore has already been loaded on the page
}]);

var myApp = angular.module('myApp', ['ngRoute', 'ui.mask', 'underscore']);

// configure our routes
myApp.config(function ($locationProvider, $routeProvider) {

    $locationProvider.html5Mode(true);

    $routeProvider
        .when('/', { title: 'Projects', template: '<project></project>' })
        .when('/people', { title: 'People', template: '<people-list></people-list>' })
        .when('/people/add', { title: 'Person', template: '<person></person>' })
        .when('/resources', { title: 'Resources', template: '<resource></resource>' })
        .otherwise({ redirectTo: '/' });
});

myApp.run(['$rootScope', '$route', function ($rootScope, $route) {
    $rootScope.$on('$routeChangeSuccess', function () {
        document.title = $route.current.title;
    });
}]);