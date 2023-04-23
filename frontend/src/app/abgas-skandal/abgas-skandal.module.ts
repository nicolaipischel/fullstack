import { NgModule } from '@angular/core';
import { AbgasSkandalComponent } from './abgas-skandal.component';
import { OverviewComponent } from './overview/overview.component';
import { CaseComponent } from './case/case.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { AbgasSkandalRoutingModule } from './abgas-skandal-routing.module';

@NgModule({
  declarations: [
    AbgasSkandalComponent,
    OverviewComponent,
    CaseComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AbgasSkandalRoutingModule
  ]
})
export class AbgasSkandalModule { }
