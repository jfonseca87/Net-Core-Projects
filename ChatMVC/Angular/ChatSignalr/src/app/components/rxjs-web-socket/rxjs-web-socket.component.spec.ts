import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RxjsWebSocketComponent } from './rxjs-web-socket.component';

describe('RxjsWebSocketComponent', () => {
  let component: RxjsWebSocketComponent;
  let fixture: ComponentFixture<RxjsWebSocketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RxjsWebSocketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RxjsWebSocketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
