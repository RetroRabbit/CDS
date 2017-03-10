
app.directive('scroller', function () {
    return {
        restrict: 'AE',
        link: function ($scope, $elem, attrs) {
            $elem.scroller();
        }
    };
});
