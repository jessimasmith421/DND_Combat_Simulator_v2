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

    // with the adding characters method, I will need to make sure the character.race and character.weapon fields are OBJECTS, so I may need to do a find on the array or another get or something
    addNewCharacter(newChar) {
        return http.post('/characters/', newChar)
    }
}