import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { iPost } from '../models/i-post';
import { PostServiceService } from '../../services/post-service.service';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {
  post!: iPost;
  showSpinner = true;

  constructor(
    private route: ActivatedRoute,
    private postService: PostServiceService
  ) { }

ngOnInit(): void {
  this.showSpinner = true;  // Mostra lo spinner

  this.route.params.subscribe((params: any) => {
    setTimeout(() => {  // Aggiungi un timeout di 3 secondi
      const post = this.postService.getPostById(+params.id);
      if (post) {
        this.post = post;
      }
      this.showSpinner = false;  // Nascondi lo spinner
    }, 3000);
  });
}
}
