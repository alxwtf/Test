import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    auth: null
  },
  getters: {
    IsAuthenticated: state => {
      return (
        state.auth !== null &&
        state.auth.access_token !== null &&
        new Date(state.auth.access_token_expiration) > new Date()
      );
    },
    isInRole: (state, getters) => role => {
      const result = getters.IsAuthenticated && state.auth.roles.indexOf(role) > -1;
      return result;
    }
  },
  mutations: {
    Logout(state) {
      state.auth = null;
    },
    LoginSuccess(state, payload) {
      state.auth = payload;
    },
    initialise(state, payload) {
      Object.assign(state, payload);
    }
  },
  actions: {
    login({ commit }, payload) {
      return new Promise((resolve, reject) => {
        axios
          .post("/api/token/gettoken", payload)
          .then(response => {
            const auth = response.data;
            axios.defaults.headers.common[
              "Authorization"
            ] = `Bearer ${auth.access_token}`;
            commit("LoginSuccess", auth);
            resolve(response);
          })
          .catch(err => {
            delete axios.defaults.headers.common["Authorization"];
            reject(err.response);
          });
      });
    },
    register({ commit }, payload) {
      return new Promise((resolve, reject) => {
        axios
          .post("/api/token/register", payload)
          .then(response => {
            resolve(response);
          })
          .catch(err => {
            reject(err.response);
          });
      });
    },
    logout({ commit }) {
      commit("Logout");
      delete axios.defaults.headers.common["Authorization"];
    }
  },
  modules: {}
});
// export default store;