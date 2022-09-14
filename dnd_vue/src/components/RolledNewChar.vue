<template>
  <div>
    <div v-if="statGen.isRolled" id="rolledInfo">
        When you roll stats, you roll 4 6-sided dice and add the three highest
        numbers together (dropping the lowest number!)
        <div>
          <table>
            <thead>
              <th v-for="(button, index) in 6" v-bind:key="index">
                <button v-on:click.prevent="rollStat" v-bind:id="index">
                  ROLL DICE
                </button>
              </th>
              <!-- <th>
                <button v-on:click.prevent="rollStat" id="roll2">
                  ROLL DICE
                </button>
              </th>
              <th>
                <button v-on:click.prevent="rollStat" id="roll3">
                  ROLL DICE
                </button>
              </th>
              <th>
                <button v-on:click.prevent="rollStat" id="roll4">
                  ROLL DICE
                </button>
              </th>
              <th>
                <button v-on:click.prevent="rollStat" id="roll5">
                  ROLL DICE
                </button>
              </th>
              <th>
                <button v-on:click.prevent="rollStat" id="roll6">
                  ROLL DICE
                </button>
              </th> -->
            </thead>
            <tbody>
              <tr>
                <td
                  v-for="num in statGen.rolledNums"
                  v-bind:key="num.id"
                  
                >
                  {{ num.roll }}
                </td>
              </tr>
            </tbody>
          </table>
        </div>
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
            v-for="numObj in statGen.rolledNums"
            v-bind:key="numObj.id"
            v-bind:value="numObj.roll"
          >
            {{ numObj.id }}. {{ numObj.roll }}
          </option>
          </select>
          </p>
  </div>
</template>

<script>
export default {
    props: {
        newChar: Object,
        statGen: Object,
    },
     emits:['model'],
     methods: {
        rollStat(){
            this.$emit('rollStat','$event')
        },
        updateCheckArray(){
        this.$emit('updateCheckArray', '$event')
    }
     }

}
</script>

<style>

</style>