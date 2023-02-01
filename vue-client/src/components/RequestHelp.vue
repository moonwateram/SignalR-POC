<script setup lang="ts">
import { ref } from "vue";
import * as signalR from "@microsoft/signalr";
import { onMounted } from "vue";

const seconds = ref(1);
const username = ref("Jonh");

let showMessage = ref("client > server > client");
let showMessage2 = ref("server > client");

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
      showMessage2.value = item;
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
    showMessage.value = message;
  });
});

function sendHelp() {
  connection
    .start()
    .then(() => connection.invoke("SendHelp", username.value, seconds.value));
}
</script>

<template>
  <button @click="sendHelp">Help me</button>
  <br />
  <input v-model="seconds" placeholder="time in seconds" />
  <br />
  <input v-model="username" placeholder="Name" />
  <br />
  <p>{{ showMessage }}</p>
  <br />
  <hr />
  <br />
  <p>{{ showMessage2 }}</p>
</template>
