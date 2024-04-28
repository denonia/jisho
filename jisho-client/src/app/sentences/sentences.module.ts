import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SentencesPageComponent } from './sentences-page.component';
import {HttpClientModule} from "@angular/common/http";
import { WeblioListComponent } from './weblio-list/weblio-list.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SentencesPageComponent,
    WeblioListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ]
})
export class SentencesModule { }
