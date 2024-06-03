import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { Route, RouterModule } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { FormsModule } from '@angular/forms';
import { RandomColorDirective } from 'src/directives/randomColor.directive';
import { PostsModule } from './posts/posts.module';
import { SinglePostComponent } from './single-post/single-post.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomepageComponent,
    SinglePostComponent
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, RandomColorDirective,PostsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
