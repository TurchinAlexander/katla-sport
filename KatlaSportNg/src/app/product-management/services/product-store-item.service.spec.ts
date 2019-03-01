import { TestBed, inject } from '@angular/core/testing';

import { ProductStoreItemService } from './product-store-item.service';

describe('ProductStoreItemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductStoreItemService]
    });
  });

  it('should be created', inject([ProductStoreItemService], (service: ProductStoreItemService) => {
    expect(service).toBeTruthy();
  }));
});
