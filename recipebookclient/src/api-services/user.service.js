import Axios from 'axios'
// import { getInstance } from '@/auth'

const RESOURCE_NAME = '/user'

export default {
  getAll () {
    return Axios.get(`${RESOURCE_NAME}`)
  },
  async get (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`)
  },
  getWithRecipes (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}/recipes`)
  },
  async getWithFavorites (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}/favorites`)
  },
  create (payload) {
    return Axios.post(`${RESOURCE_NAME}`, payload)
  }
}
