import { TestBed } from '@angular/core/testing';

import { CSFRInterceptor } from './csfr.interceptor';

describe('CSFRInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      CSFRInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: CSFRInterceptor = TestBed.inject(CSFRInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
