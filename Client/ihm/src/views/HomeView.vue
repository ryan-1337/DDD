<template>
  <div class="home-container">
    <div class="hotel-background"></div>
    <div class="content">
      <h1 class="animated fadeInDown">Welcome to XYZHotel</h1>
      <p class="animated fadeInUp">Discover the luxury and comfort of our hotel</p>
    </div>
  </div>
</template>

<style>
.home-container {
  position: relative;
  height: 100vh;
  overflow: hidden;
}

.hotel-background {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-image: url('https://e0.pxfuel.com/wallpapers/396/575/desktop-wallpaper-hidden-background-episode-anime-anime-scenery-hotel-room.jpg');
  background-size: cover;
  background-position: center;
  filter: blur(5px) grayscale(80%); 
}

.content {
  position: relative;
  z-index: 1;
  text-align: center;
  padding-top: 20%;
}

.animated {
  animation-duration: 1s;
}

.fadeInDown {
  animation-name: fadeInDown;
}

.fadeInUp {
  animation-name: fadeInUp;
}

@keyframes fadeInDown {
  0% {
    opacity: 0;
    transform: translateY(-50px);
  }
  100% {
    opacity: 1;
    transform: translateY(0);
  }
}

@keyframes fadeInUp {
  0% {
    opacity: 0;
    transform: translateY(50px);
  }
  100% {
    opacity: 1;
    transform: translateY(0);
  }
}
</style>
