import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from '../models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private categories: Category[] = [
    { categoryId: 101, categoryName: 'Electronics', description: 'Gadgets, devices, and accessories' },
    { categoryId: 102, categoryName: 'Books', description: 'Educational and fiction books' },
    { categoryId: 103, categoryName: 'Clothing', description: 'Apparel for men, women, and children' }
  ];

  constructor() { }

  getCategories(): Observable<Category[]> {
    return of([...this.categories]);
  }

  getCategoryById(id: number): Observable<Category | undefined> {
    const category = this.categories.find(c => c.categoryId === id);
    return of(category ? { ...category } : undefined);
  }

  addCategory(category: Category): Observable<Category> {
    const nextId = this.categories.length > 0 ? Math.max(...this.categories.map(c => c.categoryId)) + 1 : 101;
    const newCategory = { ...category, categoryId: nextId };
    this.categories.push(newCategory);
    return of(newCategory);
  }

  updateCategory(category: Category): Observable<Category> {
    const index = this.categories.findIndex(c => c.categoryId === category.categoryId);
    if (index !== -1) {
      this.categories[index] = { ...category };
    }
    return of({ ...category });
  }

  deleteCategory(id: number): Observable<boolean> {
    const index = this.categories.findIndex(c => c.categoryId === id);
    if (index !== -1) {
      this.categories.splice(index, 1);
      return of(true);
    }
    return of(false);
  }
}
