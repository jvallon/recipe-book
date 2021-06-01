<template>
  <div>
    <v-container>
          <v-card
            light>
            <v-row>
              <v-col cols="8">
                <v-card-title>{{ recipe.title }}</v-card-title>
                <v-card-subtitle>
                  <v-tooltip bottom>
                    <template v-slot:activator="{ on, attrs }">
                      <div class="prep time"
                        v-bind="attrs"
                        v-on="on">
                        <v-icon>mdi-book-clock</v-icon>
                        <span>{{ prepTime }}</span>
                      </div>
                    </template>
                    <span>Prep Time</span>
                  </v-tooltip>
                  <v-tooltip bottom>
                    <template v-slot:activator="{ on, attrs }">
                      <div class="cook time"
                        v-bind="attrs"
                        v-on="on">
                        <v-icon>mdi-cookie-clock</v-icon>
                        {{ cookTime }}
                      </div>
                    </template>
                    <span>Cook Time</span>
                  </v-tooltip>
                </v-card-subtitle>
                <v-card-text>{{ recipe.description }}</v-card-text>
                <v-card-text>Written by: {{ author }}</v-card-text>
              </v-col>
              <v-col cols="4">
                <v-img :src="imageUrl" size="250px"></v-img>
              </v-col>
            </v-row>
            <v-row class="ingredients">
              <v-subheader>Ingredients</v-subheader>
            </v-row>
            <v-row class="instructions">
              <v-subheader>Instructions</v-subheader>
            </v-row>
          </v-card>
    </v-container>
  </div>
</template>

<script>
import RecipeService from '@/api-services/recipe.service'

export default {
  name: 'RecipeDetail',
  props: ['id'],
  data () {
    return {
      recipe: {},
      prepTime: 0,
      cookTime: 0,
      imageUrl: '',
      author: ''
    }
  },
  computed: {
  },
  watch: {
    recipe (newval, oldval) {
      this.prepTime = this.recipe.prepTime.value.totalMinutes
      this.cookTime = this.recipe.cookTime.value.totalMinutes
      this.imageUrl = `/${this.recipe.imageUrl}`
      this.author = this.recipe.user.username
      console.log(this.recipe.imageUrl)
    }
  },
  mounted () {
    this.fetchRecipe(this.id)
  },
  methods: {
    fetchRecipe (id) {
      RecipeService.getDetails(id)
        .then(response => {
          this.recipe = response.data
        })
        .catch(e => {
          console.error(e)
        })
    }
  }
}
</script>

<style>

</style>
