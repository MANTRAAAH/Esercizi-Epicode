import { iPost } from '../models/i-post';
import { iData } from '../models/i-data';
import { Router } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  dbUrl = '../../../assets/db.json';
  postArray: iPost[] = [];
  randomPosts: iPost[] = [];
  featuredPost: iPost= {} as iPost;
  constructor(private router: Router) { }

  ngOnInit() {
    this.getPosts().then(() => {
      this.randomPosts = this.getRandomPosts(10);
      this.featuredPost = this.getRandomPosts(1)[0];
    });
  }
  goToPostDetail(): void {
    this.router.navigate(['/post-detail', this.featuredPost.id]);
  }
  async getPosts(): Promise<void> {
    const response = await fetch(this.dbUrl);
    const data: iData = await response.json();
    this.postArray = data.posts;
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
}
