import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { iPhoto } from '../../../models/photo';
import { PhotosService } from '../../../service/photos.service';

@Component({
  selector: 'app-single-photo',
  templateUrl: './single-photo.component.html',
  styleUrls: ['./single-photo.component.scss']
})
export class SinglePhotoComponent implements OnInit {
  @Input() photo!: iPhoto;
  @Output() photoDeleted = new EventEmitter<number>();
  liked = false;

  constructor(private photosService: PhotosService) { }

  ngOnInit(): void {
  }
  likePhoto(): void {
    if (!this.photo.liked) {
      this.photosService.likePhoto();
      this.photo.liked = true;
    } else {
      this.photosService.unlikePhoto();
      this.photo.liked = false;
    }
  }
  deletePhoto(): void {
    this.photosService.deletePhoto(this.photo.id).subscribe(() => {
      this.photoDeleted.emit(this.photo.id);
    });
  }
}
