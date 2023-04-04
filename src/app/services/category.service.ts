import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CategoryModel } from 'src/app/models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'api/categories';

  constructor(private http: HttpClient) {}

  getCategories(): Observable<CategoryModel[]> {
    return this.http
      .get<CategoryModel[]>(this.apiUrl)
      .pipe(catchError(this.handleError));
  }

  getCategoryById(id: number): Observable<CategoryModel> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<CategoryModel>(url).pipe(catchError(this.handleError));
  }

  addCategory(category: CategoryModel): Observable<CategoryModel> {
    return this.http
      .post<CategoryModel>(this.apiUrl, category)
      .pipe(catchError(this.handleError));
  }

  updateCategory(category: CategoryModel): Observable<any> {
    const url = `${this.apiUrl}/${category.categoryID}`;
    return this.http.put(url, category).pipe(catchError(this.handleError));
  }

  deleteCategory(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Ocurrió un error al realizar la solicitud.';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Error: ${error.error.message}`;
    } else if (error.status === 404) {
      errorMessage = 'No se encontraron resultados.';
    }
    return throwError(errorMessage);
  }
}
