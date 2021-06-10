<template>
  <div>
    <v-container>
      <v-card class="recipe-detail" light>
        <v-row>
          <v-col cols="8">
            <v-card-title>{{ recipe.title }}</v-card-title>
            <v-card-subtitle>
              <v-row>
                <v-col cols="4">
                  <v-icon class="icon">mdi-book-clock</v-icon>
                  <span>Prep Time: {{ prepTime }}</span>
                </v-col>
                <v-col cols="4">
                  <v-icon class="icon">mdi-cookie-clock</v-icon>
                  <span>Cook Time: {{ cookTime }}</span>
                </v-col>
              </v-row>
            </v-card-subtitle>
            <v-card-text>{{ recipe.description }}</v-card-text>
            <v-card-text>Written by: {{ author }}</v-card-text>
          </v-col>
          <v-col cols="4">
            <v-img :src="imageUrl" size="250px"></v-img>
          </v-col>
        </v-row>
        <div class="ingredient-list">
          <v-row class="subheader">
            <v-subheader>Ingredients</v-subheader>
          </v-row>
          <div v-for="ingredient in ingredients" :key="ingredient.id">
            <v-row>
              <ingredient-item :qty="ingredient.qty" :unit="ingredient.unit" :name="ingredient.name"></ingredient-item>
            </v-row>
          </div>
        </div>
        <div class="instruction-list">
          <v-row class="subheader">
            <v-subheader>Instructions</v-subheader>
          </v-row>
          <div v-for="instruction in instructions" :key="instruction.step">
            <instruction-item :step="instruction.step" :description="instruction.description"></instruction-item>
          </div>
        </div>
      </v-card>
    </v-container>
  </div>
</template>

<script>
import RecipeService from '@/api-services/recipe.service'
import IngredientItem from '@/components/IngredientItem'
import InstructionItem from './InstructionItem.vue'
// import Favorite from './Favorite.vue'

export default {
  name: 'RecipeDetail',
  components: {
    IngredientItem,
    InstructionItem
    // Favorite
  },
  props: ['id'],
  data () {
    return {
      recipe: {},
      prepTime: 0,
      cookTime: 0,
      imageUrl: '',
      author: '',
      ingredients: [],
      instructions: [
        {
          step: 1,
          description: 'Boil potatoes for 30 minutes, drain.'
        },
        {
          step: 2,
          description: 'Add butter and milk.'
        },
        {
          step: 3,
          description: 'Mash until smooth.'
        }
      ]
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
      this.ingredients = this.recipe.recipeIngredients
      // this.instructions = this.recipe.instructions
      // console.log(this.recipe.ingredients)
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

<style lang="scss" scoped>
.row {
  margin: 0px;
}

.recipe-detail {
  margin: 12px;
  // padding: 12px;
}

.icon {
  margin-right: .5em;
}

.ingredient-list {
  margin: 12px;

  .subheader {
    border-bottom: 1px solid lightgrey;
  }
}

.instruction-list {
  margin: 12px;

  .subheader {
    border-bottom: 1px solid lightgrey;
  }
}

</style>
