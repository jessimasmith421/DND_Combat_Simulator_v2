import axios from "axios";

const http = axios.create({
    baseURL: "http://localhost:3405"
  });

export default{
    getRaceById(id){
        return http.get('/races/' + id);
    },
    //Gets all the races
    getRaces() {
        return http.get('/races/');
    },
    getWeaponById(id){
        return http.get('/weapons/' + id);
    },
    //Gets all weapons
    getWeapons() {
        return http.get('/weapons/');
    },
    getCharacterById(id){
        return http.get('/characters/' + id);
    },
    //Gets all characters
    getCharacters() {
        return http.get('/characters/');
    },
}