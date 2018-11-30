namespace TheHunt {
    'use strict';

    import ITheHuntClient = TheHunt.Client.ITheHuntClient;
    import BusinessStream = TheHunt.Client.BusinessStream;
    import Company = TheHunt.Client.Company;
    import SkillSet = TheHunt.Client.SkillSet;

    const AdminMetadata: ng.IComponentOptions = {
        bindings: {
        },
        templateUrl: ['paths', (paths: IPaths): string => `${paths.AppBase}components/admin-metadata/admin-metadata.html`],
        controller: 'AdminMetadataController'
    }

    export interface IAdminMetadataController extends ng.IController {
        CreateBusinessStream(): void;
        CreateCompany(): void;
        CreateSkillSet(): void;
    }

    class AdminMetadataController implements IAdminMetadataController {
        public static readonly $inject: string[] = ['TheHuntClient', 'toastr'];

        private theHuntClient: ITheHuntClient;
        private toastr: ng.toastr.IToastrService;

        public businessStream: BusinessStream;
        public businessStreams: BusinessStream[];

        public company: Company;

        public skillSet: SkillSet;

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

                this.theHuntClient.createBusinessStream(this.businessStream).then(businessStream => {
                    this.businessStream = businessStream;
                    this.toastr.success('You successfully saved a BusinessStream');
                })
                .catch(error => {
                    this.toastr.error('An error occured ' + error);
                });
            }
            else {
                this.toastr.error('Please enter a Business Stream Name');
            }
        }

        public CreateCompany = (): void => {
            if (this.company.companyName && this.company.businessStreamId && this.company.profileDescription) {
                if (this.company.establishmentDate) {
                    this.company.establishmentDate = new Date(this.company.establishmentDate.toString());
                }

                this.theHuntClient.createCompany(this.company).then(company => {
                    this.company = company;
                    this.toastr.success('You successfully saved a Company');
                })
                .catch(error => {
                    this.toastr.error('An error occured ' + error);
                });
            }
            else {
                this.toastr.error('Complete required fields to save a company');
            }
        }

        public CreateSkillSet = (): void => {
            if (this.skillSet.skillSetName) {
                this.theHuntClient.saveSkillSet(this.skillSet).then(skillSet => {
                    this.skillSet = skillSet;
                    this.toastr.success('You successfully saved a SkillSet');
                })
                    .catch(error => {
                        this.toastr.error('An error occured ' + error);
                    });
            }
            else {
                this.toastr.error('SkillSet Name is required');
            }
        }
    }

    angular.module('angularApp')
        .component('adminMetadata', AdminMetadata)
        .controller('AdminMetadataController', AdminMetadataController);
}