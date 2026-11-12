import { TestBed } from '@angular/core/testing';

import { VuelosServices } from './vuelos-services';

describe('VuelosServices', () => {
  let service: VuelosServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VuelosServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
