import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, Subject, map } from 'rxjs';
import { catchError } from 'rxjs';
import{throwError} from 'rxjs';
import { iPhoto } from '../models/photo';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {
  private apiUrl = 'https://jsonplaceholder.typicode.com/photos';
  likesChange = new Subject<number>();

  constructor(private http: HttpClient) { }

getPhotos(): Observable<iPhoto[]> {
  return this.http.get<iPhoto[]>(this.apiUrl).pipe(
    map(photos => photos.slice(0, 50)), // Limita il numero di foto, eventualmente possiamo gestirlo dinamicamente
    catchError(this.handleError)
  );
}

deletePhoto(id: number): Observable<{}> {
  const url = `${this.apiUrl}/${id}`;
  return this.http.delete<{}>(url).pipe(
    catchError(this.handleError)
  );
}
likePhoto(): void {
  this.likesChange.next(1);
}
unlikePhoto(): void {
  this.likesChange.next(-1);
}

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'ERRORE!';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Errore: ${error.error.message}`;
    } else {
      errorMessage = `Codice Errore: ${error.status} Descrizione: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => new Error(errorMessage));
  }

}
