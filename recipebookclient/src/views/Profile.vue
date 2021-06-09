<template>
  <div>
    <div>
      <img :src="$auth.user.picture">
      <h2>{{ $auth.user.name }}</h2>
      <p>{{ $auth.user.email }}</p>
    </div>

    <div>
      <pre>{{ JSON.stringify($auth.user, null, 2) }}</pre>
    </div>
  </div>
</template>
<script>
import UserService from '@/api-services/user.service'

export default {
  name: 'Profile',
  data () {
    return {
      userId: ''
    }
  },
  methods: {
    getUser () {
      UserService.get(this.$auth.user.sub.split('|')[1])
        .then(response => {
          console.log(response)
          this.userId = response.userId
        })
    }
  },
  mounted () {
    this.getUser()
  }
}
</script>

<style>

</style>
