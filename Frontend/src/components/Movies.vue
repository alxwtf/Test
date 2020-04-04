<template>
  <div class="grid">
    <div v-for="movie in movies" :key="movie.id" class="moviecard">
      <p>
        <img :src="movie.poster" />
      </p>
      <p>
        <b-link :to="{path:`/film/`+movie.id}">{{movie.name}}</b-link>
      </p>
    </div>
  </div>
</template>

<script>
export default {
  props: ["movies"]
};
</script>

<style lang="scss">
.grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  // grid-template-rows: 100px 80px;
}
.moviecard {
  p {
    text-align: center;
    img {
      width: 30%;
    }
  }
}
</style>