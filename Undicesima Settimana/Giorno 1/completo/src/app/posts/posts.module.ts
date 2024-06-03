import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivePostsComponent } from './active-posts/active-posts.component';
import { InactivePostsComponent } from './inactive-posts/inactive-posts.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { RouterModule } from '@angular/router';
import { PostsRoutingModule } from './posts-routing.module';



@NgModule({
  declarations: [
    ActivePostsComponent,
    InactivePostsComponent,
    PostDetailComponent,
  ],
  imports: [
    CommonModule,
    PostsRoutingModule
  ]
})
export class PostsModule { }
