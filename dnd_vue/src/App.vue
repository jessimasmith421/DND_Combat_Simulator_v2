<template>
  <div id="app">
    <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/races">Races</router-link> |
      <router-link to="/weapons">Weapons</router-link> |
      <router-link to="/characters">Characters</router-link>
    </nav>
    <router-view/>
  </div>
</template>

<script>
import DNDService from './services/DnDService.js'

export default {
  setup() {
    
  },
  created() {
    DNDService.getRaces()
      .then(response=>{
        let racesList = response.data;
        this.$store.commit('GET_RACES', racesList);
      } );
      DNDService.getWeapons()
        .then(response =>{
          let weaponsList = response.data;
          this.$store.commit('GET_WEAPONS',weaponsList);
        })
      DNDService.getCharacters()
      .then(response => {
        let charactersList = response.data;
        this.$store.commit('GET_CHARACTERS', charactersList)
      });
  }
}
</script>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
