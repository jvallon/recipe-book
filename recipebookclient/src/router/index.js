import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Home'
import Profile from '@/views/Profile'
import AuthTest from '@/views/AuthTest'
import RecipeDetail from '@/components/RecipeDetail'
import NewRecipeForm from '@/components/NewRecipeForm'
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
    path: '/newrecipe',
    name: 'newrecipe',
    component: NewRecipeForm,
    beforeEnter: authGuard
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('@/components/Auth/Login.vue')
  },
  {
    path: '/logout',
    name: 'Logout',
    component: () => import('@/components/Auth/Logout.vue')
  },
  {
    path: '/profile',
    name: 'Profile',
    component: Profile,
    beforeEnter: authGuard
  },
  {
    path: '/authtest',
    name: 'AuthTest',
    component: AuthTest
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
