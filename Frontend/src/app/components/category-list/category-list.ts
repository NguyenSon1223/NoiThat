import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/category';
import { CategoryService } from '../../services/category';
import { NgForm } from '@angular/forms';
import { NgModel } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-category-list',
  imports: [CommonModule],
  templateUrl: './category-list.html',
  styleUrl: './category-list.css'
})
export class CategoryListComponent implements OnInit {

  categories: Category[] = [];
  constructor(private categoryService: CategoryService){}

  ngOnInit(): void {
    console.log('CategoryComponent loaded');
    this.categoryService.getAll().subscribe(data => {
      this.categories = data;
    });
  }

}
