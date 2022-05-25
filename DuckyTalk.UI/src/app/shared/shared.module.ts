import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { SliceWordsPipe } from './helper/slice-words.pipe';



@NgModule({
  declarations: [SpinnerComponent, SliceWordsPipe],
  imports: [
    CommonModule
  ],
  exports: [SpinnerComponent, SliceWordsPipe]
})
export class SharedModule { }
