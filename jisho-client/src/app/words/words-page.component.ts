import {Component, inject, signal} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {StoreService} from '../services/store.service';
import {Observable, Subject, of} from "rxjs";
import {DictionaryEntry} from '../models/dictionary-entry.model';

@Component({
  templateUrl: './words-page.component.html',
})
export class WordsPageComponent {
  query = signal('');

  store = inject(StoreService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  wordsList$!: Observable<DictionaryEntry[]>;

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
        if ('query' in params)
          this.query.set(params['query']);
        if (this.query() != '')
          this.wordsList$ = this.store.getWordsList(this.query());
      }
    );
  }

  search(e: Event) {
    this.router.navigate(['.'], {
      relativeTo: this.route, queryParams: {
        query: (e.target as HTMLInputElement).value
      }
    });
  }
}
