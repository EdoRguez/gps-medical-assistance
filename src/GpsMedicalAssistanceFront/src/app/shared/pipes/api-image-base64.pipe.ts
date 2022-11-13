import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'apiImageBase64'
})
export class ApiImageBase64Pipe implements PipeTransform {

  transform(value: string | undefined): string | null {
    return value ? 'data:image/jpeg;base64,' + value : null;
  }

}
