<template>
  <div>
    <h1>Add a new Character!!</h1>
    <form v-on:submit.prevent="addCharacter()">
      <p>
        <label for="name">Name: </label>
        <input type="text" name="name" v-model="newChar.name" />
        <button v-on:click.prevent="randomNameGenerate">Random Name!</button>
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
        Stat Generation Method:
        <button v-on:click.prevent="changeStatGenMethod" v-bind:class="{active : statGen.isPointBuy}" name="pointBuy">Point Buy</button>
        <button v-on:click.prevent="changeStatGenMethod" v-bind:class="{active : statGen.isStandardArray}" name="standardArray">Standard Array</button>
        <button v-on:click.prevent="changeStatGenMethod" v-bind:class="{active : statGen.isRolled}" name="rolled">Rolled</button>
      </p>
      <div v-if="statGen.isPointBuy" id="pointBuyInfo">Total points remaining: {{statGen.points}}
        <p><a href="https://mykindofmeeple.com/how-to-use-point-buy-5e-dnd-pros-cons/">"Point buy is a method for assigning ability scores during character creation in D&D 5e. You have a set pool of points which you can use to 'buy' corresponding ability scores. When you've spent all your points, you can't increase your scores anymore."</a> </p>
        <p>You cannot have more than 15 or less than 8 in any stat. The cost to increase stats is shown below:</p>
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
      <div v-if="statGen.isStandardArray" id="standardArrayInfo">If you want to go quick, you can assign these 6 numbers to each of the 6 stats! Only use each number once!
        <p>15, 14, 13, 12, 10, 8</p>
         </div>
      <p>
        <label for="strength">Strength: </label>
        <select name="strength" id="" v-if="statGen.isStandardArray" v-model="newChar.strength" v-on:change.prevent="updateCheckArray">
          <option v-for="num in statGen.stanArray" v-bind:key="num" v-bind:value="num">{{num}}</option>
        </select>
        <input type="number" name="strength" v-model="newChar.strength" :disabled="statGen.isPointBuy" v-else/>
        <span v-if="statGen.isPointBuy"><button name= "strength" v-on:click.prevent="increaseStat" :disabled="newChar.strength ==15 || statGen.points==0">+</button><button name= "strength" v-on:click.prevent="decreaseStat" :disabled="newChar.strength ==8 || statGen.points==27">-</button></span>
      </p>
      <p>
        <label for="dexterity">Dexterity: </label>
        <select name="dexterity" id="" v-if="statGen.isStandardArray" v-model="newChar.dexterity" v-on:change.prevent="updateCheckArray">
          <option v-for="num in statGen.stanArray" v-bind:key="num" v-bind:value="num">{{num}}</option>
        </select>
        <input type="number" name="dexterity" v-model="newChar.dexterity" :disabled="statGen.isPointBuy" v-else/>
        <span v-if="statGen.isPointBuy"><button name= "dexterity" v-on:click.prevent="increaseStat" :disabled="newChar.dexterity ==15 || statGen.points==0">+</button><button name= "dexterity" v-on:click.prevent="decreaseStat" :disabled="newChar.dexterity ==8 || statGen.points==27">-</button></span>
      </p>
      <p>
        <label for="constitution">Constitution: </label>
        <select name="constitution" id="" v-if="statGen.isStandardArray" v-model="newChar.constitution" v-on:change.prevent="updateCheckArray">
          <option v-for="num in statGen.stanArray" v-bind:key="num" v-bind:value="num">{{num}}</option>
        </select>
        <input
          type="number"
          name="constitution"
          v-model="newChar.constitution"
          :disabled="statGen.isPointBuy"
          v-else
        />
        <span v-if="statGen.isPointBuy"><button name= "constitution" v-on:click.prevent="increaseStat" :disabled="newChar.constitution ==15 || statGen.points==0">+</button><button name= "constitution" v-on:click.prevent="decreaseStat" :disabled="newChar.constitution ==8 || statGen.points==27">-</button></span>
      </p>
      <p>
        <label for="intelligence">Intelligence: </label>
        <select name="intelligence" id="" v-if="statGen.isStandardArray" v-model="newChar.intelligence" v-on:change.prevent="updateCheckArray">
          <option v-for="num in statGen.stanArray" v-bind:key="num" v-bind:value="num">{{num}}</option>
        </select>
        <input
          type="number"
          name="intelligence"
          v-model="newChar.intelligence"
          :disabled="statGen.isPointBuy"
          v-else
        />
        <span v-if="statGen.isPointBuy"><button name= "intelligence" v-on:click.prevent="increaseStat" :disabled="newChar.intelligence ==15 || statGen.points==0">+</button><button name= "intelligence" v-on:click.prevent="decreaseStat" :disabled="newChar.intelligence ==8 || statGen.points==27">-</button></span>
      </p>
      <p>
        <label for="wisdom">Wisdom: </label>
        <select name="wisdom" id="" v-if="statGen.isStandardArray" v-model="newChar.wisdom" v-on:change.prevent="updateCheckArray">
          <option v-for="num in statGen.stanArray" v-bind:key="num" v-bind:value="num">{{num}}</option>
        </select>
        <input type="number" name="wisdom" v-model="newChar.wisdom" :disabled="statGen.isPointBuy" v-else/>
        <span v-if="statGen.isPointBuy"><button name= "wisdom" v-on:click.prevent="increaseStat" :disabled="newChar.wisdom ==15 || statGen.points==0">+</button><button name= "wisdom" v-on:click.prevent="decreaseStat" :disabled="newChar.wisdom ==8 || statGen.points==27">-</button></span>
      </p>
      <p>
        <label for="charisma">Charisma: </label>
        <select name="charisma" id="" v-if="statGen.isStandardArray" v-model="newChar.charisma" v-on:change.prevent="updateCheckArray">
          <option v-for="num in statGen.stanArray" v-bind:key="num" v-bind:value="num">{{num}}</option>
        </select>
        <input type="number" name="charisma" v-model="newChar.charisma" :disabled="statGen.isPointBuy" v-else/>
        <span v-if="statGen.isPointBuy"><button name= "charisma" v-on:click.prevent="increaseStat" :disabled="newChar.charisma ==15 || statGen.points==0">+</button><button name= "charisma" v-on:click.prevent="decreaseStat" :disabled="newChar.charisma ==8 || statGen.points==27">-</button></span>
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
      <input type="submit" id="submit" :disabled='conditions'/>
    </form>
  </div>
