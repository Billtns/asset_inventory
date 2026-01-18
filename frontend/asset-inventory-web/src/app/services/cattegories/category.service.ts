import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Category } from '../../models/category.model';
import { ResponseModel } from '../../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = `${environment.apiUrl}/Categories`;

  constructor(private http: HttpClient) { }

  // GET: list
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}/Get`);
  }

  // GET: by id
  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}/GetById/${id}`);
  }

  // POST: create
  createCategory(data: Partial<Category>): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(`${this.apiUrl}/Create`, data);
  }

  // PUT: update
  updateCategory(data: Partial<Category>): Observable<ResponseModel> {
    return this.http.put<ResponseModel>(`${this.apiUrl}/Update`, data);
  }

  // DELETE
  deleteCategory(id: number): Observable<ResponseModel> {
    return this.http.delete<ResponseModel>(`${this.apiUrl}/Delete/${id}`);
  }
}
