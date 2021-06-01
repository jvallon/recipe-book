import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import Axios from 'axios'

Vue.config.productionTip = false

Axios.defaults.baseURL = process.env.VUE_APP_API_ENDPOINT

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
