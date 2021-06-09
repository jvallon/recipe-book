/* eslint-disable no-unused-vars */
<template>
  <div id="home-container">
    <v-container fluid>
      <v-row dense>
        <v-col
          v-for="recipe in recipes"
          :key="recipe.recipeId"
          >
            <recipe-card
              :id="recipe.recipeId"
              :title="recipe.title"
              :description="recipe.description"
              :src="recipe.imageUrl"
              :favorite="isUserFavorite(recipe)"
              @update-favorite="updateFavorite($event, recipe.recipeId)">
            </recipe-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import RecipeService from '@/api-services/recipe.service'
import UserService from '@/api-services/user.service'
// eslint-disable-next-line no-unused-vars
import FavoriteService from '@/api-services/favorite.service'
import RecipeCard from '../components/RecipeCard.vue'

export default {
  name: 'Home',
  components: {
    RecipeCard
  },
  // props: ['user'],
  data () {
    return {
      recipes: [],
      favorites: []
    }
  },
  computed: {
    userId () {
      return this.$auth.user.sub.split('|')[1]
    }
  },
  methods: {
    isUserFavorite (recipe) {
      if (this.favorites.filter(fav => fav.recipeId === recipe.recipeId).length > 0) {
        return true
      }

      return false
    },
    getFavoriteId (userId, recipeId) {
      return this.favorites.filter(fav => fav.recipeId === recipeId && fav.userId === userId)[0]
    },
    updateFavorite (value, recipeId) {
      // console.log(value, recipeId, this.getFavoriteId(this.user.id, recipeId))
      const fav = this.getFavoriteId(this.userId, recipeId)

      if (value === false) {
        FavoriteService.delete(fav.id).then(response => this.retrieveFavorites())
      } else {
        FavoriteService.create({ userId: this.userId, recipeId: recipeId }).then(response => this.retrieveFavorites())
      }
    },
    retrieveFavorites () {
      UserService.getWithFavorites(this.userId)
        .then(response => {
          this.favorites = response.data.favorites
        })
        .catch(e => {
          console.error(e)
        })
    }
  },
  created () {
    RecipeService.getAll()
      .then(response => {
        this.recipes = response.data
      })
      .catch(e => {
        console.error(e)
      })

    this.retrieveFavorites()
  }
}
</script>

<style>

</style>
