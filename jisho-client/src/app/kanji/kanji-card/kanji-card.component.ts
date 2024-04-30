import {Component, Input} from '@angular/core';
import {KanjiEntry} from '../../models/kanji-entry.model';

@Component({
  selector: 'app-kanji-card',
  templateUrl: './kanji-card.component.html',
})
export class KanjiCardComponent {
  @Input({required: true})
  kanji: KanjiEntry;

  countryFlagUrl(code: string) {
    if (code == 'en') code = 'gb';
    return `http://purecatamphetamine.github.io/country-flag-icons/3x2/${code.toUpperCase()}.svg`;
  }

  onReadings() {
    return this.kanji.readings.filter(r => r.type.code === 'ja_on');
  }

  kunReadings() {
    return this.kanji.readings.filter(r => r.type.code === 'ja_kun');
  }

  readingDisplayName(type: string) {
    const types: Record<string, string> = {
      'pinyin': 'Chinese',
      'korean_r': 'Korean',
      'korean_h': 'Korean',
      'vietnam': 'Vietnamese',
      'ja_on': 'On',
      'ja_kun': 'Kun'
    };
    return types[type];
  }
}
