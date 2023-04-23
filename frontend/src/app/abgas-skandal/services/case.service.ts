import { Injectable } from '@angular/core';
import { CreateCaseRequest } from '../case/create-case-request';
import { Case } from '../models/case';

@Injectable({
  providedIn: 'root'
})
export class CaseService {

  constructor() { }

  async getAll(): Promise<Case[]> {
    const response = await fetch("https://localhost:7208/cases");
    const body = await response.json();
    const cases = body?.cases as Case[];
    return cases;
  }
  async createNew(c: CreateCaseRequest): Promise<void> {

    console.log(JSON.stringify(c));

    const response = await fetch('https://localhost:7208/cases', {
      method: "POST",
      body: JSON.stringify(c),
      headers: {
        "content-Type": "application/json",
      }
    });
  }
}
