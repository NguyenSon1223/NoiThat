import { Component, OnInit } from '@angular/core';
import { Category } from '../../../models/category';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../../../layouts/layouts/navbar/navbar';
import { CategoryService } from '../../../services/category';

@Component({
  selector: 'app-category-list',
  imports: [CommonModule, NavbarComponent],
  standalone: true,
  templateUrl: './category-list.html',
  styleUrl: './category-list.css'
})
export class CategoryList implements OnInit{

  categories: Category [] = [];
  constructor(private categoryService: CategoryService){}

  ngOnInit(): void{
    this.categoryService.getAll().subscribe({
      next: (data) => {
        this.categories = data;
      },
      error: (err) => {
        console.error('Loi khi load danh muc ', err);
      }
    })
  }
}
