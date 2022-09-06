import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'
import RacesView from '../views/RacesView.vue'
import RacesDetails from '../components/RacesDetails.vue'
import WeaponsView from '../views/WeaponsView.vue'
import WeaponsDetails from '../components/WeaponsDetails.vue'
import CharactersView from '../views/CharactersViewFix.vue'
import CharactersDetails from '../components/CharactersDetails.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/races',
    name: 'races',
    component: RacesView
  },
  {
    path: '/races/:id',
    name: 'RacesDetails',
    component: RacesDetails,
  },
  {
    path: '/weapons/',
    name: 'weapons',
    component: WeaponsView,
  },
  {
    path: '/weapons/:id',
    name: 'WeaponsDetails',
    component: WeaponsDetails,
  },
  {
    path: '/characters/',
    name: 'characters',
    component: CharactersView,
  },
  {
    path: '/characters/:id',
    name: 'CharactersDetails',
    component: CharactersDetails,
  }
  // Don't forget a "Not Found" route
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
