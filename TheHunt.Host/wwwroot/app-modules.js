var TheHunt;
(function (TheHunt) {
    'use strict';
    angular.module('angularApp', [
        'siteConstants',
        'ngAnimate',
        'toastr',
        'cgBusy'
    ]);
})(TheHunt || (TheHunt = {}));

var TheHunt;
(function (TheHunt) {
    'use strict';
    var siteConstants = angular.module('siteConstants', []);
    var siteRoot = '/';
    var paths = {
        AppBase: siteRoot + "AppBase/",
        ImagesDirectory: siteRoot + "Images/"
    };
    siteConstants.constant('paths', paths);
})(TheHunt || (TheHunt = {}));