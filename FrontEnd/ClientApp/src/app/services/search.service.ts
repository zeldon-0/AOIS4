import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  SearchRequest } from '../models/search-request';
import {  ElectricityUsage } from '../models/electricity-usage';
import { Observable, of, from } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SearchService {

    constructor(private http: HttpClient) { }
    readonly  apiUrl : string  = `https://localhost:44336/api/search`;

    classifyImage (searchRequest : SearchRequest) : Observable<ElectricityUsage> {
        return this.http.post<ElectricityUsage>(`${this.apiUrl}/getSolution`, searchRequest);
    }
}