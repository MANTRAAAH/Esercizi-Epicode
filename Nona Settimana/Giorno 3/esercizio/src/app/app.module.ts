import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { PostDetailComponent } from './components/post-detail/post-detail.component';
import { ActivePostsComponent } from './components/active-posts/active-posts.component';
import { InactivePostsComponent } from './components/inactive-posts/inactive-posts.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { Page404Component } from './components/page404/page404.component';
import { SinglePostComponent } from './components/single-post/single-post.component';
import { FormsModule } from '@angular/forms';
import { PostServiceService } from './services/post-service.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PostDetailComponent,
    ActivePostsComponent,
    InactivePostsComponent,
    NavbarComponent,
    FooterComponent,
    Page404Component,
    SinglePostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [PostServiceService],
  bootstrap: [AppComponent]

})
export class AppModule { }
