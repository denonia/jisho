import {Component, Input, inject, OnChanges, SimpleChanges} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {WeblioList} from './weblio-list.model';

@Component({
  selector: 'app-weblio-list',
  templateUrl: './weblio-list.component.html',
})
export class WeblioListComponent {
  @Input({required: true})
  query: string;
  @Input()
  page: number = 1;

  result: WeblioList | undefined;
  entries: [string, string][] | undefined;

  http = inject(HttpClient);

  ngOnChanges(changes: SimpleChanges): void {
    if (this.query !== '') {
      this.loadWeblioList(this.query, this.page);
    }
  }

  loadWeblioList(query: string, page: number) {
    this.result = undefined;
    this.http.get<WeblioList>(`http://localhost:5284/weblio/sentences?query=${query}&page=${page}`)
      .subscribe(data => {
        this.result = data
        this.entries = Object.entries(this.result.entries);
      });
  }
}
