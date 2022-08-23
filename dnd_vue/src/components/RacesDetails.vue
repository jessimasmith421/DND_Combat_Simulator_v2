<template>
  <div>
    <h1>Races</h1>
    <div v-for="race in races" v-bind:key="race.id" class='races'>
      <h2>{{race.raceType}}</h2>
      <p>Strength bonus: {{race.strengthBonus}}</p>
      <p>Dexterity bonus: {{race.dexterityBonus}}</p>
      <p>Constitution bonus: {{race.constitutionBonus}}</p>
      <p>Intelligence bonus: {{race.intelligenceBonus}}</p>
      <p>Wisdom bonus: {{race.wisdomBonus}}</p>
      <p>Charisma bonus: {{race.charismaBonus}}</p>
      <p>Size: {{race.size}}</p>
      <p>Speed: {{race.speed}}ft</p>
      <p>Additional Traits: {{race.traits}}</p>
    </div>
  </div>
</template>

<script>

export default {
  name:"Races-View",
  props: {
    races:[]
  },
}
</script>

<style>
.races {
    border: 2px solid black;
}

</style>