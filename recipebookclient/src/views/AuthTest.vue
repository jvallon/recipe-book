<template>
  <div>
    <v-btn @click="getInfo">Get User Info</v-btn>
    <div>Auth response: {{ response }}</div>
    <div>User info: {{ info }}</div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'AuthTest',
  data () {
    return {
      response: '',
      info: ''
    }
  },
  methods: {
    async getInfo () {
      // let token
      // const token = await this.$auth.getTokenSilently()

      const { data } = await axios.get('/authtest/private', {
        headers: {
          Authorization: `Bearer ${this.$token}` // send the access token through the 'Authorization' header
        }
      })
      // // .then(response => {
      // //   this.response = response.data.message
      // // }).catch(err => {
      // //   console.error(err)
      // // })
      this.response = data
      this.info = this.$auth.user
    }
  },
  mounted () {
  }
}
</script>

<style>

</style>
