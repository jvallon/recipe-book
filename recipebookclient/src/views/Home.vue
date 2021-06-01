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
              :src="recipe.imageUrl">
            </recipe-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import RecipeService from '@/api-services/recipe.service'
import RecipeCard from '../components/RecipeCard.vue'

export default {
  name: 'Home',
  components: {
    RecipeCard
  },
  data () {
    return {
      recipes: []
    }
  },
  computed: {
  },
  created () {
    RecipeService.getAll()
      .then(response => {
        this.recipes = response.data
      })
      .catch(e => {
        console.error(e)
      })
  }
}
</script>

<style>

</style>
