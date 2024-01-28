<!-- App.vue -->
<template>
  <div id="app">
    <NavBar></NavBar>
    <router-view></router-view>
    <Footer></Footer>
  </div>
</template>

<script>
import NavBar from './components/NavBar.vue';
import Footer from './components/Footer.vue';
export default {
  name: "App",
  components: {
    NavBar,
    Footer
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


