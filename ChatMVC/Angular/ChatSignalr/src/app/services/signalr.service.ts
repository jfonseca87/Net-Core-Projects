import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as signalr from '@aspnet/signalr';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private messageSubject$ = new Subject<any>();
  private hubConnection: signalr.HubConnection;

  constructor(private http: HttpClient) {
    this.startConnection();
    this.hubConnection.on('ReceiveMessage', (user, message) => {
      const object = {
        user,
        message,
      };
      this.setMessage(object);
    });
  }

  // Method that start de connection with the socket
  public startConnection(): void {
    this.hubConnection = new signalr.HubConnectionBuilder()
      .withUrl('https://localhost:6001/chatSocket')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err) => console.error(`Error while starting connection: ${err}`));
  }

  private setMessage(data: any): void {
    debugger;
    this.messageSubject$.next(data);
  }

  public chatSubscription(): Observable<any> {
    return this.messageSubject$.asObservable();
  }

  public broadcastMessage(data: any): void {
    // this.http
    //   .post('https:localhost:6001/api/chat/send', data)
    //   .subscribe((res) => console.log('response from service call ' + res));
    this.hubConnection.invoke('SendMessage', data.user, data.message);
  }
}
