import {Component, computed, input, signal} from '@angular/core';
import {JmdictEntry} from '../../models/jmdict-entry.model';

@Component({
  selector: 'app-jmdict-card',
  templateUrl: './jmdict-card.component.html',
  styleUrl: './jmdict-card.component.css'
})
export class JmdictCardComponent {
  entry = input.required<JmdictEntry>();

  collapsed = signal(true);

  primaryReading = computed(() =>
    this.entry().kanjis.length !== 0 ? this.entry().kanjis[0].text : this.entry().readings[0].text);

  alternativeForms = computed(() =>
    this.entry().kanjis.map(k => k.text).slice(1).join(', '));

  readingList = computed(() =>
    this.entry().readings.map(k => k.text).join(', '));

  englishSenses = computed(() => this.entry().senses
    .filter(s => s.glosses[0].language.twoLetterCode === 'en'));

  otherSenses = computed(() => this.entry().senses
    .filter(s => s.glosses[0].language.twoLetterCode !== 'en'));

  senses = computed(() =>
    this.collapsed() ? this.englishSenses()
      : this.englishSenses().concat(this.otherSenses()));

  countryFlagClass(code: string) {
    if (code == 'en') code = 'gb';
    if (code == 'sv') code = 'se';
    if (code == 'sl') code = 'si';
    return `fi fi-${code}`;
  }
}
