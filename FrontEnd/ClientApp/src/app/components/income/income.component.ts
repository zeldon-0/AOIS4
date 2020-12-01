import { Component, OnInit } from '@angular/core';
import { SearchService } from '../../services/search.service'; 
import { Income } from '../../models/income';
import { SearchRequest } from '../../models/search-request';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrls: ['./income.component.css']
})
export class IncomeComponent implements OnInit {
  constructor(private searchService : SearchService) { }
  formatLabel(value: number) {
    return value;
  }
  public epochs : number;
  public population : number;
  public mutationProbability : number;
  private searchRequest : SearchRequest;
  public income : Income;
  ngOnInit() {
  }
  search(){
    this.searchRequest = new SearchRequest(this.epochs, this.population, this.mutationProbability/100);
    this.searchService
      .searchForIncome(this.searchRequest)
      .subscribe(
        usage => {
          this.income = usage;
        }
      )
  }

}
