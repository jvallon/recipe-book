<template>
  <v-app>
    <Header class="header"></Header>

    <v-main class="main">
      <router-view :user="userInfo"/>
    </v-main>
  </v-app>
</template>

<script>
import Header from '@/components/Header'

export default {
  name: 'App',
  components: {
    Header
  },

  data: () => ({
    userInfo: {
      id: 1,
      firstName: 'Josh',
      lastName: 'Vallon',
      username: 'jvallon'
    }
  })
}
</script>
<style lang="scss" scoped>
.header {
  height: 56px;
}
</style>
