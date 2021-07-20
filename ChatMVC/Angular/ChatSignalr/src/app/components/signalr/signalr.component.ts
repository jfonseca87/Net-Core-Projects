import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SignalrService } from 'src/app/services/signalr.service';

@Component({
  selector: 'app-signalr',
  templateUrl: './signalr.component.html',
  styleUrls: ['./signalr.component.css'],
})
export class SignalrComponent implements OnInit {
  user: string;
  message: string;
  data = [];

  constructor(private signalrService: SignalrService) {}

  ngOnInit(): void {
    // There is a subscription method that receive the message and process it
    this.signalrService.chatSubscription().subscribe(
      res => {
        this.data.push(res);
      }
    );
  }

  sendMessage(): void {
    const object = {
      user: this.user,
      message: this.message,
    };

    // Send the message to all connected clients
    this.signalrService.broadcastMessage(object);
  }
}
