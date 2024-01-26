<!-- ClientForm.vue -->
<template>
  <div class="container">
    <h2>Create Client</h2>
    <form @submit.prevent="createClient">
      <label for="fullName" class="form-label">Full Name:</label>
      <input class="form-control" type="text" v-model="fullName" required />

      <label class="form-label" for="email">Email:</label>
      <input class="form-control" type="email" v-model="email" required />

      <label for="phoneNumber">Phone Number:</label>
      <input class="form-control" type="tel" v-model="phoneNumber" required />

      <button type="submit" class="btn btn-primary">Create Client</button>
    </form>
    <div>
      <p>Réponse du serveur : {{ serverResponse }}</p>
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
              // Si la réponse est OK, gérer le cas de réussite
              this.serverResponse = data.id;
              console.log('Client created successfully:', data.id);
            } else {
              // Si la réponse n'est pas OK, consigner les détails de l'erreur du corps JSON
              console.error('Error details:', data.detail);

              // Consigner chaque erreur de validation spécifique
              if (data.errors) {
                data.errors.forEach((error) => {
                  this.serverResponse = `${error.propertyName}: ${error.errorMessage}`;
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
