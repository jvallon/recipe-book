import Axios from 'axios'

const RESOURCE_NAME = '/recipe'

export default {
  getAll () {
    return Axios.get(`${RESOURCE_NAME}`)
  },
  get (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`)
  },
  getDetails (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}/details`)
  }
}
