import { Component, OnInit } from '@angular/core';
import { ProductService, Product } from '../../services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  category: string | null = null;
  errorMessage: string = '';
  loading: boolean = true;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.category = params.get('category');
      this.loadProducts();
    });
  }

  loadProducts(): void {
    this.loading = true;
    this.errorMessage = '';

    if (this.category) {
      this.productService.getProductsByCategory(this.category).subscribe({
        next: (data) => {
          this.products = data;
          this.loading = false;
        },
        error: (err) => {
          this.errorMessage = err.message;
          this.loading = false;
        }
      });
    } else {
      this.productService.getProducts().subscribe({
        next: (data) => {
          this.products = data;
          this.loading = false;
        },
        error: (err) => {
          this.errorMessage = err.message;
          this.loading = false;
        }
      });
    }
  }
}