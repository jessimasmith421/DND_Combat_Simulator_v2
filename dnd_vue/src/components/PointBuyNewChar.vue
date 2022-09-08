<template>
    <div>
        <div v-if="statGen.isPointBuy" id="pointBuyInfo">
        Total points remaining: {{ statGen.points }}
        <p>
          <a
            href="https://mykindofmeeple.com/how-to-use-point-buy-5e-dnd-pros-cons/"
            >"Point buy is a method for assigning ability scores during
            character creation in D&D 5e. You have a set pool of points which
            you can use to 'buy' corresponding ability scores. When you've spent
            all your points, you can't increase your scores anymore."</a
          >
        </p>
        <p>
          You cannot have more than 15 or less than 8 in any stat. The cost to
          increase stats is shown below:
        </p>
        <table>
          <thead>
            <th>Score</th>
            <th>Cost</th>
          </thead>
          <tbody>
            <tr>
              <td>8</td>
              <td>0</td>
            </tr>
            <tr>
              <td>9</td>
              <td>1</td>
            </tr>
            <tr>
              <td>10</td>
              <td>2</td>
            </tr>
            <tr>
              <td>11</td>
              <td>3</td>
            </tr>
            <tr>
              <td>12</td>
              <td>4</td>
            </tr>
            <tr>
              <td>13</td>
              <td>5</td>
            </tr>
            <tr>
              <td>14</td>
              <td>7</td>
            </tr>
            <tr>
              <td>15</td>
              <td>9</td>
            </tr>
          </tbody>
        </table>
      </div>
      <p v-for="(stat,index) in newChar.stats" v-bind:key="index">
        <label v-bind:for="stat"> {{stat.name[0].toUpperCase() + stat.name.substring(1)}}: </label>
        <input
          type="number"
          v-bind:name="stat.name"
          v-bind:value="newChar.stats[index].value"
          :disabled="statGen.isPointBuy"
        />
        <span v-if="statGen.isPointBuy"
          ><button
            v-bind:name="stat.name"
            v-on:click.prevent="increaseStat"
            :disabled="newChar.stats[index].value== 15 || statGen.points == 0"
          >
            +</button
          ><button
            v-bind:name="stat.name"
            v-on:click.prevent="decreaseStat"
            :disabled="newChar.stats[index].value == 8 || statGen.points == 27"
          >
            -
          </button></span
        >
      </p>
    </div>
</template>

<script>
export default {
    props: {
        newChar: Object,
        statGen: Object
    },
    emits:['model','increaseStat', 'decreaseStat'],
    methods: {
        increaseStat() {
            this.$emit('increaseStat','$event')
            //console.log(event);
        },
        decreaseStat() {
            this.$emit('decreaseStat','$event')
            //console.log(event)
        }
    }

}
</script>

<style>

</style>