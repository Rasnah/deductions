import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NameInputComponent } from './name-input/name-input.component';

@NgModule({
  imports: [CommonModule],
  declarations: [NameInputComponent],
  exports: [NameInputComponent]
})

export class InputsModule {}
