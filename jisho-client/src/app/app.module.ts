import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { SentencesModule } from './sentences/sentences.module';
import { WordsModule } from './words/words.module';
import { KanjiModule } from './kanji/kanji.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    WordsModule,
    SentencesModule,
    KanjiModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
