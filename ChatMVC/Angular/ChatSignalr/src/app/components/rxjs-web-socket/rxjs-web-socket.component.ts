import { Component, OnDestroy, OnInit } from '@angular/core';
import { WebSocketRxjsService } from 'src/app/services/web-socket-rxjs.service';

@Component({
  selector: 'app-rxjs-web-socket',
  templateUrl: './rxjs-web-socket.component.html',
  styleUrls: ['./rxjs-web-socket.component.css']
})
export class RxjsWebSocketComponent implements OnInit {
  user: string;
  message: string;
  data = [];

  constructor(private webSocketService: WebSocketRxjsService) { }

  ngOnInit(): void {
    this.webSocketService.createObservableSocket().subscribe(
      res => {
        debugger
        this.data = res;
        console.log(this.data);
      },
      error => console.log(error),
      () => console.log('The observable stream was completed')
    );
  }

  sendMessage(): void {
    debugger
    const object = {
      user: this.user,
      message: this.message
    };

    this.webSocketService.sendMessage(object);
  }
}
