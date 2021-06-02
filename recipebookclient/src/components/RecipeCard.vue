<template>
  <v-card
    class="mx-auto my-6"
    max-width="400">
    <v-img
      :src="src"
      class="white--text align-end"
      gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
      height="250px">
      <v-card-title>{{ title }}</v-card-title>
    </v-img>
    <v-card-subtitle>{{ subtitle }}</v-card-subtitle>
    <v-card-text>{{ description }}</v-card-text>
    <v-card-actions>
      <v-btn @click="onRecipeClick">Try it!</v-btn>
      <v-spacer></v-spacer>
      <!-- <v-btn icon @click="favorite = !favorite"> -->
      <!-- <v-btn icon @click="$emit('favorite', $event.target.value)"> -->
      <v-checkbox
        color="red"
        off-icon="mdi-heart-outline"
        on-icon="mdi-heart"
        v-model="isFavorite"
        @change="$emit('update-favorite', $event)"></v-checkbox>
        <!-- <v-icon :style="favorite ? 'color: red' : 'color: inherit'">{{ favorite ? 'mdi-heart' : 'mdi-heart-outline' }}</v-icon> -->
      <!-- </v-btn> -->
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: 'RecipeCard',
  props: {
    id: { type: Number, required: true },
    title: { type: String, default: 'Title' },
    subtitle: { type: String, default: 'Subtitle' },
    description: { type: String, default: 'Description' },
    src: { type: String },
    favorite: { type: Boolean }
  },
  data () {
    return {
      isFavorite: this.favorite
    }
  },
  computed: {

  },
  methods: {
    onRecipeClick () {
      this.$router.push({ name: 'recipe', params: { id: this.id } })
    }
  },
  watch: {
    favorite () {
      this.isFavorite = this.favorite
    }
  },
  mounted () {
  }
}
</script>

<style lang="scss" scoped>
.v-card__title {
  word-break: normal;
}

</style>
