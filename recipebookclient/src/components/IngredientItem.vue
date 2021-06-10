<template>
  <v-container class="container">
    <v-row>
      <v-col cols="1" class="qty">{{ qty }}</v-col>
      <v-col cols="1" class="unit">{{ unit }}</v-col>
      <v-col class="name">{{ name }}</v-col>
      <v-spacer></v-spacer>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: 'IngredientItem',
  props: {
    qty: { type: String },
    unit: { type: String },
    name: { type: String }
  }
}
</script>

<style lang="scss" scoped>
.qty {
  text-align: right;
}

</style>
