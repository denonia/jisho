import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { KanjiEntry } from '../models/kanji-entry.model';

@Injectable({
  providedIn: 'root'
})
export class DesuApiService {
  http = inject(HttpClient);

  getRadicalsList(): Observable<string[]> {
    return this.http.get<string[]>(`http://localhost:5043/kanji/radicals`);
  }

  getKanjiList(query: string, radicals: string): Observable<KanjiEntry[]> {
    return this.http.get<KanjiEntry[]>(`http://localhost:5043/kanji?query=${query}&radicals=${radicals}`);
  }

  getWordsList(query: string): Observable<KanjiEntry[]> {
    return this.http.get<KanjiEntry[]>(`http://localhost:5043/kanji?query=${query}&radicals=${radicals}`);
  }
}
