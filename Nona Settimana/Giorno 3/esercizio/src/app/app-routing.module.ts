
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ActivePostsComponent } from './components/active-posts/active-posts.component';
import { InactivePostsComponent } from './components/inactive-posts/inactive-posts.component';
import { PostDetailComponent } from './components/post-detail/post-detail.component';

const routes: Routes = [
  {
    path:'',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
  path: 'home',
  component: HomeComponent
}, {
  path: 'active-posts',
  component: ActivePostsComponent
}, {
  path: 'inactive-posts',
  component: InactivePostsComponent
},
{
  path: 'post-detail',
  component: PostDetailComponent
},
{
  path: 'post-detail/:id',
  component: PostDetailComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
