
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
  selectedTag!: string
  tags: string[] = [];

  post!: iPost;
  featuredPost: any;

  constructor(private postService: PostServiceService, private router: Router) { }
    //prendo i post dal service
  ngOnInit(): void {
    this.postArray = this.postService.getPosts.slice(0, 10);
    this.tags = this.postService.getUniqueTags(this.postArray);
    this.featuredPost = this.postService.getOneRandom();
  }

  //modifica, per ora, solo il titolo, ma ovviamente non salva ancora internamente la modifica, aggiunto un feedback visivo
 onSubmit(form: NgForm): void {
  const updatedPost: iPost = {
    ...this.post,
    ...form.value
  };
  this.postService.updatePost(updatedPost);
  alert('Modifica salvata');
}



 //prendo i tag dal servizio e filtro i post in base al tag selezionato
  filterPostsByTag(tag: string): void {
    this.selectedTag = tag;
    this.postArray = this.postService.getPostsByTag(tag);
  }
  //resetto il filtro
  resetFilter(): void {
    this.selectedTag!;
    this.postArray = this.postService.getPosts;
  }
    //vado al dettaglio del post tramite id
  goToPostDetail(post: iPost): void {
    this.router.navigate(['/post-detail', post.id]);
  }
}
