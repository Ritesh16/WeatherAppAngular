import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToDateString'
})
export class ConvertToDateStringPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): unknown {
    const date = new Date(value*1000);
    //const output=date.toLocaleDateString("en-US");
    return date.toDateString();
  }

}
