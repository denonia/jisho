import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { DictionaryEntry } from '../models/dictionary-entry.model';
import {Observable} from "rxjs";
import { SentencesList } from '../models/sentences-list.model';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  http = inject(HttpClient);

  getWordsList(query: string): Observable<DictionaryEntry[]> {
    return this.http.get<DictionaryEntry[]>(`http://localhost:5284/dictionary?query=${query}`);
  }

  getWeblioList(query: string, page: number): Observable<SentencesList> {
    return this.http.get<SentencesList>(`http://localhost:5284/sentences/weblio?query=${query}&page=${page}`);
  }

  getReversoList(query: string, page: number): Observable<SentencesList> {
    return this.http.get<SentencesList>(`http://localhost:5284/sentences/reverso?query=${query}&page=${page}`);
  }
}
