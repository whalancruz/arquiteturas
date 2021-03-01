import * as Router from "koa-router";

import { GenericServices } from "./generic.services";

export class GenericController<TModelo> {
    public api: string = "";

    service: GenericServices<TModelo>;

    constructor() {
        this.service = new GenericServices()
    };

    public applyRoutes(koaRouter: Router) {

    };

};

export const genericController = new GenericController();