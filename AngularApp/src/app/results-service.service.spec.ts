import { TestBed } from '@angular/core/testing';

import { ResultsServiceService } from './results-service.service';

describe('ResultsServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ResultsServiceService = TestBed.get(ResultsServiceService);
    expect(service).toBeTruthy();
  });
});
