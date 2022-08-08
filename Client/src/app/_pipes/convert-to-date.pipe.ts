import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'convertToDate'
})
export class ConvertToDatePipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): string {
const date = new Date(value*1000);
const output=date.toLocaleDateString("en-US");
    return output;
  }

}
