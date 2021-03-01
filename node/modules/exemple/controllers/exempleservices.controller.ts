
import Router from "koa-router";

import { GenericController } from "../../../tools/generic/generic.controller";
import { APIExempleservices, IExempleservices } from "../models/exempleservices.models";
import { ExempleservicesServices } from "../services/exempleservices.services";

export class ExempleservicesController extends GenericController<IExempleservices> {
     public api: string = APIExempleservices;

     service: ExempleservicesServices;

     constructor() {
          super();
          this.service = new ExempleservicesServices();
     };

     public applyRoutes(koaRouter: Router) {


          super.applyRoutes(koaRouter);
     };

};

export const exempleservicesController = new ExempleservicesController();

