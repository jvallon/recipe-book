<template>
  <div>
    <v-card class="recipe-form" light>
      <v-card-title>Create a New fetchRecipe</v-card-title>
      <form>
          <v-text-field
            outlined
            v-model="title"
            :rules="titleRules"
            label="Recipe Title"
            required
            counter="45"
            @input="$v.name.$touch()"></v-text-field>
          <v-textarea
            outlined
            v-model="description"
            label="Description"
            required
            @input="$v.name.$touch()"></v-textarea>
          <v-text-field
            outlined
            v-model="preptime"
            :rules="timeRules"
            label="Prep Time"
            hint="HH:MM format"
            required
            @input="$v.name.$touch()"></v-text-field>
          <v-text-field
            outlined
            v-model="cooktime"
            :rules="timeRules"
            label="Cook Time"
            hint="HH:MM format"
            required
            @input="$v.name.$touch()"></v-text-field>
          <v-subheader>Ingredients</v-subheader>
          <v-divider></v-divider>
          <div class="list">
            <new-ingredient-item v-for="(instr, index) in ingredients" :key="index" v-model="ingredients[index]"
              @delete="removeIngredientAtIndex(index)"></new-ingredient-item>
            <v-btn @click="addNewIngredient">Add an Ingredient</v-btn>
          </div>
          <v-subheader>Instructions</v-subheader>
          <v-divider></v-divider>
          <div class="list">
            <new-instruction-item v-for="(instr, index) in instructions" :key="index" v-model="instructions[index]" :label="`Step ${index + 1}`"
              @delete="removeStepAtIndex(index)"></new-instruction-item>
            <v-btn @click="addNewStep">Add a Step</v-btn>
          </div>
          <v-divider></v-divider>
          <v-btn class="btn submit"
            color="success"
            type="submit"
          >Submit</v-btn>
      </form>
    </v-card>
  </div>
</template>

<script>
import RecipeService from '@/api-services/recipe.service'
import NewInstructionItem from './NewInstructionItem.vue'
import NewIngredientItem from './NewIngredientItem.vue'

export default {
  name: 'NewRecipeForm',
  components: {
    NewInstructionItem,
    NewIngredientItem
  },
  props: ['id'],
  data () {
    return {
      title: '',
      maxTitleLength: 45,
      description: '',
      preptime: '',
      cooktime: '',
      ingredients: [],
      instructions: []
    }
  },
  computed: {
    titleRules () {
      const rules = []
      if (this.maxTitleLength) {
        const rule =
          v => v.length <= this.maxTitleLength || `A maximum of ${this.maxTitleLength} characters is allowed`
        rules.push(rule)
      }
      return rules
    },
    timeRules () {
      const rules = [
        v => /^\d+:\d+$/.test(v) || 'Must be in the format HH:MM'
      ]
      return rules
    }
  },
  watch: {
    instructions () {
      console.log(this.instructions)
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
    },
    addNewIngredient () {
      this.ingredients.push({ qty: '', unit: '', name: '' })
    },
    removeIngredientAtIndex (index) {
      this.ingredients.splice(index, 1)
    },
    addNewStep () {
      this.instructions.push({ description: '' })
    },
    removeStepAtIndex (index) {
      this.instructions.splice(index, 1)
    }
  }
}
</script>

<style lang="scss" scoped>
.row {
  // margin: 0px;
}

.recipe-form {
  margin: 12px;
  padding: 12px;
}

.list {
  margin: 10px;
}

.btn.submit {
  margin-top: 20px;
}
.icon {
  margin-right: .5em;
}

</style>
