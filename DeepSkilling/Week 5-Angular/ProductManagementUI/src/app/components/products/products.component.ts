import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CategoryService } from '../../services/category.service';
import { Product } from '../../models/Product';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-products',
  standalone: false,
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];
  filteredProducts: Product[] = [];
  categories: Category[] = [];
  categoriesMap: { [key: number]: string } = {};
  
  // Filter state
  selectedCategoryId: number | string = 'all';

  // Modal state
  showModal = false;
  isEditMode = false;

  // Form model
  currentProduct: Product = {
    productId: 0,
    name: '',
    price: 0,
    stock: 0,
    categoryId: 0
  };

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    // Load categories first
    this.categoryService.getCategories().subscribe(cats => {
      this.categories = cats;
      this.categoriesMap = {};
      cats.forEach(c => {
        this.categoriesMap[c.categoryId] = c.categoryName;
      });

      // Load products
      this.productService.getProducts().subscribe(prods => {
        this.products = prods;
        this.applyFilter();
      });
    });
  }

  applyFilter(): void {
    if (this.selectedCategoryId === 'all') {
      this.filteredProducts = [...this.products];
    } else {
      const catId = Number(this.selectedCategoryId);
      this.filteredProducts = this.products.filter(p => p.categoryId === catId);
    }
  }

  getCategoryName(categoryId: number): string {
    return this.categoriesMap[categoryId] || 'Unknown';
  }

  openAddModal(): void {
    this.isEditMode = false;
    this.currentProduct = {
      productId: 0,
      name: '',
      price: 0,
      stock: 0,
      categoryId: this.categories.length > 0 ? this.categories[0].categoryId : 0
    };
    this.showModal = true;
  }

  openEditModal(product: Product): void {
    this.isEditMode = true;
    this.currentProduct = { ...product };
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
  }

  saveProduct(): void {
    if (!this.currentProduct.name.trim()) {
      alert('Product Name is required.');
      return;
    }
    if (this.currentProduct.price < 0) {
      alert('Price cannot be negative.');
      return;
    }
    if (this.currentProduct.stock < 0) {
      alert('Stock cannot be negative.');
      return;
    }
    if (!this.currentProduct.categoryId) {
      alert('Category is required.');
      return;
    }

    // Convert inputs to proper numbers
    this.currentProduct.price = Number(this.currentProduct.price);
    this.currentProduct.stock = Number(this.currentProduct.stock);
    this.currentProduct.categoryId = Number(this.currentProduct.categoryId);

    if (this.isEditMode) {
      this.productService.updateProduct(this.currentProduct).subscribe(() => {
        this.loadData();
        this.closeModal();
      });
    } else {
      this.productService.addProduct(this.currentProduct).subscribe(() => {
        this.loadData();
        this.closeModal();
      });
    }
  }

  deleteProduct(id: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(id).subscribe(success => {
        if (success) {
          this.loadData();
        } else {
          alert('Failed to delete product.');
        }
      });
    }
  }
}
