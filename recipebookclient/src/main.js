import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import Axios from 'axios'

import { Auth0Plugin, getInstance } from './auth'
import { domain, clientId, audience } from '../auth_config.json'
Vue.config.productionTip = false

Axios.defaults.baseURL = process.env.VUE_APP_API_ENDPOINT

Vue.use(Auth0Plugin, {
  domain,
  clientId,
  audience,
  onRedirectCallback: appState => {
    router.push(
      appState && appState.targetUrl
        ? appState.targetUrl
        : window.location.pathname
    )
  }
})

const instance = getInstance()

instance.$watch('loading', async loading => {
  if (!loading && instance.isAuthenticated) {
    console.log('UPDATING TOKEN')
    Vue.prototype.$token = await instance.getTokenSilently()
    Vue.prototype.$userId = instance.user.sub.split('|')[1]
  }
})

// Add a request interceptor
Axios.interceptors.request.use(function (config) {
  config.headers.Authorization = `Bearer ${Vue.prototype.$token}`
  return config
}, function (error) {
  // Do something with request error
  return Promise.reject(error)
})

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
