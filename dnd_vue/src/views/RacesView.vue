<template>
  <div>
    <races-details :races="races"/>
  </div>
</template>

<script>
import DNDService from '../services/DnDService.js';
import RacesDetails from '@/components/RacesDetails.vue'
export default {
  components: { RacesDetails },
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

</style>