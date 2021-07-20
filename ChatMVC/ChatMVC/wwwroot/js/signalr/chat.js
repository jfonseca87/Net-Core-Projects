"use strict";

const sendButton = document.getElementById('sendButton');
const userInput = document.getElementById('userInput');
const messageInput = document.getElementById('messageInput');
// API URL
const baseUrl = 'https://localhost:6001'

sendButton.disabled = true;
sendButton.addEventListener('click', (ev) => {
    debugger
    // Send the message to signalr server to distribute to all connected clients with signalr native library 
    //connection.invoke("SendMessage", userInput.value, messageInput.value)
    //    .catch((err) => {
    //        return console.error(err.toString());
    //    });

    // Send message using a signalr in API
    fetch(`${baseUrl}/api/chat/send`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            user: userInput.value,
            message: messageInput.value
        })
    })

    ev.preventDefault();
});

// Object that contains the connection with signalr hub configuretion
// const connection = new signalR.HubConnectionBuilder().withUrl('/chatHub').build();
const connection = new signalR.HubConnectionBuilder().withUrl(`${baseUrl}/chatSocket`).build();

// Call for start method to stablish communication with signalr
connection.start().then(() => {
    sendButton.disabled = false;
}).catch((err) => {
    console.log(err);
    return console.error(err.toString());
});

// Method that proccess the incoming message from signalr
connection.on('ReceiveMessage', (user, message) => {
    const msg = message.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
    const encodedMsg = `${user} says: ${msg}`;
    const li = document.createElement('li');
    li.textContent = encodedMsg;
    document.getElementById('messagesList').appendChild(li);
});

