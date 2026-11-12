import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Vueloscomponent } from './vueloscomponent';

describe('Vueloscomponent', () => {
  let component: Vueloscomponent;
  let fixture: ComponentFixture<Vueloscomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Vueloscomponent],
    }).compileComponents();

    fixture = TestBed.createComponent(Vueloscomponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
