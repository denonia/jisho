import {Component, computed, input} from '@angular/core';
import { WeblioList } from '../../models/weblio-list.model';

@Component({
  selector: 'app-weblio-list',
  templateUrl: './weblio-list.component.html',
})
export class WeblioListComponent {
  weblioList = input.required<WeblioList | null>();

  entries = computed(() => Object.entries(this.weblioList()!.entries));
}
