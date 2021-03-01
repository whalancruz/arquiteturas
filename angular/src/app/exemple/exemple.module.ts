import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExempleRoutingModule } from './exemple-routing.module';
import { AppModule } from '../app.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ExempleRoutingModule,
    AppModule
  ]
})
export class ExempleModule { }
