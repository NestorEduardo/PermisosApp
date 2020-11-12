import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import PermissionTypes from '../components/PermissionTypes.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/permissionTypes',
    name: 'permissionTypes',
    component: PermissionTypes
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
