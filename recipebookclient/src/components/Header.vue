<template>
  <div class="header-container">
    <v-app-bar
      fixed
      elevate-on-scroll
      color="#eee">
      <span v-if="isHome">Recipe Book</span>
      <span v-else><v-icon large @click="goBack">mdi-chevron-left</v-icon></span>
      <v-spacer></v-spacer>
      <v-text-field
        v-if="showSearchbox"
        class="search-box"
        rounded
        dense
        hide-details="false"
        solo
        placeholder="Search..."
        clearable></v-text-field>
      <v-btn
        class="mx-2"
        fab
        dark
        small
        color="darkgrey"
        @click="showSearchbox = !showSearchbox">
        <v-icon>mdi-magnify</v-icon>
      </v-btn>
      <v-btn
        class="mx-2"
        fab
        dark
        small
        color="darkgrey"
        @click="onNewRecipeClick"
        >
        <v-icon>mdi-plus</v-icon>
      </v-btn>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            class="mx-2"
            fab
            dark
            small
            color="darkgrey"
            v-bind="attrs"
            v-on="on">
            <v-icon>mdi-account</v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item>My Recipes</v-list-item>
          <v-list-item>Favorites</v-list-item>
          <v-list-item>Account</v-list-item>
          <v-list-item>Logout</v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  name: 'Header',
  data () {
    return {
      showSearchbox: false
    }
  },
  methods: {
    onNewRecipeClick () {
      this.$router.push({ path: '/recipe/new' })
    },
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

<style scoped>
.search-box {
  max-width: 33%;
}
</style>
