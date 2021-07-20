import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { SignalrComponent } from './components/signalr/signalr.component';
import { RxjsWebSocketComponent } from './components/rxjs-web-socket/rxjs-web-socket.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SignalrService } from './services/signalr.service';
import { WebSocketRxjsService } from 'src/app/services/web-socket-rxjs.service';

@NgModule({
  declarations: [
    AppComponent,
    SignalrComponent,
    RxjsWebSocketComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    SignalrService,
    WebSocketRxjsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
