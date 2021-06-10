<template>
  <v-container class="ingredient-container">
    <v-row>
      <v-col cols="1" class="ingredient-qty">{{ qty }}</v-col>
      <v-col cols="1" class="ingredient-unit">{{ unit }}</v-col>
      <v-col class="ingredient-name">{{ name }}</v-col>
      <v-spacer></v-spacer>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: 'Ingredient',
  props: {
    qty: { type: String },
    unit: { type: String },
    name: { type: String }
  }
}
</script>

<style lang="scss" scoped>
.ingredient-container {
  border-top: 1px solid lightgrey;
}

</style>
