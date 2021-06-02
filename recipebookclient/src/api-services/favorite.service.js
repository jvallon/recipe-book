import Axios from 'axios'

const RESOURCE_NAME = '/favorite'

export default {
  get (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`)
  },
  create (payload) {
    return Axios.post(`${RESOURCE_NAME}`, payload)
  },
  delete (id) {
    return Axios.delete(`${RESOURCE_NAME}/${id}`)
  }
}
