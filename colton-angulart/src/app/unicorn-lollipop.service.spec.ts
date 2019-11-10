import { TestBed } from '@angular/core/testing';

import { UnicornLollipopService } from './unicorn-lollipop.service';

describe('UnicornLollipopService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UnicornLollipopService = TestBed.get(UnicornLollipopService);
    expect(service).toBeTruthy();
  });
});
