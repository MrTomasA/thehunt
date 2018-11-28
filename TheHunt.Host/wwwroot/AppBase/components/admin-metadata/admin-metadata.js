var TheHunt;
(function (TheHunt) {
    'use strict';
    var BusinessStream = TheHunt.Client.BusinessStream;
    var AdminMetadata = {
        bindings: {},
        templateUrl: ['paths', function (paths) { return paths.AppBase + "components/admin-metadata/admin-metadata.html"; }],
        controller: 'AdminMetadataController'
    };
    var AdminMetadataController = /** @class */ (function () {
        function AdminMetadataController(theHuntClient) {
            var _this = this;
            this.$onInit = function () {
                _this.businessStream = new BusinessStream();
            };
            this.SaveBusinessStream = function () {
                _this.businessStream.businessStreamName = "Information Technology";
                _this.businessStream.id = 1;
                _this.theHuntClient.saveBusinessStream(_this.businessStream).then(function (businessStream) {
                    _this.businessStream = businessStream;
                });
            };
            this.theHuntClient = theHuntClient;
        }
        AdminMetadataController.$inject = ['TheHuntClient'];
        return AdminMetadataController;
    }());
    angular.module('angularApp')
        .component('adminMetadata', AdminMetadata)
        .controller('AdminMetadataController', AdminMetadataController);
})(TheHunt || (TheHunt = {}));
