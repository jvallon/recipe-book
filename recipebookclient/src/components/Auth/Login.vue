<template>
  <div>
    <center>
      <h1>Welcome {{ $auth.user.nickname }}</h1>
      <v-btn :to="{ name: 'Home' }">Click here if you are not redirected automatically.</v-btn>
    </center>
  </div>
</template>

<script>
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
  }
}
</script>

<style>

</style>
