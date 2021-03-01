
import { GenericServices } from "../../../tools/generic/generic.services";
import { APIExempleservices, IExempleservices } from "../models/exempleservices.models";
import { ObjectId } from 'mongodb';

export class ExempleservicesServices extends GenericServices<IExempleservices> {

    public api: string = APIExempleservices;

    constructor() {
        super();
        super.api = this.api;
    };

}