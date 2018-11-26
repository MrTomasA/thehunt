namespace TheHunt {
    'use strict'

    export interface IPaths {
        readonly AppBase: string;
        readonly ImagesDirectory: string;
    }

    const siteConstants = angular.module('siteConstants', []);

    let siteRoot = '/';

    const paths: IPaths = {
        AppBase: `${siteRoot}AppBase/`,
        ImagesDirectory: `${siteRoot}Images/`
    };

    siteConstants.constant('paths', paths);
}