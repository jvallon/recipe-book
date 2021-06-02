import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Home'
import RecipeDetail from '@/components/RecipeDetail'
import NotFound from '@/views/NotFound'

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
    props: true
  },
  {
    path: '/about',
    name: 'About'
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    // component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '*',
    name: '404',
    component: NotFound
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
