import { Component, OnInit } from '@angular/core';
import { iPost } from '../models/i-post';
import { PostServiceService } from '../../services/post-service.service';

@Component({
  selector: 'app-active-posts',
  templateUrl: './active-posts.component.html',
  styleUrls: ['./active-posts.component.scss']
})
export class ActivePostsComponent implements OnInit {
  activePosts: iPost[] = [];

  constructor(private postService: PostServiceService) { }
  // prendo i post con la proprietà active a true dal servizio
  ngOnInit(): void {
    this.activePosts = this.postService.getActivePosts();
  }
}
