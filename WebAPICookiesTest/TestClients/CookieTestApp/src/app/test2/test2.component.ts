import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test2',
  templateUrl: './test2.component.html',
  styleUrls: ['./test2.component.css'],
})
export class Test2Component implements OnInit {
  constructor(private client: HttpClient) {}

  ngOnInit(): void {}

  logIn(): void {
    this.client
      .post<any>('https://localhost:5001/api/auth', {
        userName: 'pperez',
        password: 'abc123',
      })
      .subscribe((res) => {
        localStorage.setItem('token', res.data);
        const headerDict = {
          Authorization: `Bearer ${localStorage.getItem('token')}`,
        };
        const requestOptions = {
          headers: new HttpHeaders(headerDict),
        };

        this.client
          .get('https://localhost:5001/api/csfr', requestOptions)
          .subscribe();
        console.log(res);
      });
  }

  getWeatherForecast(): void {
    const headerDict = {
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    };
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };
    this.client
      .get('https://localhost:5001/api/weatherforecast', {
        headers: new HttpHeaders().append('Authorization', `Bearer ${localStorage.getItem('token')}`)
      })
      .subscribe((res) => {
        console.log(res);
      });
  }
}
