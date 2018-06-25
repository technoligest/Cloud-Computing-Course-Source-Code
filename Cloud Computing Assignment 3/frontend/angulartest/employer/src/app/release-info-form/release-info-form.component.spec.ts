import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReleaseInfoFormComponent } from './release-info-form.component';

describe('ReleaseInfoFormComponent', () => {
  let component: ReleaseInfoFormComponent;
  let fixture: ComponentFixture<ReleaseInfoFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReleaseInfoFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReleaseInfoFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
