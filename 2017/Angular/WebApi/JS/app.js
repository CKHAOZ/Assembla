'use strict';

var app = angular.module('appBCubillos', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function (route, local) {
        route.when('/', {
            templateUrl: '/JS/Plantillas/Inicio.html',
            controller: 'InicioController'
        });
        route.when('/Articulo', {
            templateUrl: '/JS/Plantillas/Articulo.html',
            controller: 'ArticuloController'
        });
        route.when('/Categoria', {
            templateUrl: '/JS/Plantillas/Categoria.html',
            controller: 'CategoriaController'
        });
        route.when('/Poker', {
            templateUrl: '/JS/Plantillas/Poker.html',
            controller: 'PokerController'
        });
        local.html5Mode({
            enabled: true,
            requireBase: false
        });
    }])
    .controller('InicioController', [ctrlInicio])
    .controller('ArticuloController', [ctrArticulo])
    .controller('CategoriaController', [ctrCategoria])
    .controller('PokerController', [ctrPoker]);