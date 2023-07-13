import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as signalR from '@microsoft/signalr';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = "";
  private hubConnection: signalR.HubConnection;
  messages: any[] = [];
  newMessage: string = '';

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44368/ChatHub') // Replace with your API endpoint URL
      .build();

    this.hubConnection.start()
      .then(() => {
        console.log('Connection started');
      })
      .catch(err => console.error('Error while starting connection: ' + err));

    this.hubConnection.on('ReceiveMessage', (data) => {
      this.messages = data;
    });
  }

  sendMessage() {
    const message = {
      senderId: 1, // Replace with the appropriate sender ID
      receiverId: 2, // Replace with the appropriate receiver ID
      message: this.newMessage
    };

    this.hubConnection.invoke('chatPrivateMessage', message)
      .catch(err => console.error('Error while sending message: ' + err));

    this.newMessage = '';
  }
}
