<template>
  <div class="header-container">
    <v-app-bar>
      <span v-if="isHome">Recipe Book</span>
      <span v-else><v-icon large @click="goBack">mdi-chevron-left</v-icon></span>
      <v-spacer></v-spacer>
      <v-btn
        class="mx-2"
        fab
        dark
        small
        color="darkgrey">
        <v-icon>mdi-magnify</v-icon>
      </v-btn>
      <v-btn
        class="mx-2"
        fab
        dark
        small
        color="darkgrey">
        <v-icon>mdi-plus</v-icon>
      </v-btn>
      <v-btn
        class="mx-2"
        fab
        dark
        small
        color="darkgrey">
        <v-icon>mdi-account</v-icon>
      </v-btn>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  name: 'Header',
  methods: {
    goBack () {
      this.$router.go(-1)
    }
  },
  computed: {
    isHome () {
      return this.$route.name === 'Home'
    }
  }
}
</script>

<style>

</style>
