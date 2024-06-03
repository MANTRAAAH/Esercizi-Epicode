import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ActivePostsComponent } from './active-posts/active-posts.component';
import { InactivePostsComponent } from './inactive-posts/inactive-posts.component';
import { PostDetailComponent } from './post-detail/post-detail.component';

const routes: Routes = [
  { path: 'active', component: ActivePostsComponent },
  { path: 'inactive', component: InactivePostsComponent },
  {path: 'post/:id', component: PostDetailComponent}
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PostsRoutingModule { }
