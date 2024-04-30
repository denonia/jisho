import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { KanjiEntry } from '../models/kanji-entry.model';
import { JmdictEntry } from '../models/jmdict-entry.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DesuApiService {
  private baseUrl = environment.desuBaseUrl;

  http = inject(HttpClient);

  getRadicalsList(): Observable<string[]> {
    return this.http.get<string[]>(`${this.baseUrl}/kanji/radicals`);
  }

  getKanjiList(query: string, radicals: string): Observable<KanjiEntry[]> {
    return this.http.get<KanjiEntry[]>(`${this.baseUrl}/kanji?query=${query}&radicals=${radicals}`);
  }

  getJmdictList(query: string): Observable<JmdictEntry[]> {
    return this.http.get<JmdictEntry[]>(`${this.baseUrl}/words?query=${query}`);
  }
}
