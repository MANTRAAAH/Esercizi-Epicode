import { Component } from '@angular/core';
import { iPost } from '../models/i-post';
import { PostServiceService } from '../../services/post-service.service';

@Component({
  selector: 'app-inactive-posts',
  templateUrl: './inactive-posts.component.html',
  styleUrls: ['./inactive-posts.component.scss']
})
export class InactivePostsComponent {
  inactivePosts: iPost[] = [];

  constructor(private postService: PostServiceService) { }

  ngOnInit(): void {
      // prendo i post con la proprietà active a false dal servizio
    this.inactivePosts = this.postService.getInactivePosts();
  }
}
