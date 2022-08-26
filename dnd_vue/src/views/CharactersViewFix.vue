<template>
  <div>
    <new-character />
    <div v-for="character in characters" v-bind:key="character.id" class="characters">
      <router-link
        v-bind:to="{ name: 'CharactersDetails', params: { id: character.id } }"
      >
        <h2>{{character.name}}</h2>
      </router-link>
    </div>
  </div>
</template>

<script>
import DNDService from "../services/DnDService.js"
import NewCharacter from "../components/NewCharacter.vue"
export default {
  name: 'CharactersView',
  components:{
    NewCharacter
  },
  data() {
    return {
      characters: [],
    };
  },
  methods: {
    getCharacters() {
      DNDService.getCharacters().then((response) => {
        let list = response.data;
        this.$store.commit("GET_CHARACTERS", list);
        this.characters = list;
      });
    },
  },
  created() {
    this.getCharacters();
  },
};
</script>

<style>
.characters {
  border: 2px solid black;
}
</style>