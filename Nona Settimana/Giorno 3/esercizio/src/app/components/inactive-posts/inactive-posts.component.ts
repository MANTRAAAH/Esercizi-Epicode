import { Component } from '@angular/core';
import { iPost } from '../models/i-post';

@Component({
  selector: 'app-inactive-posts',
  templateUrl: './inactive-posts.component.html',
  styleUrl: './inactive-posts.component.scss'
})
export class InactivePostsComponent {
  inactivePosts: iPost[] = [];

  constructor() { }
ngOnInit(): void {
  fetch('../../../assets/db.json')
    .then(response => response.json())
    .then(data => {
      this.inactivePosts = data.posts.filter((post: iPost) => post.active === false);
    });
}
}
