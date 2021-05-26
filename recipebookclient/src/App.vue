<template>
  <v-app>
    <Header></Header>

      <v-main class="main">
        <router-view/>
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
    //
  })
}
</script>
<style lang="scss" scoped>
.main {
  margin-top: 5%;
}
</style>
