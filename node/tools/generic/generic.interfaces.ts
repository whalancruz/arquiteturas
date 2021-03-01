import { ObjectId } from 'mongodb';


export interface IModelo {
    _id?: ObjectId;

}

export interface FindOneAndUpdateOption {
    // projection?: SchemaMember<T, ProjectionOperators | number | boolean | any>;
    // sort?: SortOptionObject<T>;
    maxTimeMS?: number;
    upsert?: boolean;
    returnOriginal?: boolean;
    // collation?: CollationDocument;
}

