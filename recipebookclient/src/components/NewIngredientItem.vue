<template>
  <v-container class="container">
    <v-row no-gutters>
      <v-col cols="1">
        <v-text-field v-model="value.qty" label="Qty"></v-text-field>
      </v-col>
      <v-col cols="1">
        <v-text-field v-model="value.unit" label="Unit"></v-text-field>
      </v-col>
      <v-text-field v-model="value.name" label="Name"></v-text-field>
      <v-icon @click="$emit('delete')">mdi-delete</v-icon>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: 'NewIngredientItem',
  props: {
    label: { },
    value: {
      type: Object,
      required: true
    }
  },
  watch: {
    value () {
      this.$emit('input', this.value)
    }
  }
}
</script>

<style lang="scss" scoped>

.step {
  text-align: right;
}

</style>
