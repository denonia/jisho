import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WordsPageComponent } from './words-page.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {RouterModule} from "@angular/router";
import { YomitanListComponent } from './yomitan-list/yomitan-list.component';
import { JmdictListComponent } from './jmdict-list/jmdict-list.component';
import { JmdictCardComponent } from './jmdict-card/jmdict-card.component';
import { UiModule } from '../ui/ui.module';
import { YomitanCardComponent } from './yomitan-card/yomitan-card.component';



@NgModule({
  declarations: [
    WordsPageComponent,
    YomitanListComponent,
    JmdictListComponent,
    JmdictCardComponent,
    YomitanCardComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    UiModule
  ]
})
export class WordsModule { }
