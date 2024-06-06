import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DahboardRoutingModule } from './dahboard-routing.module';
import { DahboardComponent } from './dahboard.component';


@NgModule({
  declarations: [
    DahboardComponent
  ],
  imports: [
    CommonModule,
    DahboardRoutingModule
  ]
})
export class DahboardModule { }
