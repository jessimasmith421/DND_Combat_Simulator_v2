import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    races:[],
    weapons:[],
    characters:[],
  },
  mutations: {
    GET_RACES(state, array){
      state.races = array;
    },
    GET_WEAPONS(state,array){
      state.weapons = array;
    },
    GET_CHARACTERS(state,array){
      state.characters=array;
    }
  },


  // getters: {
  // },
  // actions: {
  // },
  // modules: {
  // }
})
