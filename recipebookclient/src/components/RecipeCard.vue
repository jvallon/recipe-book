<template>
  <v-card
    class="mx-auto my-6"
    max-width="400">
    <v-img
      :src="src"
      class="white--text align-end"
      gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
      height="200px">
      <v-card-title>{{ title }}</v-card-title>
    </v-img>
    <v-card-subtitle>{{ subtitle }}</v-card-subtitle>
    <v-card-text>{{ description }}</v-card-text>
  </v-card>
</template>

<script>
export default {
  name: 'RecipeCard',
  props: {
    title: { type: String, default: 'Title' },
    subtitle: { type: String, default: 'Subtitle' },
    description: { type: String, default: 'Description' },
    src: { type: String }
  }
}
</script>

<style>

</style>
