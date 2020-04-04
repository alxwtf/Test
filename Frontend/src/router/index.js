import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import store from "../store";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/login",
    name: "Login",
    component: () =>
      import(/* webpackChunkName: "login" */ "../views/Login.vue"),
    meta: { loggedOut: true }
  },
  {
    path: "/film/:id",
    name: "Film",
    component: () => import(/* webpackChunkName: "film" */ "../views/Film.vue")
  },
  {
    path: "/register",
    name: "Register",
    component: () =>
      import(/* webpackChunkName: "register" */ "../views/Register.vue"),
    meta: { loggedOut: true }
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;

router.beforeEach((to, from, next) => {
  if (to.matched.some(route => route.meta.loggedOut)) {
    if (store.getters.IsAuthenticated) {
      next({ name: "Home" });
    } else next();
  } else if (to.matched.some(route => route.meta.requiresAuth)) {
    if (!store.getters.IsAuthenticated)
      next({ name: "Login", query: { redirect: to.path } });
    else next()
  } else next();
});
