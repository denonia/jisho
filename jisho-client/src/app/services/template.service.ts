import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TemplateService {
  constructor() {
  }

  renderArray(structure: any[]): string {
    let result = '';

    for (let node of structure)
      result += this.renderNode(node);
    return result;
  }

  renderNode(node: any): string {
    if (Array.isArray(node))
      return this.renderArray(node);
    if (typeof node !== 'object')
      return node;

    let result = '';

    result += `<${node.tag ?? node.type ?? console.log(node)}`;

    for (let prop in node) {
      switch (prop) {
        case 'style':
          result += " style='";
          for (let key in node.style) {
            result += `${this.kebabize(key)}:${node.style[key]};`;
          }
          result += "'";
          break;
        case 'data':
          for (let key in node.data) {
            result += ` ${key}="${node.data[key]}"`;
          }
          break;
        case 'title':
        case 'href':
        case 'lang':
          result += ` ${prop}="${node[prop]}"`;
          break;
        case 'tag':
        case 'type':
        case 'content':
          break;
        default:
          console.log(`unknown property: ${prop}`)
          console.log(node)
          break;
      }
    }

    result += '>';

    if ('content' in node) {
      result += this.renderNode(node.content);
    }

    result += `</${node.tag ?? node.type}>`;

    return result;
  }

  private kebabize(str: string) {
    return str.replace(/[A-Z]+(?![a-z])|[A-Z]/g, ($, ofs) => (ofs ? "-" : "") + $.toLowerCase())
  }
}
