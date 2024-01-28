    <template>
    <nav class="navbar navbar-expand-lg bg-dark" data-bs-theme="dark">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">XyZHotel</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
          aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link active" aria-current="page">
                <router-link class="nav-link active" to="/">Home</router-link>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link">
                <router-link class="nav-link" to="/create-client">Client</router-link>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link">
                <router-link class="nav-link" to="/create-booking">booking</router-link>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link">
                <router-link class="nav-link" to="/list-booking">List my booking</router-link>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link">
                <router-link class="nav-link" to="/create-wallet">Create wallet</router-link>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link">
                <router-link class="nav-link" to="/list-wallet">List wallet</router-link>
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
</template>

<script>
export default {
  // Vous pouvez ajouter des méthodes ou des données ici au besoin
};
</script>