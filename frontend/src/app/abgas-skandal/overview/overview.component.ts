import { Component, OnInit } from '@angular/core';
import { Case } from '../models/case';
import { CaseStatus } from '../models/case-status';
import { CaseService } from '../services/case.service';

@Component({
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent implements OnInit{
  cases?: Case[];
  
  statusDisplay: Record<CaseStatus, string> = {
   [CaseStatus.New]: "Neu",
   [CaseStatus.InProgress]: "In Bearbeitung",
   [CaseStatus.Done]: "Abgeschlossen",
   [CaseStatus.Denied]: "Abgelehnt" 
  }

  constructor(private caseService: CaseService) {}

  async ngOnInit(): Promise<void> {
    this.cases = await this.caseService.getAll();
  }
}
