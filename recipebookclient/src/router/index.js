import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Home'
import Profile from '@/views/Profile'
import RecipeDetail from '@/components/RecipeDetail'
import NotFound from '@/views/NotFound'
import Forbidden from '@/views/Forbidden'
import { authGuard } from '../auth'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    props: true
  },
  {
    path: '/recipe/:id',
    name: 'recipe',
    component: RecipeDetail,
    props: true,
    beforeEnter: authGuard
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('@/components/Auth/Login.vue')
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    // component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/profile',
    name: 'Profile',
    component: Profile,
    beforeEnter: authGuard
  },
  {
    path: '*',
    name: '404',
    component: NotFound
  },
  {
    path: '*',
    name: '403',
    component: Forbidden
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
