<script setup lang="ts">
import { ref } from "vue";
import * as signalR from "@microsoft/signalr";
import { onMounted } from "vue";

const seconds = ref(1);
const username = ref("Jonh");

let showMessage = ref("No message yet");
let showMessage2 = ref("No message yet");

let connectionstream = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7183/tickethub/streaming")
  .build();

let connection = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7183/tickethub")
  .build();

onMounted(async () => {
  await connectionstream.start().catch(() => {
    console.log("this was a mistake");
  });

  connectionstream.stream("TriggerStream", 5).subscribe({
    next: (item) => {
      console.log(item);
    },
    complete: () => {
      console.log("completed");
    },
    error: (err) => {
      console.log(err);
    },
  });

  connection.on("SendHelp", (user, message) => {
    console.log(message);
    showMessage2.value = message;
  });
});

function sendHelp() {
  connection
    .start()
    .then(() => connection.invoke("SendHelp", username.value, seconds.value));
}
</script>

<template>
  <div>First Component</div>
  <button @click="sendHelp">Help me</button>
  <br />
  <input v-model="seconds" placeholder="time in seconds" />
  <br />
  <input v-model="username" placeholder="Name" />
  <br />
  <p>{{ showMessage }}</p>
  <hr />
  <p>{{ showMessage2 }}</p>
</template>
