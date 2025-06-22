import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = 'http://localhost:5000/api/category';

  constructor(private http: HttpClient){}

  // Ket noi toi HTTP Get Lay tat ca cua Category
  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  // Ket noi toi HTTP Post cua Category
  create(category: Category): Observable<any>{
    return this.http.post(`${this.apiUrl}`, category);
  }

  
} 
