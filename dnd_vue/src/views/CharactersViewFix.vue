<template>
  <div>
    <!-- <div class="searchBar">
      SEARCH:
      <label for="raceFilter">Race: </label>
      <div
        v-for="race in $store.state.races"
        v-bind:key="race.id"
        class="race-checkboxes"
      >
        <input
          type="checkBox"
          v-model="filter.races[race.raceType]"
          :name="race.raceType"
          v-on:change="check"
        />
        <label v-bind:for="race.raceType">{{ race.raceType }}</label>
      </div>
    </div> -->
    <div class="NewCharacter">
      <button
        v-on:click="
          addNewCharacter ? (addNewCharacter = false) : (addNewCharacter = true)
        "
      >
        {{ addNewCharacter ? "JK LMAO" : "Add New Character!" }}
      </button>
      <new-character v-show="addNewCharacter" />
    </div>
    <div class="allCharacters">
      <div
        v-for="character in characters"
        v-bind:key="character.id"
        class="characters"
      >
        <router-link
          v-bind:to="{
            name: 'CharactersDetails',
            params: { id: character.id },
          }"
        >
          <h2>{{ character.name }}</h2>
        </router-link>
        <p>Race: {{ character.race.raceType }}</p>
        <p>Weapon: {{ character.weapon.weaponType }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import DNDService from "../services/DnDService.js";
import NewCharacter from "../components/NewCharacter.vue";
export default {
  name: "CharactersView",
  components: {
    NewCharacter,
  },
  data() {
    return {
      characters: [],
      addNewCharacter: false,
      filter: {
        races: [],
        weapons: [],
        sortAZ: false,
      },
    };
  },
  methods: {
    // check(event) {
    //   console.log(event);
    //   console.log(event.target);
    //   console.log(event.target.name);
    //   let checkedRace = this.filter.races.find((r) => {
    //     r.raceType == event.target.name;
    //   });
    //   if (checkedRace.isChecked) {
    //     checkedRace.isChecked = false;
    //   } else {
    //     checkedRace.isChecked = true;
    //   }
    // },
    getCharacters() {
      DNDService.getCharacters().then((response) => {
        let list = response.data;
        this.$store.commit("GET_CHARACTERS", list);
        this.characters = list;
        this.filterRaces();
      });
    },
    sort() {
      if (this.filter.sort) {
        return this.characters.sort((a, b) => {
          let x = a.name.toLowerCase();
          let y = b.name.toLowerCase();
          if (x < y) {
            return -1;
          }
          if (x > y) {
            return 1;
          }
          return 0;
        });
      }
      return this.characters;
    },
    filterRaces() {
      return this.$store.state.races.forEach((r) => {
        let raceObj = {};
        raceObj["raceType"] = r.raceType;
        raceObj["isChecked"] = false;
        this.filter.races.push(raceObj);
      });
    },
  },
  created() {
    this.getCharacters();
  },
  computed: {
    filterList() {
      return this.characters.filter((c) => {
        if (
          this.filter.races[c.race.raceType] &&
          c.race.raceType == this.filter.race
        ) {
          return false;
        }
        if (c.weapon.weaponType == this.filter.weapon) {
          return false;
        }
        return true;
      });
    },
  },
};
</script>

<style>
.allCharacters {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
}
.characters {
  border: 2px solid black;
  width: 20vw;
  height: 20vh;
  margin: 2vh 0;
}
</style>