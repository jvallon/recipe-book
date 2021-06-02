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
  getWithFavorites (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}/favorites`)
  },
  create (payload) {
    return Axios.post(`${RESOURCE_NAME}`, payload)
  }
}
