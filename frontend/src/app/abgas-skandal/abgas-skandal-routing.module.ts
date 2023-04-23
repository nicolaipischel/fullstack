import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OverviewComponent } from './overview/overview.component';
import { CaseComponent } from './case/case.component';
import { AbgasSkandalComponent } from './abgas-skandal.component';

const routes: Routes = [
  {
    path: '', component: AbgasSkandalComponent,
    children: [
      { path: '', component: OverviewComponent },
      { path: 'faelle/neu', component: CaseComponent },
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AbgasSkandalRoutingModule { }
