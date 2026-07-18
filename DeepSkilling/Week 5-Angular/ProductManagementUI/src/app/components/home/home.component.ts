import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CategoryService } from '../../services/category.service';
import { Product } from '../../models/Product';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  totalProducts = 0;
  totalCategories = 0;
  outOfStockCount = 0;
  lowStockCount = 0;
  recentProducts: Product[] = [];
  categoriesMap: { [key: number]: string } = {};

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.categoryService.getCategories().subscribe(categories => {
      this.totalCategories = categories.length;
      categories.forEach(cat => {
        this.categoriesMap[cat.categoryId] = cat.categoryName;
      });

      this.productService.getProducts().subscribe(products => {
        this.totalProducts = products.length;
        this.outOfStockCount = products.filter(p => p.stock <= 0).length;
        this.lowStockCount = products.filter(p => p.stock > 0 && p.stock <= 10).length;
        this.recentProducts = [...products]
          .sort((a, b) => b.productId - a.productId)
          .slice(0, 3);
      });
    });
  }

  getCategoryName(categoryId: number): string {
    return this.categoriesMap[categoryId] || 'Unknown';
  }
}
