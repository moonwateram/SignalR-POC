import { ref, computed } from "vue";
import { defineStore } from "pinia";
import * as signalR from "@microsoft/signalr";

export const useTicketStore = defineStore("ticket", () => {
  const showMessage = ref("No message yet");

  const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7183/tickethub")
    .build();

  connection.on("SendHelp", (user, message) => {
    console.log(message);
    showMessage.value = message;
  });

  function sendHelp() {
    connection.start().then(() => connection.invoke("SendHelp", "test", "4"));
  }

  return { showMessage, sendHelp };
});
