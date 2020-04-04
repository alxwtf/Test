<template>
  <div class="container">
    <div class="cont" v-if="movie">
      <div class="poster">
        <img :src="movie.poster" />
        <div v-if="IsAuthenticated">
          <b-input-group>
            <select v-model="listid" class="custom-select custom-select-sm">
              <option
                v-for="list in lists"
                :selected="list.id == listid ? 'selected' : null"
                :key="list.id"
                :value="list.id"
              >{{ list.name }}</option>
            </select>
            <b-input-group-append>
              <b-button
                variant="primary"
                size="sm"
                :disabled="listid == null || loading ? true : false"
                @click="AddToList"
              >Ввод</b-button>
            </b-input-group-append>
          </b-input-group>
          <b-input-group>
            <b-button
              size="sm"
              class="mx-auto"
              variant="info"
              @click="!fav ? AddFav() : DelFav()"
              :disabled="loading ? true : false"
            >{{!fav ? "Добавить в избранное" : "Удалить из избранного"}}</b-button>
          </b-input-group>
        </div>
        <p v-else>Чтобы добавить в список или избранное войдите в аккаунт</p>
      </div>
      <div class="info">
        <div class="flexblk">
          <p>Название:</p>
          <p class="chld">{{ movie.name }}</p>
        </div>
        <div class="flexblk">
          <p>Режиссёр:</p>
          <p class="chld">{{ movie.director }}</p>
        </div>
        <div class="flexblk">
          <p>Жанры:</p>
          <div v-for="(genre, index) in movie.genres" :key="'genre' + index">
            <p class="chld">{{ genre.name }}</p>
          </div>
        </div>
        <div class="flexblk">
          <p>Актёры:</p>
          <p
            class="chld"
            v-for="(actor, index) in movie.actors"
            :key="'actor' + index"
          >{{ actor.name }}</p>
        </div>
      </div>
      <div class="description">
        <p>{{ movie.description }}</p>
      </div>
      <div class="review">
        <div v-if="IsAuthenticated">
          <div v-if="!review">
            <b-input-group>
              <b-form-textarea
                v-model="reviewText"
                rows="3"
                max-rows="9"
                :class="{'is-invalid':$v.reviewText.$error}"
              />
              <b-form-invalid-feedback v-if="!$v.reviewText.required">Поле не может быть пустым</b-form-invalid-feedback>
              <b-input-group-append>
                <b-form-invalid-feedback
                  v-if="!$v.form.ConfirmPassword.minLength"
                >Отзыв должен состоять минимум из {{ $v.reviewText.$params.minLength.min }} символов</b-form-invalid-feedback>
                <b-button variant="dark" @click="postReview()" :disabled="loading">Опубликовать</b-button>
              </b-input-group-append>
            </b-input-group>
          </div>
          <p v-else>Вы уже оставляли Отзыв</p>
          <hr />
        </div>
        <p v-else>Зарегистрируйтесь или залогиньтесь чтобы оставить отзыв</p>
        <div v-for="(review, index) in movie.reviews" :key="index" class="rw">
          <p class="user">{{ review.user }}</p>
          <p class="reviewtext">{{ review.text }}</p>
        </div>
      </div>
    </div>
    <p v-else>Загрузка</p>
  </div>
</template>

<script>
import axios from "axios";
import { mapGetters, mapState } from "vuex";
import { required, minLenght } from "vuelidate/lib/validators";
export default {
  data() {
    return {
      movie: null,
      listid: null,
      fav: false,
      loading: false,
      lists: [
        { id: null, name: "Выберите список" },
        { id: 1, name: "В процессе" },
        { id: 2, name: "Запланировано" },
        { id: 3, name: "Просмотрено" }
      ],
      review: false,
      reviewText: ""
    };
  },
  validations: {
    reviewText: {
      required,
      minLenght: minLenght(10)
    }
  },
  computed: {
    ...mapGetters(["IsAuthenticated"]),
    ...mapState(["auth"])
  },
  created() {
    this.getmovie();
  },
  methods: {
    getmovie() {
      axios
        .all([
          axios.get("/api/movie/GetMovies/" + this.$route.params.id),
          this.IsAuthenticated
            ? axios.get("/api/movie/ReviewStatus/" + this.$route.params.id)
            : "",
          this.IsAuthenticated
            ? axios.get("/api/movie/getlist/" + this.$route.params.id)
            : "",
          this.IsAuthenticated
            ? axios.get("/api/movie/FavStatus/" + this.$route.params.id)
            : ""
        ])
        .then(
          axios.spread((movie, reviewstatus, listid, fav) => {
            this.movie = movie.data;
            if (this.IsAuthenticated) this.review = reviewstatus.data;
            if (this.IsAuthenticated) this.listid = listid.data;
            if (this.IsAuthenticated) this.fav = fav.data;
          })
        )
        .catch(err => console.log("Что-то пошло не так", err));
    },
    postReview() {
      this.$v.$touch();
      if (!this.$v.$invalid) {
        this.loading = true;
        axios
          .post("/api/movie/AddReview", {
            MovieId: this.$route.params.id,
            Text: this.reviewText
          })
          .then(() => {
            this.review = true;
            this.movie.reviews.push({
              user: `${this.auth.firstName} ${this.auth.lastName}`,
              text: this.reviewText
            });
            this.loading = false;
          })
          .catch(() => (this.loading = false));
      }
    },
    AddToList() {
      this.loading = true;
      axios
        .post("/api/movie/AddToList", {
          MovieId: this.$route.params.id,
          ListId: this.listid
        })
        .then(() => (this.loading = false))
        .catch(() => (this.loading = false));
    },
    AddFav() {
      this.loading = true;
      var id = this.$route.params.id;
      axios
        .post("/api/movie/AddToFavourite", null, {
          params: {
            id: id
          }
        })
        .then(response => {
          this.fav = response.data;
          this.loading = false;
        })
        .catch(() => (this.loading = false));
    },
    DelFav() {
      this.loading = true;
      axios
        .post("/api/movie/RemoveFromFavourite", null, {
          params: { id: this.$route.params.id }
        })
        .then(response => {
          this.fav = response.data;
          this.loading = false;
        })
        .catch(() => (this.loading = false));
    }
  }
};
</script>

<style lang="scss">
.flexblk {
  display: flex;
  flex-wrap: wrap;
  border-top: 1px solid black;
  border-bottom: 1px solid black;
  .chld {
    position: relative;
    margin-left: 10px;
  }
}
.cont {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: auto;
  grid-gap: 10px;
  grid-template-areas:
    "poster info"
    "description description"
    "review review";
  .poster {
    grid-area: poster;
    display: flex;
    align-items: center;
    flex-direction: column;
    img {
      position: relative;
      width: 30%;
      margin: auto;
      margin-bottom: 2%;
      margin-top: 2%;
    }
  }
  .description {
    grid-area: description;
    border-top: 3px solid rgb(83, 75, 75);
    border-bottom: 3px solid rgb(83, 75, 75);
  }
  .review {
    grid-area: review;
    hr {
      border-bottom: 0.5px solid rgb(145, 57, 57);
    }
    .rw {
      .user {
        font-weight: bold;
      }
    }
  }
  .info {
    margin-top: 2%;
  }
}
</style>
