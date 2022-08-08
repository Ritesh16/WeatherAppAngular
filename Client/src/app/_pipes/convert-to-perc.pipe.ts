import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToPerc'
})
export class ConvertToPercPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return value + " %";
  }

}
