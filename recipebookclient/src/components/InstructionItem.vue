<template>
  <v-container class="container">
    <v-row>
      <v-col cols="1" class="step">{{ step }}</v-col>
      <v-col class="description">{{ description }}</v-col>
      <v-spacer></v-spacer>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: 'InstructionItem',
  props: {
    step: { },
    description: { type: String }
  }
}
</script>

<style lang="scss" scoped>

.step {
  text-align: right;
}

</style>
