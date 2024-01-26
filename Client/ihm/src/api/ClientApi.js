// clientApi.js
const BASE_URL = "http://localhost:5104/api/clients"; 

export const getAllClients = async () => {
  const response = await fetch(BASE_URL);
  return response.json();
};

export const createClient = async (clientData) => {
  const response = await fetch(BASE_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(clientData),
  });
  return response.json();
};
