<template>
  <div>
    <select v-model="filter.genreid" class="custom-select custom-select-sm">
      <option v-for="genre in genres" :key="genre.id" :value="genre.id">{{genre.name}}</option>
    </select>
    <select v-model="filter.actorid" class="custom-select custom-select-sm">
      <option v-for="actor in actors" :key="actor.id" :value="actor.id">{{actor.name}}</option>
    </select>
    <select v-model="filter.directorid" class="custom-select custom-select-sm">
      <option
        v-for="director in directors"
        :key="director.id"
        :value="director.id"
      >{{director.name}}</option>
    </select>
    <b-button @click="search(filter)">Фильтр</b-button>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      genres: [{ id: null, name: "Выберите жанр" }],
      actors: [{ id: null, name: "Выберите актёра" }],
      directors: [{ id: null, name: "Выберите режиссёра" }],
      filter: {
        genreid: null,
        actorid: null,
        directorid: null
      }
    };
  },
  beforeCreate() {
    axios
      .all([
        axios.get("api/movie/getgenres"),
        axios.get("api/movie/getactors"),
        axios.get("api/movie/getdirectors")
      ])
      .then(
        axios.spread((genres, actors, directors) => {
          this.genres.push(...genres.data);
          this.actors.push(...actors.data);
          this.directors.push(...directors.data);
        })
      )
      .catch(err => console.log("Что-то пошло не так ", err));
  },
  methods: {
    search(filter) {
      return this.$emit("search", filter);
    }
  }
};
</script>

<style>
</style>