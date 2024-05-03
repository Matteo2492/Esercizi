import { TestBed } from '@angular/core/testing';

import { PropostaServiceService } from './proposta-service.service';

describe('PropostaServiceService', () => {
  let service: PropostaServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PropostaServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
