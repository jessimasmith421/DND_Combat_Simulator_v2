<template>
  <div>
      <h2>{{weapon.weaponType}}</h2>
      <p>Damage: {{weapon.numOfDice}}d{{weapon.diceType}} {{weapon.damageType}}</p>
  </div>
</template>

<script>
import DNDService from '../services/DnDService.js'

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
        
        // EDIT: Now it will only make a call to the API if the character is still null after page creation.
    //       For some reason, the above stuff doesn't happen fast enough if you reload on a details page.
    //          OLD NOTE: This below also works, but doing it the above way makes it so that the website doesn't have to make another call to the API

    if (this.weapon == null) {
      DNDService.getWeaponById(id).then((response) => {
        this.weapon = response.data;
      });
    }

    }
}
</script>

<style>


</style>