import { Component, OnInit } from '@angular/core';
import { HiveSectionListItem } from 'app/hive-management/models/hive-section-list-item';
import { ProductListItem } from '../models/product-list-item';
import { ProductStoreItemRequest } from '../models/product-store-item-request';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from 'app/hive-management/services/hive-section.service';
import { ProductService } from '../services/product.service';
import { ProductRequestService } from '../services/product-request.service';

@Component({
  selector: 'app-product-request-form',
  templateUrl: './product-request-form.component.html',
  styleUrls: ['./product-request-form.component.css']
})
export class ProductRequestFormComponent implements OnInit {

  hiveSections: HiveSectionListItem[];
  products: ProductListItem[];
  request = new ProductStoreItemRequest(0, 0, 0, 1, false);

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionService: HiveSectionService,
    private productService: ProductService,
    private productRequestService: ProductRequestService
  ) { }

  ngOnInit() {
    this.hiveSectionService.getHiveSections().subscribe(
      hs => this.hiveSections = hs
    );

    this.productService.getProducts().subscribe(
      p => this.products = p
    );

    this.route.params.subscribe(p => {
          this.request.hiveSectionId = p['hiveSectionId'];
    });
  }

  onSubmit() {
    this.productRequestService.addRequest(this.request).subscribe(
      s => {
        this.router.navigate([`/store/${s.hiveSectionId}`]);
      });
  }

  navigateToProducts() {
    this.router.navigate([`store/${this.request.hiveSectionId}`]);
  }

  onCancel() {
    this.navigateToProducts();
  }
}
