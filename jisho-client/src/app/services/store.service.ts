import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { SentencesList } from '../models/sentences-list.model';
import { YomitanEntry } from '../models/yomitan-entry.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private baseUrl = environment.apiBaseUrl;

  http = inject(HttpClient);

  getYomitanList(query: string): Observable<YomitanEntry[]> {
    return this.http.get<YomitanEntry[]>(`${this.baseUrl}/dictionary?query=${query}`);
  }

  getWeblioList(query: string, page: number): Observable<SentencesList> {
    return this.http.get<SentencesList>(`${this.baseUrl}/sentences/weblio?query=${query}&page=${page}`);
  }

  getReversoList(query: string, page: number): Observable<SentencesList> {
    return this.http.get<SentencesList>(`${this.baseUrl}/sentences/reverso?query=${query}&page=${page}`);
  }

  getTatoebaList(query: string, page: number): Observable<SentencesList> {
    return this.http.get<SentencesList>(`${this.baseUrl}/sentences/tatoeba?query=${query}&page=${page}`);
  }
}
