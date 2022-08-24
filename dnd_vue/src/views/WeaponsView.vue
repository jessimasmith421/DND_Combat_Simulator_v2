<template>
  <div>
    <div v-for="weapon in weapons" v-bind:key="weapon.id" class='weapons'>
    <router-link v-bind:to="{name:'WeaponsDetails', params: {id: weapon.id}}"> 
    <h2>{{weapon.weaponType}}</h2>
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
      weapons: [],
    };
  },
  methods: {
    getWeapons() {
      DNDService.getWeapons()
      .then(response => {
        let list = response.data;
        this.$store.commit('GET_WEAPONS', response.data);
        this.weapons = list;
        
      });
    },
},
    created() {
        this.getWeapons();
    }
}
</script>

<style>
.weapons {
    border: 2px solid black;
}

</style>