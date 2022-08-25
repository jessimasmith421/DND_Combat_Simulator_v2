<template>
  <div>
    <h2>{{ character.name }}</h2>
    <p>Race: <router-link v-bind:to="{name:'RacesDetails', params: {id: character.race.id}}">{{character.race.raceType}}</router-link></p>
    <p>Strength: {{character.strength + character.race.strengthBonus}}</p>
    <p>Dexterity: {{character.dexterity + character.race.dexterityBonus}}</p>
    <p>Constitution: {{character.constitution + character.race.constitutionBonus}}</p>
    <p>Intelligence: {{character.intelligence + character.race.intelligenceBonus}}</p>
    <p>Wisdom: {{character.wisdom + character.race.wisdomBonus}}</p>
    <p>Charisma: {{character.charisma + character.race.charismaBonus}}</p>
    <p>Weapon: <router-link v-bind:to="{name:'WeaponsDetails', params: {id: character.weapon.id}}">{{character.weapon.weaponType}}</router-link></p>
  </div>
</template>

<script>
import DNDService from "../services/DnDService.js";

export default {
  name: "CharactersDetails",
  data() {
    return {
      character: null,
    };
  },
  props: {},
  created() {
    //console.log('this is the id',this.$route.params.id)
    let id = this.$route.params.id;
    this.character = this.$store.state.characters.find((r) => r.id == id);

    // EDIT: Now it will only make a call to the API if the character is still null after page creation.
    //       For some reason, the above stuff doesn't happen fast enough if you reload on a details page.
    //          OLD NOTE: This below also works, but doing it the above way makes it so that the website doesn't have to make another call to the API

    if (this.character == null) {
      DNDService.getCharacterById(id).then((response) => {
        this.character = response.data;
      });
    }
  },
};
</script>

<style>
</style>