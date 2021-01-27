import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';

import { State } from '@progress/kendo-data-query';
import { WeatherForecastService } from './weather-forecast.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  public gridLoading = false;
  public state: State = {
    skip: 0,
    take: 300,
    sort: [{
      field: 'date',
      dir: 'desc'
    }]
  };
  public weatherForecasts: GridDataResult;

  constructor(private weatherForecastService: WeatherForecastService) { }

  public ngOnInit(): void {
    this.gridLoading = true;
    this.weatherForecastService.list(this.state).subscribe(result => {
      this.weatherForecasts = result;
      this.gridLoading = false;
    });
  }

  public dataStateChange(state: DataStateChangeEvent): void {
    this.gridLoading = true;
    this.state = state;
    this.weatherForecastService.list(this.state).subscribe(result => {
      this.weatherForecasts = result;
      this.gridLoading = false;
    });
  }

}
