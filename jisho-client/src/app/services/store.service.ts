import {inject, Injectable} from '@angular/core';
import { WeblioList } from '../models/weblio-list.model';
import {HttpClient} from "@angular/common/http";
import { DictionaryEntry } from '../models/dictionary-entry.model';
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  http = inject(HttpClient);

  getWordsList(query: string): Observable<DictionaryEntry[]> {
    return this.http.get<DictionaryEntry[]>(`http://localhost:5284/dictionary?query=${query}`);
  }

  getWeblioList(query: string, page: number): Observable<WeblioList> {
    return this.http.get<WeblioList>(`http://localhost:5284/weblio/sentences?query=${query}&page=${page}`);
  }
}
