import {Component, inject, signal} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {StoreService} from '../services/store.service';
import {Observable} from "rxjs";
import {WeblioList} from '../models/weblio-list.model';

@Component({
  templateUrl: './sentences-page.component.html',
})
export class SentencesPageComponent {
  query = signal('');
  page = signal(1);

  store = inject(StoreService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  weblioList$!: Observable<WeblioList>;

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
        if ('query' in params)
          this.query.set(params['query']);
        if (this.query() != '')
          this.weblioList$ = this.store.getWeblioList(this.query(), this.page());
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
