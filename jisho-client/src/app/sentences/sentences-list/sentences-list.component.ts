import {Component, computed, input} from '@angular/core';
import { SentencesList } from '../../models/sentences-list.model';

@Component({
  selector: 'app-sentences-list',
  templateUrl: './sentences-list.component.html',
})
export class SentencesListComponent {
  sentencesList = input.required<SentencesList | null>();

  entries = computed(() => Object.entries(this.sentencesList()!.entries));
}
