import mongoose from 'mongoose';


import { mongoDB } from '../mongo/mongo';
import { isNullOrUndefined } from 'util';
import { FindOneAndUpdateOption, IModelo } from './generic.interfaces';
import { ObjectId } from 'mongodb';



export class GenericServices<TModelo> {
     public api: string = "";

     constructor() { };


     public getCollection(): mongoose.Collection { return mongoDB.getCollection(this.api); };



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

     public async IncluirAsync(obj: TModelo): Promise<TModelo> {
          return new Promise(async (response, reject) => {
               if (isNullOrUndefined(obj)) reject("Nenhum objeto definido!");
               await this.getCollection().insertOne(obj);
          });
     };

     public async ExcluirAsync() {

     };


};