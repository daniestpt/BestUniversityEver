function signalR() {
}

// connected event
signalR.onConnected = "signalRConnected";

function notesSignalR() {
}

// hub
notesSignalR.hubName = "courseHub";

// client calls
notesSignalR.addCourse = "addCourse";
notesSignalR.removeCourse = "removeCourse";

// client callbacks
notesSignalR.onNewCourse = "broadcastNewCourse";
notesSignalR.onRemoveCourse = "broadcastRemoveCourse";



