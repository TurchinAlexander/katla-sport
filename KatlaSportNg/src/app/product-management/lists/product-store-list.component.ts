import { Component, OnInit } from '@angular/core';
import { ProductStoreListItem } from '../models/product-store-list-item';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductStoreItemService } from '../services/product-store-item.service';

@Component({
  selector: 'app-product-store-list',
  templateUrl: './product-store-list.component.html',
  styleUrls: ['./product-store-list.component.css']
})
export class ProductStoreListComponent implements OnInit {

  hiveSectionId: number;
  storeProducts: ProductStoreListItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productStoreItemService: ProductStoreItemService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveSectionId = p['hiveSectionId'];
      this.productStoreItemService.getProductStoreItems(this.hiveSectionId)
        .subscribe(p => this.storeProducts = p);
    })
  }
}