</template>

<script>
import DNDService from "@/services/DnDService";
import { nameByRace } from "fantasy-name-generator"; // this is a npm i found and installed

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
      statGen: {
        isPointBuy: false,
        points: 27,
        isStandardArray: false,
        stanArray: [8,10,12,13,14,15],
        checkArray:[],
        isRolled: false,
      },
    };
  },
  methods: {
    increaseStat(){
      switch(event.target.name){
        case 'strength':
          if(this.newChar.strength< 13){
            this.newChar.strength++;
          this.statGen.points--;
          }
          else {
            this.newChar.strength++;
            this.statGen.points -=2;
          }
            break;
          case 'dexterity':
            if(this.newChar.dexterity< 13){
            this.newChar.dexterity++;
          this.statGen.points--;
          }
          else {
            this.newChar.dexterity++;
            this.statGen.points -=2;
          }
            break;
            case 'constitution':
            if(this.newChar.constitution< 13){
            this.newChar.constitution++;
          this.statGen.points--;
          }
          else {
            this.newChar.constitution++;
            this.statGen.points -=2;
          }
            break;
            case 'intelligence':
            if(this.newChar.intelligence< 13){
            this.newChar.intelligence++;
          this.statGen.points--;
          }
          else {
            this.newChar.intelligence++;
            this.statGen.points -=2;
          }
            break;
            case 'wisdom':
            if(this.newChar.wisdom< 13){
            this.newChar.wisdom++;
          this.statGen.points--;
          }
          else {
            this.newChar.wisdom++;
            this.statGen.points -=2;
          }
            break;
            case 'charisma':
            if(this.newChar.charisma< 13){
            this.newChar.charisma++;
          this.statGen.points--;
          }
          else {
            this.newChar.charisma++;
            this.statGen.points -=2;
          }
            break;

      }
    },
    decreaseStat(event){
      switch(event.target.name){
        case 'strength':
          if(this.newChar.strength<= 13){
            this.newChar.strength--;
          this.statGen.points++;
          }
          else {
            this.newChar.strength--;
            this.statGen.points +=2;
          }
            break;
          case 'dexterity':
            if(this.newChar.dexterity<= 13){
            this.newChar.dexterity--;
          this.statGen.points++;
          }
          else {
            this.newChar.dexterity--;
            this.statGen.points +=2;
          }
            break;
            case 'constitution':
            if(this.newChar.constitution<= 13){
            this.newChar.constitution--;
          this.statGen.points++;
          }
          else {
            this.newChar.constitution--;
            this.statGen.points +=2;
          }
            break;
            case 'intelligence':
            if(this.newChar.intelligence<= 13){
            this.newChar.intelligence--;
          this.statGen.points++;
          }
          else {
            this.newChar.intelligence--;
            this.statGen.points +=2;
          }
            break;
            case 'wisdom':
            if(this.newChar.wisdom<= 13){
            this.newChar.wisdom--;
          this.statGen.points++;
          }
          else {
            this.newChar.wisdom--;
            this.statGen.points +=2;
          }
            break;
            case 'charisma':
            if(this.newChar.charisma<= 13){
            this.newChar.charisma--;
          this.statGen.points++;
          }
          else {
            this.newChar.charisma--;
            this.statGen.points +=2;
          }
            break;

      }
    },
    changeStatGenMethod(event) {
      console.log(event);
      if (event.target.name == "pointBuy" && !this.statGen.isPointBuy) {
        this.statGen.isPointBuy = true;
        this.statGen.isStandardArray = false;
        this.statGen.isRolled = false;
        this.statGen.points = 27;
        this.newChar.strength = 8;
        this.newChar.dexterity= 8;
        this.newChar.constitution = 8;
        this.newChar.intelligence = 8;
        this.newChar.wisdom = 8;
        this.newChar.charisma = 8;
      } else if (
        event.target.name == "standardArray" &&
        !this.statGen.isStandardArray
      ) {
        this.statGen.isPointBuy = false;
        this.statGen.isStandardArray = true;
        this.statGen.isRolled = false;
       
          this.newChar.strength= 0;
          this.newChar.dexterity= 0;
          this.newChar.constitution= 0;
          this.newChar.intelligence= 0;
          this.newChar.wisdom= 0;
          this.newChar.charisma= 0;
        
        this.statGen.checkArray = [];
      } else if (event.target.name == "rolled" && !this.statGen.isRolled) {
        this.statGen.isPointBuy = false;
        this.statGen.isStandardArray = false;
        this.statGen.isRolled = true;
      }
      console.log("point buy", this.statGen.isPointBuy);
      console.log("standard array", this.statGen.isStandardArray);
      console.log("rolled", this.statGen.isRolled);
    },
    randomNameGenerate() {
      let randoName = nameByRace("human", {
        allowMultipleNames: true,
      });
      // console.log(randoName);
      this.newChar.name = randoName;
    },
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
        this.statGen= {
          isPointBuy: false,
        points: 27,
        isStandardArray: false,
        checkArray: [],
        isRolled: false,
        }
      });
    },
    updateCheckArray(event){
      if(!this.statGen.checkArray.includes(event.target.value)){

        this.statGen.checkArray.push(event.target.value);
      }
      console.log(this.statGen.checkArray.length)
    }

  },
  created() {},
  computed: {
    conditions(){
      if (this.statGen.isPointBuy && this.statGen.points>=0) {
        return false;
      }
      // else if (!this.statGen.isPointBuy){
      //   return false;
      // }
      else if (this.statGen.isStandardArray && this.statGen.checkArray.length == 6){// this doesn't work perfectly because they could add all the stats to the check array and then change them to submit but it's a start
          return false;
      }
      return true;
    }
  },
};
</script>

<style>
#pointBuyInfo{
  width: 75%;
  text-align: center;
}
table{
  border: 1px solid black;
  margin: auto;
  padding: 5px;
}

form {
  display: flex;
  flex-direction: column;
  /* justify-content: center; */
  align-items: center;
}
#submit {
  width: 30%;
}

.active{
  background-color: red;
}
</style>