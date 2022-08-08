import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToHg'
})
export class ConvertToHgPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): unknown {
    const pressueInHg = Math.round(value * 0.02953) + ' Hg'; 
    return  pressueInHg;
  }

}
