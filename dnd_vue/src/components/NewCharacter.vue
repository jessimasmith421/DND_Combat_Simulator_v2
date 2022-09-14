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
        <button
          v-on:click.prevent="changeStatGenMethod"
          v-bind:class="{ active: statGen.isPointBuy }"
          name="pointBuy"
        >
          Point Buy
        </button>
        <button
          v-on:click.prevent="changeStatGenMethod"
          v-bind:class="{ active: statGen.isStandardArray }"
          name="standardArray"
        >
          Standard Array
        </button>
        <button
          v-on:click.prevent="changeStatGenMethod"
          v-bind:class="{ active: statGen.isRolled }"
          name="rolled"
        >
          Rolled
        </button>
        <button v-on:click.prevent="reset" id="reset">RESET</button>
      </p>
      <point-buy-new-char
        :newChar="newChar"
        :statGen="statGen"
        @increaseStat="increaseStat"
        @decreaseStat="decreaseStat"
        v-if="statGen.isPointBuy"
      />
      <standard-array-new-char :newChar.sync="newChar" :statGen.sync="statGen" @updateCheckArray="updateCheckArray" v-else-if="statGen.isStandardArray" />
      <rolled-new-char :newChar="newChar" :statGen="statGen" v-else-if="statGen.isRolled" @rollStat="rollStat"  @updateCheckArray="updateCheckArray" />
      
      <div v-else> <!-- Add a v-else here!!! for when stats are not rolled, stan array, or point buy-->

      <p> <!-- loop through stats array here -->
        <label for="strength">Strength: </label>
        
         
          
        <input
          type="number"
          name="strength"
          v-model="newChar.strength"
          :disabled="statGen.isPointBuy"
          
        />
                
      </p>
      <p v-if="!statGen.isPointBuy">
        <label for="dexterity">Dexterity: </label>
        <select
          name="dexterity"
          id=""
          v-if="statGen.isStandardArray || statGen.isRolled"
          v-model="newChar.dexterity"
          v-on:change="updateCheckArray"
        >
          <!-- <option
            v-for="num in statGen.stanArray"
            v-bind:key="num"
            v-bind:value="num"
            v-show="statGen.isStandardArray"
          >
            {{ num }}
          </option> -->
          <option
            v-show="statGen.isRolled"
            v-for="numObj in statGen.rolledNums"
            v-bind:key="numObj.id"
            v-bind:value="numObj"
          >
            {{ numObj.id }}. {{ numObj.roll }}
          </option>
        </select>
        <input
          type="number"
          name="dexterity"
          v-model="newChar.dexterity"
          :disabled="statGen.isPointBuy"
          v-else
        />
        <span v-if="statGen.isPointBuy"
          ><button
            name="dexterity"
            v-on:click.prevent="increaseStat"
            :disabled="newChar.dexterity == 15 || statGen.points == 0"
          >
            +</button
          ><button
            name="dexterity"
            v-on:click.prevent="decreaseStat"
            :disabled="newChar.dexterity == 8 || statGen.points == 27"
          >
            -
          </button></span
        >
      </p>
      <p v-if="!statGen.isPointBuy">
        <label for="constitution">Constitution: </label>
        <select
          name="constitution"
          id=""
          v-if="statGen.isStandardArray || statGen.isRolled"
          v-model="newChar.constitution"
          v-on:change="updateCheckArray"
        >
          <!-- <option
            v-for="num in statGen.stanArray"
            v-bind:key="num"
            v-bind:value="num"
            v-show="statGen.isStandardArray"
          >
            {{ num }}
          </option> -->
          <option
            v-show="statGen.isRolled"
            v-for="numObj in statGen.rolledNums"
            v-bind:key="numObj.id"
            v-bind:value="numObj"
          >
            {{ numObj.id }}. {{ numObj.roll }}
          </option>
        </select>
        <input
          type="number"
          name="constitution"
          v-model="newChar.constitution"
          :disabled="statGen.isPointBuy"
          v-else
        />
        <span v-if="statGen.isPointBuy"
          ><button
            name="constitution"
            v-on:click.prevent="increaseStat"
            :disabled="newChar.constitution == 15 || statGen.points == 0"
          >
            +</button
          ><button
            name="constitution"
            v-on:click.prevent="decreaseStat"
            :disabled="newChar.constitution == 8 || statGen.points == 27"
          >
            -
          </button></span
        >
      </p>
      <p v-if="!statGen.isPointBuy">
        <label for="intelligence">Intelligence: </label>
        <select
          name="intelligence"
          id=""
          v-if="statGen.isStandardArray || statGen.isRolled"
          v-model="newChar.intelligence"
          v-on:change="updateCheckArray"
        >
          <!-- <option
            v-for="num in statGen.stanArray"
            v-bind:key="num"
            v-bind:value="num"
            v-show="statGen.isStandardArray"
          >
            {{ num }}
          </option> -->
          <option
            v-show="statGen.isRolled"
            v-for="numObj in statGen.rolledNums"
            v-bind:key="numObj.id"
            v-bind:value="numObj"
          >
            {{ numObj.id }}. {{ numObj.roll }}
          </option>
        </select>
        <input
          type="number"
          name="intelligence"
          v-model="newChar.intelligence"
          :disabled="statGen.isPointBuy"
          v-else
        />
        <span v-if="statGen.isPointBuy"
          ><button
            name="intelligence"
            v-on:click.prevent="increaseStat"
            :disabled="newChar.intelligence == 15 || statGen.points == 0"
          >
            +</button
          ><button
            name="intelligence"
            v-on:click.prevent="decreaseStat"
            :disabled="newChar.intelligence == 8 || statGen.points == 27"
          >
            -
          </button></span
        >
      </p>
      <p v-if="!statGen.isPointBuy">
        <label for="wisdom">Wisdom: </label>
        <select
          name="wisdom"
          id=""
          v-if="statGen.isStandardArray || statGen.isRolled"
          v-model="newChar.wisdom"
          v-on:change="updateCheckArray"
        >
          <!-- <option
            v-for="num in statGen.stanArray"
            v-bind:key="num"
            v-bind:value="num"
            v-show="statGen.isStandardArray"
          >
            {{ num }}
          </option> -->
          <option
            v-show="statGen.isRolled"
            v-for="numObj in statGen.rolledNums"
            v-bind:key="numObj.id"
            v-bind:value="numObj"
          >
            {{ numObj.id }}. {{ numObj.roll }}
          </option>
        </select>
        <input
          type="number"
          name="wisdom"
          v-model="newChar.wisdom"
          :disabled="statGen.isPointBuy"
          v-else
        />
        <span v-if="statGen.isPointBuy"
          ><button
            name="wisdom"
            v-on:click.prevent="increaseStat"
            :disabled="newChar.wisdom == 15 || statGen.points == 0"
          >
            +</button
          ><button
            name="wisdom"
            v-on:click.prevent="decreaseStat"
            :disabled="newChar.wisdom == 8 || statGen.points == 27"
          >
            -
          </button></span
        >
      </p>
      <p v-if="!statGen.isPointBuy">
        <label for="charisma">Charisma: </label>
        <select
          name="charisma"
          id=""
          v-if="statGen.isStandardArray || statGen.isRolled"
          v-model="newChar.charisma"
          v-on:change="updateCheckArray"
        >
          <!-- <option
            v-for="num in statGen.stanArray"
            v-bind:key="num"
            v-bind:value="num"
            v-show="statGen.isStandardArray"
          >
            {{ num }}
          </option> -->
          <option
            v-show="statGen.isRolled"
            v-for="numObj in statGen.rolledNums"
            v-bind:key="numObj.id"
            v-bind:value="numObj"
          >
            {{ numObj.id }}. {{ numObj.roll }}
          </option>
        </select>
        <input
          type="number"
          name="charisma"
          v-model="newChar.charisma"
          :disabled="statGen.isPointBuy"
          v-else
        />
        <span v-if="statGen.isPointBuy"
          ><button
            name="charisma"
            v-on:click.prevent="increaseStat"
            :disabled="newChar.charisma == 15 || statGen.points == 0"
          >
            +</button
          ><button
            name="charisma"
            v-on:click.prevent="decreaseStat"
            :disabled="newChar.charisma == 8 || statGen.points == 27"
          >
            -
          </button></span
        >
      </p>
      </div>
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
      <input type="submit" id="submit" :disabled="conditions" />
      <button v-on:click.prevent="randomCharacterGenerator">
        RANDOM CHARACTER!!!
      </button>
    </form>
  </div>
