<template>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a>
                    <router-link class="nav-link active" to="/">Home</router-link>
                </a></li>
            <li class="breadcrumb-item"><a>Booking</a></li>
            <li class="breadcrumb-item active" aria-current="page">List</li>
        </ol>
    </nav>
    <div class="container">
      <div class="row">
        <div class="mx-auto col-10 col-md-8 col-lg-12">
          <!-- Form to search bookings -->
          <form class="m-3" @submit.prevent="getAllBookingsByClientId">
            <label for="clientId" class="form-label">Client id:</label>
            <input class="form-control" type="text" v-model="clientId" required />
            <div class="text-center">
              <button type="submit" class="mt-3 text-center btn btn-secondary">Search</button>
            </div>
          </form>
  
          <!-- Title -->
          <h1 class="text-center m-5">All Bookings</h1>
  
          <!-- Display bookings -->
          <div class="row">
            <div class="d-flex justify-content-evenly">
              <div v-for="(booking, index) in bookings" :key="booking.id">
                <div class="card" style="width: 18rem;">
                  <div class="card-body">
                    <h5 class="card-title text-center">Booking</h5>
                    <h6 class="card-subtitle mb-2 text-body-secondary text-center">Room : {{ booking.room.name }}</h6>
                    <p class="card-text text-center"> Date : {{ new Date(booking.checkInDate).toLocaleDateString() }}</p>
                    <p class="card-text text-center"> Initial payment : {{ booking.initialPayment }}</p>
                    <div class="text-center">
                      <button v-if="!booking.isCancelled" class="btn btn-primary m-1" @click="updateBooking(booking.id, 'confirmed')">Is confirmed : {{ booking.isConfirmed }}</button>
                      <button v-if="!booking.isConfirmed" class="btn btn-danger m-1" @click="updateBooking(booking.id, 'cancelled')">Is cancelled : {{ booking.isCancelled }}</button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        clientId: "", // Définissez votre clientId selon votre logique
        bookings: [],
      };
    },
    mounted() {
      this.getAllBookingsByClientId();
    },
    methods: {
      async getAllBookingsByClientId() {
        try {
          const response = await fetch(`http://localhost:5104/api/booking?clientId=${this.clientId}`);
          if (!response.ok) {
            console.error('Error fetching bookings:', response.statusText);
            return;
          }
          const data = await response.json();
          this.bookings = data;
        } catch (error) {
          console.error('Error fetching bookings:', error);
        }
      },
      async updateBooking(bookingId, status) {
        try {
            const response = await fetch(`http://localhost:5104/api/booking?bookingId=${bookingId}&status=${status}`, {
          method: 'PUT',
        }); 
          if (!response.ok) {
            console.error('Error updating booking:', response.statusText);
            return;
          }
          const data = await response.json();
          console.log('Booking updated successfully:', data);
          // Rafraîchir la liste des réservations
          this.getAllBookingsByClientId();
        } catch (error) {
          console.error('Error updating booking:', error);
        }
      },
    },
  };
  </script>
  
  <style scoped>
  /* Ajoutez vos styles ici */
  </style>
  