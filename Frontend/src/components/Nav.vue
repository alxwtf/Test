<template>
  <b-navbar toggleable="md" type="dark" variant="dark">
    <b-navbar-brand to="/">Logo</b-navbar-brand>
    <b-navbar-toggle target="nav-collapse" />
    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-item to="/">Home</b-nav-item>
      </b-navbar-nav>
      <b-navbar-nav class="ml-auto">
        <b-nav-form v-if="!IsAuthenticated">
          <b-button
            class="my-2 my-sm-0 mr-sm-2"
            @click="$router.push({ name: 'Login' })"
            variant="outline-light"
          >Log In</b-button>
          <b-button
            class="my-2 my-sm-0"
            @click="$router.push({ name: 'Register' })"
            variant="outline-light"
          >Register</b-button>
        </b-nav-form>
        <b-nav-item-dropdown right v-else :text="fullName">
          <b-dropdown-item @click.prevent="Logout()" type="submit">Logout</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<script>
import { mapGetters, mapState } from "vuex";
export default {
  computed: {
    ...mapState(["auth"]),
    ...mapGetters(["IsAuthenticated"]),
    fullName() {
      return `${this.auth.firstName} ${this.auth.lastName}`;
    }
  },
  methods: {
    Logout() {
      this.$store.dispatch("logout").then(() => {
        if (this.$route.matched.some(route.meta.requiresAuth))
          this.$router.push("/");
      });
    }
  }
};
</script>
