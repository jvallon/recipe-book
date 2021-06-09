import Axios from 'axios'
// import { getInstance } from '@/auth'

const RESOURCE_NAME = '/user'

export default {
  getAll () {
    return Axios.get(`${RESOURCE_NAME}`)
  },
  async get (id) {
    // Get the access token from the auth wrapper
    // const instance = getInstance()
    // const { token } = instance.getTokenSilently()
    // console.log(token)
    return Axios.get(`${RESOURCE_NAME}/${id}`, {
      // headers: {
      //   Authorization: `Bearer ${token}` // send the access token through the 'Authorization' header
      // }
    })
  },
  getWithRecipes (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}/recipes`)
  },
  async getWithFavorites (id) {
    // Get the access token from the auth wrapper
    const token = this.$token

    // Use Axios to make a call to the API
    const { data } = await Axios.get(`${RESOURCE_NAME}/${id}/favorites`, {
      headers: {
        Authorization: `Bearer ${token}` // send the access token through the 'Authorization' header
      }
    })
    console.info(data)
    return data
    // return Axios.get(`${RESOURCE_NAME}/${id}/favorites`)
  },
  create (payload) {
    // Get the access token from the auth wrapper
    const token = this.$token
    console.log(`token ${token}`)

    return Axios.post(`${RESOURCE_NAME}`, payload, {
      headers: {
        Authorization: `Bearer ${token}` // send the access token through the 'Authorization' header
      }
    })
  }
}
