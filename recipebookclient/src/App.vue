<template>
  <v-app>
    <div v-if="!$auth.loading">

    <Header class="header"></Header>

    <v-main class="main">
      <router-view/>
    </v-main>
    </div>
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
  })
}
</script>
<style lang="scss" scoped>
.header {
  height: 56px;
}
</style>
