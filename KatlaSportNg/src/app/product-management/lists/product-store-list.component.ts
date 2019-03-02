import { Component, OnInit } from '@angular/core';
import { ProductStoreListItem } from '../models/product-store-list-item';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductStoreItemService } from '../services/product-store-item.service';
import { ProductService } from '../services/product.service';
import { ProductListItem } from '../models/product-list-item';

@Component({
  selector: 'app-product-store-list',
  templateUrl: './product-store-list.component.html',
  styleUrls: ['./product-store-list.component.css']
})
export class ProductStoreListComponent implements OnInit {

  hiveSectionId: number;
  storeProducts: ProductStoreListItem[];
  products: ProductListItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productStoreItemService: ProductStoreItemService,
    private productService: ProductService
  ) { }

  ngOnInit() {
    this.productService.getProducts().subscribe(p => this.products = p);

    this.route.params.subscribe(p => {
      this.hiveSectionId = p['hiveSectionId'];
      this.productStoreItemService.getProductStoreItems(this.hiveSectionId).subscribe(p => this.storeProducts = p);
    })
  }

  resolveProductName(productId: number): string {
    return this.products.find(p => p.id == productId).name;
  }
}
