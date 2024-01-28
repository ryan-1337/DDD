# DDD

Ubiquitous Language :

Endpoints :

    Clients :
        GET /clients/{id} : Récupère les détails d'un client spécifique.
        POST /clients : Crée un nouveau client.

    Bookings :
        GET /bookings : Récupère la liste des réservations en fonction de l'id client.
        GET /bookings/{id} : Récupère les détails d'une réservation spécifique.
        POST /bookings : Crée une nouvelle réservation.
        PUT /bookings/{id} : Met à jour les informations d'une réservation existante.

    Rooms :
        GET /rooms : Récupère la liste des chambres.
        GET /rooms/{id} : Récupère les détails d'une chambre spécifique.

    Paiements :
        GET /payments : Récupère la liste des paiements.
        GET /payments/{id} : Récupère les détails d'un paiement spécifique.
        POST /payments : Crée un nouveau paiement.
        PUT /payments/{id} : Met à jour les informations d'un paiement existant.
        DELETE /payments/{id} : Supprime un paiement existant.


    Wallets :
        GET /wallet/{id} : Récupère les détails d'un wallet en fonction de l'id client.
        POST /wallet : Crée un nouveau wallet pour un client.
        PUT /wallet/{id} : Met à jour les informations d'un w wallet existant.


Modèles de données :

    Client :
        id : Identifiant unique du client.
        fullName : Nom complet du client.
        email : Adresse email du client.
        phoneNumber : Numéro de téléphone du client.

    Booking :
        id : Identifiant unique de la réservation.
        clientId : Identifiant du client associé à la réservation.
        roomId : Identifiant de la chambre réservée.
        checkInDate : Date d'arrivée.
        amount : Montant de la reservation.

    Room :
        id : Identifiant unique de la chambre.
        name : Nom ou numéro de la chambre.
        type : Type de chambre (simple, double, suite, etc.).
        pricePerNight : Prix par nuitée de la chambre.

    Paiement :
        id : Identifiant unique du paiement.
        bookingId : Identifiant de la réservation associée au paiement.
        amount : Montant du paiement.
        currency : Devise du paiement (EUR, USD, etc.).
        paymentDate : Date du paiement.


    Wallet :
        id : Identifiant unique du walet.
        clientId : Identifiant de wallet du client.
        amount : Montant du paiement.
        currency : Devise du wallet (EUR, USD, etc.).
