import { TestBed, inject } from '@angular/core/testing';

import { MyDataServiceService } from './my-data-service.service';

describe('MyDataServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MyDataServiceService]
    });
  });

  it('should be created', inject([MyDataServiceService], (service: MyDataServiceService) => {
    expect(service).toBeTruthy();
  }));
});
