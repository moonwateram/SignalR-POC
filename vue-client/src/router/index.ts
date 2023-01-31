import { createRouter, createWebHistory } from "vue-router";
import TicketView from "../views/TicketView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "ticket",
      component: TicketView,
    },
  ],
});

export default router;
