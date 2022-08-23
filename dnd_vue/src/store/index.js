import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    races:[]
  },
  mutations: {
    GET_RACES(state, array){
      state.races = array;
    }
  },


  // getters: {
  // },
  // actions: {
  // },
  // modules: {
  // }
})
