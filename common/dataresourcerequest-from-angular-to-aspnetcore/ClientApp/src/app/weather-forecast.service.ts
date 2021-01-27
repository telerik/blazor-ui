import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { DataResult, DataSourceRequestState, toDataSourceRequestString } from '@progress/kendo-data-query';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {
  private BASE_URL = 'api';

  constructor(private httpClient: HttpClient) { }

  public list(state: DataSourceRequestState): Observable<DataResult> {
    const queryStr = toDataSourceRequestString(state);
    return this.httpClient.get<DataResult>(`${this.BASE_URL}/weatherforecast?${queryStr}`);
  }

}
