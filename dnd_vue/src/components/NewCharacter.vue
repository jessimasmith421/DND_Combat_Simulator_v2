<template>
  <div>
    <h1>Add a new Character!!</h1>
    <form v-on:submit.prevent="addCharacter()">
        <p>

      <label for="name">Name: </label>
      <input type="text" name="name" v-model="newChar.name" />
        </p>
        <p>

      <label for="race">Race: </label>
      <select name="race" v-model="newChar.race">
        <option value=""></option>
        <option
          v-for="race in $store.state.races"
          v-bind:key="race.id"
          v-bind:value="race.raceType"
        >
          {{ race.raceType }}
        </option>
      </select>
        </p>
      <p>

      <label for="strength">Strength: </label>
      <input type="number" name="strength" v-model="newChar.strength" />
      </p>
      <p>

      <label for="dexterity">Dexterity: </label>
      <input type="number" name="dexterity" v-model="newChar.dexterity" />
      </p>
      <p>

      <label for="constitution">Constitution: </label>
      <input type="number" name="constitution" v-model="newChar.constitution" />
      </p>
      <p>

      <label for="intelligence">Intelligence: </label>
      <input type="number" name="intelligence" v-model="newChar.intelligence" />
      </p>
      <p>

      <label for="wisdom">Wisdom: </label>
      <input type="number" name="wisdom" v-model="newChar.wisdom" />
      </p>
      <p>

      <label for="charisma">Charisma: </label>
      <input type="number" name="charisma" v-model="newChar.charisma" />
      </p>
      <p>
        
      <label for="weapon">Weapon: </label>
      <select name="weapon" v-model="newChar.weapon">
        <option value=""></option>
        <option
          v-for="weapon in $store.state.weapons"
          v-bind:key="weapon.id"
          v-bind:value="weapon.weaponType"
        >
          {{ weapon.weaponType }}
        </option>
      </select>
      </p>
      <input type="submit" id="submit"/>
    </form>
  </div>
</template>

<script>
import DNDService from "@/services/DnDService";
export default {
  name: "CharactersView",
  data() {
    return {
      newChar: {
        name: "",
        race: "", //this cannot stay as a string!!! on click, before it is sent, it needs to be an object!!
        strength: 0,
        dexterity: 0,
        constitution: 0,
        intelligence: 0,
        wisdom: 0,
        charisma: 0,
        weapon: "", //this cannot stay as a string!!!! on click, before it is sent, it needs to be an object!!
      },
    };
  },
  methods: {
    addCharacter() {
      console.log(this.newChar.race);
      let findRace = this.$store.state.races.find(
        (r) => r.raceType.toLowerCase() == this.newChar.race.toLowerCase()
      );
      console.log(findRace);
      this.newChar.race = findRace;
      console.log(this.newChar.weapon);
      let findWeapon = this.$store.state.weapons.find(
        (r) => r.weaponType.toLowerCase() == this.newChar.weapon.toLowerCase()
      );
      console.log(findWeapon);
      this.newChar.weapon = findWeapon;
      DNDService.addNewCharacter(this.newChar).then((response) => {
        this.newChar = response.data;
        this.$store.commit("ADD_CHARACTER", this.newChar);
        this.newChar = {
          name: "",
          race: "",
          strength: 0,
          dexterity: 0,
          constitution: 0,
          intelligence: 0,
          wisdom: 0,
          charisma: 0,
          weapon: "",
        };
      });
    },
  },
  created() {},
  computed: {},
};
</script>

<style>
form{
    display: flex;
    flex-direction: column;
    /* justify-content: center; */
    align-items: center;
}
#submit{
    width: 30%;
}
</style>