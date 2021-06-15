<template>
  <div class="favorite">
    <v-btn fab top right absolute>
      <!-- <v-icon v-if="isFavorited" style="color: red" @click.prevent="unFavorite(recipe)">mdi-heart</v-icon>
      <v-icon v-else @click.prevent="favorite(recipe)">mdi-heart-outline</v-icon> -->
      <v-checkbox
        color="red"
        off-icon="mdi-heart-outline"
        on-icon="mdi-heart"
        v-model="isFavorited"
        @change="$emit('update-favorite', $event)"></v-checkbox>
    </v-btn>
  </div>
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
      FavoriteService.create({ userId: this.$userId, recipeId: recipe.id })
        .then(this.isFavorited = true)
        .catch(response => console.log(response.data))
    },
    unFavorite (recipe) {
      FavoriteService.delete()
    }
  }
}
</script>

<style lang="scss" scoped>
.favorite .btn {
  margin-top: 20px;
  margin-left: 20px;
}

</style>
