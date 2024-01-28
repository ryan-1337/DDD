<!-- ClientForm.vue -->
<template>
  <div class="container">
    <div class="row">
      <div class="mx-auto col-10 col-md-8 col-lg-6">
    <h2 class="text-center mt-5">Create Client</h2>
    <form @submit.prevent="createClient">
      <label for="fullName" class="form-label">Full Name:</label>
      <input class="form-control" type="text" v-model="fullName" required />

      <label class="form-label" for="email">Email:</label>
      <input class="form-control" type="email" v-model="email" required />

      <label for="phoneNumber">Phone Number:</label>
      <input class="form-control" type="tel" v-model="phoneNumber" required />

      <div class="text-center">
      <button type="submit" class="mt-3 text-center btn btn-secondary">Create Client</button>
      </div>
    </form>
    <div>
      <p>{{ serverResponse }}</p>
    </div>
    </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      fullName: "",
      email: "",
      phoneNumber: "",
      serverResponse: '',
    };
  },
  methods: {
    async createClient() {
      fetch("http://localhost:5104/api/clients", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          fullName: this.fullName,
          email: this.email,
          phoneNumber: this.phoneNumber
        }),
      })
        .then((response) => {
          // Utilisez une fonction fléchée pour conserver le contexte
          response.json().then((data) => {
            if (response.ok) {
              // Si la réponse est OK gérer le cas de réussite
              this.serverResponse = `=Votre id : ${data.id}`;
              console.log('Client created successfully:', data.id);
            } else {
              // Si la réponse n'est pas OK, consigner les détails de l'erreur du corps JSON
              console.error('Error details:', data.detail);

              // Consigner chaque erreur de validation spécifique
              if (data.errors) {
                data.errors.forEach((error) => {
                  this.serverResponse = `erreur : ${error.propertyName}: ${error.errorMessage}`;
                  console.error(error.propertyName + ': ' + error.errorMessage);
                });
              }
            }
          });
        })
        .catch((error) => {
          // Consigner les erreurs réseau ou autres erreurs qui ont empêché la requête de s'achever
          console.error('Request failed:', error);
        });
    },
  },
};
;
</script>

<style scoped></style>
