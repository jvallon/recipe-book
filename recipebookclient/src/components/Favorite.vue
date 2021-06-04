<template>
  <span>
    <v-icon v-if="isFavorited" style="color: red" @click.prevent="unFavorite(recipe)">mdi-heart</v-icon>
    <v-icon v-else @click.prevent="favorite(recipe)">mdi-heart-outline</v-icon>
  </span>
</template>

<script>
import FavoriteService from '@/api-services/favorite.service'

export default {
  name: 'Favorite',
  props: ['recipe', 'favorited'],
  data () {
    return {
      isFavorited: ''
    }
  },
  mounted () {
    this.isFavorited = !!this.isFavorite
  },
  computed: {
    isFavorite () {
      return this.favorited
    }
  },
  methods: {
    favorite (recipe) {
      FavoriteService.create({ userId: this.user.id, recipeId: recipe.id })
        .then(this.isFavorited = true)
        .catch(response => console.log(response.data))
    },
    unFavorite (recipe) {
      FavoriteService.delete()
    }
  }
}
</script>

<style>

</style>
