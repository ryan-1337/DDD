//import './assets/main.css'

import { createApp } from "vue";
import 'bootstrap/dist/js/bootstrap.bundle.min';
import "bootstrap/dist/css/bootstrap.css";
import App from "./App.vue";
//import "./assets/main.css";

// Import Bootstrap and BootstrapVue CSS files (order is important)


// Make BootstrapVue available throughout your project
import { createRouter, createWebHistory } from "vue-router";
import ClientForm from "@/components/ClientForm.vue";
import HomeView from "@/views/HomeView.vue";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/home", component: HomeView },
    { path: "/create-client", component: ClientForm },
  ],
});

const app = createApp(App);
app.use(router);
app.mount("#app");
