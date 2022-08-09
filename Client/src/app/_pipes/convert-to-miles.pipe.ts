import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToMiles'
})
export class ConvertToMilesPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): unknown {
    return Math.round(value * 0.000621371) + ' miles';
  }

}
