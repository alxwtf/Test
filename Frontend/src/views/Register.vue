<template>
  <b-form @submit.prevent="register">
    <b-alert variant="danger" :show="errors !== null" dismissible @dismissed="errors=null">
      <div v-for="(error,index) in errors" :key="index">{{error[0]}}</div>
    </b-alert>
    <b-form-group id="input-group-1" label="Логин" label-for="input-1">
      <b-form-input
        id="input-1"
        v-model.lazy="form.Email"
        placeholder="Введите Email"
        :class="{'is-invalid':$v.form.Email.$error}"
      />
      <b-form-invalid-feedback v-if="!$v.form.Email.required">Поле не может быть пустым</b-form-invalid-feedback>
      <b-form-invalid-feedback v-if="!$v.form.Email.email">В поле должен быть Email</b-form-invalid-feedback>
    </b-form-group>

    <b-form-group id="input-group-2" label="Пароль" label-for="input-2">
      <b-form-input
        id="input-2"
        type="password"
        v-model.lazy="form.Password"
        placeholder="Введите пароль"
        :class="{'is-invalid':$v.form.Password.$error}"
      />
      <b-form-invalid-feedback v-if="!$v.form.Password.required">Поле не может быть пустым</b-form-invalid-feedback>
      <b-form-invalid-feedback
        v-if="!$v.form.Password.minLength"
      >Пароль должен состоять минимум из {{ $v.form.Password.$params.minLength.min }} символов</b-form-invalid-feedback>
    </b-form-group>

    <b-form-group id="input-group-3" label="Повторите пароль" label-for="input-3">
      <b-form-input
        id="input-3"
        type="password"
        v-model.lazy="form.ConfirmPassword"
        placeholder="Повторите пароль"
        :class="{'is-invalid':$v.form.ConfirmPassword.$error}"
      />
      <b-form-invalid-feedback v-if="!$v.form.ConfirmPassword.required">Поле не может быть пустым</b-form-invalid-feedback>
      <b-form-invalid-feedback
        v-if="!$v.form.ConfirmPassword.minLength"
      >Пароль должен состоять минимум из {{ $v.form.Password.$params.minLength.min }} символов</b-form-invalid-feedback>
      <b-form-invalid-feedback v-if="!$v.form.ConfirmPassword.SameAs">Пароли должны совпадать</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group id="input-group-4" label="Имя" label-for="input-4">
      <b-form-input
        id="input-4"
        v-model.lazy="form.FirstName"
        placeholder="Введите Имя"
        :class="{'is-invalid':$v.form.FirstName.$error}"
      />
      <b-form-invalid-feedback v-if="!$v.form.FirstName.required">Поле не может быть пустым</b-form-invalid-feedback>
      <b-form-invalid-feedback v-if="!$v.form.FirstName.alpha">Имя должно содержать только буквы</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group id="input-group-5" label="Фамилия" label-for="input-5">
      <b-form-input
        id="input-5"
        v-model.lazy="form.LastName"
        placeholder="Введите Фамилию"
        :class="{'is-invalid':$v.form.LastName.$error}"
      />
      <b-form-invalid-feedback v-if="!$v.form.LastName.required">Поле не может быть пустым</b-form-invalid-feedback>
      <b-form-invalid-feedback v-if="!$v.form.LastName.alpha">Фамилия должна содержать только буквы</b-form-invalid-feedback>
    </b-form-group>
    <b-button type="submit" variant="primary" value="Login">Регистрация</b-button>
  </b-form>
</template>

<script>
import {
  email,
  required,
  minLength,
  sameAs,
  helpers
} from "vuelidate/lib/validators";
export default {
  data() {
    return {
      form: {
        Email: "",
        Password: "",
        ConfirmPassword: "",
        FirstName: "",
        LastName: ""
      },
      errors: null
    };
  },
  validations: {
    form: {
      Email: {
        required,
        email
      },
      Password: {
        required,
        minLength: minLength(5)
      },
      ConfirmPassword: {
        required,
        minLength: minLength(5),
        sameAs: sameAs("Password")
      },
      FirstName: {
        required,
        alpha: helpers.regex("alpha", /^[a-zA-Zа-яА-Я]+$/)
      },
      LastName: {
        required,
        alpha: helpers.regex("alpha", /^[a-zA-Zа-яА-Я]+$/)
      }
    }
  },
  methods: {
    register() {
      this.$v.$touch();
      if (!this.$v.$invalid)
        this.$store
          .dispatch("register", this.form)
          .then(response => {
            this.$store
              .dispatch("login", {
                Email: this.form.Email,
                Password: this.form.Password
              })
              .then(response => this.$router.back());
          })
          .catch(error => {
            if (typeof error.data === "string" || error.data instanceof String)
              this.errors = { error: [error.data] };
            else this.errors = error.data;
          });
    }
  }
};
</script>

<style>
</style>