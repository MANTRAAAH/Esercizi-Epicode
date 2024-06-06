import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { AuthGuard } from './components/pages/auth/auth.guard';
import { GuestGuard } from './components/pages/auth/guest.guard';

const routes: Routes = [{ path: 'auth', loadChildren: () => import('./components/pages/auth/auth.module').then(m => m.AuthModule)},
{
  path: '',
  pathMatch: 'full',
  component: HomeComponent

},
{ path: 'dashboard', loadChildren: () => import('./components/pages/dahboard/dahboard.module').then(m => m.DahboardModule),canActivate:[AuthGuard],canActivateChild:[AuthGuard] },];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
