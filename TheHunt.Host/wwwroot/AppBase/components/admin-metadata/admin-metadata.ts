namespace TheHunt {
    'use strict';

    import ITheHuntClient = TheHunt.Client.ITheHuntClient;
    import BusinessStream = TheHunt.Client.BusinessStream;
    import Company = TheHunt.Client.Company;
    import SkillSet = TheHunt.Client.SkillSet;
    import UserType = TheHunt.Client.UserType;
    import UserAccount = TheHunt.Client.UserAccount;
    import JobType = TheHunt.Client.JobType;
    import JobLocation = TheHunt.Client.JobLocation;
    import JobPost = TheHunt.Client.JobPost;

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
        CreateUserType(): void;
        CreateUserAccount(): void;
        CreateJobType(): void;
        CreateJobLocation(): void;
        CreateJobPost(): void;
    }

    class AdminMetadataController implements IAdminMetadataController {
        public static readonly $inject: string[] = ['TheHuntClient', 'toastr'];

        private theHuntClient: ITheHuntClient;
        private toastr: ng.toastr.IToastrService;

        public businessStream: BusinessStream;
        public businessStreams: BusinessStream[];
        public company: Company;
        public companies: Company[];
        public skillSet: SkillSet;
        public userType: UserType;
        public userTypes: UserType[];
        public userAccount: UserAccount;
        public userAccounts: UserAccount[];
        public jobType: JobType;
        public jobTypes: JobType[];
        public jobLocation: JobLocation;
        public jobLocations: JobLocation[];
        public jobPost: JobPost;

        public genders: object[];

        constructor(theHuntClient: ITheHuntClient, toastr: ng.toastr.IToastrService) {
            this.theHuntClient = theHuntClient;
            this.toastr = toastr;
        }

        public $onInit = (): void => {
            this.businessStream = new BusinessStream();
            this.company = new Company();
            this.skillSet = new SkillSet();
            //this.userType = new UserType();
            this.userAccount = new UserAccount();
            this.jobType = new JobType();
            this.jobLocation = new JobLocation();
            this.jobPost = new JobPost();

            this.businessStreams = [];
            this.userTypes = [];
            this.companies = [];
            this.jobTypes = [];
            this.jobLocations = [];
            this.userAccounts = [];

            this.theHuntClient.getBusinessStreams().then(businessStreams => {
                this.businessStreams = businessStreams;
            });

            this.theHuntClient.getUserTypes().then(userTypes => {
                this.userTypes = userTypes;
            });

            this.theHuntClient.getCompanies().then(companies => {
                this.companies = companies;
            });

            this.theHuntClient.getJobLocations().then(jobLocations => {
                this.jobLocations = jobLocations;
            });

            this.theHuntClient.getJobTypes().then(jobTypes => {
                this.jobTypes = jobTypes;
            });

            this.theHuntClient.getUserAccounts().then(userAccounts => {
                this.userAccounts = userAccounts;
            });

            this.genders =[
                { "key": "M", "value": "Male" },
                { "key": "F", "value": "Female" }
            ]
        }

        public CreateBusinessStream = (): void => {
            if (this.businessStream.businessStreamName) {

                this.theHuntClient.createBusinessStream(this.businessStream).then(businessStream => {
                    this.businessStream = businessStream;
                    this.toastr.success('You successfully saved a BusinessStream');
                    this.theHuntClient.getBusinessStreams().then(businessStreams => {
                        this.businessStreams = businessStreams;
                    });
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
                this.theHuntClient.createSkillSet(this.skillSet).then(skillSet => {
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

        public CreateUserType = (): void => {
            if (this.userType.userTypeName) {
                this.theHuntClient.createUserType(this.userType).then(userType => {
                    this.userType = userType;
                    this.toastr.success('You successfully saved a UserType');
                    this.theHuntClient.getUserTypes().then(userTypes => {
                        this.userTypes = userTypes;
                    });
                })
                .catch(error => {
                    this.toastr.error('An error occured ' + error);
                });
            }
            else {
                this.toastr.error('UserType Name is required');
            }
        }

        public CreateUserAccount = (): void => {
            if (this.userAccount.email && this.userAccount.userTypeId) {
                if (this.userAccount.dateOfBirth) {
                    this.userAccount.dateOfBirth = new Date(this.userAccount.dateOfBirth.toString());
                }

                this.userAccount.registrationDate = new Date();
                this.userAccount.isActive = true;

                this.theHuntClient.createUserAccount(this.userAccount).then(userAccount => {
                    this.userAccount = userAccount;
                    this.toastr.success('You successfully saved a User Account');
                })
                    .catch(error => {
                        this.toastr.error('An error occured ' + error);
                    });
            }
            else {
                this.toastr.error('Complete required fields to save a user account');
            }
        }

        public CreateJobType = (): void => {
            if (this.jobType.name) {
                this.theHuntClient.createJobType(this.jobType).then(jobType => {
                    this.jobType = jobType;
                    this.toastr.success('You successfully saved a Job Type');
                })
                    .catch(error => {
                        this.toastr.error('An error occured ' + error);
                    });
            }
            else {
                this.toastr.error('Complete required fields to save a job type');
            }
        }

        public CreateJobLocation = (): void => {
            if (this.jobLocation.streetAddress && this.jobLocation.city && this.jobLocation.state && this.jobLocation.country && this.jobLocation.zip) {
                this.theHuntClient.createJobLocation(this.jobLocation).then(jobLocation => {
                    this.jobLocation = jobLocation;
                    this.toastr.success('You successfully saved a Job Location');
                })
                    .catch(error => {
                        this.toastr.error('An error occured ' + error);
                    });
            }
            else {
                this.toastr.error('Complete required fields to save a job location');
            }
        }

        public CreateJobPost = (): void => {
            if (this.jobPost.companyId && this.jobPost.jobLocationId && this.jobPost.jobTypeId && this.jobPost.postedById && this.jobPost.jobDescription) {
                this.jobPost.createdDate = new Date();

                if (!this.jobPost.isCompanyNameHidden) {
                    this.jobPost.isCompanyNameHidden = false;
                }

                if (!this.jobPost.isActive) {
                    this.jobPost.isActive = false;
                }

                this.theHuntClient.createJobPost(this.jobPost).then(jobPost => {
                    this.jobPost = jobPost;
                    this.toastr.success('You successfully saved a Job Post');
                })
                    .catch(error => {
                        this.toastr.error('An error occured ' + error);
                    });
            }
            else {
                this.toastr.error('Complete required fields to save a job post');
            }
        }
    }

    angular.module('angularApp')
        .component('adminMetadata', AdminMetadata)
        .controller('AdminMetadataController', AdminMetadataController);
}