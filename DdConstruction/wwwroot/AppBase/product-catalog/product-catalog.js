var TheHunt;
(function (TheHunt) {
    'use strict';
    var ProductCatalogComponent = {
        bindings: {},
        templateUrl: ['paths', function (paths) { return paths.AppBase + "product-catalog/product-catalog.html"; }],
        controller: 'ProductCatalogController'
    };
    var ProductCatalogController = /** @class */ (function () {
        function ProductCatalogController(TheHuntClient, paths) {
            var _this = this;
            this.$onInit = function () {
                _this.load = _this.TheHuntClient.getAllProducts().then(function (products) {
                    _this.catalogItems = products;
                });
            };
            this.GetProductImage = function (description) {
                var imageUrl = _this.paths.ImagesDirectory + description + ".jpg";
                return imageUrl;
            };
            this.TheHuntClient = TheHuntClient;
            this.paths = paths;
        }
        ProductCatalogController.$inject = ['TheHuntClient', 'paths'];
        return ProductCatalogController;
    }());
    angular.module('angularApp')
        .component('productCatalog', ProductCatalogComponent)
        .controller('ProductCatalogController', ProductCatalogController);
})(TheHunt || (TheHunt = {}));
