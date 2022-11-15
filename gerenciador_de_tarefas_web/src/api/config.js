import axios from 'axios'

const url = "https://localhost:44371/api/"

const api = axios.create({
    baseURL: url,
    headers: { 'Content-Type': 'application/json' },
});

export default api;