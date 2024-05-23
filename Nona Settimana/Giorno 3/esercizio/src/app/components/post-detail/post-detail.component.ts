import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { iPost } from '../models/i-post';
import { iData } from '../models/i-data';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {
  post!: iPost;
  showSpinner = false;



  constructor(
    private route: ActivatedRoute
  ) { }

ngOnInit(): void {
  this.route.params.subscribe((params: any) => {
    console.log(params);
    this.showSpinner = true; // Set to true before fetch

    fetch(`assets/db.json`)
      .then(response => response.json())
      .then((data: iData) => {

        console.log('ID to find:', params.id); // Print the ID to find

        // Try converting both IDs to the same type before comparing
        const post = data.posts.find((p: iPost) => String(p.id) === String(params.id));

        if (post) {
          // Hide the spinner and show the post after a delay
          setTimeout(() => {
            this.showSpinner = false;
            this.post = post;
          }, 2500);
        }
      });
  });
}
}
