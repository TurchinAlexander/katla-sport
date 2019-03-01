import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { ProductStoreListItem } from '../models/product-store-list-item';

@Injectable({
  providedIn: 'root'
})
export class ProductStoreItemService {
  private url = environment.apiUrl + 'api/stores/'

  constructor(private http: HttpClient) { }

  getProductStoreItems(hiveSectionId: number): Observable<Array<ProductStoreListItem>> {
    return this.http.get<Array<ProductStoreListItem>>(`${this.url}${hiveSectionId}`);
  }
}
