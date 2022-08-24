<template>
  <div>
      <h2>{{race.raceType}}</h2>
      <p>Size: {{race.size}}</p>
      <p>Speed: {{race.speed}}ft</p>
      <p>Additional Traits: {{race.traits}}</p>
      <h3>Bonuses</h3>
      <p v-if="race.strengthBonus!=0">Strength bonus: {{race.strengthBonus}}</p>
      <p v-if="race.dexterityBonus!=0">Dexterity bonus: {{race.dexterityBonus}}</p>
      <p v-if="race.constitutionBonus!=0">Constitution bonus: {{race.constitutionBonus}}</p>
      <p v-if="race.intelligenceBonus!=0">Intelligence bonus: {{race.intelligenceBonus}}</p>
      <p v-if="race.wisdomBonus!=0">Wisdom bonus: {{race.wisdomBonus}}</p>
      <p v-if="race.charismaBonus!=0">Charisma bonus: {{race.charismaBonus}}</p>
  </div>
</template>

<script>
//import DNDService from '../services/DnDService.js'

export default {
  name:"RacesDetails",
  data() {
    return {
      race: {}
    }
  },
  props: {},
  created() {
        //console.log('this is the id',this.$route.params.id)
        let id = this.$route.params.id;
        this.race = this.$store.state.races.find(r => r.id == id)
        
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