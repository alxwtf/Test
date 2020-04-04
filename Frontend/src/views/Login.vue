<template>
  <b-form @submit.prevent="login">
    <b-alert variant="danger" :show="errors !== null"
    dismissible @dismissed="errors=null">
      <div v-for="(error,index) in errors" :key="index">
        {{error[0]}}
      </div>
      </b-alert>
      <b-form-group
      id="input-group-1"
      label="Логин"
      label-for="input-1">
        <b-form-input id="input-1" v-model.lazy="form.Email" placeholder="Enter Email"
        :class="{'is-invalid':$v.form.Email.$error}" />
        <b-form-invalid-feedback
        v-if="!$v.form.Email.required">Поле не может быть пустым</b-form-invalid-feedback>
        <b-form-invalid-feedback
        v-if="!$v.form.Email.email">В поле должен быть Email</b-form-invalid-feedback>
      </b-form-group>

      <b-form-group
      id="input-group-2"
      label="Пароль"
      label-for="input-2">
        <b-form-input 
        id="input-2"
        type="password" 
        v-model.lazy="form.Password" 
        placeholder="Enter Password" 
        :class="{'is-invalid':$v.form.Password.$error}"
        />
        <b-form-invalid-feedback
        v-if="!$v.form.Password.required">Поле не может быть пустым</b-form-invalid-feedback>
        <b-form-invalid-feedback
        v-if="!$v.form.Password.minLength">Пароль должен состоять минимум из {{ $v.form.Password.$params.minLength.min }} символов</b-form-invalid-feedback>
      </b-form-group>
      <b-button type="submit" variant="primary" value="Login" >Login</b-button>      
  </b-form>
</template>

<script>
  import { email, required, minLength } from "vuelidate/lib/validators";
  export default {
    data() {
      return {
        form: {
          Email: "",
          Password: "",
        },
        errors:null
      };
    },
    validations:{
      form:{
        Email:{
          required,
          email
        },
        Password:{
          required,
          minLength:minLength(5)
        }
      }
    },
    methods: {
      login() {
        this.$v.$touch();
        if (!this.$v.$invalid)
          this.$store
            .dispatch("login", this.form)
            .then(response => this.$router.back())
            .catch(error=>{
              if(typeof error.data === "string" || error.data instanceof String)
                this.errors = { error: [error.data] }
                else this.errors=error.data;
            });
      }
    }
  };
</script>

<style>
</style>