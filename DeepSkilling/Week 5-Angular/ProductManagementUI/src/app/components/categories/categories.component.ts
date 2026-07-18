import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-categories',
  standalone: false,
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent implements OnInit {
  categories: Category[] = [];
  
  // Modal state
  showModal = false;
  isEditMode = false;
  
  // Form model
  currentCategory: Category = {
    categoryId: 0,
    categoryName: '',
    description: ''
  };

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService.getCategories().subscribe(data => {
      this.categories = data;
    });
  }

  openAddModal(): void {
    this.isEditMode = false;
    this.currentCategory = {
      categoryId: 0,
      categoryName: '',
      description: ''
    };
    this.showModal = true;
  }

  openEditModal(category: Category): void {
    this.isEditMode = true;
    this.currentCategory = { ...category };
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
  }

  saveCategory(): void {
    if (!this.currentCategory.categoryName.trim()) {
      alert('Category Name is required.');
      return;
    }

    if (this.isEditMode) {
      this.categoryService.updateCategory(this.currentCategory).subscribe(() => {
        this.loadCategories();
        this.closeModal();
      });
    } else {
      this.categoryService.addCategory(this.currentCategory).subscribe(() => {
        this.loadCategories();
        this.closeModal();
      });
    }
  }

  deleteCategory(id: number): void {
    if (confirm('Are you sure you want to delete this category?')) {
      this.categoryService.deleteCategory(id).subscribe(success => {
        if (success) {
          this.loadCategories();
        } else {
          alert('Failed to delete category.');
        }
      });
    }
  }
}
