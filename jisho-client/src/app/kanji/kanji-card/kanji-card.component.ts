import {Component, Input} from '@angular/core';
import {KanjiEntry} from '../../models/kanji-entry.model';

@Component({
  selector: 'app-kanji-card',
  templateUrl: './kanji-card.component.html',
  styleUrl: 'kanji-card.component.css'
})
export class KanjiCardComponent {
  @Input({required: true})
  kanji: KanjiEntry;

  onReadings() {
    return this.kanji.readings.filter(r => r.type.code === 'ja_on');
  }

  kunReadings() {
    return this.kanji.readings.filter(r => r.type.code === 'ja_kun');
  }

  otherReadings() {
    const nonJapReadings = ["pinyin", "korean_h", "vietnam"];
    return this.kanji.readings.filter(r => nonJapReadings.includes(r.type.code))
  }

  countryFlagClass(code: string) {
    if (code == 'en') code = 'gb';
    if (code == 'sv') code = 'se';
    if (code == 'sl') code = 'si';
    return `fi fi-${code}`;
  }

  readingCountryCode(type: string) {
    const types: Record<string, string> = {
      'pinyin': 'cn',
      'korean_h': 'kr',
      'vietnam': 'vn',
    };
    return types[type];
  }
}
