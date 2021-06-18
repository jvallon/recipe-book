<template>
  <v-container class="container">
    <v-row>
      <v-text-field v-model="value.description"
        :label="label"
        append-outer-icon="mdi-delete"
        @click:append-outer="$emit('delete')"></v-text-field>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: 'NewInstructionItem',
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
