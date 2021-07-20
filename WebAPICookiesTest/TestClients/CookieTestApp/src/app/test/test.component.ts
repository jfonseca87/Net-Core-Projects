import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
})
export class TestComponent implements OnInit {
  constructor(private client: HttpClient) {}

  ngOnInit(): void {}

  logIn(): void {
    this.client.post(
      'https://localhost:5001/api/auth/login',
      { userName: 'pperez', password: 'abc123' }
    ).subscribe(
      res => {
        this.client.get('https://localhost:5001/api/csfr').subscribe();
        console.log(res);
      }
    );
  }

  logOut(): void {
    this.client.get(
      'https://localhost:5001/api/auth/logout'
    ).subscribe(
      res => {
        console.log(res);
      }
    );
  }

  getInfo(): void {
    this.client.get(
      'https://localhost:5001/api/info'
    ).subscribe(
      res => {
        console.log(res);
      }
    );
  }
}
