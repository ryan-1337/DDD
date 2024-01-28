<template>
    <div class="container">
      <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
          <li class="breadcrumb-item"><router-link to="/">Home</router-link></li>
          <li class="breadcrumb-item">Wallet</li>
          <li class="breadcrumb-item active" aria-current="page">List</li>
        </ol>
      </nav>
      <div class="row">
        <div class="mx-auto col-10 col-md-8 col-lg-12">
          <form class="m-3" @submit.prevent="getWalletByClientId">
            <label for="clientId" class="form-label">Client id:</label>
            <input class="form-control" type="text" v-model="clientId" required />
            <div class="text-center">
              <button type="submit" class="mt-3 text-center btn btn-secondary">Search</button>
            </div>
          </form>
  
          <!-- Display wallet info -->
          <div class="row">
            <div class="d-flex justify-content-evenly">
              <div class="card" v-if="wallet" style="width: 18rem;">
                <div class="card-body">
                  <h5 class="card-title text-center">Wallet</h5>
                  <h6 class="card-subtitle mb-2 text-body-secondary text-center">Amount : {{ wallet.amount }}</h6>
                  <div class="text-center">
                    <label for="newAmount" class="form-label">New Amount:</label>
                    <input class="form-control" type="number" v-model.number="newAmount" required />
                    <button class="btn btn-primary m-1" @click="updateWallet">Update Wallet</button>
                  </div>
                </div>
              </div>
              <div v-else class="text-center">No wallet found for this client</div>
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
        clientId: "", // Define your clientId logic
        wallet: null,
        newAmount: null, // Variable to store the new amount
      };
    },
    mounted() {
      this.getWalletByClientId();
    },
    methods: {
      async getWalletByClientId() {
        try {
          const response = await fetch(`http://localhost:5104/api/wallet?clientId=${this.clientId}`);
          if (!response.ok) {
            console.error('Error fetching wallet:', response.statusText);
            return;
          }
          const data = await response.json();
          this.wallet = data;
        } catch (error) {
          console.error('Error fetching wallet:', error);
        }
      },
      async updateWallet() {
        try {
          const response = await fetch(`http://localhost:5104/api/wallet?Id=${this.wallet.id}&amount=${this.newAmount}`, {
            method: 'PUT',
          });
          if (!response.ok) {
            console.error('Error updating wallet:', response.statusText);
            return;
          }
          const data = await response.json();
          console.log('Wallet updated successfully:', data);
          // Refresh wallet data
          this.getWalletByClientId();
        } catch (error) {
          console.error('Error updating wallet:', error);
        }
      },
    },
  };
  </script>
  
  <style scoped>
  /* Add your styles here */
  </style>
  