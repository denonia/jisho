import {Component, computed, inject, OnInit, signal} from '@angular/core';
import {DesuApiService} from '../../services/desu-api.service';
import {Observable} from "rxjs";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {KanjiEntry} from '../../models/kanji-entry.model';

@Component({
  selector: 'app-kanji-search-page',
  templateUrl: './kanji-search-page.component.html',
})
export class KanjiSearchPageComponent implements OnInit {
  query = signal('');
  radicals = signal('');
  radicalsArr = computed(() => this.radicals().split('+').filter(x => x !== ''));

  api = inject(DesuApiService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  radicals$: Observable<string[]>;
  kanjiList$: Observable<KanjiEntry[]>;

  ngOnInit(): void {
    this.radicals$ = this.api.getRadicalsList();

    this.route.queryParams.subscribe(params => {
      this.query.set(params['query'] ?? '');
      this.radicals.set(params['radicals'] ?? '');

      if (this.query() || this.radicals()) {
        this.kanjiList$ = this.api.getKanjiList(this.query(), this.radicals());
      }
    });
  }

  isRadicalOn(radical: string) {
    return this.radicals().includes(radical);
  }

  switchRadical(radical: string) {
    if (this.isRadicalOn(radical))
      this.radicalsArr().splice(this.radicalsArr().indexOf(radical), 1);
    else
      this.radicalsArr().push(radical);
    this.setParams({'radicals': this.radicalsArr().join('+')});
  }

  search(e: Event) {
    this.setParams({'query': (e.target as HTMLInputElement).value});
  }

  private setParams(params: Params) {
    this.router.navigate(['.'], {
      queryParamsHandling: 'merge',
      relativeTo: this.route, queryParams: params
    });
  }
}
