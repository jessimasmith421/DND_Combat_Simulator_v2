import axios from "axios";

const http = axios.create({
    baseURL: "http://localhost:3405"
  });

export default{
    getRaceById(id){
        return http.get('/races/' + id);
    },
    getRaces() {
        return http.get('/races/');
    },
    getWeaponById(id){
        return http.get('/weapons/' + id);
    },
    getWeapons() {
        return http.get('/weapons/');
    },
}