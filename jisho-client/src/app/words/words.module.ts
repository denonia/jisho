import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WordsPageComponent } from './words-page.component';
import { WordsListComponent } from './words-list/words-list.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {RouterModule} from "@angular/router";



@NgModule({
  declarations: [
    WordsPageComponent,
    WordsListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule
  ]
})
export class WordsModule { }
