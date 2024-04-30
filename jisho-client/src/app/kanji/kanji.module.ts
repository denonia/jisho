import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {KanjiSearchPageComponent} from './kanji-search-page/kanji-search-page.component';
import {FormsModule} from "@angular/forms";
import { KanjiCardComponent } from './kanji-card/kanji-card.component';
import {RouterModule} from "@angular/router";


@NgModule({
  declarations: [
    KanjiSearchPageComponent,
    KanjiCardComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ]
})
export class KanjiModule {
}
