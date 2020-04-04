import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "axios";
import BootstrapVue from 'bootstrap-vue';
import Vuelidate from 'vuelidate';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

store.subscribe((mutation, state) => {
  localStorage.setItem("store", JSON.stringify(state));
});


const initialStore = localStorage.getItem("store");

if (initialStore) {
  store.commit("initialise", JSON.parse(initialStore));
  if (store.getters.IsAuthenticated) {
    axios.defaults.headers.common["Authorization"] = `Bearer ${store.state.auth.access_token}`;
  }
}

Vue.use(Vuelidate)
Vue.use(BootstrapVue);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
