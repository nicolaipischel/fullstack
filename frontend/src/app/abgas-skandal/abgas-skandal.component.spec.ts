import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbgasSkandalComponent } from './abgas-skandal.component';

describe('AbgasSkandalComponent', () => {
  let component: AbgasSkandalComponent;
  let fixture: ComponentFixture<AbgasSkandalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbgasSkandalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AbgasSkandalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
