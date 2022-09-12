<template>
<div>

  <div v-if="statGen.isStandardArray" id="standardArrayInfo">
        If you want to go quick, you can assign these 6 numbers to each of the 6
        stats! Only use each number once!
        <p>15, 14, 13, 12, 10, 8</p>
      </div>
      <p v-for="(stat,index) in newChar.stats" v-bind:key="index">
        <label v-bind:for="stat">{{stat.name[0].toUpperCase() + stat.name.substring(1)}}: </label>
        <select
          v-bind:name="stat.name"
          id=""
          v-bind:value="newChar.stats[index].value"
          v-on:change="updateCheckArray"
        >
          <option
            v-for="num in statGen.stanArray"
            v-bind:key="num"
            v-bind:value="num"
          >
            {{ num }}
          </option>
        </select>
      </p>
</div>
</template>

<script>
export default {
props: {
    newChar: Object,
    statGen: Object
},
emits: ['model','updateCheckArray'],
methods: {
    updateCheckArray(){
        // console.log(event)
        // console.log(event.target.value)
        this.$emit('updateCheckArray', '$event')
    }
}
}
</script>

<style>

</style>