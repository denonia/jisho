import {Component, Signal, inject, signal} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {StoreService} from '../services/store.service';
import {Observable} from "rxjs";
import {SentencesList} from '../models/sentences-list.model';

@Component({
  templateUrl: './sentences-page.component.html',
})
export class SentencesPageComponent {
  query = signal('');
  page = signal(1);
  source = signal('reverso');

  store = inject(StoreService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  sentencesList$!: Observable<SentencesList>;

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
        this.query.set(params['query'] ?? '');
        this.page.set(parseInt(params['page']) || 1);
        this.source.set(params['ssource'] ?? 'tatoeba');

        if (this.query() != '') {
          switch (this.source()) {
            case "reverso":
              this.sentencesList$ = this.store.getReversoList(this.query(), this.page());
              break;
            case "weblio":
              this.sentencesList$ = this.store.getWeblioList(this.query(), this.page());
              break;
            case "tatoeba":
              this.sentencesList$ = this.store.getTatoebaList(this.query(), this.page());
              break;
          }
        }
      }
    );
  }

  search(e: Event) {
    this.setParams({'query': (e.target as HTMLInputElement).value, 'page': '1'});
  }

  switchSource(source: string) {
    this.setParams({'ssource': source, 'page': '1'});
  }

  previousPage() {
    this.setParams({page: (this.page() - 1).toString()});
  }

  nextPage() {
    this.setParams({page: (this.page() + 1).toString()});
  }

  private setParams(params: Params) {
    this.router.navigate(['.'], {
      queryParamsHandling: 'merge',
      relativeTo: this.route, queryParams: params
    });
  }
}
