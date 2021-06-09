<template>
  <div>
    <v-btn @click="getInfo">Get User Info</v-btn>
    <div>Auth response: {{ response }}</div>
    <div>User info: {{ info }}</div>
  </div>
</template>

<script>
import axios from 'axios'
import UserService from '@/api-services/user.service'

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
        // headers: {
        //   Authorization: `Bearer ${this.$token}` // send the access token through the 'Authorization' header
        // }
      })

      this.response = data

      UserService.get(this.$auth.user.sub.split('|')[1])
      this.info = this.$auth.user
    }
  },
  mounted () {
  }
}
</script>

<style>

</style>
