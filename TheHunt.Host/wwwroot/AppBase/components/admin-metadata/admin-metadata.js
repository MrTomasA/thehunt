var TheHunt;
(function (TheHunt) {
    'use strict';
    var BusinessStream = TheHunt.Client.BusinessStream;
    var Company = TheHunt.Client.Company;
    var SkillSet = TheHunt.Client.SkillSet;
    var UserType = TheHunt.Client.UserType;
    var UserAccount = TheHunt.Client.UserAccount;
    var AdminMetadata = {
        bindings: {},
        templateUrl: ['paths', function (paths) { return paths.AppBase + "components/admin-metadata/admin-metadata.html"; }],
        controller: 'AdminMetadataController'
    };
    var AdminMetadataController = /** @class */ (function () {
        function AdminMetadataController(theHuntClient, toastr) {
            var _this = this;
            this.$onInit = function () {
                _this.businessStream = new BusinessStream();
                _this.company = new Company();
                _this.skillSet = new SkillSet();
                _this.userType = new UserType();
                _this.userAccount = new UserAccount();
                _this.businessStreams = [];
                _this.userTypes = [];
                _this.theHuntClient.getBusinessStreams().then(function (businessStreams) {
                    _this.businessStreams = businessStreams;
                });
                _this.theHuntClient.getUserTypes().then(function (userTypes) {
                    _this.userTypes = userTypes;
                });
                _this.genders = [
                    { "key": "M", "value": "Male" },
                    { "key": "F", "value": "Female" }
                ];
            };
            this.CreateBusinessStream = function () {
                if (_this.businessStream.businessStreamName) {
                    _this.theHuntClient.createBusinessStream(_this.businessStream).then(function (businessStream) {
                        _this.businessStream = businessStream;
                        _this.toastr.success('You successfully saved a BusinessStream');
                        _this.theHuntClient.getBusinessStreams().then(function (businessStreams) {
                            _this.businessStreams = businessStreams;
                        });
                    })
                        .catch(function (error) {
                        _this.toastr.error('An error occured ' + error);
                    });
                }
                else {
                    _this.toastr.error('Please enter a Business Stream Name');
                }
            };
            this.CreateCompany = function () {
                if (_this.company.companyName && _this.company.businessStreamId && _this.company.profileDescription) {
                    if (_this.company.establishmentDate) {
                        _this.company.establishmentDate = new Date(_this.company.establishmentDate.toString());
                    }
                    _this.theHuntClient.createCompany(_this.company).then(function (company) {
                        _this.company = company;
                        _this.toastr.success('You successfully saved a Company');
                    })
                        .catch(function (error) {
                        _this.toastr.error('An error occured ' + error);
                    });
                }
                else {
                    _this.toastr.error('Complete required fields to save a company');
                }
            };
            this.CreateSkillSet = function () {
                if (_this.skillSet.skillSetName) {
                    _this.theHuntClient.createSkillSet(_this.skillSet).then(function (skillSet) {
                        _this.skillSet = skillSet;
                        _this.toastr.success('You successfully saved a SkillSet');
                    })
                        .catch(function (error) {
                        _this.toastr.error('An error occured ' + error);
                    });
                }
                else {
                    _this.toastr.error('SkillSet Name is required');
                }
            };
            this.CreateUserType = function () {
                if (_this.userType.userTypeName) {
                    _this.theHuntClient.createUserType(_this.userType).then(function (userType) {
                        _this.userType = userType;
                        _this.toastr.success('You successfully saved a UserType');
                        _this.theHuntClient.getUserTypes().then(function (userTypes) {
                            _this.userTypes = userTypes;
                        });
                    })
                        .catch(function (error) {
                        _this.toastr.error('An error occured ' + error);
                    });
                }
                else {
                    _this.toastr.error('UserType Name is required');
                }
            };
            this.CreateUserAccount = function () {
                if (_this.userAccount.email && _this.userAccount.userTypeId) {
                    if (_this.userAccount.dateOfBirth) {
                        _this.userAccount.dateOfBirth = new Date(_this.userAccount.dateOfBirth.toString());
                    }
                    _this.userAccount.registrationDate = new Date();
                    _this.userAccount.isActive = true;
                    _this.theHuntClient.createUserAccount(_this.userAccount).then(function (userAccount) {
                        _this.userAccount = userAccount;
                        _this.toastr.success('You successfully saved a User Account');
                    })
                        .catch(function (error) {
                        _this.toastr.error('An error occured ' + error);
                    });
                }
                else {
                    _this.toastr.error('Complete required fields to save a user account');
                }
            };
            this.theHuntClient = theHuntClient;
            this.toastr = toastr;
        }
        AdminMetadataController.$inject = ['TheHuntClient', 'toastr'];
        return AdminMetadataController;
    }());
    angular.module('angularApp')
        .component('adminMetadata', AdminMetadata)
        .controller('AdminMetadataController', AdminMetadataController);
})(TheHunt || (TheHunt = {}));
