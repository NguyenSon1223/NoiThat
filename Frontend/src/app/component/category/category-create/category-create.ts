import { Component } from '@angular/core';
import { Category } from '../../../models/category';
import { CategoryService } from '../../../services/category';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-category-create',
  imports: [CommonModule, FormsModule],
  templateUrl: './category-create.html',
  styleUrl: './category-create.css'
})
export class CategoryCreate {


  category: Category= {
    id: 0,
    name: '',
    displayOrder: 0
  };

  errorMessage: string = '';
  
  constructor(private categoryService: CategoryService, public router: Router){}

  createCategory() {
    if (!this.category.name.trim()) {
      this.errorMessage = 'Ten danh muc khong duoc de trong';
      return;
    }

    this.categoryService.create(this.category).subscribe({
      next:() => this.router.navigate(['/category']),
      error: err => {
        if (err.status === 400) {
          this.errorMessage = err.error;
        }
        else {
          this.errorMessage = 'Da xay ra loi khi tao danh muc ';
        }
      }
    });
  }

   goBack() {
    this.router.navigate(['/category']);
  }
}
