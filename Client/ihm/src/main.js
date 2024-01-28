//import './assets/main.css'

import { createApp } from "vue";
import 'bootstrap/dist/js/bootstrap.bundle.min';
import "bootstrap/dist/css/bootstrap.css";
import App from "./App.vue";
import "@/assets/style.css"
//import "./assets/main.css";

// Import Bootstrap and BootstrapVue CSS files (order is important)


// Make BootstrapVue available throughout your project
import { createRouter, createWebHistory } from "vue-router";
import ClientForm from "@/components/ClientForm.vue";
import BookingForm from "@/components/BookingForm.vue";
import BookingList from "@/components/BookingList.vue";
import WalletForm from "@/components/WalletForm.vue";
import WalletList from "@/components/WalletList.vue";
import HomeView from "@/views/HomeView.vue";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", component: HomeView },
    { path: "/create-client", component: ClientForm },
    { path: "/create-booking", component: BookingForm },
    { path: "/list-booking", component: BookingList },
    { path: "/create-wallet", component: WalletForm },
    { path: "/list-wallet", component: WalletList },
  ],
});

const app = createApp(App);
app.use(router);
app.mount("#app");
