'use strict'
// app.js
var app = angular.module('myApp', ['ui.router']);

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        .state('home', {
            url: '/home',
            templateUrl: 'templates/home.html',
            controller: 'indexController'
        })

        // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
        .state('login', {
            url: '/login',
            templateUrl: 'templates/login.html',
            controller: 'loginController'
        })
        .state('apply', {
            url: '/apply',
            templateUrl: 'templates/job-single.html',
            controller: 'loginController'
        })
        .state('about', {
            url: '/about',
            templateUrl: 'templates/about.html',     
        })
        .state('new-post', {
            url: '/new-post',
            templateUrl: 'templates/new-post.html',
        })
        .state('jobs', {
            url: '/jobs',
            templateUrl: 'templates/jobs.html',
        })
        .state('contact', {
            url: '/contact',
            templateUrl: 'templates/contact.html',
        });
    app.constant({
        serviceBase: "http://localhost:57666/api/"
    });
});
