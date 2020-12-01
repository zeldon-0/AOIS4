import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ElectricityUsageComponent } from './components/electricity-usage/electricity-usage.component';
import { IncomeComponent } from './components/income/income.component';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatSliderModule } from '@angular/material/slider';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ElectricityUsageComponent,
    IncomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    NoopAnimationsModule,
    MatButtonModule,
    MatSliderModule,
    RouterModule.forRoot([
      { path: '', component: ElectricityUsageComponent, pathMatch: 'full' },
      { path: 'electricity', component: ElectricityUsageComponent, pathMatch: 'full' },
      { path: 'income', component: IncomeComponent, pathMatch: 'full' },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