</template>

<script>
import DNDService from "@/services/DnDService";
import { nameByRace } from "fantasy-name-generator"; // this is a npm i found and installed
import PointBuyNewChar from "./PointBuyNewChar.vue";
import StandardArrayNewChar from "./StandardArrayNewChar.vue";
import RolledNewChar from "./RolledNewChar.vue";

export default {
  components: { PointBuyNewChar, StandardArrayNewChar, RolledNewChar },
  name: "CharactersView",
  data() {
    return {
      newChar: {
        name: "",
        race: "", //this cannot stay as a string!!! on click, before it is sent, it needs to be an object!!
        stats: [
          { name: "strength", value: 0 },
          { name: "dexterity", value: 0 },
          { name: "constitution", value: 0 },
          { name: "intelligence", value: 0 },
          { name: "wisdom", value: 0 },
          { name: "charisma", value: 0 },
        ],
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
        stanArray: [8, 10, 12, 13, 14, 15],
        checkArray: [],
        isRolled: false,
        rolledNums: [
          { id: 1, roll: "-" },
          { id: 2, roll: "-" },
          { id: 3, roll: "-" },
          { id: 4, roll: "-" },
          { id: 5, roll: "-" },
          { id: 6, roll: "-" },
        ],
      },
    };
  },
  methods: {
    randomCharacterGenerator() {
      this.reset();
      this.randomNameGenerate();
      this.newChar.strength = this.diceStatRoll();
      this.newChar.dexterity = this.diceStatRoll();
      this.newChar.constitution = this.diceStatRoll();
      this.newChar.intelligence = this.diceStatRoll();
      this.newChar.wisdom = this.diceStatRoll();
      this.newChar.charisma = this.diceStatRoll();
      let numOfWeapons = this.$store.state.weapons.length;
      let weaponIndex = Math.floor(Math.random() * numOfWeapons);
      this.newChar.weapon = this.$store.state.weapons[weaponIndex].weaponType;
      let numOfRaces = this.$store.state.races.length;
      let raceIndex = Math.floor(Math.random() * numOfRaces);
      this.newChar.race = this.$store.state.races[raceIndex].raceType;
    },
    diceStatRoll() {
      const maxNumber = 6;
      const nums = [];
      nums.push(Math.floor(Math.random() * maxNumber) + 1); //first dice roll
      nums.push(Math.floor(Math.random() * maxNumber) + 1); //second dice roll
      nums.push(Math.floor(Math.random() * maxNumber) + 1); //third dice roll
      nums.push(Math.floor(Math.random() * maxNumber) + 1); //fourth dice roll
      nums.sort(); //organizes list from smallest to largest
      nums.shift(); //removes the first element of the array
      let diceRoll = nums[0] + nums[1] + nums[2]; //adds the elements of the array together
      return diceRoll;
    },
    rollStat() {
      let diceRoll = this.diceStatRoll();
      let id = parseInt(event.target.id) + 1; //add one so that the numbers are 1-6, not 0-5
      this.statGen.rolledNums.find((o) => {
        if (o.id == id) {
          o.roll = diceRoll;
        }
      });
      event.target.disabled = true;
    },
    reset() {
      (this.newChar = {
        name: "",
        race: "",
        stats: [
          { name: "strength", value: 0 },
          { name: "dexterity", value: 0 },
          { name: "constitution", value: 0 },
          { name: "intelligence", value: 0 },
          { name: "wisdom", value: 0 },
          { name: "charisma", value: 0 },
        ],
        strength: 0,
        dexterity: 0,
        constitution: 0,
        intelligence: 0,
        wisdom: 0,
        charisma: 0,
        weapon: "",
      }),
        (this.statGen = {
          isPointBuy: false,
          points: 27,
          isStandardArray: false,
          stanArray: [8, 10, 12, 13, 14, 15],
          checkArray: [],
          isRolled: false,
          rolledNums: [
            { id: 1, roll: "-" },
            { id: 2, roll: "-" },
            { id: 3, roll: "-" },
            { id: 4, roll: "-" },
            { id: 5, roll: "-" },
            { id: 6, roll: "-" },
          ],
        });
    },
    increaseStat() {
      this.newChar.stats.find((s) => {
        if (s.name == event.target.name) {
          if (s.value < 13) {
            s.value++;
            this.statGen.points--;
          } else if(!((this.statGen.points - 2 )<0)){
            s.value++;
            this.statGen.points -= 2;
          }
          else {
            console.log("Not enough points!!");
          }
          }
        }
      );
    },
    
    decreaseStat(){
      this.newChar.stats.find((s) => {
        if (s.name == event.target.name) {
          if (s.value <= 13) {
            s.value--;
            this.statGen.points++;
          } else {
            s.value--;
            this.statGen.points += 2;
          }
        }
      });
    },
    changeStatGenMethod(event) {
      //console.log(event);
      if (event.target.name == "pointBuy" && !this.statGen.isPointBuy) {
        this.statGen.isPointBuy = true;
        this.statGen.isStandardArray = false;
        this.statGen.isRolled = false;
        this.statGen.points = 27;
        this.newChar.stats.forEach(s =>{s.value = 8})
        // this.newChar.strength = 8;
        // this.newChar.dexterity = 8;
        // this.newChar.constitution = 8;
        // this.newChar.intelligence = 8;
        // this.newChar.wisdom = 8;
        // this.newChar.charisma = 8;
      } else if (
        event.target.name == "standardArray" &&
        !this.statGen.isStandardArray
      ) {
        this.statGen.isPointBuy = false;
        this.statGen.isStandardArray = true;
        this.statGen.isRolled = false;
        this.newChar.stats.forEach(s =>{s.value = 0})
        // this.newChar.strength = 0;
        // this.newChar.dexterity = 0;
        // this.newChar.constitution = 0;
        // this.newChar.intelligence = 0;
        // this.newChar.wisdom = 0;
        // this.newChar.charisma = 0;

        this.statGen.checkArray = [];
      } else if (event.target.name == "rolled" && !this.statGen.isRolled) {
        this.statGen.isPointBuy = false;
        this.statGen.isStandardArray = false;
        this.statGen.isRolled = true;
      }
      // console.log("point buy", this.statGen.isPointBuy);
      // console.log("standard array", this.statGen.isStandardArray);
      // console.log("rolled", this.statGen.isRolled);
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
        (this.newChar = {
          name: "",
          race: "", //this cannot stay as a string!!! on click, before it is sent, it needs to be an object!!
          strength: 0,
          dexterity: 0,
          constitution: 0,
          intelligence: 0,
          wisdom: 0,
          charisma: 0,
          weapon: "", //this cannot stay as a string!!!! on click, before it is sent, it needs to be an object!!
        }),
          (this.statGen = {
            isPointBuy: false,
            points: 27,
            isStandardArray: false,
            stanArray: [8, 10, 12, 13, 14, 15],
            checkArray: [],
            isRolled: false,
            rolledNums: [
              { id: 1, roll: "-" },
              { id: 2, roll: "-" },
              { id: 3, roll: "-" },
              { id: 4, roll: "-" },
              { id: 5, roll: "-" },
              { id: 6, roll: "-" },
            ],
          });
      });
    },
    updateCheckArray() {
      if (this.statGen.isStandardArray) {
        let stat = this.newChar.stats.find(s => s.name == event.target.name)
          stat.value = parseInt(event.target.value); //this is where the stat is set

          if (!this.statGen.checkArray.includes(event.target.value)) {
            this.statGen.checkArray.push(event.target.value);
        }
        if (this.statGen.stanArray.includes(event.target.value)) {
          this.statGen.stanArray = this.statGen.stanArray.filter(
            (num) => num != event.target.value
          );
        }
            
        console.log("check Array Length: ", this.statGen.checkArray.length);
      } else if (this.statGen.isRolled) {
        let stat = this.newChar.stats.find(s => s.name == event.target.name)
        let i = event.target.options.selectedIndex;
          stat.value = parseInt(event.target.options[i]._value);
        // console.log(event)
        // console.log(event.target)
        // console.log(event.target.options)
        // console.log(event.target.options[i])
        // console.log(event.target.options[i]._value)
        // console.log(event.target.options[i]._value)
        if (!this.statGen.checkArray.find((o) => o.id == i)) {
          this.statGen.checkArray.push(event.target.options[i]._value);
        }

        for (let index = 0; index < event.target.options.length; index++) {
          event.target.options[index].disabled = false;
        }
        event.target.options[i].disabled = true;
      }
    },
  },
  created() {},
  computed: {
    conditions() {
      //answers question "is the submit button supposed to be disabled?"
      if (this.statGen.isPointBuy && this.statGen.points >= 0) {
        return false;
      } else if (
        this.statGen.isStandardArray &&
        this.statGen.checkArray.length == 6 &&
        this.updatedStanArray.length == 0
      ) {
        // this doesn't work perfectly because they could add all the stats to the check array and then change them to submit but it's a start
        // fixed it so that the computed property Updated Stan Array needs to have a length of 0 in order to submit
        return false;
      } else if (this.statGen.isRolled && this.rollStatCheck.length == 0) {
        return false;
      } else if (
        !this.statGen.isPointBuy &&
        !this.statGen.isStandardArray &&
        !this.statGen.isRolled
      ) {
        return false;
      }
      return true;
    },
    updatedStanArray() {
      return this.statGen.stanArray.filter((num) => {
        //console.log("number here??", num);
          
        if (num == this.newChar.stats[0].value) {
          return false;
        }
        if (num == this.newChar.stats[1].value) {
          return false;
        }
        if (num == this.newChar.stats[2].value) {
          return false;
        }
        if (num == this.newChar.stats[3].value) {
          return false;
        }
        if (num == this.newChar.stats[4].value) {
          return false;
        }
        if (num == this.newChar.stats[5].value) {
          return false;
        }
        return true;
      });
    },
    rollStatCheck() {
      return this.statGen.rolledNums.filter((num) => {
        //console.log("number here??", num);
          
        if (num.roll == this.newChar.stats[0].value) {
          return false;
        }
        if (num.roll == this.newChar.stats[1].value) {
          return false;
        }
        if (num.roll == this.newChar.stats[2].value) {
          return false;
        }
        if (num.roll == this.newChar.stats[3].value) {
          return false;
        }
        if (num.roll == this.newChar.stats[4].value) {
          return false;
        }
        if (num.roll == this.newChar.stats[5].value) {
          return false;
        }
        return true;
      });
    },
  },
};
</script>

<style>
#pointBuyInfo {
  width: 75%;
  text-align: center;
}
table {
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

.active {
  background-color: red;
}
.statUsed {
  text-decoration: line-through;
}
</style>