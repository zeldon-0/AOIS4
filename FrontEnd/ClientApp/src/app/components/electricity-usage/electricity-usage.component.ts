import { Component, OnInit } from '@angular/core';
import { SearchService } from '../../services/search.service'; 
import { ElectricityUsage } from '../../models/electricity-usage';
import { SearchRequest } from '../../models/search-request';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-electricity-usage',
  templateUrl: './electricity-usage.component.html',
  styleUrls: ['./electricity-usage.component.css']
})
export class ElectricityUsageComponent implements OnInit {

  constructor(private searchService : SearchService) { }
  formatLabel(value: number) {
    return value;
  }
  public epochs : number;
  public population : number;
  public mutationProbability : number;
  private searchRequest : SearchRequest;
  public electricityUsage : ElectricityUsage;
  ngOnInit() {
  }
  search(){
    this.searchRequest = new SearchRequest(this.epochs, this.population, this.mutationProbability/100);
    this.searchService
      .searchForElectricityUsage(this.searchRequest)
      .subscribe(
        usage => {
          this.electricityUsage = usage;
        }
      )
  }
}
