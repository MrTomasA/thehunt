var TheHunt;
(function (TheHunt) {
    'use strict';
    var BusinessStream = TheHunt.Client.BusinessStream;
    var Company = TheHunt.Client.Company;
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
                _this.businessStreams = [];
                _this.theHuntClient.getAllBusinessStreams().then(function (businessStreams) {
                    _this.businessStreams = businessStreams;
                });
            };
            this.CreateBusinessStream = function () {
                if (_this.businessStream.businessStreamName) {
                    _this.theHuntClient.saveBusinessStream(_this.businessStream).then(function (businessStream) {
                        _this.businessStream = businessStream;
                        _this.toastr.success('You successfully saved a BusinessStream');
                    });
                }
                else {
                    _this.toastr.error('Please enter a Business Stream Name');
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
