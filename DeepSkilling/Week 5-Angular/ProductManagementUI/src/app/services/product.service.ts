import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private products: Product[] = [
    { productId: 1, name: 'Smartphone Pro', price: 999.99, stock: 25, categoryId: 101 },
    { productId: 2, name: 'Wireless Headphones', price: 149.99, stock: 50, categoryId: 101 },
    { productId: 3, name: 'Angular in Action', price: 44.99, stock: 15, categoryId: 102 },
    { productId: 4, name: 'Design Patterns: Elements of Reusable Object-Oriented Software', price: 54.95, stock: 8, categoryId: 102 },
    { productId: 5, name: 'Unisex Cotton Hoodie', price: 39.99, stock: 40, categoryId: 103 }
  ];

  constructor() { }

  getProducts(): Observable<Product[]> {
    return of([...this.products]);
  }

  getProductById(id: number): Observable<Product | undefined> {
    const product = this.products.find(p => p.productId === id);
    return of(product ? { ...product } : undefined);
  }

  getProductsByCategoryId(categoryId: number): Observable<Product[]> {
    return of(this.products.filter(p => p.categoryId === categoryId));
  }

  addProduct(product: Product): Observable<Product> {
    const nextId = this.products.length > 0 ? Math.max(...this.products.map(p => p.productId)) + 1 : 1;
    const newProduct = { ...product, productId: nextId };
    this.products.push(newProduct);
    return of(newProduct);
  }

  updateProduct(product: Product): Observable<Product> {
    const index = this.products.findIndex(p => p.productId === product.productId);
    if (index !== -1) {
      this.products[index] = { ...product };
    }
    return of({ ...product });
  }

  deleteProduct(id: number): Observable<boolean> {
    const index = this.products.findIndex(p => p.productId === id);
    if (index !== -1) {
      this.products.splice(index, 1);
      return of(true);
    }
    return of(false);
  }
}
