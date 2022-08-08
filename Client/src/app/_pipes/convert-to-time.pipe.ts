import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToTime'
})
export class ConvertToTimePipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): unknown {
    const date = new Date(value*1000);
    const output=date.toLocaleTimeString("en-US");
        return output;
      }
}
