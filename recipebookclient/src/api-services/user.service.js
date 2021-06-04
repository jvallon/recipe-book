import Axios from 'axios'

const RESOURCE_NAME = '/user'

export default {
  getAll () {
    return Axios.get(`${RESOURCE_NAME}`)
  },
  get (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`)
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
    return Axios.post(`${RESOURCE_NAME}`, payload)
  }
}
