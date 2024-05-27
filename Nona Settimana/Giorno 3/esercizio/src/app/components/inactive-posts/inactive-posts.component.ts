import { Component } from '@angular/core';
import { iPost } from '../models/i-post';
import { PostServiceService } from '../../services/post-service.service';

@Component({
  selector: 'app-inactive-posts',
  templateUrl: './inactive-posts.component.html',
  styleUrl: './inactive-posts.component.scss'
})
export class InactivePostsComponent {
  inactivePosts: iPost[] = [];

  constructor(private postService: PostServiceService) { }

ngOnInit(): void {
  this.inactivePosts = this.postService.getPosts.filter((post: iPost) => post.active === false);
}
}
