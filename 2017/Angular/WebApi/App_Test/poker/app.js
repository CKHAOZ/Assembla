(function () {
    angular.module('app', ['angular.filter']);
})();

(function () {
    angular.module('app')
        .controller('poker', poker);

    poker.$inject = ['pokerCards', 'pokerRules'];

    function poker($cards, $rules) {

        var vm = this;

        vm.cards = [];
        vm.rules = [];
        vm.limit = 10;

        vm.reset = reset;

        active();

        return;

        function active() {
            runGame();
        }

        function runGame() {
            vm.cards = $cards.getRandom(vm.limit);
            vm.rules = $rules.veriedRules(angular.copy(vm.cards));
        }

        function reset() {
            runGame();
        }

    }

})();

(function () {

    angular.module('app')
        .factory('pokerCards', pokerCards);

    function pokerCards() {

        var numbers = [
                'ace',
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                'jack',
                'queen',
                'king'
            ],
            pins = [
                'clubs',
                'diamonds',
                'hearts',
                'spades'
            ];

        var public = {
            get: get,
            getRandom: getRandom,
            mazo: {
                numbers: numbers,
                pins: pins
            }
        };

        return public;

        function get() {
            var cards = [];
            angular.forEach(pins, function (pin) {
                var i = 0;
                angular.forEach(numbers, function (number) {
                    cards.push({
                        i: i++,
                        url: number + '_of_' + pin + '.png',
                        pin: pin,
                        number: number,
                    });
                });
            });
            return cards;
        };

        function getRandom(limit) {
            var cards = get(),
                cardsRandom = [];
            for (var i = 0; i < limit; i++) {
                var card = null;
                do {
                    card = cards[Math.floor((Math.random() * 100))];
                } while (!card);
                cards.splice(cards.indexOf(card), 1);
                cardsRandom.push(card);
            }
            return cardsRandom;
        }

    }

})();

(function () {
    angular.module('app')
        .factory('pokerRules', pokerRules);

    pokerRules.$inject = ['$filter', 'pokerCards'];

    function pokerRules($filter, $cards) {

        var public = {
            veriedRules: veriedRules
        };

        var
            orderBy = $filter('orderBy'),
            where = $filter('filter'),
            groupBy = $filter('groupBy');

        return public;

        function veriedRules(cards) {
            var rules = [];

            rules = rules.concat(escalera(cards));
            rules = rules.concat(cuarteto(cards));
            rules = rules.concat(trio(cards));
            rules = rules.concat(duo(cards));

            return rules;
        }

        function escalera(_cards) {
            var rule = {
                name: 'Escalera',
                combinations: []
            };
            var pints = groupBy(_cards, 'pin');

            angular.forEach(pints, function (cards) {
                var orderCards = orderBy(cards, '+i');
                var sequence = 1;
                var scalera = 5;
                for (var i = 1; i < orderCards.length; i++) {
                    if (orderCards[i - 1] && orderCards[i] &&
                        orderCards[i - 1].i === (orderCards[i].i - 1)) {
                        sequence++;
                    } else {
                        if (sequence >= scalera) { break; }
                        sequence = 1;
                    }
                    if (i === orderCards.length - 1 &&
                        orderCards[orderCards.length - 1].i === 12 &&
                        orderCards[orderCards.length - 1].i === 0) {
                        sequence++;
                    } 
                }
                if (sequence >= scalera) {
                    rule.combinations.push({

                    });
                }
            });

            return rule;
        }

        function duo(_cards) {
            var rule = {
                name: 'Duo',
                combinations: []
            };
            angular.forEach(_cards, function (card) {
                var duoCards = where(_cards, function (duoCard) {
                    return card.i === duoCard.i && card.pin !== duoCard.pin;
                });

                if (duoCards.length) {
                    rule.combinations.push({
                        pivot: card,
                        combinations: duoCards,
                    });
                    var aux = [card].concat(duoCards);
                    angular.forEach(aux, function (_card) {
                        _cards.splice(_cards.indexOf(_card), 1);
                    });
                }


            });
            return rule;
        }

        function trio(_cards) {
            var rule = {
                name: 'Trio',
                combinations: []
            };
            angular.forEach(_cards, function (card) {
                var trioCards = where(_cards, function (trioCard) {
                    return card.i === trioCard.i && card.pin !== trioCard.pin;
                });

                if (trioCards.length > 1) {
                    rule.combinations.push({
                        pivot: card,
                        combinations: trioCards,
                    });
                    var aux = [card].concat(trioCards);
                    angular.forEach(aux, function (_card) {
                        _cards.splice(_cards.indexOf(_card), 1);
                    });
                }


            });
            return rule;
        }

        function cuarteto(_cards) {
            var rule = {
                name: 'Cuarteto',
                combinations: []
            };
            angular.forEach(_cards, function (card) {
                var trioCards = where(_cards, function (trioCard) {
                    return card.i === trioCard.i && card.pin !== trioCard.pin;
                });

                if (trioCards.length > 2) {
                    rule.combinations.push({
                        pivot: card,
                        combinations: trioCards,
                    });
                    var aux = [card].concat(trioCards);
                    angular.forEach(aux, function (_card) {
                        _cards.splice(_cards.indexOf(_card), 1);
                    });
                }


            });
            return rule;
        }
    }

})();


