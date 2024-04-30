import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WordsPageComponent } from './words/words-page.component';
import { SentencesPageComponent } from './sentences/sentences-page.component';
import { KanjiSearchPageComponent } from './kanji/kanji-search-page/kanji-search-page.component';

const routes: Routes = [
  { path: 'words', component: WordsPageComponent },
  { path: 'sentences', component: SentencesPageComponent },
  { path: 'kanji', component: KanjiSearchPageComponent },
  { path: '', redirectTo: 'words', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
