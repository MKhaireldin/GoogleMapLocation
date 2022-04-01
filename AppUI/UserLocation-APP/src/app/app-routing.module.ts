import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserlocationComponent } from './userlocation/userlocation.component';

const routes: Routes = [
  {path:'userlocation',component:UserlocationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
