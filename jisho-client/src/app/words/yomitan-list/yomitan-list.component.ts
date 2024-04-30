import {Component, inject, input, ViewEncapsulation} from '@angular/core';
import {DomSanitizer, SafeHtml} from "@angular/platform-browser";
import { TemplateService } from '../../services/template.service';
import { YomitanEntry } from '../../models/yomitan-entry.model';

@Component({
  selector: 'app-yomitan-list',
  templateUrl: './yomitan-list.component.html',
  styleUrl: './yomitan-list.component.css',
  encapsulation: ViewEncapsulation.ShadowDom
})
export class YomitanListComponent {
  wordsList = input.required<YomitanEntry[] | null>();

  template = inject(TemplateService);
  sanitizer = inject(DomSanitizer);

  renderDefinitions(definitions: any[]): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(this.template.renderArray(definitions));
  }
}
