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
              :favorite="isUserFavorite(recipe)">
            </recipe-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import RecipeService from '@/api-services/recipe.service'
import UserService from '@/api-services/user.service'
import RecipeCard from '../components/RecipeCard.vue'

export default {
  name: 'Home',
  components: {
    RecipeCard
  },
  data () {
    return {
      recipes: [],
      favorites: [],
      userId: 1
    }
  },
  computed: {
  },
  methods: {
    isUserFavorite (recipe) {
      if (this.favorites.filter(fav => fav.recipeId === recipe.recipeId).length > 0) {
        return true
      }

      return false
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

    UserService.getWithFavorites(this.userId)
      .then(response => {
        this.favorites = response.data.favorites
        console.log(this.favorites)
      })
      .catch(e => {
        console.error(e)
      })
  }
}
</script>

<style>

</style>
