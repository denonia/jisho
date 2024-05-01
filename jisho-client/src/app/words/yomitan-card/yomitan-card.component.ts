import {Component, inject, Input, ViewEncapsulation} from '@angular/core';
import { YomitanEntry } from '../../models/yomitan-entry.model';
import {DomSanitizer, SafeHtml} from "@angular/platform-browser";
import { TemplateService } from '../../services/template.service';

@Component({
  selector: 'app-yomitan-card',
  templateUrl: './yomitan-card.component.html',
  styleUrl: './yomitan-card.component.css',
  encapsulation: ViewEncapsulation.ShadowDom
})
export class YomitanCardComponent {
  @Input({ required: true})
  entry: YomitanEntry;


  template = inject(TemplateService);
  sanitizer = inject(DomSanitizer);

  renderDefinitions(definitions: any[]): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(this.template.renderArray(definitions));
  }
}
