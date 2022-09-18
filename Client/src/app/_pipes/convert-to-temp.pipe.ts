import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToTemp'
})
export class ConvertToTempPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): string {
    return value + " °F";
  }

}
