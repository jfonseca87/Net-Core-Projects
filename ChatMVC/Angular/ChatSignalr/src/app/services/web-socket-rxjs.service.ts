import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WebSocketRxjsService {
  webSocket: WebSocket;
  private url = 'wss://localhost:6001/chatsocket';

  constructor() {}

  createObservableSocket(): Observable<any> {
    this.webSocket = new WebSocket(this.url);

    return new Observable((observer) => {
      this.webSocket.onmessage = (evt) => {
        observer.next(evt.data);
      };
      this.webSocket.onerror = (evt) => {
        observer.error(evt);
      };
      this.webSocket.onclose = (evt) => {
        observer.complete();
      };
      return () => {
        this.webSocket.close(1000, 'User disconnected');
      };
    });
  }

  sendMessage(data: any): void {
    if (this.webSocket.readyState === 1) {
      this.webSocket.send(data);
    }
  }
}
