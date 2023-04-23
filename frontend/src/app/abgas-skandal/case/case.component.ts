import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Case } from '../models/case';
import { CaseService } from '../services/case.service';
import { CreateCaseRequest } from './create-case-request';

@Component({
  templateUrl: './case.component.html'
})
export class CaseComponent implements OnInit {
  public get router(): Router {
    return this._router;
  }
  public set router(value: Router) {
    this._router = value;
  }

  form!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private _router: Router,
    private caseService: CaseService
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      manifacturer: ['', Validators.required],
      model: ['', Validators.required],
      price: ['', Validators.required],
      purchaseType: ['new', Validators.required],
      paymentType: ['', Validators.required],
      productionYear: ['', Validators.required],
      purchaseYear: ['', Validators.required],
      hasInsurance: ['', Validators.required],
    })
  }

  //TODO: get from backend
  manifacturers: string[] = [
    'Audi',
    'BMW',
    'Dacia',
    'Fiat',
    'Ford',
    'Hyundai',
    'Jaguar',
    'Jeep',
    'Land Rover',
    'Mazda',
    'Mercedes-Benz',
    'Mini',
    'Mitsubishi',
    'Nissan',
    'Opel',
    'Porsche',
    'Renault',
    'Seat',
    'Skoda',
    'Subaru',
    'Suzuki',
    'Volvo',
    'VW'
  ]

  //TODO: get from backend
  models: string[] = ['A1','A2','A3','A4','A5','A6','A7','A8'];

  productionYears: number[] = [
    2008,
    2009,
    2010,
    2011,
    2012,
    2013,
    2014,
    2015,
    2016,
    2017,
    2018,
    2019,
    2020,
    2021
  ]

  purchaseYears: number[] = [
    2013,
    2014,
    2015,
    2016,
    2017,
    2018,
    2019,
    2020,
    2021
  ]

  async onSubmit() {
    const request = {
      manifacturer: this.form.get('manifacturer')?.value as string,
      model: this.form.get('model')?.value as string,
      productionYear: this.form.get('productionYear')?.value as number,
      hasInsurance: this.form.get('hasInsurance')?.value as boolean,
      paymentType: this.form.get('paymentType')?.value as string,
      price: this.form.get('price')?.value,
      isNewCar: this.form.get('purchaseType')?.value === 'new',
      purchaseYear: this.form.get('purchaseYear')?.value as number
    } as CreateCaseRequest

    await this.caseService.createNew(request)
  }
}
