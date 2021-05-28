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
import axios from 'axios'
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
    axios
      .get('http://localhost:5000/api/recipe')
      // .get('sample-recipes.json')
      .then(response => {
        this.recipes = response.data
        console.log(response.data)
      })
      .catch(e => {
        console.error(e)
      })
  }
}
</script>

<style>

</style>
