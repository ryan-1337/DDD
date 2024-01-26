<!-- App.vue -->
<template>
  <div id="app">
    <NavBar></NavBar>
    <router-view></router-view>
  </div>
</template>

<script>
import NavBar from './components/NavBar.vue';
export default {
  name: "App",
  components: {
    NavBar,
  },
  data() {
    return {
    };
  },
};
</script>

<style>
/* Ajoutez du style CSS au besoin */
</style>


