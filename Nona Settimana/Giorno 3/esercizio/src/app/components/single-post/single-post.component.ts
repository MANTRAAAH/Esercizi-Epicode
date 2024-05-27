import { Component, Input, OnInit } from '@angular/core';
import { iPost } from '../models/i-post';

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.scss']
})
export class SinglePostComponent implements OnInit {
  @Input() post!: iPost;
  showForm = false;
  active!: boolean;
  postService: any;

  constructor() { }

  ngOnInit(): void {
    this.active = this.postService?.active;
  }
}
