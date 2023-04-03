import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryModel } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'https://localhost:44341/api/categories';

  constructor(private http: HttpClient) {}

  getCategories(): Observable<CategoryModel[]> {
    return this.http.get<CategoryModel[]>(this.apiUrl);
  }

  getCategory(id: number): Observable<CategoryModel> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<CategoryModel>(url);
  }

  addCategory(category: CategoryModel): Observable<CategoryModel> {
    return this.http.post<CategoryModel>(this.apiUrl, category);
  }

  updateCategory(category: CategoryModel): Observable<void> {
    const url = `${this.apiUrl}/${category.categoryID}`;
    return this.http.put<void>(url, category);
  }

  deleteCategory(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }
  getCategoryById(categoryId: number): Observable<CategoryModel> {
    const url = `${this.apiUrl}/${categoryId}`;
    return this.http.get<CategoryModel>(url);
  }
  createCategory(category: CategoryModel): Observable<CategoryModel> {
    return this.http.post<CategoryModel>(this.apiUrl, category);
  }
}
