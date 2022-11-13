import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiImageBase64Pipe } from './api-image-base64.pipe';

@NgModule({
    declarations: [ApiImageBase64Pipe],
    exports: [ApiImageBase64Pipe],
})
export class GlobalPipesModule {}
