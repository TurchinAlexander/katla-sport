import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductStoreItemRequest } from '../models/product-store-item-request';

@Injectable({
  providedIn: 'root'
})
export class ProductRequestService {
  private url = environment.apiUrl + 'api/requests/';

  constructor(private http: HttpClient) { }

  getRequests(): Observable<Array<ProductStoreItemRequest>> {
    return this.http.get<Array<ProductStoreItemRequest>>(this.url);
  }

  addRequest(request: ProductStoreItemRequest): Observable<ProductStoreItemRequest> {
    return this.http.post<ProductStoreItemRequest>(`${this.url}`, request);
  }

  setCompletedStatus(requestId: number): Observable<Object> {
    return this.http.put(`${this.url}${requestId}/completed`, null);
  }
}
