import {Component, input} from '@angular/core';
import {YomitanEntry} from '../../models/yomitan-entry.model';

@Component({
  selector: 'app-yomitan-list',
  templateUrl: './yomitan-list.component.html',
})
export class YomitanListComponent {
  wordsList = input.required<YomitanEntry[] | null>();
}
