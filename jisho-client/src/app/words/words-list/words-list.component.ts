import {Component, inject, input, ViewEncapsulation} from '@angular/core';
import {DomSanitizer, SafeHtml} from "@angular/platform-browser";
import { TemplateService } from '../../services/template.service';
import { DictionaryEntry } from '../../models/dictionary-entry.model';

@Component({
  selector: 'app-words-list',
  templateUrl: './words-list.component.html',
  styleUrl: './words-list.component.css',
  encapsulation: ViewEncapsulation.ShadowDom
})
export class WordsListComponent {
  wordsList = input.required<DictionaryEntry[] | null>();

  template = inject(TemplateService);
  sanitizer = inject(DomSanitizer);

  renderDefinitions(definitions: any[]): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(this.template.renderArray(definitions));
  }
}
