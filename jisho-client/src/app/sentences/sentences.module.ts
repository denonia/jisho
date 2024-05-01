import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SentencesPageComponent } from './sentences-page.component';
import {HttpClientModule} from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { SentencesListComponent } from './sentences-list/sentences-list.component';
import { UiModule } from '../ui/ui.module';


@NgModule({
  declarations: [
    SentencesPageComponent,
    SentencesListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    UiModule
  ]
})
export class SentencesModule { }
