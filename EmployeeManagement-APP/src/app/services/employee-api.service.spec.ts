import { TestBed } from '@angular/core/testing';

import { EmployeeService } from './employee-api.service';

describe('EmployeeAPIService', () => {
  let service: EmployeeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
