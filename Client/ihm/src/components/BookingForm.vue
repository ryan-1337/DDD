<template>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a>
                    <router-link class="nav-link active" to="/">Home</router-link>
                </a></li>
            <li class="breadcrumb-item"><a>Booking</a></li>
            <li class="breadcrumb-item active" aria-current="page">Create</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row">
            <div class="mx-auto col-10 col-md-8 col-lg-6">
                <h2 class="text-center mt-5">Booking</h2>
                <form @submit.prevent="createBooking">
                    <label for="clientId" class="form-label">Client id:</label>
                    <input class="form-control" type="text" v-model="clientId" required />

                    <label class="form-label" for="numberOfNights">Number of night:</label>
                    <input class="form-control" type="number" v-model="numberOfNights" required />

                    <label class="form-label" for="checkInDate">Check In Date:</label>
                    <input class="form-control" type="date" v-model="checkInDate" required />

                    <label class="form-label" for="room">Select your room: </label>
                    <select class="form-select" v-model="room" aria-label="1">
                        <option selected>Select your room</option>
                        <option value="1">Standard</option>
                        <option value="2">Supérieur</option>
                        <option value="3">Suite</option>
                    </select>

                    <div class="text-center">
                        <button type="submit" class="mt-3 text-center btn btn-secondary">Booking</button>
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
            clientId: '',
            checkInDate: new Date(),
            numberOfNights: 0,
            room: 0,
            serverResponse: '',
        };
    },
    methods: {
        async createBooking() {
            fetch("http://localhost:5104/api/booking", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    clientId: this.clientId,
                    numberOfNights: this.numberOfNights,
                    checkInDate: this.checkInDate,
                    room: this.room,
                }),
            })
                .then((response) => {
                    // Utilisez une fonction fléchée pour conserver le contexte
                    response.json().then((data) => {
                        if (data.isSuccess) {
                            // Si la réponse est OK gérer le cas de réussite
                            this.serverResponse = `Your booking is created`;
                            console.log('Booking created successfully:', data.id);
                        } else {
                            // Si la réponse n'est pas OK, consigner les détails de l'erreur du corps JSON
                            this.serverResponse = data.errorMessage;
                            console.error('Error details:', data.errorMessage);
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
