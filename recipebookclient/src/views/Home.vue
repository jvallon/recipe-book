<template>
  <div id="home-container">
    <recipe-card
      v-for="recipe in recipes"
      :key="recipe.id"
      :title="recipe.title"
      :subtitle="recipe.subtitle"
      :description="recipe.description"
      :src="recipe.src"></recipe-card>
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
  created () {
    axios
      .get('sample-recipes.json')
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
