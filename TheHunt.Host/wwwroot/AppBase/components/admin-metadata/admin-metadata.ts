namespace TheHunt {
    'use strict';

    import ITheHuntClient = TheHunt.Client.ITheHuntClient;
    import BusinessStream = TheHunt.Client.BusinessStream;
    import Company = TheHunt.Client.Company;

    const AdminMetadata: ng.IComponentOptions = {
        bindings: {
        },
        templateUrl: ['paths', (paths: IPaths): string => `${paths.AppBase}components/admin-metadata/admin-metadata.html`],
        controller: 'AdminMetadataController'
    }

    export interface IAdminMetadataController extends ng.IController {
        CreateBusinessStream(): void;
    }

    class AdminMetadataController implements IAdminMetadataController {
        public static readonly $inject: string[] = ['TheHuntClient', 'toastr'];

        private theHuntClient: ITheHuntClient;
        private toastr: ng.toastr.IToastrService;

        public businessStream: BusinessStream;
        public businessStreams: BusinessStream[];

        public company: Company;

        constructor(theHuntClient: ITheHuntClient, toastr: ng.toastr.IToastrService) {
            this.theHuntClient = theHuntClient;
            this.toastr = toastr;
        }

        public $onInit = (): void => {
            this.businessStream = new BusinessStream();
            this.company = new Company();
            this.businessStreams = [];

            this.theHuntClient.getAllBusinessStreams().then(businessStreams => {
                this.businessStreams = businessStreams;
            });
        }

        public CreateBusinessStream = (): void => {
            if (this.businessStream.businessStreamName) {

                this.theHuntClient.saveBusinessStream(this.businessStream).then(businessStream => {
                    this.businessStream = businessStream;
                    this.toastr.success('You successfully saved a BusinessStream');
                });
            }
            else {
                this.toastr.error('Please enter a Business Stream Name');
            }
        }
    }

    angular.module('angularApp')
        .component('adminMetadata', AdminMetadata)
        .controller('AdminMetadataController', AdminMetadataController);
}