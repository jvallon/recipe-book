<template>
  <div>
    <center>
      <h1>Welcome {{ $auth.user.nickname }}</h1>
      <v-btn :to="{ name: 'Home' }">Click here if you are not redirected automatically.</v-btn>
    </center>
  </div>
</template>

<script>
import UserService from '@/api-services/user.service'

export default {
  name: 'Login',
  data () {
    return {
    }
  },
  watch: {
  },
  mounted () {
    setTimeout(() => this.$router.push('/'),
      5000)

    this.$store.dispatch('retrieveTokenFromAuthz')

    console.log(this.$auth.user)
    const userId = this.$auth.user.sub.split('|')[1]
    UserService.get(userId)
      .catch(err => console.log(err))

    // if (user === 'undefined') {
    //   UserService.create(new {
    //     userId: userId,
    //     firstName: this.$auth.user.name,
    //     lastName: '',
    //     userName: this.$auth.user.nickname,
    //     emailAddress: this.$auth.user.email
    //   }())
    // }
  }
}
</script>

<style>

</style>
