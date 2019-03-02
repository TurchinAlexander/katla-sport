import { Component, OnInit } from '@angular/core';
import { ProductStoreItemRequest } from '../models/product-store-item-request';
import { ProductRequestService } from '../services/product-request.service';

@Component({
  selector: 'app-product-request-list',
  templateUrl: './product-request-list.component.html',
  styleUrls: ['./product-request-list.component.css']
})
export class ProductRequestListComponent implements OnInit {

  requests: ProductStoreItemRequest[]

  constructor(private productRequestService: ProductRequestService) { }

  ngOnInit() {
    this.productRequestService.getRequests().subscribe(r => this.requests = r);
  }

  onComplete(requestId: number) {
    var request = this.requests.find(r => r.id == requestId);
    this.productRequestService.setCompletedStatus(requestId).subscribe(r => request.completed = true);
  }

} 
