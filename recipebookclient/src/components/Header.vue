<template>
  <div class="header-container">
    <v-app-bar
      fixed
      elevate-on-scroll
      color="#eee">
      <span v-if="isHome">Recipe Book</span>
      <span v-else><v-icon large @click="goHome">mdi-chevron-left</v-icon></span>
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
      <v-btn v-if="!$auth.isAuthenticated"
        class="mx-2"
        dark
        rounded
        color="darkgrey"
        @click="login">
        Login
      </v-btn>
      <v-menu offset-y v-if="$auth.isAuthenticated">
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            class="mx-2"
            fab
            dark
            small
            color="darkgrey"
            v-bind="attrs"
            v-on="on">
            <v-icon v-if="$auth.loading">mdi-account</v-icon>
            <v-img v-else
              class="user-picture"
              :src="$auth.user.picture"
              contain
              aspect-ratio="1"
              max-width="45px"></v-img>
          </v-btn>
        </template>
        <v-list>
          <v-list-item>{{ $auth.user.nickname }}</v-list-item>
          <hr/>
          <v-list-item :to="{ name: 'AuthTest' }">My Recipes</v-list-item>
          <v-list-item>Favorites</v-list-item>
          <v-list-item :to="{ name: 'Profile' }">Profile</v-list-item>
          <v-list-item @click="logout">Logout</v-list-item>
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
    // Log the user in
    login () {
      this.$auth.loginWithRedirect({
        redirect_uri: `${window.location.origin}/login`
      })
    },
    // Log the user out
    logout () {
      this.$auth.logout({
        returnTo: `${window.location.origin}/logout`
      })
    },
    onNewRecipeClick () {
      this.$router.push({ name: 'newrecipe' })
    },
    goHome () {
      this.$router.push({ path: '/' })
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

.user-picture {
  border-radius: 45px;
}
</style>
