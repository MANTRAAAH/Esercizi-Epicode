import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'cutter'
})
export class CutterPipe implements PipeTransform {

  transform(value: string): string {
    return value.substring(0, 100) + '...';
  }

}
