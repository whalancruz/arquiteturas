import * as Router from "koa-router";

import { GenericServices } from "./generic.services";

export class GenericController<TModelo> {
    public api: string = "";

    service: GenericServices<TModelo>;

    constructor() {
        this.service = new GenericServices()
    };

    public applyRoutes(koaRouter: Router) {
        koaRouter.get(`/${this.api}/salvar`, (ctx) => { });
        koaRouter.get(`/${this.api}/editar`, (ctx) => { });
        koaRouter.get(`/${this.api}/excluir`, (ctx) => { });
    };

};

export const genericController = new GenericController();