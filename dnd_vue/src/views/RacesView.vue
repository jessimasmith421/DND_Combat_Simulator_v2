<template>
  <div>
    <div v-for="race in races" v-bind:key="race.id" class='races'>
    <router-link v-bind:to="{name:'RacesDetails', params: {id: race.id}}"> 
    <h2>{{race.raceType}}</h2>
    </router-link>
    </div>
  </div>
</template>

<script>
import DNDService from '../services/DnDService.js';
//import RacesDetails from '@/components/RacesDetails.vue'
export default {
  // components: { RacesDetails },
  data() {
    return {
      races: [],
    };
  },
  methods: {
    getRaces() {
      DNDService.getRaces()
      .then(response => {
        let list = response.data;
        this.$store.commit('GET_RACES', response.data);
        this.races = list;
        
      });
    },
},
    created() {
        this.getRaces();
    }
}
</script>

<style>
.races {
    border: 2px solid black;
}

</style>