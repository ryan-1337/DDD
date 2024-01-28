<template>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a>
                    <router-link class="nav-link active" to="/">Home</router-link>
                </a></li>
            <li class="breadcrumb-item"><a>Wallet</a></li>
            <li class="breadcrumb-item active" aria-current="page">Create</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row">
            <div class="mx-auto col-10 col-md-8 col-lg-6">
                <h2 class="text-center mt-5">Wallet</h2>
                <form @submit.prevent="createWallet">
                    <label for="clientId" class="form-label">Client id:</label>
                    <input class="form-control" type="text" v-model="clientId" required />

                    <label class="form-label" for="amount">Amount:</label>
                    <input class="form-control" type="number" v-model="amount" required />

                    <label class="form-label" for="currency">currency:</label>
                    <input class="form-control" value="€" type="text" v-model="currency" disabled />

                    <div class="text-center">
                        <button type="submit" class="mt-3 text-center btn btn-secondary">Create</button>
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
            amount: 0,
            currency: 'EUR',
            serverResponse: '',
        };
    },
    methods: {
        async createWallet() {
            fetch("http://localhost:5104/api/wallet", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    clientId: this.clientId,
                    amount: this.amount,
                    currency: this.currency,
                }),
            })
                .then((response) => {
                    response.json().then((data) => {
                        if (data.isSuccess) {
                            this.serverResponse = `Your wallet is created`;
                            console.log('wallet created successfully:', data.amount);
                        } else {
                            this.serverResponse = data.errorMessage;
                            console.error('Error details:', data.errorMessage);
                        }
                    });
                })
                .catch((error) => {
                    console.error('Request failed:', error);
                });
        },
    },
};
;
</script>

<style scoped></style>
