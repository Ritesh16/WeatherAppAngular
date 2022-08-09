import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToDatetime'
})
export class ConvertToDatetimePipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): unknown {
    const date = new Date(value*1000);
    const output=date.toLocaleString("en-us");
    return output;
  }

}
