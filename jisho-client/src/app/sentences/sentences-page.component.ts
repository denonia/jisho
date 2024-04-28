import { Component } from '@angular/core';

@Component({
  templateUrl: './sentences-page.component.html',
})
export class SentencesPageComponent {
  query: string = '';
  page: number = 1;
}
