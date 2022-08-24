<template>
  <div>
      <h2>{{weapon.weaponType}}</h2>
      <p>Damage: {{weapon.numOfDice}}d{{weapon.diceType}} {{weapon.damageType}}</p>
  </div>
</template>

<script>
//import DNDService from '../services/DnDService.js'

export default {
  name:"WeaponsDetails",
  data() {
    return {
      weapon: {}
    }
  },
  props: {},
  created() {
        //console.log('this is the id',this.$route.params.id)
        let id = this.$route.params.id;
        this.weapon = this.$store.state.weapons.find(r => r.id == id)
        
        // This below also works, but doing it the above way makes it so that the website doesn't have to make another call to the API
        // DNDService.getRaceById(id)
        //   .then(response => {
        //     this.race = response.data;

        //   })

    }
}
</script>

<style>


</style>