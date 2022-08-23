import axios from "axios";

const http = axios.create({
    baseURL: "http://localhost:3405"
  });

export default{
    getRaceById(id){
        return http.get(`/races/${id}`);
    },
    getRaces() {
        return http.get('/races/');
    }
}