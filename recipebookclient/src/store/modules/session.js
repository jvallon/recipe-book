import { getInstance } from '@/auth'

const state = {
  token: null
}

const getters = {
  token (state) {
    return state.token
  }
}

const mutations = {
  setToken (state, token) {
    console.log('mutating token')
    state.token = token
  }
}

const actions = {
  retrieveTokenFromAuthz (context) {
    return new Promise((resolve, reject) => {
      const instance = getInstance()
      instance.$watch('loading', loading => {
        if (loading === false && instance.isAuthenticated) {
          instance
            .getTokenSilently()
            .then(authToken => {
              context.commit('setToken', authToken)
              resolve(authToken)
            })
            .catch(error => {
              reject(error)
            })
        }
      })
    })
  }
}

export default {
  state,
  actions,
  mutations,
  getters
}
