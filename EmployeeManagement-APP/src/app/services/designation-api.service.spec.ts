import { TestBed } from '@angular/core/testing';

import { DesignationApiService } from './designation-api.service';

describe('DesignationApiService', () => {
  let service: DesignationApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DesignationApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
