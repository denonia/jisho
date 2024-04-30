import {Component, inject, signal} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {StoreService} from '../services/store.service';
import {Observable, Subject, of} from "rxjs";
import {YomitanEntry} from '../models/yomitan-entry.model';
import {DesuApiService} from '../services/desu-api.service';
import {JmdictEntry} from '../models/jmdict-entry.model';

@Component({
  templateUrl: './words-page.component.html',
})
export class WordsPageComponent {
  query = signal('');
  source = signal('jmdict');

  api = inject(DesuApiService);
  store = inject(StoreService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  jmdictList$!: Observable<JmdictEntry[]>;
  yomitanList$!: Observable<YomitanEntry[]>;

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
        this.query.set(params['query'] ?? '');
        this.source.set(params['source'] ?? 'jmdict');
        if (this.query() != '') {
          switch (this.source()) {
            case 'jitendex':
              this.yomitanList$ = this.store.getYomitanList(this.query());
              break;
            default:
              this.jmdictList$ = this.api.getJmdictList(this.query());
          }
        }
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

  switchSource(source: string) {
    this.router.navigate(['.'], {
      relativeTo: this.route, queryParams: {
        source: source
      },
      queryParamsHandling: 'merge'
    });
  }
}
