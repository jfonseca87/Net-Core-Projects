import { TestBed } from '@angular/core/testing';

import { WebSocketRxjsService } from './web-socket-rxjs.service';

describe('WebSocketRxjsService', () => {
  let service: WebSocketRxjsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WebSocketRxjsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
