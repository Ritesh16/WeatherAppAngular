import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToTime'
})
export class ConvertToTimePipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): unknown {
      const date = new Date(value*1000);
      const time=date.toLocaleTimeString("en-US");
      const output = time.split(':');
      const type = output[2].split(' ');

      return output[0] + ':' + output[1] + ' ' + type[1];
    }
}
