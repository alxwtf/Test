<template>
  <div class="home">
    <b-alert variant="info" :show="info !== null" dismissible @dismissed="info=null">{{info}}</b-alert>
    <Filters @search="filter" />
    <Movies :movies="Movies" />
  </div>
</template>

<script>
import Movies from "@/components/Movies.vue";
import Filters from "@/components/Filters.vue";
import axios from "axios";
export default {
  name: "Home",
  components: {
    Movies,
    Filters
  },
  data() {
    return {
      Movies: [],
      info: null
    };
  },
  beforeCreate() {
    axios.get("/api/movie/GetMovies").then(r => (this.Movies = r.data));
  },
  methods: {
    filter(payload) {
      axios
        .get("/api/Movie/filter", {
          params: {
            genreid: payload.genreid,
            actorid: payload.actorid,
            directorid: payload.directorid
          }
        })
        .then(response => {
          if (response.data.length) {
            this.Movies = response.data;
          } else this.info = "По Вашему критерию ничего не найдено";
        })
        .catch(err => console.log("Что-то пошло не так:", err));
    }
  }
};
</script>
<style lang="scss">
.home {
  margin: 30px;
}
</style>