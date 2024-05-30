import { Component, OnInit } from '@angular/core';
import { PhotosService } from '../../../service/photos.service';
import { iPhoto } from '../../../models/photo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  photos!: iPhoto[];
  likes = 0
  constructor(private photosService: PhotosService) { }

  ngOnInit(): void {
    this.photosService.getPhotos().subscribe(photos => this.photos = photos);
    this.photosService.likesChange.subscribe(change => this.likes += change);
  }
  onPhotoDeleted(id: number): void {
    this.photos = this.photos.filter(photo => photo.id !== id);
  }
}
