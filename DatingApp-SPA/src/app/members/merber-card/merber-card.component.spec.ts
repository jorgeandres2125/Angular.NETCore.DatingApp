import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MerberCardComponent } from './merber-card.component';

describe('MerberCardComponent', () => {
  let component: MerberCardComponent;
  let fixture: ComponentFixture<MerberCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MerberCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MerberCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
