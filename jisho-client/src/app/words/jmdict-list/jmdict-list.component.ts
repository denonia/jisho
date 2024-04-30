import {Component, input} from '@angular/core';
import { JmdictEntry } from '../../models/jmdict-entry.model';

@Component({
  selector: 'app-jmdict-list',
  templateUrl: './jmdict-list.component.html',
  styleUrl: './jmdict-list.component.css'
})
export class JmdictListComponent {
  wordsList = input.required<JmdictEntry[] | null>();
}
