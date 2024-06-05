import { AuthGuard } from './components/auth/auth.guard';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuestGuard } from './components/auth/guest.guard';

const routes: Routes = [{
  path:"",loadChildren:()=>import('../app/components/pages/home/home.module').then(m=>m.HomeModule),pathMatch:'full'
},{
  path:"home",
  pathMatch:'full',
  redirectTo:''
}
  ,{
  path: 'auth', loadChildren: () => import('../app/components/auth/auth.module').then(m => m.AuthModule),
  canActivate: [GuestGuard],
  canActivateChild: [GuestGuard]},
  { path: 'dashboard', loadChildren: () => import('./components/pages/dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard]
   },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
