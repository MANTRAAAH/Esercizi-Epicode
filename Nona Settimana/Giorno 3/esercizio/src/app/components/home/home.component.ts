import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { iPost } from '../models/i-post';
import { PostServiceService } from '../../services/post-service.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  postArray: iPost[] = [];
  randomPosts: iPost[] = [];
  featuredPost: iPost = {} as iPost;

  constructor(private router: Router, private postService: PostServiceService) { }

  ngOnInit(): void {
    this.postArray = this.postService.getPosts;
    this.randomPosts = this.getRandomPosts(10);
    this.featuredPost = this.getRandomPosts(1)[0];
  }

  goToPostDetail(): void {
    this.router.navigate(['/post-detail', this.featuredPost.id]);
  }

  getRandomPosts(n: number): iPost[] {
    const randomIndices = this.getRandomIndices(n, this.postArray.length);
    return randomIndices.map(index => this.postArray[index]);
  }

  getRandomIndices(n: number, max: number): number[] {
    const indices = new Set<number>();
    while (indices.size < n) {
      indices.add(Math.floor(Math.random() * max));
    }
    return Array.from(indices);
  }
  onSubmit(post: iPost, form: NgForm): void {
    post.title = form.value.title;
    alert('Modifica salvata');
  }

}
