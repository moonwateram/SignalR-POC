<script setup lang="ts">
import { ref } from "vue";
import * as signalR from "@microsoft/signalr";

const seconds = ref(1);
const username = ref("Jonh");

let showMessage = ref("No message yet");

let connection = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7183/tickethub")
  .build();

// no interface
// connection.on("HelpSentEvent", (user, message) => {
//   console.log(user, message);
//   showMessage.value = message;
// });

connection.on("SendHelp", (user, message) => {
  console.log(message);
  showMessage.value = message;
});

function sendHelp() {
  connection
    .start()
    .then(() => connection.invoke("SendHelp", username.value, seconds.value));
}
</script>

<template>
  <div>Request Help</div>
  <button @click="sendHelp">Help me</button>
  <br />
  <input v-model="seconds" placeholder="time in seconds" />
  <br />
  <input v-model="username" placeholder="Name" />
  <br />
  <p>{{ showMessage }}</p>
</template>
