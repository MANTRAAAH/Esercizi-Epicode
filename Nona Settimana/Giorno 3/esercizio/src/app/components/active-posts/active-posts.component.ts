import { Component } from '@angular/core';
import { iPost } from '../models/i-post';

@Component({
  selector: 'app-active-posts',
  templateUrl: './active-posts.component.html',
  styleUrls: ['./active-posts.component.scss']
})
export class ActivePostsComponent {
  activePosts: iPost[] = [];

  constructor() { }
ngOnInit(): void {
  fetch('../../../assets/db.json')
    .then(response => response.json())
    .then(data => {
      this.activePosts = data.posts.filter((post: iPost) => post.active);
    });
}
}
