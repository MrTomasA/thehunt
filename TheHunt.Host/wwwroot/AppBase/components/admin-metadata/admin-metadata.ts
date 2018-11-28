namespace TheHunt {
    'use strict';

    import ITheHuntClient = TheHunt.Client.ITheHuntClient;
    import BusinessStream = TheHunt.Client.BusinessStream;

    const AdminMetadata: ng.IComponentOptions = {
        bindings: {
        },
        templateUrl: ['paths', (paths: IPaths): string => `${paths.AppBase}components/admin-metadata/admin-metadata.html`],
        controller: 'AdminMetadataController'
    }

    export interface IAdminMetadataController extends ng.IController {
        SaveBusinessStream(): void;
    }

    class AdminMetadataController implements IAdminMetadataController {
        public static readonly $inject: string[] = ['TheHuntClient'];

        private theHuntClient: ITheHuntClient;

        public businessStream: BusinessStream;

        constructor(theHuntClient: ITheHuntClient) {
            this.theHuntClient = theHuntClient;
        }

        public $onInit = (): void => {
            this.businessStream = new BusinessStream()
        }

        public SaveBusinessStream = (): void => {
            this.businessStream.businessStreamName = "Information Technology";
            this.businessStream.id = 1;

            this.theHuntClient.saveBusinessStream(this.businessStream).then(businessStream => {
                this.businessStream = businessStream;
            });
        }
    }

    angular.module('angularApp')
        .component('adminMetadata', AdminMetadata)
        .controller('AdminMetadataController', AdminMetadataController);
}