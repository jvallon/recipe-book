<template>
  <div>
    <center>
      <h1>Welcome {{ $auth.user.nickname }}</h1>
      <v-btn :to="{ name: 'Home' }">Click here if you are not redirected automatically.</v-btn>
    </center>
  </div>
</template>

<script>
import { getInstance } from '@/auth/authWrapper'
import UserService from '@/api-services/user.service'

export default {
  name: 'Login',
  data () {
    return {
    }
  },
  computed: {
    userId () {
      return this.$auth.user.sub.split('|')[1]
    }
  },
  created () {
  },
  methods: {
    async getUser () {
      var instance = getInstance()
      var user = await instance.getTokenSilently().then((authToken) => {
        const userId = this.userId
        return UserService.get(userId)
          .then(user => {
            return user.data
          })
      })
      return user
    },
    async createUser () {
      const userId = this.userId
      UserService.create({
        userId: userId,
        firstName: this.$auth.user.name,
        lastName: '',
        userName: this.$auth.user.nickname,
        emailAddress: this.$auth.user.email
      })
    }
  },
  async mounted () {
    this.getUser()
      .then(user => {
        // user exists update store? console.log('mounted user:', user)
      })
      .catch(err => {
        if (err.response.status === 404) {
          this.createUser() // this should probably be done on the server
        }
      })
  }
}
</script>

<style>

</style>
