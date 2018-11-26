namespace TheHunt {
    'use strict';

    import ITheHuntClient = TheHunt.Client.ITheHuntClient;
    import Product = TheHunt.Client.Product;

    const ProductCatalogComponent: ng.IComponentOptions = {
        bindings: {
        },
        templateUrl: ['paths', (paths: IPaths): string => `${paths.AppBase}product-catalog/product-catalog.html`],
        controller: 'ProductCatalogController'
    }

    export interface IProductCatalogController extends ng.IController {
        TheHuntClient: ITheHuntClient;
        catalogItems: Product[];
        GetProductImage: (description: string) => string;
        load: ng.IPromise<void>;
    }

    class ProductCatalogController implements IProductCatalogController {
        public static readonly $inject: string[] = ['TheHuntClient', 'paths'];

        private paths: IPaths;

        public TheHuntClient: ITheHuntClient;
        public catalogItems: Product[];
        public load: ng.IPromise<void>;

        constructor(TheHuntClient: ITheHuntClient, paths: IPaths) {
            this.TheHuntClient = TheHuntClient;
            this.paths = paths;
        }

        public $onInit = (): void => {
            this.load = this.TheHuntClient.getAllProducts().then(products => {
                this.catalogItems = products;
            });
        }

        public GetProductImage = (description: string): string => {
            let imageUrl = this.paths.ImagesDirectory + description + ".jpg";
            return imageUrl;
        }
    }

    angular.module('angularApp')
        .component('productCatalog', ProductCatalogComponent)
        .controller('ProductCatalogController', ProductCatalogController);
}