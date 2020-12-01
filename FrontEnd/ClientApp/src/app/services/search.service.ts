import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  SearchRequest } from '../models/search-request';
import {  ElectricityUsage } from '../models/electricity-usage';
import {  Income } from '../models/income';
import { Observable, of, from } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SearchService {

    constructor(private http: HttpClient) { }
    readonly  apiUrl : string  = `https://localhost:44320/api/search`;

    searchForElectricityUsage (searchRequest : SearchRequest) : Observable<ElectricityUsage> {
        return this.http.post<ElectricityUsage>(`${this.apiUrl}/SearchForElectricityUsage`, searchRequest);
    }

    searchForIncome (searchRequest : SearchRequest) : Observable<Income> {
      return this.http.post<Income>(`${this.apiUrl}/SearchForIncome`, searchRequest);
    }
}