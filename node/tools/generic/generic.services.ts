import mongoose from 'mongoose';


import { mongoDB } from '../mongo/mongo';
import { isNullOrUndefined } from 'util';
import { FindOneAndUpdateOption, IModelo } from './generic.interfaces';
import { ObjectId } from 'mongodb';



export class GenericServices<TModelo> {
     public api: string = "";

     constructor() { };

     //#region CRUD

     public async AlterarAsync(obj: TModelo): Promise<TModelo> {
          return new Promise(async (response, reject) => {
               if (isNullOrUndefined(obj)) reject("Nenhum objeto definido!");

               var params = obj as IModelo;

               params._id = (isNullOrUndefined(params._id)) ? new ObjectId() : params._id;

               await this.getCollection().findOneAndUpdate({ _id: params._id }, { $set: obj }, <FindOneAndUpdateOption>{ upsert: true }, (error) => {
                    if (!isNullOrUndefined(error)) reject(error.message);
               });

          });
     };

     public async DeletarAsync(obj: TModelo): Promise<TModelo> {
          return new Promise(async (response, reject) => {
               var params = obj as IModelo;

               await this.getCollection().deleteOne({ _id: params._id }, (error) => {
                    if (!isNullOrUndefined(error)) reject(error.message);
               });

          });
     };

     //#endregion

     //#region SEVERAL

     public getCollection(): mongoose.Collection { return mongoDB.getCollection(this.api); };

     //#endregion

};